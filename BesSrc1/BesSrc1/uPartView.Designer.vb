<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uPartView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tblPartTableLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblStored = New System.Windows.Forms.Label()
        Me.lblDerived = New System.Windows.Forms.Label()
        Me.rtxtStored = New System.Windows.Forms.RichTextBox()
        Me.rtxtDerived = New System.Windows.Forms.RichTextBox()
        Me.grdPartProps = New System.Windows.Forms.DataGridView()
        Me.colProperty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblPartTableLayout.SuspendLayout()
        CType(Me.grdPartProps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblPartTableLayout
        '
        Me.tblPartTableLayout.ColumnCount = 2
        Me.tblPartTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPartTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPartTableLayout.Controls.Add(Me.lblStored, 0, 1)
        Me.tblPartTableLayout.Controls.Add(Me.lblDerived, 1, 1)
        Me.tblPartTableLayout.Controls.Add(Me.rtxtStored, 0, 2)
        Me.tblPartTableLayout.Controls.Add(Me.rtxtDerived, 1, 2)
        Me.tblPartTableLayout.Controls.Add(Me.grdPartProps, 0, 0)
        Me.tblPartTableLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPartTableLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tblPartTableLayout.Location = New System.Drawing.Point(0, 0)
        Me.tblPartTableLayout.Name = "tblPartTableLayout"
        Me.tblPartTableLayout.RowCount = 3
        Me.tblPartTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPartTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tblPartTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPartTableLayout.Size = New System.Drawing.Size(589, 307)
        Me.tblPartTableLayout.TabIndex = 0
        '
        'lblStored
        '
        Me.lblStored.AutoSize = True
        Me.lblStored.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStored.Location = New System.Drawing.Point(3, 144)
        Me.lblStored.Name = "lblStored"
        Me.lblStored.Size = New System.Drawing.Size(157, 18)
        Me.lblStored.TabIndex = 0
        Me.lblStored.Text = "Synopsis (Stored):"
        '
        'lblDerived
        '
        Me.lblDerived.AutoSize = True
        Me.lblDerived.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDerived.Location = New System.Drawing.Point(297, 144)
        Me.lblDerived.Name = "lblDerived"
        Me.lblDerived.Size = New System.Drawing.Size(164, 18)
        Me.lblDerived.TabIndex = 1
        Me.lblDerived.Text = "Synopsis (Derived):"
        '
        'rtxtStored
        '
        Me.rtxtStored.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtStored.Location = New System.Drawing.Point(3, 165)
        Me.rtxtStored.Name = "rtxtStored"
        Me.rtxtStored.ReadOnly = True
        Me.rtxtStored.Size = New System.Drawing.Size(288, 139)
        Me.rtxtStored.TabIndex = 2
        Me.rtxtStored.Text = ""
        '
        'rtxtDerived
        '
        Me.rtxtDerived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtDerived.Location = New System.Drawing.Point(297, 165)
        Me.rtxtDerived.Name = "rtxtDerived"
        Me.rtxtDerived.ReadOnly = True
        Me.rtxtDerived.Size = New System.Drawing.Size(289, 139)
        Me.rtxtDerived.TabIndex = 3
        Me.rtxtDerived.Text = ""
        '
        'grdPartProps
        '
        Me.grdPartProps.AllowUserToAddRows = False
        Me.grdPartProps.AllowUserToDeleteRows = False
        Me.grdPartProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPartProps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProperty, Me.colValue})
        Me.tblPartTableLayout.SetColumnSpan(Me.grdPartProps, 2)
        Me.grdPartProps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartProps.Location = New System.Drawing.Point(3, 3)
        Me.grdPartProps.Name = "grdPartProps"
        Me.grdPartProps.ReadOnly = True
        Me.grdPartProps.Size = New System.Drawing.Size(583, 138)
        Me.grdPartProps.TabIndex = 4
        '
        'colProperty
        '
        Me.colProperty.HeaderText = "Property:"
        Me.colProperty.Name = "colProperty"
        Me.colProperty.ReadOnly = True
        '
        'colValue
        '
        Me.colValue.HeaderText = "Value:"
        Me.colValue.Name = "colValue"
        Me.colValue.ReadOnly = True
        '
        'uPartView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblPartTableLayout)
        Me.Name = "uPartView"
        Me.Size = New System.Drawing.Size(589, 307)
        Me.tblPartTableLayout.ResumeLayout(False)
        Me.tblPartTableLayout.PerformLayout()
        CType(Me.grdPartProps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblPartTableLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblStored As System.Windows.Forms.Label
    Friend WithEvents lblDerived As System.Windows.Forms.Label
    Friend WithEvents rtxtStored As System.Windows.Forms.RichTextBox
    Friend WithEvents rtxtDerived As System.Windows.Forms.RichTextBox
    Friend WithEvents grdPartProps As System.Windows.Forms.DataGridView
    Friend WithEvents colProperty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValue As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
