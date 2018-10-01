'Following required for SQL functions
'Imports Microsoft.SqlServer
'Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports System.Data.SqlTypes
Imports System.Text.RegularExpressions

Public Class DocSearch
    'Object bringing together the function Bessie uses to search for documents.
    Const MODNAME As String = "DocSearch"
    Friend mRoutineName As String = ""      'To hold the name of the routine which generates an exception

    Public Sub New()

    End Sub

    
    Public Function ListDocumentRows() As Collection
        'Get the rows for the documents which match the list of keys
        mRoutineName = "ListDocumentRows()"

        Dim xlistDocumentRows As New Collection

        Dim result As Boolean = False 'Default to failed result

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
                queryText = queryText & " dr.DocumentId, "
                queryText = queryText & " dr.DateOnDoc, "
                queryText = queryText & " dr.DocumentLabel, "
                queryText = queryText & " dr.Title "
                queryText = queryText & " FROM dbo.DocumentRow as dr"
                queryText = queryText & " WHERE dr.DocumentId in (  "
                queryText = queryText & " SELECT fnd.DocumentId FROM dbo.FoundDocIds as fnd ) "

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)


                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                Dim documentRow As New DocumentRow
                                documentRow.DocId = reader.Item("DocumentId")
                                documentRow.DocDate = reader.Item("DateOnDoc")
                                documentRow.Label = reader.Item("DocumentLabel")
                                documentRow.Title = reader.Item("Title")

                                xlistDocumentRows.Add(documentRow)
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

        Return xlistDocumentRows

    End Function

    Public Function DocBatch_IsThereExisting(FileName As String) As Boolean
        'Return True if there is an existing row and False if there isn't
        'There is a unique index on DocBatch.Filename so there will only ever be zero or 1 rows
        mRoutineName = "DocBatch_IsThereExisting(FileName As String)"

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        'Construct the query string
        Dim queryString As String = "Select * From dbo.DocBatch as bat WHERE "
        queryString = queryString & "bat.FileName = @FileName "

        'Console.WriteLine(queryString)

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)
                sqlConnection.Open()
                Using sqlCommand As New SqlCommand(queryString, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@FileName", FileName)

                    Using reader = sqlCommand.ExecuteReader()
                        If reader.HasRows Then
                            Return True
                        Else
                            Return False
                        End If
                    End Using
                End Using
                sqlConnection.Close()
            End Using

            'Should never reach this point!
            Return True 'Which will stop anything bad happening!

        Catch ex As SqlException
            Call Me.handleSQLException(ex)
            Return True

        Catch ex As Exception
            Call Me.handleGeneralException(ex)
            Return True
        End Try

    End Function

    Public Function DocBatch_IDofRecord(FileName As String) As Integer
        'Return the integer DocBatchId matching the FileName
        'There is a unique index on DocBatch.Filename so there will only ever be zero or 1 rows
        mRoutineName = "DocBatch_IDofRecord(FileName As String)"
        Const ERRORKEY As Integer = -99999

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        'Construct the query string
        Dim queryString As String = "Select bat.DocBatchId From dbo.DocBatch as bat WHERE "
        queryString = queryString & "bat.FileName = @FileName "

        'Console.WriteLine(queryString)

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)
                sqlConnection.Open()
                Using sqlCommand As New SqlCommand(queryString, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@FileName", FileName)

                    Using reader = sqlCommand.ExecuteReader()
                        If reader.HasRows Then
                            Do While reader.Read

                                Return reader.Item("DocBatchId")

                            Loop
                        Else
                            Return ERRORKEY
                        End If
                    End Using
                End Using
                sqlConnection.Close()
            End Using

            'Should never reach this point!
            Return ERRORKEY 'Which will stop anything bad happening!

        Catch ex As SqlException
            Call Me.handleSQLException(ex)
            Return ERRORKEY

        Catch ex As Exception
            Call Me.handleGeneralException(ex)
            Return ERRORKEY
        End Try

    End Function


    Private Function Doc_IDofRecord(DocumentLabel As String) As Integer
        'Return the DocID of the Document we have just added. Used by Doc_Insert
        'Label (and FileName) is an external identifier. It will have a unique index.
        mRoutineName = "Doc_IDofRecord(DocumentLabel As String)"
        Const ERRORKEY As Integer = -99999

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        'Construct the query string
        Dim queryString As String = "Select doc.DocumentId From dbo.Document as doc WHERE "
        queryString = queryString & "doc.DocumentLabel = @DocumentLabel"

        'Console.WriteLine("----> " & queryString)

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)
                sqlConnection.Open()
                Using sqlCommand As New SqlCommand(queryString, sqlConnection)

                    'Substitute the parameter into the query command
                    sqlCommand.Parameters.AddWithValue("@DocumentLabel", DocumentLabel)

                    Using reader = sqlCommand.ExecuteReader()
                        If reader.HasRows Then
                            Do While reader.Read

                                Return reader.Item("DocumentId")

                            Loop
                        Else
                            Return ERRORKEY
                        End If
                    End Using
                End Using
                sqlConnection.Close()
            End Using

            'Should never reach this point!
            Return ERRORKEY 'Which will stop anything bad happening!

        Catch ex As SqlException
            Call Me.handleSQLException(ex)
            Return ERRORKEY

        Catch ex As Exception
            Call Me.handleGeneralException(ex)
            Return ERRORKEY
        End Try

    End Function

    Private Sub DocSynopsis_Insert(documentId As Integer, partNum As Integer, synopsis As String)
        'Insert the text into the DocSynopsis table
        mRoutineName = "DocSynopsis_Insert(...)"

        'Console.WriteLine("--Synopsis--- " & synopsis.Length.ToString & " ----> " & synopsis.ToString)

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB
        Dim sqlConnection As New System.Data.SqlClient.SqlConnection(conString.ConnectionString)

        'Build the query command structure
        Dim queryString As String = "INSERT INTO dbo.DocSynopsis ("
        queryString = queryString & "DocumentID, PartNum, Synopsis )"
        queryString = queryString & " VALUES( "
        queryString = queryString & " @DocumentID, @PartNum, @Synopsis "
        queryString = queryString & " )"

        'Console.WriteLine(queryString)

        Dim sqlCommand = New SqlCommand(queryString, sqlConnection)

        'Now substitute the values into the command
        sqlCommand.Parameters.AddWithValue("@DocumentID", documentId)
        sqlCommand.Parameters.AddWithValue("@PartNum", partNum)
        sqlCommand.Parameters.AddWithValue("@Synopsis", synopsis)

        'Console.WriteLine("--sqlCommand--> " & sqlCommand.CommandText)

        Try
            Dim numRows As Integer = 0

            sqlCommand.Connection.Open()
            Dim iRows As Integer = sqlCommand.ExecuteNonQuery()
            'MsgBox("Number Synopsis rows inserted = " & iRows.ToString)
            sqlCommand.Connection.Close()

        Catch ex As SqlException
            Call Me.handleSQLException(ex)

        End Try


    End Sub

    Public Function DocsEqualArg(argument As String) As BesIntSet
        'Get the DocumentIds of documents which contain the exact to the search argument
        'return the results as a "set" of integers
        mRoutineName = "DocsEqualArg(argument As String)"

        Dim xDocsEqualArg As New BesIntSet                  'Defined empty
        'practice safe computing
        argument = argument.Trim.ToLower

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)

                sqlConnection.Open()
                Dim queryText As String = "SELECT DISTINCT "
                queryText = queryText & " wu.DocumentId "
                queryText = queryText & " FROM dbo.WordUsage as wu"
                queryText = queryText & " WHERE wu.WordText = @argument"

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)

                    'Now substitute the values into the command
                    sqlCommand.Parameters.AddWithValue("@argument", argument)


                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                'Console.WriteLine("Equal DocumentId    : " & reader.Item("DocumentId").ToString())

                                xDocsEqualArg.Add(reader.Item("DocumentId"))
                            Loop
                            'Console.WriteLine(" ")
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

        Return xDocsEqualArg

    End Function

    Public Function DocsLikeArg(argument As String) As BesIntSet
        'Get the DocumentIds of documents which contain words which are a LIKE match to the search argument
        'return the results as a "set" of integers
        mRoutineName = "DocsLikeArg(argument As String)"

        Dim xDocsLikeArg As New BesIntSet                  'Defined empty
        'practice safe computing
        argument = argument.Trim.ToLower

        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB

        Try
            Using sqlConnection As New SqlConnection(conString.ConnectionString)

                sqlConnection.Open()
                Dim queryText As String = "SELECT DISTINCT "
                queryText = queryText & " wu.DocumentId "
                queryText = queryText & " FROM dbo.WordUsage as wu"
                queryText = queryText & " WHERE wu.WordText LIKE @argument"

                Using sqlCommand As New SqlCommand(queryText, sqlConnection)

                    'Now substitute the values into the command
                    sqlCommand.Parameters.AddWithValue("@argument", argument)


                    Using reader = sqlCommand.ExecuteReader()

                        If reader.HasRows Then
                            'Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                'Console.WriteLine("Like DocumentId    : " & reader.Item("DocumentId").ToString())

                                xDocsLikeArg.Add(reader.Item("DocumentId"))
                            Loop
                            'Console.WriteLine(" ")
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

        Return xDocsLikeArg

    End Function

    Public Function ParsedSearchArgs(enteredString As String) As Collection
        'Break whatever the user has entered into individual "words" which are returned as a collection
        'The words are stripped of leading and trailing spaces and folded to lower case but are not otherwise interpretted. 
        'return the results as a collection of strings
        mRoutineName = "ParsedSearchArgs(enterdString As String)"

        'The parser is simple but probably inefficient. It uses Microsoft written code, so it is probably as good
        'as it is possible to get.

        Dim argumentList As New Collection

        'Define the characters which will be used to split the string into words

        'Line ends will always cause a word-split. I'm not even sure if a user can enter these in a text-box
        Const LINEEND As String = vbCr & vbCrLf
        '
        Dim splitChars As String = " " & LINEEND  'Really only spaces


        'Do the actual split
        Dim words = enteredString.Split(splitChars.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        'Let the user enter pretty much anything. Even let them repeat themselves

        For Each candidateWord In words
        
            Dim trimChars As String = " " 'Characters to remove from the beginning and end of the candidate

            candidateWord = candidateWord.Trim(trimChars.ToCharArray)

            If candidateWord.Length > 0 Then    'Skip any candidates which have become empty
                argumentList.Add(candidateWord.ToLower)
            End If
        Next
        Return argumentList

    End Function

    Public Function MatchingDocs(argumentList As Collection) As BesIntSet
        'For each argument find the matching documents. Add the DocumentId of the document to the MatchingDocs set. 
        mRoutineName = "MatchingDocs(argumentList As Collection)"

        Const LIKEMARKERS As String = "%_[]"                'Presence of these characters indicates a "LIKE" parm
        Dim xMatchingDocs As New BesIntSet                  'Set of the matching DocumentIds

        'The set starts out empty. The first set of results has to be added into it.
        Dim iRowCounter As Integer = 0                      'Intialise a iRowCounter
        For Each argument As String In argumentList
            iRowCounter = iRowCounter + 1

            If argument.IndexOfAny(LIKEMARKERS) <> -1 Then        'The argument is for the "LIKE" case. -1 is the "not found"
                If iRowCounter = 1 Then
                    Dim curSetMatchingDocs As New BesIntSet
                    curSetMatchingDocs = srch.DocsLikeArg(argument)

                    xMatchingDocs = xMatchingDocs.Union(curSetMatchingDocs)
                Else
                    xMatchingDocs = xMatchingDocs.Intersection(srch.DocsLikeArg(argument))
                End If

            Else                                            'The argument is for the "equals" case
                If iRowCounter = 1 Then
                    Dim curSetMatchingDocs As New BesIntSet
                    curSetMatchingDocs = srch.DocsEqualArg(argument)

                    xMatchingDocs = xMatchingDocs.Union(curSetMatchingDocs)
                Else
                    xMatchingDocs = xMatchingDocs.Intersection(srch.DocsEqualArg(argument))
                End If

            End If
        Next

        Return xMatchingDocs
    End Function

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
        Console.Writeline("*** Exception *** in routine: " & mRoutineName)

        Console.WriteLine("Error: " & ex.Message.ToString & " is not a valid column" & vbNewLine)
        Console.WriteLine(ex.ToString & vbNewLine)

        MsgBox("Non-SQL exception - Look at the console", MsgBoxStyle.Critical, "Bessie SQL")

    End Sub

End Class
