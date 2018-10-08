Public Class frmViewPdfDoc

    Public Sub New(fileName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = fileName
        '
        Me.pdfViewer.src = fileName
        '
    End Sub
End Class