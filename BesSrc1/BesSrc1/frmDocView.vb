Public Class frmDocView
    Private Const PROPLABELWIDTH As Integer = 125 '250
    '
    'Indexes for the DocTabControl (Used when accessing the tabs thru the TabPages collection)
    '**** Just to confuse, they can't have the same names as the tabs!
    Private Const DOCHEDRTAB As Integer = 0
    Private Const DPARTSTAB As Integer = 1
    Private Const ORGDOCTAB As Integer = 2

    Private myPVCol As New PartViewCollection(Me)
    Private curDocument As Document                 'So it can be shared throughout the Form
    Private mFileName As String                     'Fully qualified name of the DocumentFile

    Public Sub New(ByVal DocumentId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Bessie: DocumentId: " & DocumentId.ToString
        Me.ToolStripStatusLabel1.Text = Me.Text

        'Load the Document object
        curDocument = New Document(DocumentId) 'Get the Document values from the database
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
        Me.Text = Me.Text & " Label: " & curDocument.DocumentLabel.Substring(0, 12)
        '
        Dim iDocDate As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocDate).Cells.Item(LABCOL).Value = "Orig Date"
        Me.GrdDocProps.Rows.Item(iDocDate).Cells.Item(VALCOL).Value = curDocument.DateOnDoc.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
        '
        Dim iDocTitle As Integer = Me.GrdDocProps.Rows.Add()
        Me.GrdDocProps.Rows.Item(iDocTitle).Cells.Item(LABCOL).Value = "Title"
        Me.GrdDocProps.Rows.Item(iDocTitle).Cells.Item(VALCOL).Value = curDocument.Title
        Me.Text = Me.Text & " - " & curDocument.Title
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

                    .Synopsis_Stored = part.Synopsis_Stored
                    .Synopsis_Derived = part.Synopsis_Derived
                    '
                    Call .HighlightWords()
                End With
            Next

        Else    'This is unexpected - Set a message and disable the tab
            Me.DocTabControl.TabPages.Item(DPARTSTAB).Enabled = False           '*** Disabling/Visible tab doesn't work!
            'However, tab remains empty
            '
            Me.ToolStripStatusLabel1.Text = "No Parts found for this Document!"
        End If

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

    Private Sub frmDocView_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '*** I have no idea why mFileName is not visible inside cmdViewDocument
        'I am using lblFileNameBodge to pass the name in. Ugly!

        Me.cmdViewDocument.Enabled = False

        'Construct filepath for pdf, and enable/disable viewing
        Dim mFileName As String = params.FilePathHome & curDocument.Path & curDocument.FileName
        'Console.WriteLine("--Shown---> " & mFileName)
        lblFileNameBodge.Text = mFileName

        If System.IO.File.Exists(mFileName) Then
            Me.lblFileName.Text = "Filename: " & curDocument.FileName
            Me.lblFileSize.Text = "File Size: " & FileLen(mFileName).ToString & " Bytes"
            Me.cmdViewDocument.Enabled = True
        Else
            Me.lblFileName.Text = "Filename: Not found!"
            Me.lblFileSize.Text = "File Size: Not found!"
        End If


    End Sub

    Private Sub cmdViewDocument_Click(sender As Object, e As EventArgs) Handles cmdViewDocument.Click
        '*** I have no idea why mFileName is not visible inside cmdViewDocument
        'I am using lblFileNameBodge to pass the name in. Ugly!
        'Console.WriteLine("Inside the cmdViewDocument button --- Why isn't it seeing the mFileName?")
        Dim filename As String = lblFileNameBodge.Text
        'Console.WriteLine("-----> " & Me.lblFileNameBodge.Text)
        'Call MsgBox("Display File: " & Me.lblFileNameBodge.Text)

        Try
            Dim pdfViewForm As New frmViewPdfDoc(filename)
            pdfViewForm.Text = Me.Text
            Call pdfViewForm.Show()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Call MsgBox("Failure displaying pdfFile: " & Me.lblFileNameBodge.Text, MsgBoxStyle.Critical)
        End Try

    End Sub
End Class