Public Class Comments
    Dim mysql As String = String.Empty
    Dim tbl As String = "tblcomments"

#Region "Properties"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

#End Region

#Region "Procedures"
    Friend Sub SaveComments()
        Dim mysql As String = "Select * From " & tbl
        Dim ds As DataSet = LoadSQL(mysql, tbl)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(tbl).NewRow
        With dsNewRow
            .Item("JOID") = _JOID
            .Item("Comments") = _Comments
            .Item("Date_Created") = CDate(Now.ToShortDateString).ToString("yyyy/MM/dd")
            .Item("Status") = 1
        End With
        ds.Tables(tbl).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

#End Region
End Class
