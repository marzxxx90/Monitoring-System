Public Class Comments
    Dim mysql As String = String.Empty
    Dim tbl As String = "tblcomments"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _JOID As Integer
    Public Property JOID() As Integer
        Get
            Return _JOID
        End Get
        Set(ByVal value As Integer)
            _JOID = value
        End Set
    End Property

    Private _Comments As String
    Public Property Comments() As String
        Get
            Return _Comments
        End Get
        Set(ByVal value As String)
            _Comments = value
        End Set
    End Property

    Private _DateCreated As Date
    Public Property DateCreated() As Date
        Get
            Return _DateCreated
        End Get
        Set(ByVal value As Date)
            _DateCreated = value
        End Set
    End Property


    Private _Status As Integer
    Public Property Status() As Integer
        Get
            Return _Status
        End Get
        Set(ByVal value As Integer)
            _Status = value
        End Set
    End Property


#Region "Functions and Procedure"

    Friend Sub loadbyID(ByVal id As Integer)
        mysql = "SELECT * FROM " & tbl & " WHERE Joid = " & id
        mysql &= " And Status = 1 Order By Status Desc"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        loadbyRow(ds.Tables(0).Rows(0))
    End Sub

    Friend Sub VAultCOmment(ByVal id As Integer)
        mysql = "SELECT * FROM " & tbl & " WHERE Joid = " & id
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        loadbyRow(ds.Tables(0).Rows(0))

    End Sub

    Private Sub loadbyRow(ByVal dr As DataRow)
        With dr
            _ID = .Item("CID")
            _JOID = .Item("JOID")
            _Comments = .Item("Comments")
            _DateCreated = .Item("Date_Created")
            _status = .Item("Status")
        End With
    End Sub
#End Region
End Class
