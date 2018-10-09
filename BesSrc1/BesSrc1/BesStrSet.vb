Public Class BesStrSet
    'BesStrSet has the following properties:
    ' - A collection or set of strings.
    ' - Only one instance of each value allowed - no duplicates. Adding a duplicate does nothing. No error.
    ' - achieved by overriding the function Add()
    'Special function provided is:
    ' - Intersection(BesStrSet) - returns a BesStrSet containing the intersection elements 
    ' - Union(BesStrSet) - returns a BesStrSet containing the union of this set and the parameter
    'BesStrSet inherits from the simple "List" class
    'Intended us is to hold the keys of Documents which are found by the search

    Inherits List(Of String)

    Overloads Sub Add(str As String)
        ' If this is new, add it to the collection, otherwise skip it.
        If MyBase.Contains(str) Then
            'Already there skip this one
        Else
            MyBase.Add(str)
        End If

    End Sub

    Public Sub Dump()

        Console.WriteLine("--- Contents of the BesStrSet object ---- ")
        Console.WriteLine("     Number of elements: " & MyBase.Count.ToString)

        Dim j As Integer
        For j = 0 To MyBase.Count - 1       'Zero based index
            Console.WriteLine("  Item: " & j.ToString & " Value: " & MyBase.Item(j).ToString)
        Next

    End Sub

    Public Function Union(outsideSet As BesStrSet)
        'Returns the set union of this set (the "inside set") with the set provided as a parameter (the "outside set") 
        Dim result As New BesStrSet

        'Add the "Inside set" into the result
        Dim i As Integer
        For i = 0 To MyBase.Count - 1
            Call result.Add(MyBase.Item(i))
        Next

        'Add the OutsideSet into the result
        Dim j As Integer
        For j = 0 To outsideSet.Count - 1
            Call result.Add(outsideSet.Item(j))
        Next

        Return result
    End Function

    Public Function Intersection(outsideset As BesStrSet)
        Dim result As New BesStrSet

        'Assuming that it is more efficient for my code to do the minimum number of loops

        If MyBase.Count > outsideset.Count Then     'Outside is smaller, so loop around that
            Dim i As Integer
            For i = 0 To outsideset.Count - 1
                If MyBase.Contains(outsideset.Item(i)) Then
                    result.Add(outsideset.Item(i))
                End If
            Next
        Else                                        'Inside is smaller (or =) so loop around that
            Dim i As Integer
            For i = 0 To MyBase.Count - 1
                If outsideset.Contains(MyBase.Item(i)) Then
                    result.Add(MyBase.Item(i))
                End If
            Next
        End If

        Return result
    End Function


End Class
