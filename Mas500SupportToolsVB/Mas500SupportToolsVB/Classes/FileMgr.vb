'Option Explicit On
'Option Strict On

Imports System.IO
Imports System.Data
Imports FolderCompare.myFileInfo
Imports System.Text
Imports System.Security.Cryptography

Public Class FileMgr

    Dim mEnc As New EncryptionMgr()
    Public Enum enumFileType
        LegacyExcel = 1
        Excel = 2
        CSV = 3
        XML = 4
    End Enum

#Region "Methods"

    Public Function GetInstalledFiles(ByVal strComparisonFolderPath As String) As myFileInfo.FileInfoDataTable
        Dim dsMas500InstalledFiles As New myFileInfo.FileInfoDataTable()
        'Dim masInstallMgr As New Mas500InstallationMgr()
        'ProcessDirectory(masInstallMgr.Mas500InstalledDirectory.FullName.ToString(), _
        '                 10, _
        '                 dsMas500InstalledFiles)

        ProcessDirectory(strComparisonFolderPath, _
                         10, _
                         dsMas500InstalledFiles)

        Return dsMas500InstalledFiles

    End Function

    Private Sub ProcessDirectory(ByVal sourceDir As String, _
                                  ByVal recursionLevel As Integer, _
                                  ByRef dt As myFileInfo.FileInfoDataTable)

        'Dim fileEntries As String() = Directory.GetFiles(sourceDir)
        Dim di As New DirectoryInfo(sourceDir)

        Try
            'For Each filename As String In fileEntries
            For Each fi As FileInfo In di.GetFiles()
                'Dim f As FileInfo = New FileInfo(filename)
                Dim r As DataRow = dt.NewRow()
                r("FullName") = fi.FullName.ToString()
                r("Extension") = fi.Extension.ToString()
                r("CreationTimeUtc") = fi.CreationTimeUtc.ToShortDateString()
                r("LastAccessTimeUtc") = fi.LastAccessTimeUtc.ToShortDateString()
                r("Name") = fi.Name.ToString()
                'r("CRCValue") = GetMD5HasFromFile(filename)
                r("CRCValue") = mEnc.GetChecksumSha25(fi)

                dt.Rows.Add(r)

            Next

            Dim subDirEntries As String() = Directory.GetDirectories(sourceDir)
            For Each subDir As String In subDirEntries

                If (CDbl(File.GetAttributes(subDir) & FileAttributes.ReparsePoint) <> FileAttributes.ReparsePoint) Then
                    ProcessDirectory(subDir, recursionLevel, dt)
                End If

            Next
        Catch ex As UnauthorizedAccessException

            'Do nothing and allow loop to continue

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function GetFilePath(ByVal FileType As enumFileType) As String
        Dim ofd As New OpenFileDialog()

        With ofd
            Select Case FileType
                Case enumFileType.CSV
                    .Filter = "CSV Files|*.csv"
                Case enumFileType.LegacyExcel
                    .Filter = "Legacy Excel Files|*.xls"
                Case enumFileType.Excel
                    .Filter = "Excel Files|*.xlsx"
                Case enumFileType.XML
                    .Filter = "Xml Files|*.xml"
                Case Else
                    Throw New ApplicationException("This file type is not supported")
            End Select

            .CheckFileExists = False
            .CheckPathExists = True
            .AddExtension = True
            .Multiselect = False

            Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
            .InitialDirectory = di.FullName.ToString()
        End With

        Dim diagResult As DialogResult

        diagResult = ofd.ShowDialog()
        If diagResult = DialogResult.OK Then
            Dim fi As New FileInfo(ofd.FileName)
            Return fi.FullName.ToString()
        Else
            Return String.Empty
        End If

    End Function

    Public Function GetFolderPath() As String
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        With folderBrowserDialog1
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Select the folder to build a comparison file"
            .ShowNewFolderButton = False
        End With

        Dim diagResult As DialogResult
        diagResult = folderBrowserDialog1.ShowDialog()
        If diagResult = Windows.Forms.DialogResult.OK Then
            Dim folInfo As New DirectoryInfo(folderBrowserDialog1.SelectedPath)
            Return folInfo.ToString()
        Else
            Return String.Empty
        End If

    End Function

    'Private Function GetChecksumSha25(ByVal fileName As String) As String

    '    'If FileAcess.Read is not used, then files locked by the operating system will
    '    'generate an error
    '    Dim file As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
    '    Dim sha As New SHA256Managed()
    '    Dim checksum As Byte() = sha.ComputeHash(file)
    '    file.Close()
    '    Return BitConverter.ToString(checksum).Replace("-", String.Empty)

    'End Function

    'Private Function GetMD5HasFromFile(ByVal fileName As String) As String

    '    Dim file As FileStream = New FileStream(fileName, FileMode.Open)
    '    Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()


    '    Dim retVal As Byte() = md5.ComputeHash(file)
    '    file.Close()

    '    Dim enc As New ASCIIEncoding()
    '    Return enc.GetString(retVal).ToString()

    'End Function

    Public Sub PersistFilesToDisk(ByVal Path As String, ByVal dt As DataTable)

        dt.WriteXml(Path, XmlWriteMode.WriteSchema)

    End Sub

    ''' <summary>
    ''' Exports the contents of a DataGridView to a CSV file 
    ''' </summary>
    ''' <param name="strPath">The location to store the file</param>
    ''' <param name="dgv">A reference to the DataGridView</param>
    ''' <remarks></remarks>
    Public Sub ExportDataTableToCSV(ByVal strPath As String, ByVal dgv As DataGridView)

        Dim sb As New StringBuilder()
        Dim bs As BindingSource
        bs = CType(dgv.DataSource, BindingSource)

        Dim dt As DataTable = CType(bs.DataSource, DataTable)

        'Write out the header column text to the CSV file
        For i = 0 To dgv.Columns.Count - 1
            sb.Append(dgv.Columns(i).HeaderText.ToString())
            If ((i + 1) <> dt.Columns.Count) Then
                sb.Append(",")
            End If
        Next

        sb.Append(Environment.NewLine)

        'Write out each column's value
        For Each dr As DataRowView In dt.DefaultView
            For j As Integer = 0 To dt.Columns.Count - 1
                sb.Append(dr(j).ToString())
                If ((j + 1) <> dt.Columns.Count) Then
                    sb.Append(",")
                End If
            Next
            sb.Append(Environment.NewLine)
        Next

        Dim sw As New StreamWriter(strPath, False)
        sw.Write(sb.ToString())
        sw.Close()

    End Sub

#End Region


End Class
