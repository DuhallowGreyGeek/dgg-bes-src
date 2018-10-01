'Following required for SQL functions
Imports System.Data.SqlClient

Public Class FoundDocs
    'FoundDocs manages a cache of the DocumentIds for the documents which match the search criteria.
    ' - The Ids are actually in an SQL table FoundDocIds.
    ' - *** At present this is a permanent table with no key. A heap. 
    ' - *** This is undesirable but allowed for the prototype.
    ' - *** It would allow cross-talk between users on a multi-user system!
    'Possible solutions:
    ' - *** Add a "SessionId" column and use this to distingish between users. 
    ' - *** Use a "Temporary Table" (in TempDB) which naturally belongs to the session (connection). Preferred solution.
    Const MODNAME As String = "FoundDocs"
    Friend mRoutineName As String = ""      'To hold the name of the routine which generates an exception

    Dim mFoundDocIds As New Collection

    Public Sub New()
        'This is where the setup of the session-id or the temporary table will go.
    End Sub

    Public Sub Clear()
        'Clear the contents of the local cache and the sql table
        mFoundDocIds.Clear()

        mRoutineName = "Clear()"

        'Clear the SQL table
        Dim conString As New System.Data.SqlClient.SqlConnectionStringBuilder

        'Get Connection string data
        conString.DataSource = params.SQLDataSource
        conString.IntegratedSecurity = params.SQLIntegratedSecurity
        conString.InitialCatalog = params.SQLInitCatalogDB
        Dim sqlConnection As New System.Data.SqlClient.SqlConnection(conString.ConnectionString)

        'Build the query command structure
        Dim queryString As String = "DELETE FROM dbo.FoundDocIds"
        'If I use the SessionId approach, then there will be a WHERE clause with a SessionId

        'Console.WriteLine(queryString)

        Dim sqlCommand = New SqlCommand(queryString, sqlConnection)

        'Now substitute the values into the command
        'sqlCommand.Parameters.AddWithValue("@SessionId", sessionId)

        'Console.WriteLine("--sqlCommand--> " & sqlCommand.CommandText)

        Try
            Dim numRows As Integer = 0

            sqlCommand.Connection.Open()
            Dim iRows As Integer = sqlCommand.ExecuteNonQuery()
            'MsgBox("Number Synopsis rows deleted = " & iRows.ToString)
            sqlCommand.Connection.Close()

        Catch ex As SqlException
            Call Me.handleSQLException(ex)

        End Try

    End Sub

    Public Sub Dump()
        'Dump the contents of the class to the console
        Console.WriteLine("---- FoundDoc --- contains: " & mFoundDocIds.Count.ToString & " DocumentIds")

        For Each documentId As Integer In mFoundDocIds
            Console.WriteLine("    ----> " & documentId.ToString)
        Next
        Console.WriteLine(" ")
    End Sub

    ReadOnly Property FoundDocIds As Collection
        Get
            Return mFoundDocIds
        End Get
    End Property

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
