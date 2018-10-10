<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocView
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
        Me.ToolStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DocTabControl = New System.Windows.Forms.TabControl()
        Me.DocHdrTab = New System.Windows.Forms.TabPage()
        Me.tblHeaderLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.GrdDocProps = New System.Windows.Forms.DataGridView()
        Me.colDocPropLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocPropValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpOrigDoc = New System.Windows.Forms.GroupBox()
        Me.lblFileNameBodge = New System.Windows.Forms.Label()
        Me.cmdViewDocument = New System.Windows.Forms.Button()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.PartsTab = New System.Windows.Forms.TabPage()
        Me.PartsTabCntrl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PartPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.DocTabControl.SuspendLayout()
        Me.DocHdrTab.SuspendLayout()
        Me.tblHeaderLayout.SuspendLayout()
        CType(Me.GrdDocProps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrigDoc.SuspendLayout()
        Me.PartsTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 332)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(766, 22)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'DocTabControl
        '
        Me.DocTabControl.Controls.Add(Me.DocHdrTab)
        Me.DocTabControl.Controls.Add(Me.PartsTab)
        Me.DocTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocTabControl.Location = New System.Drawing.Point(0, 0)
        Me.DocTabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DocTabControl.Name = "DocTabControl"
        Me.DocTabControl.SelectedIndex = 0
        Me.DocTabControl.Size = New System.Drawing.Size(766, 332)
        Me.DocTabControl.TabIndex = 1
        '
        'DocHdrTab
        '
        Me.DocHdrTab.Controls.Add(Me.tblHeaderLayout)
        Me.DocHdrTab.Location = New System.Drawing.Point(4, 29)
        Me.DocHdrTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DocHdrTab.Name = "DocHdrTab"
        Me.DocHdrTab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DocHdrTab.Size = New System.Drawing.Size(758, 299)
        Me.DocHdrTab.TabIndex = 0
        Me.DocHdrTab.Text = "Header"
        Me.DocHdrTab.UseVisualStyleBackColor = True
        '
        'tblHeaderLayout
        '
        Me.tblHeaderLayout.ColumnCount = 1
        Me.tblHeaderLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeaderLayout.Controls.Add(Me.GrdDocProps, 0, 0)
        Me.tblHeaderLayout.Controls.Add(Me.grpOrigDoc, 0, 1)
        Me.tblHeaderLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHeaderLayout.Location = New System.Drawing.Point(4, 5)
        Me.tblHeaderLayout.Name = "tblHeaderLayout"
        Me.tblHeaderLayout.RowCount = 2
        Me.tblHeaderLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeaderLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tblHeaderLayout.Size = New System.Drawing.Size(750, 289)
        Me.tblHeaderLayout.TabIndex = 1
        '
        'GrdDocProps
        '
        Me.GrdDocProps.AllowUserToAddRows = False
        Me.GrdDocProps.AllowUserToDeleteRows = False
        Me.GrdDocProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDocProps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDocPropLabel, Me.colDocPropValue})
        Me.GrdDocProps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDocProps.Location = New System.Drawing.Point(4, 5)
        Me.GrdDocProps.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrdDocProps.Name = "GrdDocProps"
        Me.GrdDocProps.ReadOnly = True
        Me.GrdDocProps.Size = New System.Drawing.Size(742, 199)
        Me.GrdDocProps.TabIndex = 0
        '
        'colDocPropLabel
        '
        Me.colDocPropLabel.HeaderText = "Property:"
        Me.colDocPropLabel.Name = "colDocPropLabel"
        Me.colDocPropLabel.ReadOnly = True
        '
        'colDocPropValue
        '
        Me.colDocPropValue.HeaderText = "Value:"
        Me.colDocPropValue.Name = "colDocPropValue"
        Me.colDocPropValue.ReadOnly = True
        '
        'grpOrigDoc
        '
        Me.grpOrigDoc.Controls.Add(Me.lblFileNameBodge)
        Me.grpOrigDoc.Controls.Add(Me.cmdViewDocument)
        Me.grpOrigDoc.Controls.Add(Me.lblFileSize)
        Me.grpOrigDoc.Controls.Add(Me.lblFileName)
        Me.grpOrigDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOrigDoc.Location = New System.Drawing.Point(3, 212)
        Me.grpOrigDoc.Name = "grpOrigDoc"
        Me.grpOrigDoc.Size = New System.Drawing.Size(744, 74)
        Me.grpOrigDoc.TabIndex = 1
        Me.grpOrigDoc.TabStop = False
        Me.grpOrigDoc.Text = "Original Document"
        '
        'lblFileNameBodge
        '
        Me.lblFileNameBodge.AutoSize = True
        Me.lblFileNameBodge.Location = New System.Drawing.Point(321, 26)
        Me.lblFileNameBodge.Name = "lblFileNameBodge"
        Me.lblFileNameBodge.Size = New System.Drawing.Size(57, 20)
        Me.lblFileNameBodge.TabIndex = 3
        Me.lblFileNameBodge.Text = "Label2"
        Me.lblFileNameBodge.Visible = False
        '
        'cmdViewDocument
        '
        Me.cmdViewDocument.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewDocument.Location = New System.Drawing.Point(642, 27)
        Me.cmdViewDocument.Name = "cmdViewDocument"
        Me.cmdViewDocument.Size = New System.Drawing.Size(75, 34)
        Me.cmdViewDocument.TabIndex = 2
        Me.cmdViewDocument.Text = "View"
        Me.cmdViewDocument.UseVisualStyleBackColor = True
        '
        'lblFileSize
        '
        Me.lblFileSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileSize.AutoSize = True
        Me.lblFileSize.Location = New System.Drawing.Point(21, 46)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(202, 20)
        Me.lblFileSize.TabIndex = 1
        Me.lblFileSize.Text = "File size: Filesize K/M/Bytes"
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(21, 26)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(243, 20)
        Me.lblFileName.TabIndex = 0
        Me.lblFileName.Text = "Filename: Filename Filename.pdf"
        '
        'PartsTab
        '
        Me.PartsTab.Controls.Add(Me.PartsTabCntrl)
        Me.PartsTab.Location = New System.Drawing.Point(4, 29)
        Me.PartsTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartsTab.Name = "PartsTab"
        Me.PartsTab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartsTab.Size = New System.Drawing.Size(758, 299)
        Me.PartsTab.TabIndex = 1
        Me.PartsTab.Text = "Parts"
        Me.PartsTab.UseVisualStyleBackColor = True
        '
        'PartsTabCntrl
        '
        Me.PartsTabCntrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartsTabCntrl.Location = New System.Drawing.Point(4, 5)
        Me.PartsTabCntrl.Name = "PartsTabCntrl"
        Me.PartsTabCntrl.SelectedIndex = 0
        Me.PartsTabCntrl.Size = New System.Drawing.Size(750, 289)
        Me.PartsTabCntrl.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(742, 256)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(742, 256)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PartPanel
        '
        Me.PartPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartPanel.Location = New System.Drawing.Point(3, 3)
        Me.PartPanel.Name = "PartPanel"
        Me.PartPanel.Size = New System.Drawing.Size(736, 250)
        Me.PartPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(308, 20)
        Me.Label1.TabIndex = 0
        '
        'frmDocView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 354)
        Me.Controls.Add(Me.DocTabControl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmDocView"
        Me.Text = "frmDocView"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.DocTabControl.ResumeLayout(False)
        Me.DocHdrTab.ResumeLayout(False)
        Me.tblHeaderLayout.ResumeLayout(False)
        CType(Me.GrdDocProps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrigDoc.ResumeLayout(False)
        Me.grpOrigDoc.PerformLayout()
        Me.PartsTab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DocTabControl As System.Windows.Forms.TabControl
    Friend WithEvents DocHdrTab As System.Windows.Forms.TabPage
    Friend WithEvents GrdDocProps As System.Windows.Forms.DataGridView
    Friend WithEvents colDocPropLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocPropValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartsTab As System.Windows.Forms.TabPage
    Friend WithEvents PartsTabCntrl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PartPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tblHeaderLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpOrigDoc As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewDocument As System.Windows.Forms.Button
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblFileNameBodge As System.Windows.Forms.Label
End Class
