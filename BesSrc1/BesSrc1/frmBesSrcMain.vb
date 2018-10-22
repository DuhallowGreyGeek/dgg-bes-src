Public Class frmBesSrcMain
    'Used to manage to console
    Declare Function AllocConsole Lib "Kernel32" () As Int32
    Declare Function FreeConsole Lib "Kernel32" () As Int32

    'Constants used to fix the size of panels when form resizes
    Protected Friend Const RIGHTPANELWIDTH As Integer = 190
    Protected Friend Const TOPPANELHEIGHT As Integer = 76

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        'The heart of Bessie! Displays the search results
        Const MAXDOCSON As Boolean = True                                  'Ceiling on number of docs displayed
        Const MAXDOCNUM As Integer = 999                                    'Ceiling num of docs

        Try
            fdocs.Clear()                                                       'Clear the cache
            Me.grdFoundDocs.Rows.Clear()                                        'Clear the FoundDocs grid
            Me.toolStripMessage.Text = ""                                       'Clear the status message

            Dim searchArguments As New Collection                               'Parse the arguments
            searchArguments = srch.ParsedSearchArgs(txtSearchCriteria.Text.ToString)

            Dim matchedDocuments As New BesIntSet                               'Get the matching documents
            matchedDocuments = srch.MatchingDocs(searchArguments)

            'Add the matched documents to the cache
            For Each documentId As Integer In matchedDocuments
                fdocs.Add(documentId)
            Next

            If fdocs.FoundDocIds.Count > 0 Then
                If MAXDOCSON And fdocs.FoundDocIds.Count > MAXDOCNUM Then       'Too many docs to display
                    Me.toolStripMessage.Text = "Found: " & srch.ListDocumentRows.Count.ToString & " which is more than the maximum of: " & MAXDOCNUM.ToString

                Else

                    Me.toolStripMessage.Text = "Found: " & srch.ListDocumentRows.Count.ToString & " documents."

                    For Each DocumentRow As DocumentRow In srch.ListDocumentRows
                        Dim rowid As Integer = Me.grdFoundDocs.Rows.Add()
                        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(0).Value = DocumentRow.DocId
                        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(1).Value = DocumentRow.Label
                        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(2).Value = DocumentRow.DocDate.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
                        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(3).Value = DocumentRow.Title

                    Next
                End If
            Else
                Me.toolStripMessage.Text = "Found no documents."
            End If

            'Now set the focus back in the search criteria text box
            Me.txtSearchCriteria.Focus()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical, "Bessie")
        End Try

    End Sub

    Private Sub grdFoundDocs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFoundDocs.CellContentClick
        'Dim column As Integer = e.ColumnIndex
        'Dim row As Integer = e.RowIndex

        'Call MsgBox("--row--> " & e.RowIndex.ToString & "--col--> " & e.ColumnIndex.ToString)
        If e.RowIndex >= 0 Then 'Avoid problem with user clicking on headings

            Dim rowId As String = Me.grdFoundDocs.Rows.Item(e.RowIndex).Cells.Item(0).Value

            'Call MsgBox(" Clicked in Row: " & rowId.ToString)
            Dim documentForm As New frmDocView(rowId)
            Call documentForm.Show()
        End If
    End Sub


    Private Sub frmBesSrcMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        gWndHndl = Me.Handle                        'Window handle to use as session id
        fdocs = New FoundDocs(gWndHndl)             'Associate foundDocs with this window

        Me.Text = "** Bessie ** - Inverted Key Proof-of-Concept "

        'Set the minimum height for the top panel
        Me.horizSplit.Panel1MinSize = TOPPANELHEIGHT
        Me.toolStripMessage.Text = ""                                       'Clear the status message

        Call Me.SafeScreenResize()
    End Sub


    Private Sub frmBesSrcMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call Me.SafeScreenResize()
    End Sub

    Private Sub SafeScreenResize()

        If Me.WindowState <> FormWindowState.Minimized Then
            'Deal with the Form as a whole
            If Me.Width > RIGHTPANELWIDTH Then
                Me.vertSplit.SplitterDistance = Me.Width - RIGHTPANELWIDTH
            End If

            Me.horizSplit.SplitterDistance = TOPPANELHEIGHT

            'Now deal with the DocTitle column in datagrid
            Dim usedWidth As Integer
            usedWidth = colDocDate.Width + colDocLabel.Width

            If colDocId.Visible Then
                usedWidth = usedWidth + colDocId.Width
            End If

            colDocTitle.Width = Me.Width - usedWidth
        End If
    End Sub

    Private Sub DocumentIdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentIdToolStripMenuItem.Click

        If Me.colDocId.Visible = True Then
            Me.colDocId.Visible = False
            Me.DocumentIdToolStripMenuItem.Checked = False
        Else
            Me.colDocId.Visible = True
            Me.DocumentIdToolStripMenuItem.Checked = True
        End If

        Call Me.SafeScreenResize()

    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        'Test code
        Dim searchArgument As String = InputBox("Enter the search argument", "Search Argument", "")

        'Dim matchingDocs As BesIntSet = srch.DocsEqualArg(searchArgument)
        Dim matchingDocs As BesIntSet = srch.DocsLikeArg(searchArgument)

        Call matchingDocs.Dump()
    End Sub

    Private Sub SearchArgsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SearchArgsToolStripMenuItem1.Click
        'Test code

        Dim searchArguments As New Collection                               'Parse the arguments
        searchArguments = srch.ParsedSearchArgs(txtSearchCriteria.Text.ToString)

        Dim matchedDocuments As New BesIntSet                               'Get the maching documents
        matchedDocuments = srch.MatchingDocs(searchArguments)

        Call matchedDocuments.Dump()

        Console.WriteLine(" ")

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        'Clear the cache of DocumentIds
        Call fdocs.Clear()
    End Sub

    Private Sub DumpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DumpToolStripMenuItem.Click
        'Dump the cache of DocumentIds to the console
        Call fdocs.Dump()
    End Sub

    Private Sub PopulateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PopulateToolStripMenuItem.Click
        'Test Code 
        Dim inputDocumentId As Integer
        Dim inputString As String

        inputString = InputBox("DocumentId: ", "Input Test DocumentId")
        If inputString.Length > 0 And Integer.TryParse(inputString, inputDocumentId) Then
            Call fdocs.Add(inputDocumentId)
        End If
    End Sub

    Private Sub ConsoleVisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsoleVisibleToolStripMenuItem.Click
        'Toggle the debug console on and off
        'Uses functions declared at the top of the class
        'Declare Function AllocConsole Lib "Kernel32" () As Int32
        'Declare Function FreeConsole Lib "Kernel32" () As Int32

        If Me.ConsoleVisibleToolStripMenuItem.Checked = True Then
            FreeConsole()
            Me.ConsoleVisibleToolStripMenuItem.Checked = False
        Else
            AllocConsole()
            Me.ConsoleVisibleToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub OpenDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDocumentToolStripMenuItem.Click
        'Test Code 
        Dim inputDocumentId As Integer
        Dim inputString As String

        inputString = InputBox("DocumentId: ", "Input DocumentId to open")
        If inputString.Length > 0 And Integer.TryParse(inputString, inputDocumentId) Then
            Dim curDocument As New Document(inputDocumentId)    'Create a new Document from the database
            'Dim curPart As New DocPart(inputDocumentId, inputDocumentId)    'Create a new DocPart from the database
            'Dim curBatch As New DocBatch(inputDocumentId)    'Create a new DocBatch from the database
            '
            'Call curDocument.Dump()
            'Call curPart.Dump()
            'Call curBatch.Dump()

            Dim documentForm As New frmDocView(inputDocumentId)

            'documentForm.Text = "Grauniad: " & inputDocumentId.ToString
            documentForm.Show()

        End If
    End Sub
End Class