Public Class frmDocView
    Protected Friend PROPLABELWIDTH As Integer = 125 '250
    '
    'Indexes for the DocTabControl (Used when accessing the tabs thru the TabPages collection)
    '**** Just to confuse, they can't have the same names as the tabs!
    Protected Friend DOCHEDRTAB As Integer = 0
    Protected Friend DPARTSTAB As Integer = 1
    Protected Friend ORGDOCTAB As Integer = 2

    Dim myPVCol As New PartViewCollection(Me)

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
        'Now move on to the "Parts" tab
        If curDocument.Parts.Count > 0 Then
            Me.ToolStripStatusLabel1.Text = curDocument.Parts.Count.ToString & " Parts found for this document."
            Dim i As Integer = 0
            Dim partnum As Integer = 0

            Dim partTabText As String = ""
            For i = 0 To curDocument.Parts.Count - 1 'Zero based array
                partnum = i + 1
                '
                'Add the "part" pages we need
                partTabText = "Part: " & partnum.ToString
                Me.PartsTabCntrl.TabPages.Add(partTabText)      'Add the new TabPage
                myPVCol.AddNewPartView()                        'Add the new PartView
                Me.PartsTabCntrl.TabPages(i).Controls.Add(myPVCol(i)) 'Add the PartView to the controls of the TabPage
                '
                'Set the properties of the Part
                With myPVCol(i)
                    .Dock = DockStyle.Fill
                    '
                    'Properties of the Part are set by the part itself
                    .PartNum = partnum.ToString

                    Dim part As DocPart = curDocument.Parts.Item(partnum)
                    .DocSubject = part.Subject
                    .DocDate = part.DocDate.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
                    .DocFrom = part.DocFrom
                    .DocTo = part.DocTo

                    '.Synopsis_Stored = partnum.ToString & " She sells sea shells by the sea shore."
                    .Synopsis_Stored = part.Synopsis_Stored
                    .Synopsis_Derived = part.Synopsis_Derived
                End With
            Next

        Else    'This is unexpected - Set a message and disable the tab
            Me.DocTabControl.TabPages.Item(DPARTSTAB).Enabled = False           '*** Disabling/Visible tab doesn't work!
            'However, tab remains empty
            '
            Me.ToolStripStatusLabel1.Text = "No Parts found for this Document!"
        End If

        'Now display the pdf
        'Me.pdfViewer.LoadFile("C:\Users\user\Desktop\Arkema.pdf")
        'Me.pdfViewer.src = "file:///C:/Users/user/Desktop/Arkema.pdf"
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