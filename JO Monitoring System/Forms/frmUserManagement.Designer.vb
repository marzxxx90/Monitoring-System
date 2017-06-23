<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManagement
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
        Me.lvUserlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.txtCpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMiddlename = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvUserlist
        '
        Me.lvUserlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvUserlist.FullRowSelect = True
        Me.lvUserlist.GridLines = True
        Me.lvUserlist.Location = New System.Drawing.Point(12, 12)
        Me.lvUserlist.Name = "lvUserlist"
        Me.lvUserlist.Size = New System.Drawing.Size(258, 271)
        Me.lvUserlist.TabIndex = 0
        Me.lvUserlist.UseCompatibleStateImageBehavior = False
        Me.lvUserlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 48
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fullname"
        Me.ColumnHeader2.Width = 206
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(103, 108)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(185, 21)
        Me.txtUsername.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 144)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(185, 21)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(103, 13)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(186, 21)
        Me.txtFirstname.TabIndex = 8
        '
        'txtCpassword
        '
        Me.txtCpassword.Location = New System.Drawing.Point(128, 177)
        Me.txtCpassword.Name = "txtCpassword"
        Me.txtCpassword.Size = New System.Drawing.Size(159, 21)
        Me.txtCpassword.TabIndex = 7
        Me.txtCpassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Firstname"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Confirm Password"
        '
        'txtMiddlename
        '
        Me.txtMiddlename.Location = New System.Drawing.Point(103, 43)
        Me.txtMiddlename.Name = "txtMiddlename"
        Me.txtMiddlename.Size = New System.Drawing.Size(186, 21)
        Me.txtMiddlename.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Middlename"
        '
        'txtLname
        '
        Me.txtLname.Location = New System.Drawing.Point(103, 74)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(186, 21)
        Me.txtLname.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Lastname"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(51, 220)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 27)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(166, 220)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLname)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtMiddlename)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCpassword)
        Me.GroupBox1.Controls.Add(Me.txtFirstname)
        Me.GroupBox1.Location = New System.Drawing.Point(294, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 264)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(602, 290)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvUserlist)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmUserManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvUserlist As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstname As System.Windows.Forms.TextBox
    Friend WithEvents txtCpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMiddlename As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
