<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportStatus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.rbStartedDate = New System.Windows.Forms.RadioButton()
        Me.rbTargetDate = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Pending", "Served", "Cancel"})
        Me.cboType.Location = New System.Drawing.Point(243, 21)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(138, 21)
        Me.cboType.TabIndex = 5
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(243, 123)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(92, 40)
        Me.btnGenerate.TabIndex = 4
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(4, 1)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 3
        '
        'rbStartedDate
        '
        Me.rbStartedDate.AutoSize = True
        Me.rbStartedDate.Checked = True
        Me.rbStartedDate.Location = New System.Drawing.Point(243, 66)
        Me.rbStartedDate.Name = "rbStartedDate"
        Me.rbStartedDate.Size = New System.Drawing.Size(100, 17)
        Me.rbStartedDate.TabIndex = 6
        Me.rbStartedDate.TabStop = True
        Me.rbStartedDate.Text = "By Started Date"
        Me.rbStartedDate.UseVisualStyleBackColor = True
        '
        'rbTargetDate
        '
        Me.rbTargetDate.AutoSize = True
        Me.rbTargetDate.Location = New System.Drawing.Point(243, 89)
        Me.rbTargetDate.Name = "rbTargetDate"
        Me.rbTargetDate.Size = New System.Drawing.Size(97, 17)
        Me.rbTargetDate.TabIndex = 7
        Me.rbTargetDate.Text = "By Target Date"
        Me.rbTargetDate.UseVisualStyleBackColor = True
        '
        'frmReportStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 175)
        Me.Controls.Add(Me.rbTargetDate)
        Me.Controls.Add(Me.rbStartedDate)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.Name = "frmReportStatus"
        Me.Text = "Jor Order Status Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents rbStartedDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbTargetDate As System.Windows.Forms.RadioButton
End Class
