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
    Friend Sub CreateADMIN(Optional ByVal pssword As String = "misdept", Optional ByVal username As String = "Admin")
        mysql = "SELECT * FROM " & tblLogin & " WHERE USERPASS = '" & EncryptString(pssword) & "'"
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        Dim Fname = "MIS", Lname = "DEPARTMENT", ROLE = "Admin"

        If ds.Tables(0).Rows.Count >= 1 Then
            Exit Sub
        Else

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(tblLogin).NewRow

            With dsNewRow
                .Item("USERNAME") = username
                .Item("USERPASS") = EncryptString(pssword)
                .Item("FNAME") = Fname
                .Item("LNAME") = Lname
                .Item("ROLE") = ROLE
                .Item("STATUS") = 1
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds) : Console.WriteLine("Admin Updated.")
        End If

    End Sub

    Friend Sub saveuser(Optional ByVal id As Integer = 0)
        mysql = "SELECT * FROM " & tblLogin & " WHERE USERID = " & id
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        If ds.Tables(0).Rows.Count = 1 Then
          
            With ds.Tables(tblLogin).Rows(0)
                .Item("USERNAME") = _USERNAME
                .Item("USERPASS") = EncryptString(_USERPASS)
                .Item("FNAME") = _FIRSTNAME
                .Item("MNAME") = _MIDDLENAME
                .Item("LNAME") = _LASTNAME
                .Item("ROLE") = _ROLE
                .Item("STATUS") = 1
            End With
          
            database.SaveEntry(ds, False) : Console.WriteLine("User account udated.")

        Else

            Dim dsNewrow As DataRow
            dsNewrow = ds.Tables(0).NewRow
            With dsNewrow
                .Item("USERNAME") = _USERNAME
                .Item("USERPASS") = EncryptString(_USERPASS)
                .Item("FNAME") = _FIRSTNAME
                .Item("MNAME") = _MIDDLENAME
                .Item("LNAME") = _LASTNAME
                .Item("ROLE") = _ROLE
                .Item("STATUS") = 1
            End With

            ds.Tables(tblLogin).Rows.Add(dsNewrow)
            database.SaveEntry(ds) : Console.WriteLine("User account saved.")


        End If
    End Sub


    Friend Function UserLogin(ByVal Uname As String, ByVal Upass As String) As Boolean
        mysql = "SELECT * FROM " & tblLogin & " WHERE upper(USERNAME) = upper('" & Uname & "')" & _
                " AND USERPASS ='" & EncryptString(Upass) & "'"

        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        If ds.Tables(0).Rows.Count = 0 Then Return False

        LOADBYID(ds.Tables(0).Rows(0).Item(0))
        Return True
    End Function

    Friend Sub LOADBYID(ByVal UID As Integer)
        mysql = "SELECT * FROM " & tblLogin & " WHERE USERID = " & UID
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        Loadbyrow(ds.Tables(0).Rows(0))
    End Sub

    Private Sub Loadbyrow(ByVal dr As DataRow)

        With dr
            _ID = .Item("USERID")
            _USERNAME = .Item("USERNAME")
            _USERPASS = .Item("USERPASS")
            _FIRSTNAME = .Item("FNAME")
            _MIDDLENAME = IIf(IsDBNull(.Item("MNAME")), "", .Item("MNAME"))
            _LASTNAME = .Item("LNAME")
            _ROLE = .Item("ROLE")
            _STATUS = .Item("STATUS")
        End With

        Console.WriteLine("USERID :" & _ID)
    End Sub


    Friend Function IsUsernameExists(ByVal username As String) As Boolean
        mysql = "SELECT * FROM " & tblLogin & " WHERE upper(USERNAME) = upper('" & username & "')"
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        If ds.Tables(tblLogin).Rows.Count >= 1 Then Return False

        Return True
    End Function


    Friend Function IsUserpassExists(ByVal userpass As String) As Boolean
        mysql = "SELECT * FROM " & tblLogin & " WHERE USERPASS = '" & EncryptString(userpass) & "'"
        Dim ds As DataSet = LoadSQL(mysql, tblLogin)

        Console.WriteLine("Hash " & EncryptString(userpass))
        If ds.Tables(tblLogin).Rows.Count >= 1 Then Return False

        Return True
    End Function

#End Region
End Class
