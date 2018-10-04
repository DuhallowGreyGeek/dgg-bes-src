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
    Private mDocPartCollection As New Collection

    Public Sub New(DocumentId As Integer)
        'Constructor - Accepts the identifier of the Document concerned.
        'Not finding something is a serious error.
        mDocumentId = DocumentId
        '
        'Add some dummy values
        mDocumentLabel = "Dummy" & DocumentId.ToString
        mDateOnDoc = Date.Now
        mFileName = "DummyFileName.xyz"
        mPath = "C:/This/That/Something/"
        mTitle = "Dummy Title " & DocumentId.ToString & " " & DocumentId.ToString
        '
        'Now get the parts
        Call Me.FetchDocParts()


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

    Public ReadOnly Property Parts As Collection
        Get
            Return mDocPartCollection
        End Get
    End Property

    Private Sub FetchDocParts()
        'Get the Document Parts for this Document from the database
        '*** This is dummy code for testing during development

        Dim numParts As Integer = 3             'The number of dummy parts I'm going to generate (actually tested up to 999!)
        Dim partNum As Integer

        For partNum = 1 To numParts
            Dim thisPart As New DocPart(mDocumentId, partNum)
            mDocPartCollection.Add(thisPart)
        Next

    End Sub

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
        Console.WriteLine("  --- Now the Parts ---------------------")
        For Each DocPart As DocPart In mDocPartCollection
            Console.WriteLine("      -- PartNum ---> " & DocPart.PartNum.ToString)
            Console.WriteLine("      -- DocDate ---> " & DocPart.DocDate.ToString)
            Console.WriteLine("      -- DocFrom ---> " & DocPart.DocFrom)
            Console.WriteLine("      -- DocTo -----> " & DocPart.DocTo)
            Console.WriteLine("      -- Synopsis_Stored ---> " & DocPart.Synopsis_Stored)
            Console.WriteLine("      -- Synopsis_Derived --> " & DocPart.Synopsis_Derived)
            Console.WriteLine(" ")
        Next

    End Sub
End Class
