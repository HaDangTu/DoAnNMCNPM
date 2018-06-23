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
        Me.cbThang = New System.Windows.Forms.ComboBox()
        Me.btPrint = New System.Windows.Forms.Button()
        CType(Me.dgvDoanhSo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(432, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Doanh số"
        '
        'maphieu
        '
        Me.maphieu.AutoSize = True
        Me.maphieu.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maphieu.Location = New System.Drawing.Point(358, 60)
        Me.maphieu.Name = "maphieu"
        Me.maphieu.Size = New System.Drawing.Size(45, 17)
        Me.maphieu.TabIndex = 17
        Me.maphieu.Text = "Tháng"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(327, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Tổng doanh số"
        '
        'tbTongDoanhSo
        '
        Me.tbTongDoanhSo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTongDoanhSo.Location = New System.Drawing.Point(438, 94)
        Me.tbTongDoanhSo.Name = "tbTongDoanhSo"
        Me.tbTongDoanhSo.ReadOnly = True
        Me.tbTongDoanhSo.Size = New System.Drawing.Size(210, 25)
        Me.tbTongDoanhSo.TabIndex = 19
        '
        'dgvDoanhSo
        '
        Me.dgvDoanhSo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDoanhSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDoanhSo.Location = New System.Drawing.Point(12, 143)
        Me.dgvDoanhSo.Name = "dgvDoanhSo"
        Me.dgvDoanhSo.Size = New System.Drawing.Size(895, 329)
        Me.dgvDoanhSo.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Mã doanh số"
        '
        'tbMaDoanhSo
        '
        Me.tbMaDoanhSo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaDoanhSo.Location = New System.Drawing.Point(99, 55)
        Me.tbMaDoanhSo.Name = "tbMaDoanhSo"
        Me.tbMaDoanhSo.ReadOnly = True
        Me.tbMaDoanhSo.Size = New System.Drawing.Size(210, 25)
        Me.tbMaDoanhSo.TabIndex = 23
        '
        'btLapBaoCao
        '
        Me.btLapBaoCao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLapBaoCao.Location = New System.Drawing.Point(330, 478)
        Me.btLapBaoCao.Name = "btLapBaoCao"
        Me.btLapBaoCao.Size = New System.Drawing.Size(91, 42)
        Me.btLapBaoCao.TabIndex = 25
        Me.btLapBaoCao.Text = "Lập báo cáo"
        Me.btLapBaoCao.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(672, 478)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 42)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbThang
        '
        Me.cbThang.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbThang.FormattingEnabled = True
        Me.cbThang.Location = New System.Drawing.Point(438, 52)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(43, 25)
        Me.cbThang.TabIndex = 28
        '
        'btPrint
        '
        Me.btPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Location = New System.Drawing.Point(502, 478)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(91, 42)
        Me.btPrint.TabIndex = 29
        Me.btPrint.Text = "Print"
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'FrmLapBaoCaoDoanhSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 532)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.cbThang)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btLapBaoCao)
        Me.Controls.Add(Me.tbMaDoanhSo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvDoanhSo)
        Me.Controls.Add(Me.tbTongDoanhSo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.maphieu)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents cbThang As ComboBox
    Friend WithEvents btPrint As Button
End Class
