'Following required for SQL functions
'Imports Microsoft.SqlServer
'Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports System.Data.SqlTypes

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
                            Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                Console.WriteLine("DocumentId    : " & reader.Item("DocumentId").ToString())
                                Console.WriteLine("DateOnDoc     : " & reader.Item("DateOnDoc").ToString())
                                Console.WriteLine("DocumentLabel : " & reader.Item("DocumentLabel").ToString())
                                Console.WriteLine("Title         : " & reader.Item("Title").ToString())
                                Console.WriteLine()

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
                            Console.WriteLine(" -- Document List --")

                            Do While reader.Read

                                Console.WriteLine("DocumentId    : " & reader.Item("DocumentId").ToString())
                                Console.WriteLine()

                                xDocsEqualArg.Add(reader.Item("DocumentId"))
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

        Return xDocsEqualArg

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
