Imports System.Data.SqlClient

Public Class Document
    'Document presents the properties of the Document table.
    ' Remember: BesSrc is READ-ONLY. The object is created from the database.
    ' No updates are required.
    'Object bringing together the function Bessie uses to search for documents.
    Const MODNAME As String = "Document"
    Friend mRoutineName As String = ""      'To hold the name of the routine which generates an exception

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
        mRoutineName = "New"        'For when I get round to handling exceptions
        '
        mDocumentId = DocumentId
        '
        'Read the document header values from the database
        Call FetchDocDBData(DocumentId)
        '
        'Now get the parts
        Call Me.FetchDocParts(DocumentId)

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

    Private Sub FetchDocParts(DocumentId As Integer)
        'Get the Document Parts for this Document from the database
        'Should always be at least one row, usually about 3.
        mRoutineName = "FetchDocParts()"      'To hold the name of the routine which generates an exception



        'Dim numParts As Integer = 3             'The number of dummy parts I'm going to generate (actually tested up to 999!)
        'Dim partNum As Integer

        'For partNum = 1 To numParts
        'Dim thisPart As New DocPart(mDocumentId, partNum)
        'mDocPartCollection.Add(thisPart)
        'Next

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

    Private Sub FetchDocDBData(DocumentId As Integer)
        'Fetch the details of the document from the database
        'Should always be one row
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
                queryText = queryText & " doc.DateOnDoc, "
                queryText = queryText & " doc.DocumentLabel, "
                queryText = queryText & " doc.Title, "
                queryText = queryText & " doc.FileName, "
                queryText = queryText & " doc.Path "
                queryText = queryText & " FROM dbo.Document as doc"
                queryText = queryText & " WHERE doc.DocumentId = @DocumentId "

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@DocumentId", DocumentId)

                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                mDocumentLabel = reader.Item("DocumentLabel")
                                mDateOnDoc = reader.Item("DateOnDoc")
                                mTitle = reader.Item("Title")
                                mFileName = reader.Item("FileName")
                                mPath = reader.Item("Path")
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
