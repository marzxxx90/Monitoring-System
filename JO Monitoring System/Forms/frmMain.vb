Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        JobOrderToolStripMenuItem.Enabled = Not st
        JOToolStrip.Enabled = Not st


        If st Then
            tsUser.Text = "No User yet"
        Else
            tsUser.Text = "Greetings " & FullName
        End If

    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        frmLogin.Show()
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
End Class
