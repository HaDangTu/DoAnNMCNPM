Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmNhapPhatSinh
    Dim nhapphatsinhBUS As New NhapPhatSinhBUS()
    Dim ttphatsinhBUS As New TTPhatSinhBUS()
    Dim phutungBUS As New PhuTungBUS()

    Public Sub LoadDgvTTNhapPS()
        Dim ListofPhuTung As New List(Of PhuTungDTO)()
        ListofPhuTung = phutungBUS.Sellect_All()

        dgvTTNhapPS.Columns.Clear()
        dgvTTNhapPS.DataSource = Nothing

        dgvTTNhapPS.AutoGenerateColumns = False
        dgvTTNhapPS.AllowUserToAddRows = True

        Dim cbPhuTung As New DataGridViewComboBoxColumn()
        cbPhuTung.Name = "TenPhuTung"
        cbPhuTung.HeaderText = "Vật tư, phụ tùng"
        cbPhuTung.DataSource = New BindingSource(ListofPhuTung, String.Empty)
        cbPhuTung.DisplayMember = "TenPhuTung"
        cbPhuTung.ValueMember = "MaPhuTung"
        dgvTTNhapPS.Columns.Add(cbPhuTung)

        Dim clSoLuongNhap As New DataGridViewTextBoxColumn()
        clSoLuongNhap.Name = "SoLuongPS"
        clSoLuongNhap.HeaderText = "Số lượng phát sinh"
        dgvTTNhapPS.Columns.Add(clSoLuongNhap)

        Dim clDonGiaPS As New DataGridViewTextBoxColumn()
        clDonGiaPS.Name = "DonGiaPS"
        clDonGiaPS.HeaderText = "Đơn giá phát sinh"
        dgvTTNhapPS.Columns.Add(clDonGiaPS)

    End Sub
    Private Sub FrmNhapPhatSinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get nextMaPhieuNhapPS
        Dim nextMaPhieuNhapPS = "1"
        Dim result As Result
        result = nhapphatsinhBUS.BuildMaPhieuNhapPS(nextMaPhieuNhapPS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu nhập phát sinh kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        tbMaPhieuNhapPS.Text = nextMaPhieuNhapPS

        'load dgvTTNhapPS
        LoadDgvTTNhapPS()
    End Sub

    Private Sub btNhap_Click(sender As Object, e As EventArgs) Handles btNhap.Click
        Dim nhapphatsinh As New NhapPhatSinhDTO()
        Dim ListofTTNhapPS As New List(Of TTPhatSinhDTO)()
        Dim TongTienPhatSinh As Double = 0
        Dim result As Result
        Dim i = 1

        'Mapping data
        nhapphatsinh.MaPhieuNhapPS = tbMaPhieuNhapPS.Text
        nhapphatsinh.NgayNhapPS = dtpNgayNhap.Value

        For Each row As DataGridViewRow In dgvTTNhapPS.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                Dim nextMaTTNhapPS = "1"
                result = ttphatsinhBUS.BuildMaTTPhatSinh(nextMaTTNhapPS)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Lấy mã thông tin nhập phát sinh kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    Return
                End If

                ListofTTNhapPS.Add(New TTPhatSinhDTO(nextMaTTNhapPS, nhapphatsinh.MaPhieuNhapPS,
                                                       row.Cells("TenPhuTung").Value,
                                                       Integer.Parse(row.Cells("SoLuongPS").Value),
                                                       Double.Parse(row.Cells("DonGiaPS").Value)))
            End If
        Next
        'Tính tổng tiền phát sinh
        For Each ttphatsinh As TTPhatSinhDTO In ListofTTNhapPS
            TongTienPhatSinh = TongTienPhatSinh + (ttphatsinh.SoLuongPS * ttphatsinh.DonGiaPS)
        Next
        nhapphatsinh.TongTienPS = TongTienPhatSinh

        'Business

        'Insert
        'NHAPPHATSINH
        result = nhapphatsinhBUS.Insert(nhapphatsinh)
        If (result.FlagResult = True) Then
            MessageBox.Show("Nhập phát sinh thành công", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

            'get nextMaPhieuNhapPS
            Dim nextMaPhieuNhapPS = "1"
            result = nhapphatsinhBUS.BuildMaPhieuNhapPS(nextMaPhieuNhapPS)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy mã phiếu nhập phát sinh kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If
            tbMaPhieuNhapPS.Text = nextMaPhieuNhapPS

        Else
            MessageBox.Show("Nhập phát sinh không thành công", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            Return
        End If

        'TT_PHATSINH
        For Each ttphatsinh As TTPhatSinhDTO In ListofTTNhapPS
            result = ttphatsinhBUS.Insert(ttphatsinh)
            If (result.FlagResult = True) Then
                MessageBox.Show("Nhập thông tin phát sinh thành công", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nhập thông tin phát sinh không thành công", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If
        Next

        tbTongTienPS.Text = TongTienPhatSinh.ToString()
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Dim nextMaPhieuNhapPS = "1"
        Dim result As Result
        result = nhapphatsinhBUS.BuildMaPhieuNhapPS(nextMaPhieuNhapPS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu nhập phát sinh kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        tbMaPhieuNhapPS.Text = nextMaPhieuNhapPS
        tbTongTienPS.Text = String.Empty
        LoadDgvTTNhapPS()
    End Sub
End Class