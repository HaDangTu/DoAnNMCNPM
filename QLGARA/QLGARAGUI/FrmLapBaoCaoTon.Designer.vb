<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLapBaoCaoTon
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMaBaoCaoTon = New System.Windows.Forms.TextBox()
        Me.maphieu = New System.Windows.Forms.Label()
        Me.dgvBaoCaoTon = New System.Windows.Forms.DataGridView()
        Me.btLapBaoCao = New System.Windows.Forms.Button()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.dtpThang = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvBaoCaoTon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(406, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Báo cáo tồn"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mã báo cáo tồn"
        '
        'tbMaBaoCaoTon
        '
        Me.tbMaBaoCaoTon.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaBaoCaoTon.Location = New System.Drawing.Point(118, 57)
        Me.tbMaBaoCaoTon.Name = "tbMaBaoCaoTon"
        Me.tbMaBaoCaoTon.ReadOnly = True
        Me.tbMaBaoCaoTon.Size = New System.Drawing.Size(210, 25)
        Me.tbMaBaoCaoTon.TabIndex = 24
        '
        'maphieu
        '
        Me.maphieu.AutoSize = True
        Me.maphieu.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maphieu.Location = New System.Drawing.Point(409, 62)
        Me.maphieu.Name = "maphieu"
        Me.maphieu.Size = New System.Drawing.Size(45, 17)
        Me.maphieu.TabIndex = 27
        Me.maphieu.Text = "Tháng"
        '
        'dgvBaoCaoTon
        '
        Me.dgvBaoCaoTon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvBaoCaoTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBaoCaoTon.Location = New System.Drawing.Point(12, 105)
        Me.dgvBaoCaoTon.Name = "dgvBaoCaoTon"
        Me.dgvBaoCaoTon.Size = New System.Drawing.Size(881, 247)
        Me.dgvBaoCaoTon.TabIndex = 29
        '
        'btLapBaoCao
        '
        Me.btLapBaoCao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLapBaoCao.Location = New System.Drawing.Point(278, 362)
        Me.btLapBaoCao.Name = "btLapBaoCao"
        Me.btLapBaoCao.Size = New System.Drawing.Size(98, 46)
        Me.btLapBaoCao.TabIndex = 30
        Me.btLapBaoCao.Text = "Lập báo cáo"
        Me.btLapBaoCao.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRefresh.Location = New System.Drawing.Point(590, 361)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(98, 46)
        Me.btRefresh.TabIndex = 31
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'btPrint
        '
        Me.btPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Location = New System.Drawing.Point(433, 362)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(98, 46)
        Me.btPrint.TabIndex = 33
        Me.btPrint.Text = "Print"
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'dtpThang
        '
        Me.dtpThang.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpThang.Location = New System.Drawing.Point(460, 58)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(211, 25)
        Me.dtpThang.TabIndex = 34
        '
        'FrmLapBaoCaoTon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 420)
        Me.Controls.Add(Me.dtpThang)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.btLapBaoCao)
        Me.Controls.Add(Me.dgvBaoCaoTon)
        Me.Controls.Add(Me.maphieu)
        Me.Controls.Add(Me.tbMaBaoCaoTon)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmLapBaoCaoTon"
        Me.Text = "FrmLapBaoCaoTon"
        CType(Me.dgvBaoCaoTon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbMaBaoCaoTon As TextBox
    Friend WithEvents maphieu As Label
    Friend WithEvents dgvBaoCaoTon As DataGridView
    Friend WithEvents btLapBaoCao As Button
    Friend WithEvents btRefresh As Button
    Friend WithEvents btPrint As Button
    Friend WithEvents dtpThang As DateTimePicker
End Class
