Public Class DocPart
    'Document presents the properties of the Part table.
    ' Remember: BesSrc is READ-ONLY. The object is created from the database.
    ' No updates are required.

    'Variables containing the "meat" of the Document
    Private mDocumentId As Integer          'Key. Supplied as parm. Make it available throughout object
    Private mPartNum As Integer             'Ditto
    '
    Private mDocDate As Date
    Private mDocFrom As String
    Private mDocTo As String
    Private mSubject As String
    Private mSynopsis_Stored As String
    'Private mSynopsis_Derived As String 
    '
    Public Sub New(DocumentId As Integer, PartNum As Integer)
        'Constructor - Accepts the identifier of the DocPart concerned.
        'Not finding something is a serious error.
        mDocumentId = DocumentId
        mPartNum = PartNum
        '
        mDocDate = Now
        mDocFrom = "Dummy From"
        mDocTo = "Dummy To"
        mSubject = "Dummy: This is what the document is really about."
        mSynopsis_Stored = "Dummy Synopsis. Typical synopsis would be much longer than a few words."
    End Sub

    ReadOnly Property PartNum As Integer
        Get
            Return mPartNum
        End Get
    End Property

    ReadOnly Property DocDate As Date
        Get
            Return mDocDate
        End Get
    End Property

    ReadOnly Property DocFrom As String
        Get
            Return mDocFrom
        End Get
    End Property

    ReadOnly Property DocTo As String
        Get
            Return mDocTo
        End Get
    End Property

    ReadOnly Property Subject As String
        Get
            Return mSubject
        End Get
    End Property

    ReadOnly Property Synopsis_Stored As String
        Get
            Return mSynopsis_Stored
        End Get
    End Property

    ReadOnly Property Synopsis_Derived As String
        Get
            '*** Careful now! That's a dummy of a dummy!
            Return mSynopsis_Stored
        End Get
    End Property

    Public Sub Dump()
        Console.WriteLine("--- Contents of the DocPart object ---- ")
        '
        Console.WriteLine("    ---- DocumentId ------> " & mDocumentId.ToString)
        Console.WriteLine("    ---- PartNum ---------> " & mPartNum.ToString)
        Console.WriteLine("    ---- DocDate ---------> " & Me.DocDate.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Console.WriteLine("    ---- DocFrom ---------> " & Me.DocFrom)
        Console.WriteLine("    ---- DocTo -----------> " & Me.DocTo)
        Console.WriteLine("    ---- Subject ---------> " & Me.Subject)
        Console.WriteLine("    ---- Synopsis_stored -> " & Me.Synopsis_Stored)
        Console.WriteLine("    --- Synopsis_derived -> " & Me.Synopsis_Derived)
        Console.WriteLine(" ")
    End Sub

End Class
