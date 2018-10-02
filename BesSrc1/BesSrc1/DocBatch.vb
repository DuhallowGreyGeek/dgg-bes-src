Public Class DocBatch
    'Document presents the properties of the DocBatch table.
    ' Remember: BesSrc is READ-ONLY. The object is created from the database.
    ' No updates are required.

    'Variables containing the "meat" of the DocBatch
    Private mDocBatchId As Integer
    '
    Private mFileName As String
    Private mBatchDateCreated As Date
    Private mDateLoaded As Date
    Private mDescription As String

    Public Sub New(DocBatchId As Integer)
        'Constructor - Accepts the identifier of the DocBatch concerned.
        'Not finding something is a serious error.
        mDocBatchId = DocBatchId
        '
        'Add some dummy values
        mFileName = "DummyDocBatch.xml"
        mBatchDateCreated = Now
        mDateLoaded = Now
        mDescription = "Dummy description of this batch of documents."
    End Sub

    ReadOnly Property FileName As String
        Get
            Return mFileName
        End Get
    End Property

    ReadOnly Property DateCreated As Date
        Get
            Return mBatchDateCreated
        End Get
    End Property

    ReadOnly Property DateLoaded As Date
        Get
            Return mDateLoaded
        End Get
    End Property

    ReadOnly Property Description As String
        Get
            Return mDescription
        End Get
    End Property

    Public Sub Dump()
        Console.WriteLine("--- Contents of the DocBatch object ---- ")
        '
        Console.WriteLine("    ---- DocBatchId ------> " & mDocBatchId.ToString)
        Console.WriteLine("    ---- DateCreated -----> " & Me.DateCreated.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Console.WriteLine("    ---- DateLoaded ------> " & Me.DateLoaded.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Console.WriteLine("    ---- Description -----> " & Me.Description)
        Console.WriteLine(" ")
    End Sub
End Class
