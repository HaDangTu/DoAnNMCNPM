<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNhapPhatSinh
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMaPhieuNhapPS = New System.Windows.Forms.TextBox()
        Me.dtpNgayNhap = New System.Windows.Forms.DateTimePicker()
        Me.tbTongTienPS = New System.Windows.Forms.TextBox()
        Me.dgvTTNhapPS = New System.Windows.Forms.DataGridView()
        Me.btNhap = New System.Windows.Forms.Button()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTTNhapPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbTongTienPS)
        Me.Panel1.Controls.Add(Me.dtpNgayNhap)
        Me.Panel1.Controls.Add(Me.tbMaPhieuNhapPS)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(13, 49)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(764, 91)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(278, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Phiếu nhập phát sinh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã phiếu nhập phát sinh"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(360, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Ngày nhập phát sinh"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(266, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tổng tiền phát sinh"
        '
        'tbMaPhieuNhapPS
        '
        Me.tbMaPhieuNhapPS.Location = New System.Drawing.Point(170, 12)
        Me.tbMaPhieuNhapPS.Name = "tbMaPhieuNhapPS"
        Me.tbMaPhieuNhapPS.Size = New System.Drawing.Size(170, 25)
        Me.tbMaPhieuNhapPS.TabIndex = 2
        '
        'dtpNgayNhap
        '
        Me.dtpNgayNhap.Location = New System.Drawing.Point(494, 12)
        Me.dtpNgayNhap.Name = "dtpNgayNhap"
        Me.dtpNgayNhap.Size = New System.Drawing.Size(234, 25)
        Me.dtpNgayNhap.TabIndex = 3
        '
        'tbTongTienPS
        '
        Me.tbTongTienPS.Location = New System.Drawing.Point(391, 51)
        Me.tbTongTienPS.Name = "tbTongTienPS"
        Me.tbTongTienPS.Size = New System.Drawing.Size(170, 25)
        Me.tbTongTienPS.TabIndex = 4
        '
        'dgvTTNhapPS
        '
        Me.dgvTTNhapPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTTNhapPS.Location = New System.Drawing.Point(12, 147)
        Me.dgvTTNhapPS.Name = "dgvTTNhapPS"
        Me.dgvTTNhapPS.Size = New System.Drawing.Size(765, 268)
        Me.dgvTTNhapPS.TabIndex = 2
        '
        'btNhap
        '
        Me.btNhap.Location = New System.Drawing.Point(220, 435)
        Me.btNhap.Name = "btNhap"
        Me.btNhap.Size = New System.Drawing.Size(75, 23)
        Me.btNhap.TabIndex = 3
        Me.btNhap.Text = "Nhập"
        Me.btNhap.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(477, 435)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btRefresh.TabIndex = 4
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'FrmNhapPhatSinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 511)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.btNhap)
        Me.Controls.Add(Me.dgvTTNhapPS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmNhapPhatSinh"
        Me.Text = "FrmNhapPhatSinh"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTTNhapPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbTongTienPS As TextBox
    Friend WithEvents dtpNgayNhap As DateTimePicker
    Friend WithEvents tbMaPhieuNhapPS As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvTTNhapPS As DataGridView
    Friend WithEvents btNhap As Button
    Friend WithEvents btRefresh As Button
End Class
