Module formSwitch
    
    Friend Enum FormName As Integer
        EmployeeIncharge = 0
        Requestor = 1
    End Enum

    Friend Sub ReloadFormFromEmployee(ByVal gotoForm As FormName, ByVal Emp As Employee)
        Select Case gotoForm
            Case FormName.EmployeeIncharge
                frmJobOrder.LoadInCharger(Emp)
            Case FormName.Requestor
                frmJobOrder.LoadRequestor(Emp)
        End Select
    End Sub
End Module