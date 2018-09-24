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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.grdFoundDocs = New System.Windows.Forms.DataGridView()
        Me.colDocId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdFoundDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statStatusStrip
        '
        Me.statStatusStrip.Location = New System.Drawing.Point(0, 230)
        Me.statStatusStrip.Name = "statStatusStrip"
        Me.statStatusStrip.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.statStatusStrip.Size = New System.Drawing.Size(646, 22)
        Me.statStatusStrip.TabIndex = 0
        Me.statStatusStrip.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdFoundDocs)
        Me.SplitContainer1.Size = New System.Drawing.Size(646, 230)
        Me.SplitContainer1.SplitterDistance = 89
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtSearchCriteria)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmdSearch)
        Me.SplitContainer2.Size = New System.Drawing.Size(646, 89)
        Me.SplitContainer2.SplitterDistance = 430
        Me.SplitContainer2.SplitterWidth = 6
        Me.SplitContainer2.TabIndex = 0
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCriteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCriteria.Location = New System.Drawing.Point(13, 31)
        Me.txtSearchCriteria.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(401, 26)
        Me.txtSearchCriteria.TabIndex = 0
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(33, 31)
        Me.cmdSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(156, 35)
        Me.cmdSearch.TabIndex = 0
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
        Me.grdFoundDocs.Size = New System.Drawing.Size(646, 135)
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
        'frmBesSrcMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 252)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.statStatusStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmBesSrcMain"
        Me.Text = "*** Form Text - temp title - Bessie Search ***"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdFoundDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents grdFoundDocs As System.Windows.Forms.DataGridView
    Friend WithEvents colDocId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocTitle As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
