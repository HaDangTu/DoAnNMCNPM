Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmNhapPhuTung
    Dim phutungBUS As New PhuTungBUS()
    Dim nhapphutungBUS As New NhapPhuTungBUS()
    Dim ttnhapphutungBUS As New TTNhapPhuTungBUS()

    Public Sub loadListTTPhuTung()
        Dim ListTTPhuTung As New List(Of PhuTungDTO)()
        ListTTPhuTung = phutungBUS.Sellect_All()

        dgvDanhSachNhapPT.Columns.Clear()
        dgvDanhSachNhapPT.DataSource = Nothing

        dgvDanhSachNhapPT.AutoGenerateColumns = False
        dgvDanhSachNhapPT.AllowUserToAddRows = True



        Dim clPhuTung As New DataGridViewComboBoxColumn()
        clPhuTung.Name = "TenPhuTung"
        clPhuTung.HeaderText = "Vật tư, phụ tùng"
        clPhuTung.DataSource = New BindingSource(ListTTPhuTung, String.Empty)
        clPhuTung.DisplayMember = "TenPhuTung"
        clPhuTung.ValueMember = "MaPhuTung"
        dgvDanhSachNhapPT.Columns.Add(clPhuTung)

        Dim clSoLuongNhap As New DataGridViewTextBoxColumn()
        clSoLuongNhap.Name = "SoLuongNhap"
        clSoLuongNhap.HeaderText = "Số lượng nhập"
        dgvDanhSachNhapPT.Columns.Add(clSoLuongNhap)

        Dim clDonGia As New DataGridViewTextBoxColumn()
        clDonGia.Name = "DonGia"
        clDonGia.HeaderText = "Đơn giá"
        dgvDanhSachNhapPT.Columns.Add(clDonGia)

    End Sub
    Private Sub FrmNhapPhuTung_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lấy mã phiếu nhập phụ tùng
        Dim nextMaPhieuNPT = "1"
        Dim result As Result
        result = nhapphutungBUS.BuildMaNPT(nextMaPhieuNPT)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu nhập phụ tùng thất bại", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        tbMaNhapPT.Text = nextMaPhieuNPT
        'load dgv danh sách nhập 
        loadListTTPhuTung()
    End Sub

    Private Sub btNhapPhuTung_Click(sender As Object, e As EventArgs) Handles btNhapPhuTung.Click
        Dim nhapphutungDTO As New NhapPhuTungDTO()
        Dim ListofTTNhapPT As New List(Of TTNhapPhuTungDTO)()
        Dim i = 0
        Dim TongTienNhap As Double = 0
        Dim result As Result

        'Mapping data
        nhapphutungDTO.MaNhapPhuTung = tbMaNhapPT.Text
        nhapphutungDTO.NgayNhap = dtpNgayNhap.Value

        For Each row As DataGridViewRow In dgvDanhSachNhapPT.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                'get next MaTTNhapPT
                Dim nextMaTTNPT = "1"
                result = ttnhapphutungBUS.BuildMaTTNhapPT(nextMaTTNPT)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Lấy mã thông tin nhập phụ tùng thất bại", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    Return
                End If

                ListofTTNhapPT.Add(New TTNhapPhuTungDTO(nextMaTTNPT, nhapphutungDTO.MaNhapPhuTung,
                                                         row.Cells("TenPhuTung").Value,
                                                        Integer.Parse(row.Cells("SoLuongNhap").Value),
                                                        Double.Parse(row.Cells("DonGia").Value)))
            End If
        Next

        For Each ttnhapphutung As TTNhapPhuTungDTO In ListofTTNhapPT
            TongTienNhap = TongTienNhap + ttnhapphutung.DonGiaNhap
        Next
        nhapphutungDTO.TongTienNhap = TongTienNhap
        'Business

        'Insert
        'NhapPhuTung
        result = nhapphutungBUS.Insert(nhapphutungDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Lập phiếu nhập phụ tùng thành công ", "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Dim nextMaPhieuNhapPT = "1"
            result = nhapphutungBUS.BuildMaNPT(nextMaPhieuNhapPT)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy mã phiếu nhập phụ tùng kế tiếp không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
                Return
            End If

            tbMaNhapPT.Text = nextMaPhieuNhapPT
        Else
            MessageBox.Show("Lập phiếu nhập phụ tùng không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If

        'TTNhapPhuTung
        For Each ttnhapphutung As TTNhapPhuTungDTO In ListofTTNhapPT
            result = ttnhapphutungBUS.Insert(ttnhapphutung)
            If (result.FlagResult = True) Then
                MessageBox.Show("Nhập thông tin phiếu nhập phụ tùng thành công ", "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nhập thông tin phiếu nhập phụ tùng không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
                Return
            End If
        Next
        tbTongTienNhap.Text = TongTienNhap.ToString()
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        loadListTTPhuTung()
        tbTongTienNhap.Text = String.Empty
        Dim nextMaPhieuNhapPT = "1"
        Dim result As Result
        result = nhapphutungBUS.BuildMaNPT(nextMaPhieuNhapPT)
        If (Result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu nhập phụ tùng kế tiếp không thành công ", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
            Return
        End If
        tbMaNhapPT.Text = nextMaPhieuNhapPT

    End Sub
End Class