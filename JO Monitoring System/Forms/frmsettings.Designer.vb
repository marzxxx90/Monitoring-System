<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsettings
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblrefnum = New System.Windows.Forms.Label()
        Me.txtRefNum = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(293, 63)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblrefnum
        '
        Me.lblrefnum.AutoSize = True
        Me.lblrefnum.Location = New System.Drawing.Point(12, 30)
        Me.lblrefnum.Name = "lblrefnum"
        Me.lblrefnum.Size = New System.Drawing.Size(85, 13)
        Me.lblrefnum.TabIndex = 1
        Me.lblrefnum.Text = "Reference Num."
        '
        'txtRefNum
        '
        Me.txtRefNum.Location = New System.Drawing.Point(102, 26)
        Me.txtRefNum.Name = "txtRefNum"
        Me.txtRefNum.Size = New System.Drawing.Size(266, 20)
        Me.txtRefNum.TabIndex = 2
        '
        'frmsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 102)
        Me.Controls.Add(Me.txtRefNum)
        Me.Controls.Add(Me.lblrefnum)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmsettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblrefnum As System.Windows.Forms.Label
    Friend WithEvents txtRefNum As System.Windows.Forms.TextBox
End Class
