'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   GUI for the Folder Compare application. This folder compare tool is designed to 
'               help anyone quickly scan two folders and compare the differences. 

Option Strict On
Option Explicit On

Imports System.IO

Public Class frmProgramCompare

    Private comRoutines As New CommonRoutines()
    Private myBindingSource As New BindingSource()
    Private grdMgr As New GridManager()
    Private fmgr As New FileMgr()

#Region "Menu Item Methods"

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        CloseApplication()
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click

        ExportToExcel()

    End Sub

    Private Sub ExportToCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToCSVToolStripMenuItem.Click

        ExportToCSV()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Try
            Dim About As New frmAbout
            About.ShowDialog()
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub MyCompareHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyCompareHelpToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("..\..\Help\MASSupportTools.chm")
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub
#End Region

    Private Sub CloseApplication()
        Application.Exit()
    End Sub


#Region "Methods"

    ''' <summary>
    ''' Populates all combo boxes with default values
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateComboBoxes()
        Dim ComboBoxChoices() As String = _
            New String() {"All", _
                DataRowState.Added.ToString(), _
                DataRowState.Deleted.ToString(), _
                DataRowState.Modified.ToString(), _
                DataRowState.Unchanged.ToString()}

        cboViewSettings.Items.AddRange(ComboBoxChoices)
        cboViewSettings.SelectedIndex = 0
    End Sub


    ''' <summary>
    ''' Creates a source file in a specified location, as defined by the file manager class, 
    ''' if there is a location set in the txtComparisonFolderPath textbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateSourceFile()
        'Choose the location from where to build the file
        Dim strFilePathToCompare As String = ""
        Dim strPathToStoreFile As String = fmgr.GetFilePath(FileMgr.enumFileType.XML)
        strFilePathToCompare = txtComparisonFolderPath.Text.ToString()

        Try

            If Not (String.IsNullOrEmpty(strFilePathToCompare)) Then
                If Not (String.IsNullOrEmpty(strPathToStoreFile)) Then

                    'Turn on the progress bar
                    HandleProgressBar(True)

                    'Get the file list for comparison
                    Dim fmgr As New FileMgr()
                    Dim dt As New myFileInfo.FileInfoDataTable()
                    dt = fmgr.GetInstalledFiles(strFilePathToCompare)
                    txtDestinationFile.Text = (strPathToStoreFile)
                    fmgr.PersistFilesToDisk(strPathToStoreFile, dt)
                Else
                    Throw New ApplicationException _
                        ("Please choose a path to store your folder comparison file")
                End If
            Else
                HandleProgressBar(False)
                Throw New ApplicationException("Please choose a path from which to compare")

            End If
        Catch ex As ApplicationException
            HandleProgressBar(False)
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            HandleProgressBar(False)
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try

        HandleProgressBar(False)
    End Sub

    ''' <summary>
    ''' If there are two files set for comparison, this routine will compare 
    ''' the output and store it within the datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CompareSourceFiles()
        Dim dtBase As New myFileInfo.FileInfoDataTable()
        Dim dtDestination As New myFileInfo.FileInfoDataTable()
        Dim dtOutput As New myFileInfo.FileInfoDataTable()

        Try

            'Sanity Check: Are there two files to compare?
            If String.IsNullOrEmpty(txtBaseFile.Text) Or _
                String.IsNullOrEmpty(txtDestinationFile.Text) Then

                comRoutines.ShowMessageBox(constants.kRequiredFiles, _
                                           MessageBoxIcon.Information, _
                                           MessageBoxButtons.OK)
                Exit Sub
            End If

            'Sanity Check: Are the schemas on the files correct?
            If (CheckSchemaFiles() = False) Then

                comRoutines.ShowMessageBox( _
                        constants.kSchemaIsNotCorrect, _
                        MessageBoxIcon.Error, _
                        MessageBoxButtons.OK)

                Exit Sub
            End If

            dtBase.ReadXml(txtBaseFile.Text)
            dtDestination.ReadXml(txtDestinationFile.Text)

            Dim dc As New DataCompare()
            HandleProgressBar(True)
            dtOutput = dc.CompareDataSet(dtBase, dtDestination)

            BindGrid(dtOutput)


        Catch ex As Exception
            HandleProgressBar(False)
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try

        HandleProgressBar(False)
        grdMgr.FormatGrid(dgvComparison)

    End Sub


    ''' <summary>
    ''' Handles the progress bar that lets the user know if 
    ''' processing still remains for any given activity
    ''' </summary>
    ''' <param name="isStart"></param>
    ''' <remarks></remarks>
    Private Sub HandleProgressBar(ByVal isStart As Boolean)
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Maximum = 100

        If isStart = True Then

            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Enabled = True
            ToolStripProgressBar1.Visible = True
            Timer1.Enabled = True
            ToolStripProgressBar1.MarqueeAnimationSpeed = 100
            Application.DoEvents()

        Else
            Timer1.Enabled = False
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Enabled = False
            ToolStripProgressBar1.Visible = False
            ToolStripProgressBar1.MarqueeAnimationSpeed = 0
        End If


    End Sub

    ''' <summary>
    ''' The files to compare must have the correct XML schema, or the 
    ''' comparison will not work properly. This routing checks those 
    ''' comparison files to ensure they have a valid schema.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSchemaFiles() As Boolean
        Dim xmlRdr As New myXmlReader()
        Dim bAreSchemasCorrect As Boolean = False
        Dim strSourceFilePath As String = txtBaseFile.Text
        Dim strDestinationFilePath As String = txtDestinationFile.Text

        If (xmlRdr.ValidateXmlSchema(strSourceFilePath) = True _
            And xmlRdr.ValidateXmlSchema(strDestinationFilePath) = True) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Bind the datasource to the grid. This is necessary to allow viewing of the data
    ''' within the grid, as well as filtering of the grid. 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub BindGrid(ByVal dt As myFileInfo.FileInfoDataTable)

        Dim dv As New DataView

        myBindingSource.DataSource = dt
        dgvComparison.DataSource = myBindingSource

    End Sub

    ''' <summary>
    ''' A rudemintary implementation of search capabilities on the grid. 
    ''' This can be enhanced for later versions of this product.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FilterDataGridView()

        Select Case String.IsNullOrEmpty(txtFileNameToSearch.Text.ToString().Trim())
            Case True
                myBindingSource.Filter = ""
            Case False

                If cboViewSettings.Text.ToString().ToUpper() = "All".ToUpper() Then
                    myBindingSource.Filter = "Name LIKE '%" & txtFileNameToSearch.Text.ToString().Trim() & "%'"
                Else
                    myBindingSource.Filter = "Name LIKE '%" & txtFileNameToSearch.Text.ToString().Trim() & "%'" _
                     & " AND myRowState = '" & cboViewSettings.Text & "'"
                End If
        End Select

        dgvComparison.DataSource = myBindingSource
        dgvComparison.Refresh()

    End Sub

    ''' <summary>
    ''' Export the grid, in it's presently filtered state, to a Excel file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExportToExcel()
        Dim oExcel As New ExcelMgr()

        Try
            oExcel.ExportToExcel(dgvComparison, fmgr.GetFilePath(FileMgr.enumFileType.Excel))

            comRoutines.ShowMessageBox _
                ("Export to Excel complete", _
                 MessageBoxIcon.Information, _
                 MessageBoxButtons.OK)
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ExportToCSV()
        Try
            fmgr.ExportDataTableToCSV( _
                fmgr.GetFilePath(FileMgr.enumFileType.CSV), _
                dgvComparison)

            comRoutines.ShowMessageBox("Export to CSV complete", _
                                       MessageBoxIcon.Information, _
                                       MessageBoxButtons.OK)
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub frmMas500SupportTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ToolStripProgressBar1
            .MarqueeAnimationSpeed = 0
            .Visible = CBool(0)
            .Enabled = False
        End With

        PopulateComboBoxes()
        grdMgr.FormatGrid(dgvComparison)

    End Sub

    ''' <summary>
    ''' Command to generate the source file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCreateSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSourceFile.Click

        CreateSourceFile()

    End Sub

    ''' <summary>
    ''' Command to compare the source files
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click

        CompareSourceFiles()

    End Sub


    ''' <summary>
    ''' The user may instruct the program to only view certain types of rows. This filter provides 
    ''' the user basic functionality to show which rows are different, the same, modified, or missing. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboViewSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboViewSettings.SelectedIndexChanged

        Select Case cboViewSettings.Text
            Case "All"
                myBindingSource.Filter = ""
            Case DataRowState.Added.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Added.ToString() & "'"
            Case DataRowState.Deleted.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Deleted.ToString() & "'"
            Case DataRowState.Modified.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Modified.ToString() & "'"
            Case DataRowState.Unchanged.ToString()
                myBindingSource.Filter = "myRowState ='" & DataRowState.Unchanged.ToString() & "'"
            Case Else
                myBindingSource.Filter = ""
        End Select

        If Not String.IsNullOrEmpty(txtFileNameToSearch.Text) Then
            If cboViewSettings.Text.ToUpper() <> "All".ToUpper() Then
                myBindingSource.Filter = _
                    myBindingSource.Filter & " AND Name LIKE '%" & txtFileNameToSearch.Text.ToString() & "%'"
            End If

            If cboViewSettings.Text.ToUpper() = "All".ToUpper() Then
                myBindingSource.Filter = _
                    myBindingSource.Filter & " Name LIKE '%" & txtFileNameToSearch.Text.ToString() & "%'"
            End If
        End If

        With dgvComparison
            .DataSource = myBindingSource
            .Refresh()
        End With

        grdMgr.FormatGrid(dgvComparison)
    End Sub

    ''' <summary>
    ''' Retrieves the file to compare to (not intended to be the base file)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGetComparisonFilesList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetComparisonFilesList.Click
        txtDestinationFile.Text = fmgr.GetFilePath(FileMgr.enumFileType.XML)
    End Sub


    ''' <summary>
    ''' Retrieves the file to comapre agains (intended to be the base folder file listing)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGetBaseFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBaseFileList.Click
        txtBaseFile.Text = fmgr.GetFilePath(FileMgr.enumFileType.XML)
    End Sub

    ''' <summary>
    ''' Sets the text value of the destination folder (not the base folder)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetComparisonFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetComparisonFolder.Click
        txtComparisonFolderPath.Text = fmgr.GetFolderPath()
    End Sub

    ''' <summary>
    ''' If the comparison/destination folder has a value witin it, then enable the button to create a source file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtComparisonFolderPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComparisonFolderPath.TextChanged
        If String.IsNullOrEmpty(txtComparisonFolderPath.Text) Then
            btnCreateSourceFile.Enabled = False
        Else
            btnCreateSourceFile.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Instructions to export the contents of the DataGridView to an Excel file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click

        If dgvComparison.RowCount > 0 Then
            ExportToExcel()
        End If

    End Sub


    ''' <summary>
    ''' Show a context menu to export the contents of the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvComparison_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvComparison.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            'Dim hti As DataGridView.HitTestInfo = dgvComparison.HitTest(e.X, e.Y)

            'If hti.Type = DataGridViewHitTestType.Cell Then
            'End If

            ContextMenuStrip1.Show(dgvComparison, New Point(Control.MousePosition.X - 115, Control.MousePosition.Y - 155))

            'ContextMenuStrip1.Location = dgvComparison.PointToScreen(e.Location)
            'ContextMenuStrip1.Location = Control.MousePosition

            'dgvContextMenu.Location = Control.MousePosition
            ContextMenuStrip1.Show()

        End If

    End Sub

    ''' <summary>
    ''' Instructions to filter the grid based on the contents of the search textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFileNameToSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileNameToSearch.TextChanged

        Try
            FilterDataGridView()
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try
        grdMgr.FormatGrid(dgvComparison)

    End Sub

    Private Sub dgvComparison_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)

        grdMgr.FormatGrid(dgvComparison)

    End Sub
#End Region

    ''' <summary>
    ''' Cancel the File Name To Search filter criteria
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancelSearchFilterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSearchFilterValue.Click
        txtFileNameToSearch.Text = ""
    End Sub

    Private Sub dgvComparison_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvComparison.Sorted
        grdMgr.FormatGrid(dgvComparison)
    End Sub
End Class
