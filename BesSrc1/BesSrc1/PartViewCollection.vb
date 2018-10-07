'This is code copied from the internet, hence the slightly different style.
'Source : https://www.thoughtco.com/vbnet-what-happened-to-control-arrays-4079042 
'
Public Class PartViewCollection
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As System.Windows.Forms.Form
    Public Function AddNewPartView() _
    As uPartView
        ' Create a new instance of the PartView class.
        Dim aPartView As New uPartView
        ' Add the Label to the collection's
        ' internal list.
        Me.List.Add(aPartView)
        ' Add the PartView to the Controls collection   
        ' of the Form referenced by the HostForm field.
        HostForm.Controls.Add(aPartView)
        '
        Return aPartView
    End Function
    Public Sub New( _
    ByVal host As System.Windows.Forms.Form)
        HostForm = host
        '
    End Sub
    Default Public ReadOnly Property _
        Item(ByVal Index As Integer) As  _
        uPartView
        Get
            Return CType(Me.List.Item(Index), uPartView)
        End Get
    End Property
    Public Sub Remove()
        ' Check to be sure there is a PartView to remove.
        If Me.Count > 0 Then
            ' Remove the last PartView added to the array 
            ' from the host form controls collection. 
            ' Note the use of the default property in 
            ' accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
End Class

