Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Search_Record()
    End Sub

    Private Sub Search_Record()

        Dim mysql As String = "Select * From tblMaintenance"
        Dim ds As DataSet = LoadSQL(mysql, "tblMaintenance")

        For Each dr In ds.Tables(0).Rows
            Console.WriteLine(dr.item("M_Name"))
            With dr
                ' dgSample.Rows.Add(.item("M_ID"), .item("M_name"), .item("M_Value"), IIf(IsDBNull(.item("Remarks")), "", .item("Remarks")))
            End With
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String = "SELECT * FROM sample"
        Dim ds As DataSet = LoadSQL(str, "sample")
        For Each dr In ds.Tables(0).Rows
            Console.WriteLine("ID " & dr.item(0) & " Value " & dr.item(1))
        Next

    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mysql As String = "Select * From tbl_JobOrder"
        Dim ds As DataSet = LoadSQL(mysql, "tbl_JobOrder")

        For Each dr In ds.Tables(0).Rows
            MsgBox(dr.item(1), MsgBoxStyle.Information, dr.item(0))
        Next
    End Sub
End Class
