Public Class frmJobOrder
    Private RefNum As String = GetOption("REFNO")
    Private Requestor As New Employee
    Private Incharge As New Employee
    Private JobOrder As JobOrder

    Private Sub frmJobOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtRefNum.Text = String.Format("{1}#{0:000000}", RefNum, "JO")
        txtName.Clear()
        txtDescription.Clear()
        txtRemarks.Clear()
        txtRequestBy.Clear()
        txtInCharge.Clear()
        dtpFrom.Value = Now
        dtpTo.Value = Now
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub
        JobOrder = New JobOrder
        With JobOrder
            .Name = txtName.Text
            .Description = txtDescription.Text
            .Remarks = txtRemarks.Text
            .InCharge = Incharge
            .RequestBy = Requestor
            .DateStarted = dtpFrom.Value
            .DateTarget = dtpTo.Value
            .RefNum = txtRefNum.Text
            .Status = "P"
            .NotifiyStatus = 0
            .SaveJobOrder()
        End With

        RefNum += 1
        UpdateOptions("REFNO", RefNum)

        MsgBox("Job Order " & JobOrder.Name & " Successfully Saved!", MsgBoxStyle.Information, "Job Order")
        If MsgBox("Do you want to add new Job Order?", MsgBoxStyle.YesNo, "Job Order") = MsgBoxResult.Yes Then
            ClearFields()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnRequestBy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestBy.Click
        Dim secured_str As String = txtRequestBy.Text
        secured_str = DreadKnight(secured_str)
        frmEmployeList.SearchSelect(secured_str, FormName.Requestor)
        frmEmployeList.Show()
    End Sub

    Private Sub btnIncharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncharge.Click
        Dim secured_str As String = txtInCharge.Text
        secured_str = DreadKnight(secured_str)
        frmEmployeList.SearchSelect(secured_str, FormName.EmployeeIncharge)
        frmEmployeList.Show()
    End Sub

    Friend Sub LoadRequestor(ByVal Emp As Employee)
        txtRequestBy.Text = String.Format("{0} {1}" & IIf(Emp.Suffix <> "", "," & Emp.Suffix, ""), Emp.FirstName & IIf(Emp.MiddleName = "", "", Emp.MiddleName), Emp.LastName)
        Requestor = Emp
    End Sub

    Friend Sub LoadInCharger(ByVal Emp As Employee)
        txtInCharge.Text = String.Format("{0} {1}" & IIf(Emp.Suffix <> "", "," & Emp.Suffix, ""), Emp.FirstName & IIf(Emp.MiddleName = "", "", Emp.MiddleName), Emp.LastName)
        Incharge = Emp
    End Sub

    Private Sub txtRequestBy_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRequestBy.KeyPress
        If isEnter(e) Then
            btnRequestBy.PerformClick()
        End If
    End Sub

    Private Sub txtInCharge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInCharge.KeyPress
        If isEnter(e) Then
            btnIncharge.PerformClick()
        End If
    End Sub

    Private Function isValid() As Boolean
        If Requestor Is Nothing Then MsgBox("No Requestor Selected", MsgBoxStyle.Critical, "Error") : Return False
        If Incharge Is Nothing Then MsgBox("No In-Charge Selected", MsgBoxStyle.Critical, "Error") : Return False
        If txtName.Text = "" Then MsgBox("Please Fill Job Order Name", MsgBoxStyle.Critical, "Error") : Return False
        If txtDescription.Text = "" Then MsgBox("Please Add Description", MsgBoxStyle.Critical, "Error") : Return False
        If dtpFrom.Value > dtpTo.Value Then MsgBox("Invalid Target Date", MsgBoxStyle.Information, "Error") : Return False
        Return True
    End Function
End Class