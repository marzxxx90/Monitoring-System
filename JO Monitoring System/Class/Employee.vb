Public Class Employee

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

    Private _fname As String
    Public Property FirstName() As String
        Get
            Return _fname
        End Get
        Set(ByVal value As String)
            _fname = value
        End Set
    End Property

    Private _mname As String
    Public Property MiddleName() As String
        Get
            Return _mname
        End Get
        Set(ByVal value As String)
            _mname = value
        End Set
    End Property

    Private _lname As String
    Public Property LastName() As String
        Get
            Return _lname
        End Get
        Set(ByVal value As String)
            _lname = value
        End Set
    End Property

    Private _suffix As String
    Public Property Suffix() As String
        Get
            Return _suffix
        End Get
        Set(ByVal value As String)
            _suffix = value
        End Set
    End Property

    Private _jobDescription As String
    Public Property JobDescription() As String
        Get
            Return _jobDescription
        End Get
        Set(ByVal value As String)
            _jobDescription = value
        End Set
    End Property

    Private _department As String
    Public Property Department() As String
        Get
            Return _department
        End Get
        Set(ByVal value As String)
            _department = value
        End Set
    End Property

    Private _gender As Integer
    Public Property Gender() As Integer
        Get
            Return _gender
        End Get
        Set(ByVal value As Integer)
            _gender = value
        End Set
    End Property


#End Region

#Region "Procedures"
    Friend Sub SaveEmployee()
        Dim mysql As String = "Select * From tblEmployee"
        Dim ds As DataSet = LoadSQL(mysql, "tblEmployee")
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables("tblEmployee").NewRow
        With dsNewRow
            .Item("FNAME") = _fname
            If _mname <> "" Then .Item("MNAME") = _mname
            .Item("LNAME") = _lname
            If _suffix <> "" Then .Item("SUFFIX") = _suffix
            If _jobDescription <> "" Then .Item("JOB_DESCRIPTION") = _jobDescription
            .Item("DEPARTMENT") = _department
            .Item("GENDER") = _gender
        End With
        ds.Tables("tblEmployee").Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub LoadEmployee()
        Dim mysql As String = "Select * From tblEmployee Where Emp_ID = " & _id
        Dim ds As DataSet = LoadSQL(mysql, "tblEmployee")

        For Each dr In ds.Tables(0).Rows
            LoadbyRows(dr)
        Next
    End Sub

    'Private Sub LoadEmployeeByID(ByVal tmpID As Integer)
    '    Dim mysql As String = "Select * From tblEmployee Where Emp_ID = " & tmpID
    '    Dim ds As DataSet = LoadSQL(mysql, "tblEmployee")

    '    For Each dr In ds.Tables(0).Rows
    '        LoadbyRows(dr)
    '    Next
    'End Sub

    Private Sub LoadbyRows(ByVal dr As DataRow)
        With dr
            _id = .Item("EMP_ID")
            _fname = .Item("FNAME")
            If Not IsDBNull(.Item("MNAME")) Then _mname = .Item("MNAME")
            _lname = .Item("LNAME")
            If Not IsDBNull(.Item("SUFFIX")) Then _suffix = .Item("SUFFIX")
            If Not IsDBNull(.Item("JOB_DESCRIPTION")) Then _jobDescription = .Item("JOB_DESCRIPTION")
            _department = .Item("DEPARTMENT")
            _gender = .Item("GENDER")

        End With
    End Sub

    Friend Sub LoadLastEntry()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM TBLEMPLOYEE ORDER BY EMP_ID DESC LIMIT 1"
        ds = LoadSQL(mySql)

        Dim idx As Integer = ds.Tables(0).Rows(0).Item("Emp_ID")
        _id = idx

        LoadEmployee()
    End Sub
#End Region
End Class
