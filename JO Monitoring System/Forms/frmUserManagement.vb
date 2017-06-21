Public Class frmUserManagement
    Dim mysql As String = String.Empty
    Dim sUser As SystemUser
    Dim role As String = "User"

    Dim tmpass As String = ""

    Private Sub load_listUser()
        mysql = "SELECT * FROM TBLLOGIN WHERE ROLE <> 'Admin' AND STATUS ='1' ORDER BY USERID ASC"
        Dim ds As DataSet = LoadSQL(mysql, "TBLLOGIN")

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        lvUserlist.Items.Clear()
        For Each dr As DataRow In ds.Tables("TBLLOGIN").Rows()
            With dr
                Dim lv As ListViewItem = lvUserlist.Items.Add(.Item("USERID"))
                lv.SubItems.Add(.Item("FNAME") & " " & .Item("LNAME"))
            End With
        Next

        Console.WriteLine("User successfully loaded.")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "&Add" Then
            If Not IsValid() Then Exit Sub
            save_()
        ElseIf btnAdd.Text = "&Edit" Then
            btnAdd.Text = "&Update"
            disabled(True) : Exit Sub
        Else
            If Not IsValid() Then Exit Sub
            update_()
        End If

    End Sub

    Private Sub save_()
        Dim msg As DialogResult = MsgBox("Do you want to add this user?", MsgBoxStyle.YesNo, "Add")
        If msg = vbNo Then Exit Sub

        sUser = New SystemUser

        With sUser
            .USERNAME = txtUsername.Text
            .USERPASS = txtPassword.Text
            .FIRSTNAME = txtFirstname.Text
            .MIDDLENAME = txtMiddlename.Text
            .LASTNAME = txtLname.Text
            .ROLE = role

            .saveuser()
        End With

        load_listUser()
        clear()
        MsgBox("User successfully added.", MsgBoxStyle.Information, "Add")
    End Sub

    Private Sub update_()
        Dim msg As DialogResult = MsgBox("Do you want to update this user?", MsgBoxStyle.YesNo, "Update")
        If msg = vbNo Then Exit Sub

        sUser = New SystemUser

        With sUser
            .USERNAME = txtUsername.Text
            .USERPASS = IIf(txtPassword.Text = "", tmpass, txtPassword.Text)
            .FIRSTNAME = txtFirstname.Text
            .MIDDLENAME = txtMiddlename.Text
            .LASTNAME = txtLname.Text
            .ROLE = role

            .saveuser(lvUserlist.FocusedItem.Text)
        End With

        load_listUser()
        clear()
        MsgBox("User updated.", MsgBoxStyle.Information, "Update")
    End Sub

    Private Function IsValid(Optional ByVal st As Boolean = False) As Boolean
        If txtFirstname.Text = "" Then txtFirstname.Focus() : Return st
        If txtLname.Text = "" Then txtLname.Focus() : Return st
        If txtUsername.Text = "" Then txtUsername.Focus() : Return st

        If btnAdd.Text = "&Add" Then
            If txtPassword.Text = "" Then txtPassword.Focus() : Return st
            If txtCpassword.Text = "" Then txtCpassword.Focus() : Return st
        End If
       
        If txtPassword.Text <> "" Then
            If txtPassword.Text.Length < 5 Then MsgBox("Password must not less than 5 characters", MsgBoxStyle.Critical, "Error") : Return st
            If txtPassword.Text <> txtCpassword.Text Then MsgBox("Password Not Matched!", MsgBoxStyle.Exclamation, "Error") : Return st
        End If

        sUser = New SystemUser
        If sUser.UserLogin(txtUsername.Text, txtPassword.Text) Then _
            MsgBox("Username or password already exists.", MsgBoxStyle.Critical, "Error") : Return st

        If btnAdd.Text = "&Add" Then
            If Not sUser.IsUsernameExists(txtUsername.Text) Then MsgBox("Username already exists.", MsgBoxStyle.Critical, "Error") : Return st
            If Not sUser.IsUserpassExists(txtPassword.Text) Then MsgBox("Password already exists.", MsgBoxStyle.Critical, "Error") : Return st
        End If

        Return True
    End Function


    Private Sub clear()
        txtFirstname.Text = ""
        txtMiddlename.Text = ""
        txtLname.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtCpassword.Text = ""
    End Sub

    Private Sub disabled(Optional ByVal st As Boolean = False)
        txtFirstname.Enabled = st
        txtMiddlename.Enabled = st
        txtLname.Enabled = st
        txtUsername.Enabled = st
        txtPassword.Enabled = st
        txtCpassword.Enabled = st
    End Sub
    Private Sub lvUserlist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvUserlist.DoubleClick
        If lvUserlist.SelectedItems.Count = 0 Then Exit Sub

        sUser = New SystemUser

        sUser.LOADBYID(lvUserlist.FocusedItem.Text)

        With sUser
            txtFirstname.Text = .FIRSTNAME
            txtMiddlename.Text = .MIDDLENAME
            txtLname.Text = .LASTNAME
            txtUsername.Text = .USERNAME
            tmpass = DecryptString(.USERPASS)
        End With

        disabled()
        btnAdd.Text = "&Edit"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim msg As DialogResult = MsgBox("Do you want to cancel?", MsgBoxStyle.YesNo, "Question")
        If msg = vbNo Then Exit Sub

        load_listUser()
        clear()
    End Sub

    Private Sub frmUserManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_listUser()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    End Sub
End Class