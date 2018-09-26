Public Class frmBesSrcMain

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        'Test code
        'This works well toggling the colDocId column
        'If Me.colDocId.Visible = True Then
        'Me.colDocId.Visible = False
        'Else
        'Me.colDocId.Visible = True
        'End If
        
        Me.grdFoundDocs.Rows.Clear()
        If srch.ListDocumentRows.Count > 0 Then
            MsgBox("there are document rows")
            For Each DocumentRow As DocumentRow In srch.ListDocumentRows
                Dim rowid As Integer = Me.grdFoundDocs.Rows.Add()
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(0).Value = DocumentRow.DocId
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(1).Value = DocumentRow.Label
                Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(2).Value = DocumentRow.DocDate.ToString
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
        Console.WriteLine(" --- Window Handle -----> " & Me.Handle.ToString)
    End Sub
End Class