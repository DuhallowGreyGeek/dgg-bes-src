Public Class uPartView
    Private Const LABCOL As Integer = 0         'The column ids of the columns in the Properties datagrid
    Private Const VALCOL As Integer = 1

    Private Const NUMROWS As Integer = 5        'Fix the number of rows!!
    Private iPartNumId As Integer               'The row ids of the properties for the fixed purpose implementation
    Private iDocSubjectId As Integer
    Private iDocDateId As Integer
    Private iDocFromId As Integer
    Private iDocToId As Integer

    Private Sub uPartView_Load(sender As Object, e As EventArgs) Handles Me.Load
        
    End Sub

    Private Sub uPartView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'The underlying table layout
        Me.tblPartTableLayout.Width = Me.Width
        Me.tblPartTableLayout.Width = Me.Width
        '
        'The columns of the properties grid
        Me.colValue.Width = Me.Width - Me.colProperty.Width
    End Sub

    Public Property PartNum As String
        Get
            Return Me.grdPartProps.Rows.Item(iPartNumId).Cells.Item(VALCOL).Value
        End Get
        Set(value As String)
            Me.grdPartProps.Rows.Item(iPartNumId).Cells.Item(VALCOL).Value = value
        End Set
    End Property

    Public Property DocSubject As String
        Get
            Return Me.grdPartProps.Rows.Item(iDocSubjectId).Cells.Item(VALCOL).Value
        End Get
        Set(value As String)
            Me.grdPartProps.Rows.Item(iDocSubjectId).Cells.Item(VALCOL).Value = value
        End Set
    End Property

    Public Property DocDate As String
        Get
            Return Me.grdPartProps.Rows.Item(iDocDateId).Cells.Item(VALCOL).Value
        End Get
        Set(value As String)
            Me.grdPartProps.Rows.Item(iDocDateId).Cells.Item(VALCOL).Value = value
        End Set
    End Property

    Public Property DocFrom As String
        Get
            Return Me.grdPartProps.Rows.Item(iDocFromId).Cells.Item(VALCOL).Value
        End Get
        Set(value As String)
            Me.grdPartProps.Rows.Item(iDocFromId).Cells.Item(VALCOL).Value = value
        End Set
    End Property

    Public Property DocTo As String
        Get
            Return Me.grdPartProps.Rows.Item(iDocToId).Cells.Item(VALCOL).Value
        End Get
        Set(value As String)
            Me.grdPartProps.Rows.Item(iDocToId).Cells.Item(VALCOL).Value = value
        End Set
    End Property

    Public Property Synopsis_Stored As String
        Get
            Return Me.rtxtStored.Text
        End Get
        Set(value As String)
            Me.rtxtStored.Text = value
        End Set
    End Property

    Public Property Synopsis_Derived As String
        Get
            Return Me.rtxtDerived.Text
        End Get
        Set(value As String)
            Me.rtxtDerived.Text = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Set the initial width of the Label column
        Const LABCOLWIDTH As Integer = 150
        Me.colProperty.Width = LABCOLWIDTH

        'For this implementation make the rows fixed purpose and then expose the values cells
        'Add the rows to the data grid. Populate Property names. Property Values from setters.
        '
        'Dim iPartNumId As Integer = Me.grdPartProps.Rows.Add()
        iPartNumId = Me.grdPartProps.Rows.Add
        Me.grdPartProps.Rows.Item(iPartNumId).Cells.Item(LABCOL).Value = "Part Number:"
        'Me.grdPartProps.Rows.Item(iPartNumId).Cells.Item(VALCOL).Value = value
        '
        'Dim iDocSubjectId As Integer = Me.grdPartProps.Rows.Add()
        iDocSubjectId = Me.grdPartProps.Rows.Add
        Me.grdPartProps.Rows.Item(iDocSubjectId).Cells.Item(LABCOL).Value = "Subject:"
        'Me.grdPartProps.Rows.Item(iDocSubjectId).Cells.Item(VALCOL).Value = value
        '
        'Dim iDocDateId As Integer = Me.grdPartProps.Rows.Add()
        iDocDateId = Me.grdPartProps.Rows.Add
        Me.grdPartProps.Rows.Item(iDocDateId).Cells.Item(LABCOL).Value = "Document Date:"
        'Me.grdPartProps.Rows.Item(iDocDateId).Cells.Item(VALCOL).Value = value
        '
        'Dim iDocFromId As Integer = Me.grdPartProps.Rows.Add()
        iDocFromId = Me.grdPartProps.Rows.Add
        Me.grdPartProps.Rows.Item(iDocFromId).Cells.Item(LABCOL).Value = "Document From:"
        'Me.grdPartProps.Rows.Item(iDocFromId).Cells.Item(VALCOL).Value = value
        '
        'Dim iDocToId As Integer = Me.grdPartProps.Rows.Add()
        iDocToId = Me.grdPartProps.Rows.Add
        Me.grdPartProps.Rows.Item(iDocToId).Cells.Item(LABCOL).Value = "Document To:"
        'Me.grdPartProps.Rows.Item(iDocToId).Cells.Item(VALCOL).Value = value

        If Me.grdPartProps.Rows.Count <> NUMROWS Then
            Call MsgBox("Error in the setup of the PartView Object!")
        End If

    End Sub

    Public Sub HighlightWords()
        'Highlight all the words which match the search criteria
        Call Me.HighlightEqWords()
        Call Me.HighlightLikeWords()
        '
    End Sub

    Private Sub HighlightEqWords()
        'Highlight all the words which match the equals criteria
        For Each word As String In srch.EqualsArguments
            Dim intIndexToText As Integer = 0

            While intIndexToText >= 0
                intIndexToText = intIndexToText + 1

                intIndexToText = rtxtStored.Find(word, intIndexToText, 9999, RichTextBoxFinds.WholeWord)
                rtxtStored.SelectionFont = New Font("Verdana", 12, FontStyle.Bold)
                rtxtStored.SelectionColor = Color.Red

            End While
        Next
    End Sub

    Private Sub HighlightLikeWords()
        'Highlight all the words which match the LIKE criteria
        For Each word As String In srch.WordsLikeArguments
            Dim intIndexToText As Integer = 0

            While intIndexToText >= 0
                intIndexToText = intIndexToText + 1

                intIndexToText = rtxtStored.Find(word, intIndexToText, 9999, RichTextBoxFinds.WholeWord)
                rtxtStored.SelectionFont = New Font("Verdana", 12, FontStyle.Bold)
                rtxtStored.SelectionColor = Color.Red

            End While
        Next
    End Sub
End Class
