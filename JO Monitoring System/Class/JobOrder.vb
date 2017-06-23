Public Class JobOrder

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

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Private _requestBy As New Employee
    Public Property RequestBy() As Employee
        Get
            Return _requestBy
        End Get
        Set(ByVal value As Employee)
            _requestBy = value
        End Set
    End Property

    Private _inCharge As New Employee
    Public Property InCharge() As Employee
        Get
            Return _inCharge
        End Get
        Set(ByVal value As Employee)
            _inCharge = value
        End Set
    End Property

    Private _dateStarted As Date
    Public Property DateStarted() As Date
        Get
            Return _dateStarted
        End Get
        Set(ByVal value As Date)
            _dateStarted = value
        End Set
    End Property

    Private _dateTarget As Date
    Public Property DateTarget() As Date
        Get
            Return _dateTarget
        End Get
        Set(ByVal value As Date)
            _dateTarget = value
        End Set
    End Property


    Private _refnum As String
    Public Property RefNum() As String
        Get
            Return _refnum
        End Get
        Set(ByVal value As String)
            _refnum = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _notifiyStatus As Integer
    Public Property NotifiyStatus() As Integer
        Get
            Return _notifiyStatus
        End Get
        Set(ByVal value As Integer)
            _notifiyStatus = value
        End Set
    End Property

    Private _commentCollect As Comment_Collect
    Public Property CommentCollect() As Comment_Collect
        Get
            Return _commentCollect
        End Get
        Set(ByVal value As Comment_Collect)
            _commentCollect = value
        End Set
    End Property


#End Region

#Region "Procedures"
    Friend Sub SaveJobOrder()
        Dim mysql As String = "Select * From tblJobOrder"
        Dim ds As DataSet = LoadSQL(mysql, "tblJobOrder")

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables("tblJobOrder").NewRow
        With dsNewRow
            .Item("Name") = _name
            .Item("Description") = _description
            If _remarks <> "" Then .Item("Remarks") = _remarks
            .Item("Assignee") = _inCharge.ID
            .Item("Requestor") = _requestBy.ID
            .Item("Date_Started") = _dateStarted
            .Item("Date_Target") = _dateTarget
            .Item("RefNo") = _refnum
            .Item("Status") = _status
            .Item("NotifyStatus") = _notifiyStatus
        End With
        ds.Tables("tblJobOrder").Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub LoadJobOrder()
        Dim mysql As String = "Select * From tblJobOrder Where Joid = " & _id
        Dim ds As DataSet = LoadSQL(mysql, "tblJobOrder")


        _commentCollect = New Comment_Collect
        For Each dr In ds.Tables(0).Rows
            LoadbyRows(dr)
            mysql = "Select * From tblComments Where Joid = " & _id
            ds = LoadSQL(mysql, "tblComments")
            For Each dr2 In ds.Tables(0).Rows
                Dim cm As New Comments
                cm.VAultCOmment(dr2.item("CID"))
                _commentCollect.Add(cm)
            Next
        Next
    End Sub

    Private Sub LoadbyRows(ByVal dr As DataRow)
        With dr
            _id = .Item("JOID")
            _name = .Item("NAME")
            _description = .Item("DESCRIPTION")
            If Not IsDBNull(.Item("REMARKS")) Then _remarks = .Item("REMARKS")

            _inCharge.ID = .Item("Assignee")
            _inCharge.LoadEmployee()

            _requestBy.ID = .Item("Requestor")
            _requestBy.LoadEmployee()

            _dateStarted = .Item("Date_Started")
            _dateTarget = .Item("Date_Target")
            _refnum = .Item("RefNo")
            _status = .Item("Status")
            _notifiyStatus = .Item("NotifyStatus")



        End With

    End Sub
#End Region

End Class
