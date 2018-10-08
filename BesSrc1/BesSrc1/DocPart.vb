Imports System.Data.SqlClient

Public Class DocPart
    'Document presents the properties of the Part table.
    ' Remember: BesSrc is READ-ONLY. The object is created from the database.
    ' No updates are required.
    Const MODNAME As String = "DocPart"
    Friend mRoutineName As String = ""      'To hold the name of the routine which generates an exception

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
        'Fetch the contents of the part
        Call Me.FetchDocPart(DocumentId, PartNum)

        'mDocDate = Now
        'mDocFrom = "Dummy From"
        'mDocTo = "Dummy To"
        'mSubject = "Dummy: " & DocumentId.ToString & " " & PartNum.ToString & "This is what the document is really about."
        'mSynopsis_Stored = "Dummy Synopsis. Typical synopsis would be much longer than a few words."
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

    Private Sub FetchDocPart(documentId As Integer, partNum As Integer)
        'Fetch the details of one Document Part from the database
        'There should allways be one row because we are using the keys.
        mRoutineName = "FetchDocPart(documentId As Integer, partNum As Integer)"      'To hold the name of the routine which generates an exception
        '
        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)
                'The DocumentIds we want to display are in the FoundDocIds table
                sqlConnection.Open()
                Dim queryText As String = "SELECT "
                queryText = queryText & " prt.DocDate, "
                queryText = queryText & " prt.DocFrom, "
                queryText = queryText & " prt.DocTo, "
                queryText = queryText & " prt.DocSubject "
                queryText = queryText & " FROM dbo.Part as prt"
                queryText = queryText & " WHERE prt.DocumentId = @DocumentId "
                queryText = queryText & " AND prt.PartNum = @PartNum "

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@DocumentId", documentId)
                    sqlCommand.Parameters.AddWithValue("@PartNum", partNum)

                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                mDocDate = reader.Item("DocDate")
                                mDocFrom = reader.Item("DocFrom")
                                mDocTo = reader.Item("DocTo")
                                mSubject = reader.Item("DocSubject")
                                '
                            Loop
                        End If
                    End Using
                End Using
                sqlConnection.Close()
            End Using

        Catch ex As SqlException
            Call Me.handleSQLException(ex)

        Catch ex As Exception
            Call Me.handleGeneralException(ex)

        End Try


    End Sub

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

    Private Sub handleSQLException(ex As SqlException)
        Console.WriteLine("*** Error *** in Module: " & MODNAME)
        Console.WriteLine("*** Exception *** in routine: " & mRoutineName)

        Dim i As Integer = 0
        For i = 0 To ex.Errors.Count - 1
            Console.WriteLine("Index#: " & i.ToString & vbNewLine & "Error: " & ex.Errors(i).ToString & vbNewLine)
        Next
        MsgBox("SQL Exception trapped - Look at the console", MsgBoxStyle.Critical, "Bessie SQL")
    End Sub

    Private Sub handleGeneralException(ex As Exception)
        Console.WriteLine("*** Error *** in Module: " & MODNAME)
        Console.WriteLine("*** Exception *** in routine: " & mRoutineName)

        Console.WriteLine("Error: " & ex.Message.ToString & " is not a valid column" & vbNewLine)
        Console.WriteLine(ex.ToString & vbNewLine)

        MsgBox("Non-SQL exception - Look at the console", MsgBoxStyle.Critical, "Bessie SQL")

    End Sub

End Class
