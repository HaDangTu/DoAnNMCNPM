<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNhapPhuTung
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
        Me.tbTongTienNhap = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpNgayNhap = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbMaNhapPT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDanhSachNhapPT = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btNhapPhuTung = New System.Windows.Forms.Button()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvDanhSachNhapPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbTongTienNhap)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtpNgayNhap)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbMaNhapPT)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(47, 95)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 113)
        Me.Panel1.TabIndex = 0
        '
        'tbTongTienNhap
        '
        Me.tbTongTienNhap.Location = New System.Drawing.Point(344, 68)
        Me.tbTongTienNhap.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTongTienNhap.Name = "tbTongTienNhap"
        Me.tbTongTienNhap.ReadOnly = True
        Me.tbTongTienNhap.Size = New System.Drawing.Size(209, 25)
        Me.tbTongTienNhap.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tổng tiền nhập"
        '
        'dtpNgayNhap
        '
        Me.dtpNgayNhap.Location = New System.Drawing.Point(505, 22)
        Me.dtpNgayNhap.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpNgayNhap.Name = "dtpNgayNhap"
        Me.dtpNgayNhap.Size = New System.Drawing.Size(228, 25)
        Me.dtpNgayNhap.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(425, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ngày nhập"
        '
        'tbMaNhapPT
        '
        Me.tbMaNhapPT.Location = New System.Drawing.Point(173, 22)
        Me.tbMaNhapPT.Margin = New System.Windows.Forms.Padding(4)
        Me.tbMaNhapPT.Name = "tbMaNhapPT"
        Me.tbMaNhapPT.ReadOnly = True
        Me.tbMaNhapPT.Size = New System.Drawing.Size(209, 25)
        Me.tbMaNhapPT.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mã phiếu nhập phụ tùng"
        '
        'dgvDanhSachNhapPT
        '
        Me.dgvDanhSachNhapPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachNhapPT.Location = New System.Drawing.Point(12, 226)
        Me.dgvDanhSachNhapPT.Name = "dgvDanhSachNhapPT"
        Me.dgvDanhSachNhapPT.Size = New System.Drawing.Size(839, 181)
        Me.dgvDanhSachNhapPT.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(300, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 36)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Phiếu nhập phụ tùng"
        '
        'btNhapPhuTung
        '
        Me.btNhapPhuTung.Location = New System.Drawing.Point(283, 423)
        Me.btNhapPhuTung.Name = "btNhapPhuTung"
        Me.btNhapPhuTung.Size = New System.Drawing.Size(118, 31)
        Me.btNhapPhuTung.TabIndex = 3
        Me.btNhapPhuTung.Text = "Nhập phụ tùng"
        Me.btNhapPhuTung.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(477, 423)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(118, 31)
        Me.btRefresh.TabIndex = 4
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'FrmNhapPhuTung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 465)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.btNhapPhuTung)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvDanhSachNhapPT)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmNhapPhuTung"
        Me.Text = "FrmNhapPhuTung"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvDanhSachNhapPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbTongTienNhap As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpNgayNhap As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents tbMaNhapPT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDanhSachNhapPT As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents btNhapPhuTung As Button
    Friend WithEvents btRefresh As Button
End Class
