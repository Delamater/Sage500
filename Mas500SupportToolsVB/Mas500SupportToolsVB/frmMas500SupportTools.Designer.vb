<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramCompare
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramCompare))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.MyCompareHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tavFileSelection = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGetComparisonFilesList = New System.Windows.Forms.Button
        Me.txtDestinationFile = New System.Windows.Forms.TextBox
        Me.btnGetBaseFileList = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBaseFile = New System.Windows.Forms.TextBox
        Me.grpComparisonFile = New System.Windows.Forms.GroupBox
        Me.btnSetComparisonFolder = New System.Windows.Forms.Button
        Me.txtComparisonFolderPath = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCreateSourceFile = New System.Windows.Forms.Button
        Me.tabInstallCompare = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvComparison = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancelSearchFilterValue = New System.Windows.Forms.Button
        Me.lblSearchFileName = New System.Windows.Forms.Label
        Me.btnExportToExcel = New System.Windows.Forms.Button
        Me.txtFileNameToSearch = New System.Windows.Forms.TextBox
        Me.btnCompare = New System.Windows.Forms.Button
        Me.cboViewSettings = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tavFileSelection.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpComparisonFile.SuspendLayout()
        Me.tabInstallCompare.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(100, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator5, Me.MyCompareHelpToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(163, 6)
        '
        'MyCompareHelpToolStripMenuItem
        '
        Me.MyCompareHelpToolStripMenuItem.Name = "MyCompareHelpToolStripMenuItem"
        Me.MyCompareHelpToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MyCompareHelpToolStripMenuItem.Text = "myCompare Help"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(163, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tavFileSelection)
        Me.TabControl1.Controls.Add(Me.tabInstallCompare)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 549)
        Me.TabControl1.TabIndex = 1
        '
        'tavFileSelection
        '
        Me.tavFileSelection.Controls.Add(Me.GroupBox1)
        Me.tavFileSelection.Controls.Add(Me.grpComparisonFile)
        Me.tavFileSelection.Location = New System.Drawing.Point(4, 22)
        Me.tavFileSelection.Name = "tavFileSelection"
        Me.tavFileSelection.Padding = New System.Windows.Forms.Padding(3)
        Me.tavFileSelection.Size = New System.Drawing.Size(784, 523)
        Me.tavFileSelection.TabIndex = 0
        Me.tavFileSelection.Text = "File Selection"
        Me.tavFileSelection.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnGetComparisonFilesList)
        Me.GroupBox1.Controls.Add(Me.txtDestinationFile)
        Me.GroupBox1.Controls.Add(Me.btnGetBaseFileList)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBaseFile)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(761, 178)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Set Comparison File Locations"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Comparison File"
        '
        'btnGetComparisonFilesList
        '
        Me.btnGetComparisonFilesList.Location = New System.Drawing.Point(639, 136)
        Me.btnGetComparisonFilesList.Name = "btnGetComparisonFilesList"
        Me.btnGetComparisonFilesList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetComparisonFilesList.TabIndex = 16
        Me.btnGetComparisonFilesList.Text = "Set Comparison File"
        Me.btnGetComparisonFilesList.UseVisualStyleBackColor = True
        '
        'txtDestinationFile
        '
        Me.txtDestinationFile.Enabled = False
        Me.txtDestinationFile.Location = New System.Drawing.Point(4, 110)
        Me.txtDestinationFile.Name = "txtDestinationFile"
        Me.txtDestinationFile.Size = New System.Drawing.Size(751, 20)
        Me.txtDestinationFile.TabIndex = 18
        '
        'btnGetBaseFileList
        '
        Me.btnGetBaseFileList.Location = New System.Drawing.Point(639, 65)
        Me.btnGetBaseFileList.Name = "btnGetBaseFileList"
        Me.btnGetBaseFileList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetBaseFileList.TabIndex = 17
        Me.btnGetBaseFileList.Text = "Set Base File"
        Me.btnGetBaseFileList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Base"
        '
        'txtBaseFile
        '
        Me.txtBaseFile.Enabled = False
        Me.txtBaseFile.Location = New System.Drawing.Point(4, 39)
        Me.txtBaseFile.Name = "txtBaseFile"
        Me.txtBaseFile.Size = New System.Drawing.Size(751, 20)
        Me.txtBaseFile.TabIndex = 14
        '
        'grpComparisonFile
        '
        Me.grpComparisonFile.Controls.Add(Me.btnSetComparisonFolder)
        Me.grpComparisonFile.Controls.Add(Me.txtComparisonFolderPath)
        Me.grpComparisonFile.Controls.Add(Me.Label3)
        Me.grpComparisonFile.Controls.Add(Me.btnCreateSourceFile)
        Me.grpComparisonFile.Location = New System.Drawing.Point(13, 10)
        Me.grpComparisonFile.Name = "grpComparisonFile"
        Me.grpComparisonFile.Size = New System.Drawing.Size(763, 94)
        Me.grpComparisonFile.TabIndex = 21
        Me.grpComparisonFile.TabStop = False
        Me.grpComparisonFile.Text = "Comparison File"
        '
        'btnSetComparisonFolder
        '
        Me.btnSetComparisonFolder.Location = New System.Drawing.Point(6, 65)
        Me.btnSetComparisonFolder.Name = "btnSetComparisonFolder"
        Me.btnSetComparisonFolder.Size = New System.Drawing.Size(128, 23)
        Me.btnSetComparisonFolder.TabIndex = 24
        Me.btnSetComparisonFolder.Text = "Set Comparison Folder"
        Me.btnSetComparisonFolder.UseVisualStyleBackColor = True
        '
        'txtComparisonFolderPath
        '
        Me.txtComparisonFolderPath.Enabled = False
        Me.txtComparisonFolderPath.Location = New System.Drawing.Point(6, 33)
        Me.txtComparisonFolderPath.Name = "txtComparisonFolderPath"
        Me.txtComparisonFolderPath.Size = New System.Drawing.Size(751, 20)
        Me.txtComparisonFolderPath.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Set Folder To Create Comparison File"
        '
        'btnCreateSourceFile
        '
        Me.btnCreateSourceFile.Enabled = False
        Me.btnCreateSourceFile.Location = New System.Drawing.Point(140, 65)
        Me.btnCreateSourceFile.Name = "btnCreateSourceFile"
        Me.btnCreateSourceFile.Size = New System.Drawing.Size(135, 23)
        Me.btnCreateSourceFile.TabIndex = 21
        Me.btnCreateSourceFile.Text = "Create Comparison File"
        Me.btnCreateSourceFile.UseVisualStyleBackColor = True
        '
        'tabInstallCompare
        '
        Me.tabInstallCompare.Controls.Add(Me.Panel2)
        Me.tabInstallCompare.Controls.Add(Me.Panel1)
        Me.tabInstallCompare.Location = New System.Drawing.Point(4, 22)
        Me.tabInstallCompare.Name = "tabInstallCompare"
        Me.tabInstallCompare.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInstallCompare.Size = New System.Drawing.Size(784, 523)
        Me.tabInstallCompare.TabIndex = 1
        Me.tabInstallCompare.Text = "Installation Comparison"
        Me.tabInstallCompare.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvComparison)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 479)
        Me.Panel2.TabIndex = 5
        '
        'dgvComparison
        '
        Me.dgvComparison.AllowUserToAddRows = False
        Me.dgvComparison.AllowUserToDeleteRows = False
        Me.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComparison.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComparison.Location = New System.Drawing.Point(0, 0)
        Me.dgvComparison.Name = "dgvComparison"
        Me.dgvComparison.ReadOnly = True
        Me.dgvComparison.Size = New System.Drawing.Size(778, 479)
        Me.dgvComparison.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelSearchFilterValue)
        Me.Panel1.Controls.Add(Me.lblSearchFileName)
        Me.Panel1.Controls.Add(Me.btnExportToExcel)
        Me.Panel1.Controls.Add(Me.txtFileNameToSearch)
        Me.Panel1.Controls.Add(Me.btnCompare)
        Me.Panel1.Controls.Add(Me.cboViewSettings)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 38)
        Me.Panel1.TabIndex = 4
        '
        'btnCancelSearchFilterValue
        '
        Me.btnCancelSearchFilterValue.Image = CType(resources.GetObject("btnCancelSearchFilterValue.Image"), System.Drawing.Image)
        Me.btnCancelSearchFilterValue.Location = New System.Drawing.Point(613, 6)
        Me.btnCancelSearchFilterValue.Name = "btnCancelSearchFilterValue"
        Me.btnCancelSearchFilterValue.Size = New System.Drawing.Size(26, 23)
        Me.btnCancelSearchFilterValue.TabIndex = 11
        Me.btnCancelSearchFilterValue.Text = "Cancel"
        Me.btnCancelSearchFilterValue.UseVisualStyleBackColor = True
        '
        'lblSearchFileName
        '
        Me.lblSearchFileName.AutoSize = True
        Me.lblSearchFileName.Location = New System.Drawing.Point(334, 11)
        Me.lblSearchFileName.Name = "lblSearchFileName"
        Me.lblSearchFileName.Size = New System.Drawing.Size(91, 13)
        Me.lblSearchFileName.TabIndex = 10
        Me.lblSearchFileName.Text = "Search File Name"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Location = New System.Drawing.Point(646, 6)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(127, 23)
        Me.btnExportToExcel.TabIndex = 9
        Me.btnExportToExcel.Text = "Export To Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'txtFileNameToSearch
        '
        Me.txtFileNameToSearch.Location = New System.Drawing.Point(431, 7)
        Me.txtFileNameToSearch.Name = "txtFileNameToSearch"
        Me.txtFileNameToSearch.Size = New System.Drawing.Size(176, 20)
        Me.txtFileNameToSearch.TabIndex = 7
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(226, 6)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(102, 23)
        Me.btnCompare.TabIndex = 6
        Me.btnCompare.Text = "Compare Files"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'cboViewSettings
        '
        Me.cboViewSettings.FormattingEnabled = True
        Me.cboViewSettings.Location = New System.Drawing.Point(80, 7)
        Me.cboViewSettings.Name = "cboViewSettings"
        Me.cboViewSettings.Size = New System.Drawing.Size(140, 21)
        Me.cboViewSettings.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "View Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(792, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.CausesValidation = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem, Me.ExportToCSVToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 48)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "Export To CSV"
        '
        'frmProgramCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmProgramCompare"
        Me.Text = "Folder Compare"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tavFileSelection.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpComparisonFile.ResumeLayout(False)
        Me.grpComparisonFile.PerformLayout()
        Me.tabInstallCompare.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tavFileSelection As System.Windows.Forms.TabPage
    Friend WithEvents tabInstallCompare As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents cboViewSettings As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtFileNameToSearch As System.Windows.Forms.TextBox
    Friend WithEvents grpComparisonFile As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetComparisonFolder As System.Windows.Forms.Button
    Friend WithEvents txtComparisonFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCreateSourceFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetComparisonFilesList As System.Windows.Forms.Button
    Friend WithEvents txtDestinationFile As System.Windows.Forms.TextBox
    Friend WithEvents btnGetBaseFileList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBaseFile As System.Windows.Forms.TextBox
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvComparison As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchFileName As System.Windows.Forms.Label
    Friend WithEvents btnCancelSearchFilterValue As System.Windows.Forms.Button
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MyCompareHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
