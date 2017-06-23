Public Class frmViewComments
    Dim mysql As String
    Dim ds As DataSet

    Friend Sub AddItem(ByVal cm As Comments)
        With cm
            Dim lv As ListViewItem = LvComment.Items.Add(.JOID)
            lv.SubItems.Add(.Comments)
        End With
    End Sub

    Private Sub loadcomments()
        mysql = "Select * from tblcomments WHERE JOID = '" & txtSearch.Text & "' ORDER BY CID DESC"
        ds = LoadSQL(mysql, "tblcomments")
   
        If ds.Tables(0).Rows.Count = 0 Then LvComment.Items.Clear() : Exit Sub

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

    Private Sub frmViewComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class