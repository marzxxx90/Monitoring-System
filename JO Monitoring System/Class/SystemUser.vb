Public Class SystemUser

    Dim mysql As String = String.Empty
    Dim tblLogin As String = "tbllogin"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _USERNAME As String
    Public Property USERNAME() As String
        Get
            Return _USERNAME
        End Get
        Set(ByVal value As String)
            _USERNAME = value
        End Set
    End Property

    Private _USERPASS As String
    Public Property USERPASS() As String
        Get
            Return _USERPASS
        End Get
        Set(ByVal value As String)
            _USERPASS = value
        End Set
    End Property

    Private _FIRSTNAME As String
    Public Property FIRSTNAME() As String
        Get
            Return _FIRSTNAME
        End Get
        Set(ByVal value As String)
            _FIRSTNAME = value
        End Set
    End Property


    Private _MIDDLENAME As String
    Public Property MIDDLENAME() As String
        Get
            Return _MIDDLENAME
        End Get
        Set(ByVal value As String)
            _MIDDLENAME = value
        End Set
    End Property


    Private _LASTNAME As String
    Public Property LASTNAME() As String
        Get
            Return _LASTNAME
        End Get
        Set(ByVal value As String)
            _LASTNAME = value
        End Set
    End Property

    Private _ROLE As String
    Public Property ROLE() As String
        Get
            Return _ROLE
        End Get
        Set(ByVal value As String)
            _ROLE = value
        End Set
    End Property

    Private _STATUS As Integer
    Public Property STATUS() As Integer
        Get
            Return _STATUS
        End Get
        Set(ByVal value As Integer)
            _STATUS = value
        End Set
    End Property

#Region "FUNCTIONS AND PROCEDURES"
    Friend Sub CreateADMIN(Optional ByVal pssword As String = "MISDEPT", Optional ByVal username As String = "Admin")
        mysql = "SELECT * FROM " & tblLogin
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        Dim Fname = "MIS", Lname = "DEPARTMENT", ROLE = "Admin"

        Dim dsNewrow As DataRow
        dsNewrow = ds.Tables(0).NewRow

        With dsNewrow
            .Item("USERNAME") = username
            .Item("USERPASS") = EncryptString(pssword)
            .Item("FNAME") = Fname
            .Item("LNAME") = Lname
            .Item("ROLE") = ROLE
            .Item("STATUS") = 1
        End With
        ds.Tables(0).Rows.Add(dsNewrow)
        database.SaveEntry(ds)
        Console.WriteLine("Admin created.")
    End Sub

#End Region
End Class
