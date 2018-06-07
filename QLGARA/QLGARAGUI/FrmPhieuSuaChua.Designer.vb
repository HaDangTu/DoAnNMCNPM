<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPhieuSuaChua
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
        Me.tbMaPhieuSC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbBienSo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpNgaySuaChua = New System.Windows.Forms.DateTimePicker()
        Me.btLapPhieu = New System.Windows.Forms.Button()
        Me.dgvTT_PhieuSC = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.dgvTT_PhieuSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mã phiếu sửa chữa"
        '
        'tbMaPhieuSC
        '
        Me.tbMaPhieuSC.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaPhieuSC.Location = New System.Drawing.Point(163, 45)
        Me.tbMaPhieuSC.Name = "tbMaPhieuSC"
        Me.tbMaPhieuSC.ReadOnly = True
        Me.tbMaPhieuSC.Size = New System.Drawing.Size(104, 25)
        Me.tbMaPhieuSC.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Biển số"
        '
        'tbBienSo
        '
        Me.tbBienSo.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBienSo.Location = New System.Drawing.Point(163, 86)
        Me.tbBienSo.Name = "tbBienSo"
        Me.tbBienSo.Size = New System.Drawing.Size(104, 25)
        Me.tbBienSo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(557, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ngày sửa chữa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(376, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 33)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Phiếu sửa chữa"
        '
        'dtpNgaySuaChua
        '
        Me.dtpNgaySuaChua.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgaySuaChua.Location = New System.Drawing.Point(661, 45)
        Me.dtpNgaySuaChua.Name = "dtpNgaySuaChua"
        Me.dtpNgaySuaChua.Size = New System.Drawing.Size(220, 25)
        Me.dtpNgaySuaChua.TabIndex = 5
        '
        'btLapPhieu
        '
        Me.btLapPhieu.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLapPhieu.Location = New System.Drawing.Point(426, 417)
        Me.btLapPhieu.Name = "btLapPhieu"
        Me.btLapPhieu.Size = New System.Drawing.Size(89, 43)
        Me.btLapPhieu.TabIndex = 6
        Me.btLapPhieu.Text = "Lập phiếu"
        Me.btLapPhieu.UseVisualStyleBackColor = True
        '
        'dgvTT_PhieuSC
        '
        Me.dgvTT_PhieuSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTT_PhieuSC.Location = New System.Drawing.Point(12, 169)
        Me.dgvTT_PhieuSC.Name = "dgvTT_PhieuSC"
        Me.dgvTT_PhieuSC.Size = New System.Drawing.Size(869, 242)
        Me.dgvTT_PhieuSC.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(388, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(156, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Thông tin phiếu sửa chữa"
        '
        'FrmPhieuSuaChua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 567)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dgvTT_PhieuSC)
        Me.Controls.Add(Me.btLapPhieu)
        Me.Controls.Add(Me.dtpNgaySuaChua)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbBienSo)
        Me.Controls.Add(Me.tbMaPhieuSC)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPhieuSuaChua"
        Me.Text = "FrmPhieuSuaChua"
        CType(Me.dgvTT_PhieuSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbMaPhieuSC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbBienSo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpNgaySuaChua As DateTimePicker
    Friend WithEvents btLapPhieu As Button
    Friend WithEvents dgvTT_PhieuSC As DataGridView
    Friend WithEvents Label10 As Label
End Class
