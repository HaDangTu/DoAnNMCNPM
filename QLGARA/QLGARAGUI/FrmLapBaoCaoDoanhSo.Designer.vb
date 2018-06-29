<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLapBaoCaoDoanhSo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.maphieu = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbTongDoanhSo = New System.Windows.Forms.TextBox()
        Me.dgvDoanhSo = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMaDoanhSo = New System.Windows.Forms.TextBox()
        Me.btLapBaoCao = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.dtpThang = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvDoanhSo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Doanh số"
        '
        'maphieu
        '
        Me.maphieu.AutoSize = True
        Me.maphieu.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maphieu.Location = New System.Drawing.Point(380, 75)
        Me.maphieu.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.maphieu.Name = "maphieu"
        Me.maphieu.Size = New System.Drawing.Size(45, 17)
        Me.maphieu.TabIndex = 17
        Me.maphieu.Text = "Tháng"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(339, 125)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Tổng doanh số"
        '
        'tbTongDoanhSo
        '
        Me.tbTongDoanhSo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTongDoanhSo.Location = New System.Drawing.Point(440, 120)
        Me.tbTongDoanhSo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTongDoanhSo.Name = "tbTongDoanhSo"
        Me.tbTongDoanhSo.ReadOnly = True
        Me.tbTongDoanhSo.Size = New System.Drawing.Size(265, 25)
        Me.tbTongDoanhSo.TabIndex = 19
        '
        'dgvDoanhSo
        '
        Me.dgvDoanhSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDoanhSo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDoanhSo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDoanhSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDoanhSo.Location = New System.Drawing.Point(16, 187)
        Me.dgvDoanhSo.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDoanhSo.Name = "dgvDoanhSo"
        Me.dgvDoanhSo.Size = New System.Drawing.Size(903, 340)
        Me.dgvDoanhSo.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Mã doanh số"
        '
        'tbMaDoanhSo
        '
        Me.tbMaDoanhSo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaDoanhSo.Location = New System.Drawing.Point(114, 72)
        Me.tbMaDoanhSo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbMaDoanhSo.Name = "tbMaDoanhSo"
        Me.tbMaDoanhSo.ReadOnly = True
        Me.tbMaDoanhSo.Size = New System.Drawing.Size(156, 25)
        Me.tbMaDoanhSo.TabIndex = 23
        '
        'btLapBaoCao
        '
        Me.btLapBaoCao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLapBaoCao.Location = New System.Drawing.Point(252, 546)
        Me.btLapBaoCao.Margin = New System.Windows.Forms.Padding(4)
        Me.btLapBaoCao.Name = "btLapBaoCao"
        Me.btLapBaoCao.Size = New System.Drawing.Size(121, 55)
        Me.btLapBaoCao.TabIndex = 25
        Me.btLapBaoCao.Text = "Lập báo cáo"
        Me.btLapBaoCao.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(610, 546)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 55)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btPrint
        '
        Me.btPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Location = New System.Drawing.Point(429, 546)
        Me.btPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(121, 55)
        Me.btPrint.TabIndex = 29
        Me.btPrint.Text = "Print"
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'dtpThang
        '
        Me.dtpThang.Location = New System.Drawing.Point(440, 70)
        Me.dtpThang.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(212, 25)
        Me.dtpThang.TabIndex = 30
        '
        'FrmLapBaoCaoDoanhSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 609)
        Me.Controls.Add(Me.dtpThang)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btLapBaoCao)
        Me.Controls.Add(Me.tbMaDoanhSo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvDoanhSo)
        Me.Controls.Add(Me.tbTongDoanhSo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.maphieu)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmLapBaoCaoDoanhSo"
        Me.Text = "FrmBaoCaoDoanhSo"
        CType(Me.dgvDoanhSo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents maphieu As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbTongDoanhSo As TextBox
    Friend WithEvents dgvDoanhSo As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents tbMaDoanhSo As TextBox
    Friend WithEvents btLapBaoCao As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btPrint As Button
    Friend WithEvents dtpThang As DateTimePicker
End Class
