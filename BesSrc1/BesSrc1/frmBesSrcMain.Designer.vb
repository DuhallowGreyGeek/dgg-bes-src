<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBesSrcMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBesSrcMain))
        Me.statStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.horizSplit = New System.Windows.Forms.SplitContainer()
        Me.vertSplit = New System.Windows.Forms.SplitContainer()
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.grdFoundDocs = New System.Windows.Forms.DataGridView()
        Me.colDocId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentIdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchArgsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopulateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DumpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statStatusStrip.SuspendLayout()
        CType(Me.horizSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.horizSplit.Panel1.SuspendLayout()
        Me.horizSplit.Panel2.SuspendLayout()
        Me.horizSplit.SuspendLayout()
        CType(Me.vertSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vertSplit.Panel1.SuspendLayout()
        Me.vertSplit.Panel2.SuspendLayout()
        Me.vertSplit.SuspendLayout()
        CType(Me.grdFoundDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'statStatusStrip
        '
        Me.statStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMessage})
        Me.statStatusStrip.Location = New System.Drawing.Point(0, 230)
        Me.statStatusStrip.Name = "statStatusStrip"
        Me.statStatusStrip.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.statStatusStrip.Size = New System.Drawing.Size(646, 22)
        Me.statStatusStrip.TabIndex = 0
        Me.statStatusStrip.Text = "StatusStrip1"
        '
        'horizSplit
        '
        Me.horizSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.horizSplit.Location = New System.Drawing.Point(0, 24)
        Me.horizSplit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.horizSplit.Name = "horizSplit"
        Me.horizSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'horizSplit.Panel1
        '
        Me.horizSplit.Panel1.Controls.Add(Me.vertSplit)
        '
        'horizSplit.Panel2
        '
        Me.horizSplit.Panel2.Controls.Add(Me.grdFoundDocs)
        Me.horizSplit.Size = New System.Drawing.Size(646, 206)
        Me.horizSplit.SplitterDistance = 66
        Me.horizSplit.SplitterWidth = 6
        Me.horizSplit.TabIndex = 1
        '
        'vertSplit
        '
        Me.vertSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vertSplit.Location = New System.Drawing.Point(0, 0)
        Me.vertSplit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.vertSplit.Name = "vertSplit"
        '
        'vertSplit.Panel1
        '
        Me.vertSplit.Panel1.Controls.Add(Me.txtSearchCriteria)
        '
        'vertSplit.Panel2
        '
        Me.vertSplit.Panel2.Controls.Add(Me.cmdSearch)
        Me.vertSplit.Size = New System.Drawing.Size(646, 66)
        Me.vertSplit.SplitterDistance = 489
        Me.vertSplit.SplitterWidth = 6
        Me.vertSplit.TabIndex = 0
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCriteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCriteria.Location = New System.Drawing.Point(13, 31)
        Me.txtSearchCriteria.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(460, 26)
        Me.txtSearchCriteria.TabIndex = 0
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(31, 22)
        Me.cmdSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(73, 35)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'grdFoundDocs
        '
        Me.grdFoundDocs.AllowUserToAddRows = False
        Me.grdFoundDocs.AllowUserToDeleteRows = False
        Me.grdFoundDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFoundDocs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDocId, Me.colDocLabel, Me.colDocDate, Me.colDocTitle})
        Me.grdFoundDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFoundDocs.Location = New System.Drawing.Point(0, 0)
        Me.grdFoundDocs.Name = "grdFoundDocs"
        Me.grdFoundDocs.Size = New System.Drawing.Size(646, 134)
        Me.grdFoundDocs.TabIndex = 0
        '
        'colDocId
        '
        Me.colDocId.HeaderText = "Doc Id:"
        Me.colDocId.Name = "colDocId"
        '
        'colDocLabel
        '
        Me.colDocLabel.HeaderText = "Label:"
        Me.colDocLabel.Name = "colDocLabel"
        '
        'colDocDate
        '
        Me.colDocDate.HeaderText = "Date:"
        Me.colDocDate.Name = "colDocDate"
        '
        'colDocTitle
        '
        Me.colDocTitle.HeaderText = "Title:"
        Me.colDocTitle.Name = "colDocTitle"
        Me.colDocTitle.Width = 500
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.TestToolStripMenuItem, Me.HelpToolStripMenuItem, Me.SearchArgsToolStripMenuItem1, Me.CacheToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(646, 24)
        Me.mnuMainMenu.TabIndex = 2
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentIdToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'DocumentIdToolStripMenuItem
        '
        Me.DocumentIdToolStripMenuItem.Checked = True
        Me.DocumentIdToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DocumentIdToolStripMenuItem.Name = "DocumentIdToolStripMenuItem"
        Me.DocumentIdToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.DocumentIdToolStripMenuItem.Text = "Document Id visible"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'SearchArgsToolStripMenuItem1
        '
        Me.SearchArgsToolStripMenuItem1.Name = "SearchArgsToolStripMenuItem1"
        Me.SearchArgsToolStripMenuItem1.Size = New System.Drawing.Size(78, 20)
        Me.SearchArgsToolStripMenuItem1.Text = "SearchArgs"
        '
        'CacheToolStripMenuItem
        '
        Me.CacheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.PopulateToolStripMenuItem, Me.DumpToolStripMenuItem, Me.SearchToolStripMenuItem})
        Me.CacheToolStripMenuItem.Name = "CacheToolStripMenuItem"
        Me.CacheToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.CacheToolStripMenuItem.Text = "Cache"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'PopulateToolStripMenuItem
        '
        Me.PopulateToolStripMenuItem.Name = "PopulateToolStripMenuItem"
        Me.PopulateToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PopulateToolStripMenuItem.Text = "Populate"
        '
        'DumpToolStripMenuItem
        '
        Me.DumpToolStripMenuItem.Name = "DumpToolStripMenuItem"
        Me.DumpToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DumpToolStripMenuItem.Text = "Dump"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'toolStripMessage
        '
        Me.toolStripMessage.Name = "toolStripMessage"
        Me.toolStripMessage.Size = New System.Drawing.Size(120, 17)
        Me.toolStripMessage.Text = "ToolStripStatusLabel1"
        '
        'frmBesSrcMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 252)
        Me.Controls.Add(Me.horizSplit)
        Me.Controls.Add(Me.statStatusStrip)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmBesSrcMain"
        Me.Text = "*** Form Text - temp title - Bessie Search ***"
        Me.statStatusStrip.ResumeLayout(False)
        Me.statStatusStrip.PerformLayout()
        Me.horizSplit.Panel1.ResumeLayout(False)
        Me.horizSplit.Panel2.ResumeLayout(False)
        CType(Me.horizSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.horizSplit.ResumeLayout(False)
        Me.vertSplit.Panel1.ResumeLayout(False)
        Me.vertSplit.Panel1.PerformLayout()
        Me.vertSplit.Panel2.ResumeLayout(False)
        CType(Me.vertSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vertSplit.ResumeLayout(False)
        CType(Me.grdFoundDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents horizSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents vertSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents grdFoundDocs As System.Windows.Forms.DataGridView
    Friend WithEvents colDocId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentIdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchArgsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopulateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DumpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripMessage As System.Windows.Forms.ToolStripStatusLabel
End Class
