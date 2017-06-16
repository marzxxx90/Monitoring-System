Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain
    Private SampleString As String = "Data Source=MISLAMION-PC\SQLEXPRESS;Initial Catalog=C@TCHM3;Integrated Security=True"

    Private SampleCon As SqlConnection
    Private SampleCommand As SqlCommand
    Private da As SqlDataAdapter

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Search_Record()
    End Sub

    Private Sub Search_Record()
        'Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"
        Dim sql As String = "Select * From tblMaintenance"
        Dim connection As New SqlConnection(SampleString)
        Dim datadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        connection.Open()
        datadapter.Fill(ds, "tblMaintenance")
        connection.Close()

        dgSample.DataSource = ds
        dgSample.DataMember = "tblMaintenance"

    End Sub

    Private Sub dbOpen()
        SampleCon = New SqlConnection(SampleString)
        Try
            SampleCon.Open()
            SampleCon.Close()
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try
    End Sub

    Public Sub dbClose()
        SampleCon.Close()
    End Sub
End Class
