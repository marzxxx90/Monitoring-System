﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmabout
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
        Me.btnCLose = New System.Windows.Forms.Button()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCLose
        '
        Me.btnCLose.Location = New System.Drawing.Point(327, 236)
        Me.btnCLose.Name = "btnCLose"
        Me.btnCLose.Size = New System.Drawing.Size(45, 23)
        Me.btnCLose.TabIndex = 0
        Me.btnCLose.Text = "&Close"
        Me.btnCLose.UseVisualStyleBackColor = True
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.BackColor = System.Drawing.Color.White
        Me.LabelCompanyName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelCompanyName.Location = New System.Drawing.Point(14, 60)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(358, 15)
        Me.LabelCompanyName.TabIndex = 14
        Me.LabelCompanyName.Text = "CompanyName"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.BackColor = System.Drawing.Color.White
        Me.LabelCopyright.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelCopyright.Location = New System.Drawing.Point(14, 43)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(358, 15)
        Me.LabelCopyright.TabIndex = 13
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.BackColor = System.Drawing.Color.White
        Me.LabelVersion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelVersion.Location = New System.Drawing.Point(14, 26)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(358, 15)
        Me.LabelVersion.TabIndex = 12
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelProductName
        '
        Me.LabelProductName.BackColor = System.Drawing.Color.White
        Me.LabelProductName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelProductName.Location = New System.Drawing.Point(14, 9)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(358, 15)
        Me.LabelProductName.TabIndex = 11
        Me.LabelProductName.Text = "Product Name"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(12, 87)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.Size = New System.Drawing.Size(360, 143)
        Me.TextBoxDescription.TabIndex = 15
        '
        'frmabout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(384, 264)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.LabelCompanyName)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelProductName)
        Me.Controls.Add(Me.btnCLose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmabout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmabout"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCLose As System.Windows.Forms.Button
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
End Class
