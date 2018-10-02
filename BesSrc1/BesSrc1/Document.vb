Public Class Document
    'Document presents the properties of the Document table.
    ' Remember: BesSrc is READ-ONLY. The object is created from the database.
    ' No updates are required.

    'Variables containing the "meat" of the Document
    Private mDocumentId As Integer          'Key. Supplied as parm. Make it available throughout object
    '
    Private mDocumentLabel As String
    Private mDateOnDoc As Date
    Private mFileName As String
    Private mPath As String
    Private mTitle As String

    Public Sub New(DocumentId As Integer)
        'Constructor - Accepts the identifier of the Document concerned.
        'Not finding something is a serious error.
        mDocumentId = DocumentId
        '
        'Add some dummy values
        mDocumentLabel = "Dummy"
        mDateOnDoc = Date.Now
        mFileName = "DummyFileName.xyz"
        mPath = "C:/This/That/Something/"
        mTitle = "Dummy Title"

    End Sub

    Public ReadOnly Property DocumentLabel As String
        Get
            Return mDocumentLabel
        End Get
    End Property

    Public ReadOnly Property DateOnDoc As Date
        Get
            Return mDateOnDoc
        End Get
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return mFileName
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return mPath
        End Get
    End Property

    Public ReadOnly Property Title As String
        Get
            Return mTitle
        End Get
    End Property

    Public Sub Dump()
        Console.WriteLine("--- Contents of the Document object ---- ")
        '
        Console.WriteLine("    ---- DocumentId ------> " & mDocumentId.ToString)
        Console.WriteLine("    ---- DocumentLabel ---> " & Me.DocumentLabel)
        Console.WriteLine("    ---- DateOnDoc -------> " & Me.DateOnDoc.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Console.WriteLine("    ---- FileName --------> " & Me.FileName)
        Console.WriteLine("    ---- Path ------------> " & Me.Path)
        Console.WriteLine("    ---- Title -----------> " & Me.Title)
        Console.WriteLine(" ")
    End Sub
End Class
