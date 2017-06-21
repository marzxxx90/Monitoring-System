Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        JOToolStrip.Enabled = Not st
        UserManagementToolStripMenuItem.Enabled = Not st

        If Not st Then
            LoginToolStripMenuItem.Text = "&Log Out"
        Else
            LoginToolStripMenuItem.Text = "&Login"
        End If

        If st Then
            tsUser.Text = "No User yet"
        Else
            tsUser.Text = "Greetings " & FullName
        End If

    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        If LoginToolStripMenuItem.Text = "&Login" Then
            frmLogin.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            SysUser = Nothing
            Dim formNames As New List(Of String)
            For Each Form In My.Application.OpenForms
                If Form.Name <> "frmMain" Or Not Form.name <> "frmLogin" Then
                    formNames.Add(Form.Name)
                End If
            Next
            For Each currentFormName As String In formNames
                Application.OpenForms(currentFormName).Close()
            Next
            MsgBox("Thank you!", MsgBoxStyle.Information)
            NotYetLogin()
            frmLogin.Show()
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If SysUser.USERNAME = "" Then
            Console.WriteLine("Not Yet Login")
            NotYetLogin()
        Else
            Console.WriteLine(FullName & " welcome!")
            NotYetLogin(False)
        End If

    End Sub

    Private Sub JOToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOToolStrip.Click
        frmJobOrderList.Show()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        If SysUser.ROLE = "Admin" Then
            frmUserManagement.Show() : Exit Sub
        End If
        MsgBox("You don't have persmision in this module!", MsgBoxStyle.Critical, "Error")
    End Sub
End Class
