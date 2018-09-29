﻿Public Class frmBesSrcMain

    'Constants used to fix the size of panels when form resizes
    Protected Friend Const RIGHTPANELWIDTH As Integer = 190
    Protected Friend Const TOPPANELHEIGHT As Integer = 76

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click

        Me.grdFoundDocs.Rows.Clear()
        If srch.ListDocumentRows.Count > 0 Then
            'MsgBox("there are document rows")
            For Each DocumentRow As DocumentRow In srch.ListDocumentRows
                Dim rowid As Integer = Me.grdFoundDocs.Rows.Add()
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(0).Value = DocumentRow.DocId
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(1).Value = DocumentRow.Label
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(2).Value = DocumentRow.DocDate.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(3).Value = DocumentRow.Title

            Next
        Else
            MsgBox("there are no document rows")
        End If

    End Sub

    Private Sub grdFoundDocs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFoundDocs.CellContentClick
        Dim column As Integer = e.ColumnIndex
        Dim row As Integer = e.RowIndex

        Dim rowId As String = Me.grdFoundDocs.Rows.Item(e.RowIndex).Cells.Item(0).Value

        Call MsgBox(" Clicked in Row: " & rowId.ToString)
    End Sub

    Private Sub frmBesSrcMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Set the minimum height for the top panel
        Me.horizSplit.Panel1MinSize = TOPPANELHEIGHT

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

        Dim searchArguments As New Collection
        searchArguments = srch.ParsedSearchArgs(txtSearchCriteria.Text.ToString)

        Console.WriteLine("---- The user entered ----")
        Console.WriteLine(Me.txtSearchCriteria.Text.ToString)
        Console.WriteLine("     which breaks into: ")

        For Each argument As String In searchArguments
            Console.WriteLine("     -----> " & argument)
        Next

        Console.WriteLine(" ")

    End Sub
End Class