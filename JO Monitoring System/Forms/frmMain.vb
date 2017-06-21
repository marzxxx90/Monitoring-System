Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        tsJobOrder.Enabled = Not st
        tsEmployee.Enabled = Not st


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

    Private Sub tsJobOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsJobOrder.Click
        frmJobOrderList.Show()
    End Sub

    Private Sub stEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEmployee.Click
        frmEmployeList.Show()
    End Sub
End Class
