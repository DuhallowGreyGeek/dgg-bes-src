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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GrdDocProps = New System.Windows.Forms.DataGridView()
        Me.colDocPropLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocPropValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.DocTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GrdDocProps, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DocTabControl.Controls.Add(Me.TabPage1)
        Me.DocTabControl.Controls.Add(Me.TabPage2)
        Me.DocTabControl.Controls.Add(Me.TabPage3)
        Me.DocTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocTabControl.Location = New System.Drawing.Point(0, 0)
        Me.DocTabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DocTabControl.Name = "DocTabControl"
        Me.DocTabControl.SelectedIndex = 0
        Me.DocTabControl.Size = New System.Drawing.Size(766, 332)
        Me.DocTabControl.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GrdDocProps)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(758, 299)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Header"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Size = New System.Drawing.Size(924, 342)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Parts"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Size = New System.Drawing.Size(924, 342)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Orig Text"
        Me.TabPage3.UseVisualStyleBackColor = True
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
        Me.GrdDocProps.Size = New System.Drawing.Size(750, 289)
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
        Me.TabPage1.ResumeLayout(False)
        CType(Me.GrdDocProps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DocTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GrdDocProps As System.Windows.Forms.DataGridView
    Friend WithEvents colDocPropLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocPropValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
