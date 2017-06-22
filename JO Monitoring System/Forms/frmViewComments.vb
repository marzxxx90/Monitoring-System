Public Class frmViewComments
    Dim mysql As String
    Dim ds As DataSet

    Private Sub frmViewComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadcomments()
    End Sub

    Private Sub loadcomments()
        If txtSearch.Text = "" Then
            mysql = "Select * from tblcomments ORDER BY DATE_CREATED DESC LIMIT 30"
            ds = LoadSQL(mysql, "tblcomments")
        Else
            mysql = "Select * from tblcomments WHERE JOID = '" & txtSearch.Text & "'"
            ds = LoadSQL(mysql, "tblcomments")
        End If

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        LvComment.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                Dim lv As ListViewItem = LvComment.Items.Add(.Item("JOID"))
                lv.SubItems.Add(.Item("Comments"))
            End With
        Next

        Console.WriteLine("Comments loaded.")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadcomments()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub LvComment_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvComment.DoubleClick
        If LvComment.SelectedItems.Count = 0 Then Exit Sub

        Me.Enabled=false
        frmcomment1.txtComments.Text = LvComment.SelectedItems(0).SubItems(1).Text
        frmcomment1.Show()
    End Sub
End Class