Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.Text

Public Class frmDbCompare

    Private Enum SqlStatements
        GetColumns = 1
        GetIndexes = 2
    End Enum

    Private mComm As New CommonRoutines()
    Private mEnc As New EncryptionMgr()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        dgv1.DataSource = GetTables()

    End Sub

    Private Function GetTables() As DataTable
        Dim cnn As String = GetConnectionString()
        Dim tbl As New DataTable()

        Using connection As New SqlConnection(cnn)
            connection.Open()
            tbl = connection.GetSchema("Tables")
        End Using

        Return tbl
    End Function

    Private Function GetConnectionString() As String
        Return "Data Source = (Local);Database=custom500_app;Integrated Security=true;"
    End Function

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.ColumnIndex() = 2 Then
            dgv2.DataSource = GetColumns(GetTables(), "")
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Function GetColumns(ByVal dt As DataTable, ByVal strTableName As String) As DataTable
        Dim myDt As New DataTable()
        Dim d As New System.Collections.Specialized.HybridDictionary()
        Dim dcCheckSum As New DataColumn("CheckSum", System.Type.GetType("System.String"))

        myDt = GetSqlData(SqlStatements.GetColumns)

        myDt.Columns.Add(dcCheckSum)



        For Each r As DataRow In myDt.Rows
            Dim sbStringToEncrypt As New StringBuilder()

            'Exclude the "CheckSum column" 
            For i = 1 To myDt.Columns.Count
                sbStringToEncrypt.Append(r(i - 1).ToString())
            Next

            r("CheckSum") = mEnc.GetChecksumSha25(sbStringToEncrypt.ToString())
        Next






        Return myDt

    End Function

    Private Function GetIndexes() As DataTable

        Return GetSqlData(SqlStatements.GetIndexes)

    End Function

    Private Function GetSqlData(ByVal sql As SqlStatements) As DataTable

        Dim myDt As New DataTable()
        Dim fr As New FileReader()
        Dim strSQL As String = ""

        Select Case sql
            Case SqlStatements.GetColumns
                strSQL = _
                    fr.GetFlatFileContents _
                    ("C:\Documents and Settings\BDelamater\My Documents\Visual Studio 2008\Mas500SupportToolsVB\Mas500SupportToolsVB\SqlCode\GetColumns.sql").ToString()
            Case SqlStatements.GetIndexes
                strSQL = _
                    fr.GetFlatFileContents _
                    ("C:\Documents and Settings\BDelamater\My Documents\Visual Studio 2008\Mas500SupportToolsVB\Mas500SupportToolsVB\SqlCode\GetIndexes.sql").ToString()
            Case Else
                mComm.ShowMessageBox(constants.kInvalidSqlStatement, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Select

        Dim da As New SqlDataAdapter(strSQL, GetConnectionString())

        da.Fill(myDt)

        Return myDt

    End Function

    Private Function GetColumnsDataTableStructure() As DataTable

        Dim tmpDt As New DataTable()
        Dim colID As New DataColumn("ID", System.Type.GetType("System.Int32"))
        Dim colName As New DataColumn("ColumnName", System.Type.GetType("System.String"))
        Dim colDataType As New DataColumn("DataType", System.Type.GetType("System.String"))
        Dim colSize As New DataColumn("MaxLength", System.Type.GetType("System.String"))
        Dim colAllowDbNull As New DataColumn("AllowDbNull", System.Type.GetType("System.Boolean"))

        colID.AutoIncrement = True
        colID.AutoIncrementSeed = 1
        colID.AutoIncrementStep = 1


        tmpDt.Columns.Add(colID)
        tmpDt.Columns.Add(colName)
        tmpDt.Columns.Add(colDataType)
        tmpDt.Columns.Add(colSize)
        tmpDt.Columns.Add(colAllowDbNull)

        Return tmpDt

    End Function

    Private Sub btnGetConstraints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetConstraints.Click

    End Sub

    Private Sub btnGetProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProcedures.Click

    End Sub

    Private Sub btnGetColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetColumns.Click

    End Sub
End Class