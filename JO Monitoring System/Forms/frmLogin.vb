Public Class frmLogin
    Dim users As SystemUser

    Dim i As Integer = 0.0R

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtuserpass.Text = "" Or txtuserpass.Text = "" Then Exit Sub

        Dim uName As String = DreadKnight(txtusername.Text)
        Dim pName As String = txtuserpass.Text

        users = New SystemUser

        If Not users.UserLogin(uName, pName) Then
            'Username not register
                If i >= 3 Then
                    MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                    Clearfield()
                    End
                End If
            MsgBox("Invalid Username or Password!", MsgBoxStyle.Exclamation, "Invalid") : Clearfield() : Exit Sub
        End If


        SysUser = users
        UType = SysUser.ROLE
        UserID = users.ID
        FullName = users.FIRSTNAME & " " & users.LASTNAME

        MsgBox(String.Format("Welcome {0}, you login as {1} ", users.USERNAME, _
                                users.ROLE & "", MsgBoxStyle.Information, "Login"))

        frmMain.Show()
        frmMain.NotYetLogin(False)

        Me.Close()
    End Sub

    Private Sub Clearfield()
        txtusername.Text = ""
        txtuserpass.Text = ""
    End Sub


    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        SysUser.CreateADMIN()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
End Class