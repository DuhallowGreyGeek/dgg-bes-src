<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewPdfDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewPdfDoc))
        Me.pdfViewer = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.pdfViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pdfViewer
        '
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Enabled = True
        Me.pdfViewer.Location = New System.Drawing.Point(0, 0)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.OcxState = CType(resources.GetObject("pdfViewer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfViewer.Size = New System.Drawing.Size(516, 382)
        Me.pdfViewer.TabIndex = 0
        '
        'frmViewPdfDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 382)
        Me.Controls.Add(Me.pdfViewer)
        Me.Name = "frmViewPdfDoc"
        Me.Text = "frmViewPdfDoc"
        CType(Me.pdfViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pdfViewer As AxAcroPDFLib.AxAcroPDF
End Class
