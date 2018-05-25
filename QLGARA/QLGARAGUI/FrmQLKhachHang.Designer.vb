<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQLKhachHang
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbTenKH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbTienNo = New System.Windows.Forms.TextBox()
        Me.tbDiaChi = New System.Windows.Forms.TextBox()
        Me.tbDienThoai = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbMaKH = New System.Windows.Forms.TextBox()
        Me.dgvDanhSachKH = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btThem = New System.Windows.Forms.Button()
        Me.btcapnhat = New System.Windows.Forms.Button()
        Me.btXoa = New System.Windows.Forms.Button()
        CType(Me.dgvDanhSachKH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Họ tên "
        '
        'tbTenKH
        '
        Me.tbTenKH.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTenKH.Location = New System.Drawing.Point(116, 135)
        Me.tbTenKH.Name = "tbTenKH"
        Me.tbTenKH.Size = New System.Drawing.Size(210, 25)
        Me.tbTenKH.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Địa chỉ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(472, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Điện thoại"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(472, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tiền nợ"
        '
        'tbTienNo
        '
        Me.tbTienNo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTienNo.Location = New System.Drawing.Point(545, 135)
        Me.tbTienNo.Name = "tbTienNo"
        Me.tbTienNo.Size = New System.Drawing.Size(210, 25)
        Me.tbTienNo.TabIndex = 12
        '
        'tbDiaChi
        '
        Me.tbDiaChi.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDiaChi.Location = New System.Drawing.Point(116, 189)
        Me.tbDiaChi.Multiline = True
        Me.tbDiaChi.Name = "tbDiaChi"
        Me.tbDiaChi.Size = New System.Drawing.Size(210, 67)
        Me.tbDiaChi.TabIndex = 13
        '
        'tbDienThoai
        '
        Me.tbDienThoai.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDienThoai.Location = New System.Drawing.Point(545, 189)
        Me.tbDienThoai.Name = "tbDienThoai"
        Me.tbDienThoai.Size = New System.Drawing.Size(210, 25)
        Me.tbDienThoai.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Mã khách hàng"
        '
        'tbMaKH
        '
        Me.tbMaKH.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaKH.Location = New System.Drawing.Point(116, 76)
        Me.tbMaKH.Name = "tbMaKH"
        Me.tbMaKH.ReadOnly = True
        Me.tbMaKH.Size = New System.Drawing.Size(210, 25)
        Me.tbMaKH.TabIndex = 16
        '
        'dgvDanhSachKH
        '
        Me.dgvDanhSachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachKH.Location = New System.Drawing.Point(16, 439)
        Me.dgvDanhSachKH.Name = "dgvDanhSachKH"
        Me.dgvDanhSachKH.Size = New System.Drawing.Size(791, 232)
        Me.dgvDanhSachKH.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 419)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Danh sách khách hàng"
        '
        'btThem
        '
        Me.btThem.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThem.Location = New System.Drawing.Point(116, 337)
        Me.btThem.Name = "btThem"
        Me.btThem.Size = New System.Drawing.Size(75, 23)
        Me.btThem.TabIndex = 19
        Me.btThem.Text = "Thêm"
        Me.btThem.UseVisualStyleBackColor = True
        '
        'btcapnhat
        '
        Me.btcapnhat.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcapnhat.Location = New System.Drawing.Point(291, 337)
        Me.btcapnhat.Name = "btcapnhat"
        Me.btcapnhat.Size = New System.Drawing.Size(75, 23)
        Me.btcapnhat.TabIndex = 20
        Me.btcapnhat.Text = "Cập nhật"
        Me.btcapnhat.UseVisualStyleBackColor = True
        '
        'btXoa
        '
        Me.btXoa.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXoa.Location = New System.Drawing.Point(460, 337)
        Me.btXoa.Name = "btXoa"
        Me.btXoa.Size = New System.Drawing.Size(75, 23)
        Me.btXoa.TabIndex = 21
        Me.btXoa.Text = "Xóa"
        Me.btXoa.UseVisualStyleBackColor = True
        '
        'QLKhachHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 683)
        Me.Controls.Add(Me.btXoa)
        Me.Controls.Add(Me.btcapnhat)
        Me.Controls.Add(Me.btThem)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvDanhSachKH)
        Me.Controls.Add(Me.tbMaKH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbDienThoai)
        Me.Controls.Add(Me.tbDiaChi)
        Me.Controls.Add(Me.tbTienNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbTenKH)
        Me.Controls.Add(Me.Label2)
        Me.Name = "QLKhachHang"
        Me.Text = "QLKhachHang"
        CType(Me.dgvDanhSachKH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents tbTenKH As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbTienNo As TextBox
    Friend WithEvents tbDiaChi As TextBox
    Friend WithEvents tbDienThoai As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbMaKH As TextBox
    Friend WithEvents dgvDanhSachKH As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents btThem As Button
    Friend WithEvents btcapnhat As Button
    Friend WithEvents btXoa As Button
End Class
