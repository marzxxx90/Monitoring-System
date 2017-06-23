Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain
    Friend dateSet As Boolean = False

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)

        tsJobOrder.Enabled = Not st
        tsEmployee.Enabled = Not st
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
            tsCurrentDate.Text = "Date not set" : dateSet = False
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
            tmpTimer.Start()
        End If

        dateSet = False
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.MaximumSize = New Size(850, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub tsJobOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsJobOrder.Click
        frmJobOrderList.Show()
    End Sub

    Private Sub stEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmEmployeList.Show()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        If SysUser.ROLE = "Admin" Then
            frmUserManagement.Show() : Exit Sub
        End If
        MsgBox("You don't have persmision in this module!", MsgBoxStyle.Critical, "Error")

    End Sub


    Private Sub DailyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyToolStripMenuItem.Click
        frmReportStatus.FormType = frmReportStatus.Type.Daily
        frmReportStatus.Show()
    End Sub

    Private Sub MonthlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyToolStripMenuItem.Click
        frmReportStatus.FormType = frmReportStatus.Type.Monthly
        frmReportStatus.Show()

    End Sub
    Private Sub tsEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEmployee.Click
        frmEmploye.Show()
    End Sub

    Private Sub tmpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmpTimer.Tick
        If dateSet Then
            tsCurrentDate.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        Else
            tsCurrentDate.Text = "Date not set"
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmabout.Show()

    End Sub
End Class
