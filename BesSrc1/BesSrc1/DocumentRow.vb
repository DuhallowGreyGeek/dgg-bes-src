Public Class DocumentRow
    'The row representing a document which is displayed on the main form datagrid.
    Private mDocId As Integer
    Private mLabel As String
    Private mDocDate As Date
    Private mTitle As String

    Public Property DocId As Integer
        Get
            Return mDocId
        End Get
        Set(value As Integer)
            mDocId = value
        End Set
    End Property
    Public Property Label As String
        Get
            Return mLabel
        End Get
        Set(value As String)
            mLabel = value
        End Set
    End Property
    Public Property DocDate As Date
        Get
            Return mDocDate
        End Get
        Set(value As Date)
            mDocDate = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return mTitle
        End Get
        Set(value As String)
            mTitle = value
        End Set
    End Property

End Class
