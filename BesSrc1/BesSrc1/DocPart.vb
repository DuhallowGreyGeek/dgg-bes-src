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
    Private mSynopsis_Derived As String
    '
    Public Sub New(DocumentId As Integer, PartNum As Integer)
        'Constructor - Accepts the identifier of the DocPart concerned.
        'Not finding something is a serious error.
        mDocumentId = DocumentId
        mPartNum = PartNum
        '
        'Fetch the contents of the part
        Call Me.FetchDocPart(DocumentId, PartNum)

        'Finally get the synopsis
        mSynopsis_Stored = Me.FetchSynopsis(DocumentId, PartNum)
        '
        mSynopsis_Derived = Me.DeriveSynopsis(DocumentId, PartNum)
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
            'All the work is done in DeriveSynopsis() and DeriveSynopsisCol()
            Return mSynopsis_Derived
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

    Private Function FetchSynopsis(documentId As Integer, PartNum As Integer) As String
        'Fetch the details of Stored Synopsis from the database
        'There should allways be one row because we are using the keys.
        mRoutineName = "FetchSynopsis()"      'To hold the name of the routine which generates an exception
        Dim synopsisText As String = "*** Error fetching the synopsis for: " & documentId.ToString & " : " & PartNum.ToString
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
                queryText = queryText & " syn.Synopsis "
                queryText = queryText & " FROM dbo.DocSynopsis as syn"
                queryText = queryText & " WHERE syn.DocumentId = @DocumentId "
                queryText = queryText & " AND syn.PartNum = @PartNum "

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@DocumentId", documentId)
                    sqlCommand.Parameters.AddWithValue("@PartNum", PartNum)

                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                synopsisText = reader.Item("Synopsis")

                            Loop
                        Else

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
        Return synopsisText
    End Function

    Public Function DeriveSynopsisCol(documentId As Integer, PartNum As Integer) As Collection
        'Derive the details of the Synopsis from the Usage and DocWord tables as a collection
        'Return a collection of the words used, in the order they are encountered in the Synopsis column.
        'There will be duplicates, because there will be in the original field.
        'Intended to be used by the DeriveSysnopsis() as String function.
        mRoutineName = "DeriveSynopsisCol()"      'To hold the name of the routine which generates an exception

        Dim colUsedWords As New Collection
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
                Dim queryText As String = "SELECT DISTINCT"
                queryText = queryText & " usg.WordSeqNum, wrd.WordText "
                queryText = queryText & " FROM dbo.DictWord AS wrd"
                queryText = queryText & " INNER JOIN dbo.Usage AS usg on wrd.WordId = usg.WordId "
                queryText = queryText & " WHERE usg.DocumentId = @DocumentId "
                queryText = queryText & " AND usg.PartNum = @PartNum "
                queryText = queryText & " ORDER BY usg.WordSeqNum "

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@DocumentId", documentId)
                    sqlCommand.Parameters.AddWithValue("@PartNum", PartNum)

                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                colUsedWords.Add(reader.Item("WordText"))

                            Loop
                        Else

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
        Return colUsedWords

    End Function

    Public Function DeriveSynopsis(documentId As Integer, PartNum As Integer) As String
        'Derive the details of the Synopsis from the Usage and DocWord tables as a collection
        'Return a string containing the words used, in the order they are encountered in the Synopsis column.
        'There will be duplicates, because there will be in the original field.
        'Most of the work is done by the DeriveSysnopsisCol() as Collection function.
        mRoutineName = "DeriveSynopsisCol()"      'To hold the name of the routine which generates an exception

        Dim derivedSynopsis As String = ""

        For Each wordtxt As String In Me.DeriveSynopsisCol(documentId, PartNum)
            derivedSynopsis = derivedSynopsis & " " & wordtxt
        Next

        Return derivedSynopsis

    End Function

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

        Throw New ApplicationException("SQL Exception - Look at the console:", ex)
    End Sub

    Private Sub handleGeneralException(ex As Exception)
        Console.WriteLine("*** Error *** in Module: " & MODNAME)
        Console.WriteLine("*** Exception *** in routine: " & mRoutineName)

        Console.WriteLine("Error: " & ex.Message.ToString & " is not a valid column" & vbNewLine)
        Console.WriteLine(ex.ToString & vbNewLine)

        Throw New ApplicationException("Non-SQL Exception - Look at the console:", ex)

    End Sub

End Class
