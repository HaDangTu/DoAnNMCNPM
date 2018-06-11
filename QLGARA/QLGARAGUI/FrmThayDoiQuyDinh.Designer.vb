<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThayDoiQuyDinh
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
        Me.tbSoXeSC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btThayDoi = New System.Windows.Forms.Button()
        Me.btReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbSoXeSC
        '
        Me.tbSoXeSC.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSoXeSC.Location = New System.Drawing.Point(281, 66)
        Me.tbSoXeSC.Name = "tbSoXeSC"
        Me.tbSoXeSC.Size = New System.Drawing.Size(100, 25)
        Me.tbSoXeSC.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Số lượng xe tiếp nhận tối đa trong ngày"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(100, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(244, 36)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Thay đổi quy định"
        '
        'btThayDoi
        '
        Me.btThayDoi.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThayDoi.Location = New System.Drawing.Point(106, 170)
        Me.btThayDoi.Name = "btThayDoi"
        Me.btThayDoi.Size = New System.Drawing.Size(75, 23)
        Me.btThayDoi.TabIndex = 3
        Me.btThayDoi.Text = "Thay đổi "
        Me.btThayDoi.UseVisualStyleBackColor = True
        '
        'btReset
        '
        Me.btReset.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btReset.Location = New System.Drawing.Point(281, 170)
        Me.btReset.Name = "btReset"
        Me.btReset.Size = New System.Drawing.Size(75, 23)
        Me.btReset.TabIndex = 4
        Me.btReset.Text = "Reset"
        Me.btReset.UseVisualStyleBackColor = True
        '
        'FrmThayDoiQuyDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 235)
        Me.Controls.Add(Me.btReset)
        Me.Controls.Add(Me.btThayDoi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSoXeSC)
        Me.Name = "FrmThayDoiQuyDinh"
        Me.Text = "FrmThayDoiQuyDinh"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbSoXeSC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btThayDoi As Button
    Friend WithEvents btReset As Button
End Class
