<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJOMonitoring
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"EllieGwapo", "Junmar", "For Party party", "Sam Apple", "Hoo Jun Maa", "Tratar De Cogerme", "05/16/2016", "05/16/2018", "RefNum# 101470"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJOMonitoring))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.chkPending = New System.Windows.Forms.CheckBox()
        Me.chkServed = New System.Windows.Forms.CheckBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lvJobOrder = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnComments = New System.Windows.Forms.Button()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(530, 17)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 41)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "&Find"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Find string"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCancel)
        Me.GroupBox2.Controls.Add(Me.chkPending)
        Me.GroupBox2.Controls.Add(Me.chkServed)
        Me.GroupBox2.Controls.Add(Me.txtFilter)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(891, 70)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.BackColor = System.Drawing.Color.Red
        Me.chkCancel.Location = New System.Drawing.Point(803, 26)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(73, 21)
        Me.chkCancel.TabIndex = 4
        Me.chkCancel.Text = "Cancel"
        Me.chkCancel.UseVisualStyleBackColor = False
        '
        'chkPending
        '
        Me.chkPending.AutoSize = True
        Me.chkPending.Checked = True
        Me.chkPending.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPending.Location = New System.Drawing.Point(623, 26)
        Me.chkPending.Name = "chkPending"
        Me.chkPending.Size = New System.Drawing.Size(80, 21)
        Me.chkPending.TabIndex = 2
        Me.chkPending.Text = "Pending"
        Me.chkPending.UseVisualStyleBackColor = True
        '
        'chkServed
        '
        Me.chkServed.AutoSize = True
        Me.chkServed.BackColor = System.Drawing.Color.Lime
        Me.chkServed.Location = New System.Drawing.Point(713, 27)
        Me.chkServed.Name = "chkServed"
        Me.chkServed.Size = New System.Drawing.Size(73, 21)
        Me.chkServed.TabIndex = 3
        Me.chkServed.Text = "Served"
        Me.chkServed.UseVisualStyleBackColor = False
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(93, 25)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(431, 25)
        Me.txtFilter.TabIndex = 0
        '
        'lvJobOrder
        '
        Me.lvJobOrder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvJobOrder.FullRowSelect = True
        Me.lvJobOrder.GridLines = True
        Me.lvJobOrder.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvJobOrder.Location = New System.Drawing.Point(24, 91)
        Me.lvJobOrder.Name = "lvJobOrder"
        Me.lvJobOrder.Size = New System.Drawing.Size(891, 268)
        Me.lvJobOrder.TabIndex = 1
        Me.lvJobOrder.UseCompatibleStateImageBehavior = False
        Me.lvJobOrder.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 108
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 154
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Remarks"
        Me.ColumnHeader3.Width = 59
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Requestor"
        Me.ColumnHeader4.Width = 112
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "In Charge"
        Me.ColumnHeader5.Width = 106
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Date"
        Me.ColumnHeader6.Width = 69
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Target Date"
        Me.ColumnHeader7.Width = 53
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Ref #"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Status"
        Me.ColumnHeader9.Width = 114
        '
        'btnComments
        '
        Me.btnComments.Location = New System.Drawing.Point(810, 364)
        Me.btnComments.Name = "btnComments"
        Me.btnComments.Size = New System.Drawing.Size(105, 41)
        Me.btnComments.TabIndex = 6
        Me.btnComments.Text = "&Comment"
        Me.btnComments.UseVisualStyleBackColor = True
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "#"
        Me.ColumnHeader10.Width = 0
        '
        'frmJOMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 410)
        Me.Controls.Add(Me.btnComments)
        Me.Controls.Add(Me.lvJobOrder)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(220, 120)
        Me.Name = "frmJOMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "JO Monitoring"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents chkPending As System.Windows.Forms.CheckBox
    Friend WithEvents chkServed As System.Windows.Forms.CheckBox
    Friend WithEvents lvJobOrder As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnComments As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader

End Class
