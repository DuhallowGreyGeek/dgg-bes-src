Public Class frmDocView
    Protected Friend PROPLABELWIDTH As Integer = 125 '250

    Public Sub New(ByVal DocumentId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Passed value: " & DocumentId.ToString
        Me.ToolStripStatusLabel1.Text = Me.Text

        'Load the Document object
        Dim curDocument As New Document(DocumentId)    'Create a new Document from the database
        'Call curDocument.Dump()

        'Add the rows to the data grid and populate with values
        Const LABCOL As Integer = 0
        Const VALCOL As Integer = 1
        '
        Dim iDocId As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocId).Cells.Item(LABCOL).Value = "Document Id"
        Me.GrdDocProps.Rows.Item(iDocId).Cells.Item(VALCOL).Value = DocumentId.ToString
        '
        Dim iDocLabel As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocLabel).Cells.Item(LABCOL).Value = "Document Label"
        Me.GrdDocProps.Rows.Item(iDocLabel).Cells.Item(VALCOL).Value = curDocument.DocumentLabel
        '
        Dim iDocDate As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocDate).Cells.Item(LABCOL).Value = "Orig Date"
        Me.GrdDocProps.Rows.Item(iDocDate).Cells.Item(VALCOL).Value = curDocument.DateOnDoc.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
        '
        Dim iDocTitle As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocTitle).Cells.Item(LABCOL).Value = "Title"
        Me.GrdDocProps.Rows.Item(iDocTitle).Cells.Item(VALCOL).Value = curDocument.Title
        '
        Dim iFname As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iFname).Cells.Item(LABCOL).Value = "File name"
        Me.GrdDocProps.Rows.Item(iFname).Cells.Item(VALCOL).Value = curDocument.FileName
        '
        Dim iFpath As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iFpath).Cells.Item(LABCOL).Value = "File path"
        Me.GrdDocProps.Rows.Item(iFpath).Cells.Item(VALCOL).Value = curDocument.Path
        '
    End Sub

    Private Sub SafeScreenResize()

        If Me.WindowState <> FormWindowState.Minimized Then

            'Now deal with the Value column in datagrid

            colDocPropValue.Width = Me.Width - colDocPropLabel.Width
        End If
    End Sub

    Private Sub frmDocView_Load(sender As Object, e As EventArgs) Handles Me.Load
        colDocPropLabel.Width = PROPLABELWIDTH

        Call Me.SafeScreenResize()
    End Sub

    Private Sub frmDocView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call Me.SafeScreenResize()
    End Sub
End Class