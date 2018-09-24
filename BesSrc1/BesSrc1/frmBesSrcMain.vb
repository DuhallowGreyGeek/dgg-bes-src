Public Class frmBesSrcMain

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        'Test code
        'This works well toggling the colDocId column
        'If Me.colDocId.Visible = True Then
        'Me.colDocId.Visible = False
        'Else
        'Me.colDocId.Visible = True
        'End If
        Dim rowid As Integer = Me.grdFoundDocs.Rows.Add()
        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(0).Value = "Junk " & rowid.ToString
        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(1).Value = "Garbage"
        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(2).Value = "1900-12-31"
        Me.grdFoundDocs.Rows.Item(rowid).Cells.Item(3).Value = "This is pretending to be the title"

        Console.WriteLine(" --- RowId = ---> " & rowid.ToString)

    End Sub

    Private Sub grdFoundDocs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFoundDocs.CellContentClick
        Dim column As Integer = e.ColumnIndex
        Dim row As Integer = e.RowIndex

        Dim rowId As String = Me.grdFoundDocs.Rows.Item(e.RowIndex).Cells.Item(0).Value

        Call MsgBox(" Clicked in Row: " & rowId.ToString)
    End Sub
End Class