Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmLapPhieuSuaChua
    Private phieusuachuaBUS As New PhieuSuaChuaBUS()
    Private phieutiepnhanBUS As New PhieuTiepNhanBUS()
    Private phutungBUS As New PhuTungBUS()
    Private loaitiencongBUS As New LoaiTienCongBUS()
    Private khachhangBUS As New KhachHangBUS()
    Private tt_phieusuachuaBUS As New TTPhieuSuaChuaBUS()



    Public Sub LoadListofPhuTung(ByRef ListofPhuTung As List(Of PhuTungDTO))
        ListofPhuTung = phutungBUS.Sellect_All()
    End Sub

    Public Sub LoadListofTienCong(ByRef ListofTienCong As List(Of LoaiTienCongDTO))
        ListofTienCong = loaitiencongBUS.SelectALL()
    End Sub

    Public Sub Load_DgvTT_PhieuSC()
        'Lấy danh sách phụ tùng
        Dim ListofPhuTung As New List(Of PhuTungDTO)()
        LoadListofPhuTung(ListofPhuTung)

        'Lấy danh sách tiền công
        Dim ListofTienCong As New List(Of LoaiTienCongDTO)()
        LoadListofTienCong(ListofTienCong)

        dgvTT_PhieuSC.Columns.Clear()
        dgvTT_PhieuSC.DataSource = Nothing

        dgvTT_PhieuSC.AutoGenerateColumns = False
        dgvTT_PhieuSC.AllowUserToAddRows = True

        Dim clNoiDung As New DataGridViewTextBoxColumn()
        clNoiDung.Name = "NoiDung"
        clNoiDung.HeaderText = "Nội dung"
        dgvTT_PhieuSC.Columns.Add(clNoiDung)

        Dim cbVatTuPhuTung As New DataGridViewComboBoxColumn()
        cbVatTuPhuTung.Name = "TenPhuTung"
        cbVatTuPhuTung.HeaderText = "Vật tư phụ tùng"
        cbVatTuPhuTung.DataSource = New BindingSource(ListofPhuTung, String.Empty)
        cbVatTuPhuTung.DisplayMember = "TenPhuTung"
        cbVatTuPhuTung.ValueMember = "MaPhuTung"
        dgvTT_PhieuSC.Columns.Add(cbVatTuPhuTung)

        Dim clSoLuong As New DataGridViewTextBoxColumn()
        clSoLuong.Name = "SoLuong"
        clSoLuong.HeaderText = "Số lượng"
        dgvTT_PhieuSC.Columns.Add(clSoLuong)

        Dim clDonGia As New DataGridViewTextBoxColumn()
        clDonGia.Name = "DonGia"
        clDonGia.HeaderText = "Đơn giá"
        clDonGia.ReadOnly = True
        dgvTT_PhieuSC.Columns.Add(clDonGia)

        Dim cbTienCong As New DataGridViewComboBoxColumn()
        cbTienCong.Name = "TienCong"
        cbTienCong.HeaderText = "Tiền công"
        cbTienCong.DataSource = New BindingSource(ListofTienCong, String.Empty)
        cbTienCong.DisplayMember = "TenLoaiTC"
        cbTienCong.ValueMember = "MaTC"
        dgvTT_PhieuSC.Columns.Add(cbTienCong)

        Dim clThanhTien As New DataGridViewTextBoxColumn()
        clThanhTien.Name = "ThanhTien"
        clThanhTien.HeaderText = "Thành Tiền"
        clThanhTien.ReadOnly = True
        dgvTT_PhieuSC.Columns.Add(clThanhTien)
    End Sub
    Private Sub FrmPhieuSuaChua_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim result As Result

        Dim nextMaPhieuSC = "1"
        result = phieusuachuaBUS.BuildMaPhieuSC(nextMaPhieuSC)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy tự động mã phiếu sửa chữa kế tiếp không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        tbMaPhieuSC.Text = nextMaPhieuSC

        Load_DgvTT_PhieuSC()
    End Sub

    Private Sub btLapPhieu_Click(sender As Object, e As EventArgs) Handles btLapPhieu.Click
        Dim phieusuachuaDTO As New PhieuSuaChuaDTO()
        Dim tt_phieusuachuaDTO As New TTPhieuSuaChuaDTO()
        Dim khachhangDTO As New KhachHangDTO()
        Dim result As Result
        Dim ListofPhuTungDTO As New List(Of PhuTungDTO)()
        LoadListofPhuTung(ListofPhuTungDTO)

        'Tìm mã phiếu tiếp nhận thông qua biển số
        Dim maphieutiepnhan As String
        maphieutiepnhan = phieutiepnhanBUS.SelectPhieutiepnhan_ByBienso(tbBienSo.Text).MaPhieu

        'Kiểm tra loại vật tư phụ tùng có nằm trong danh sách vật tư phụ tùng hay không
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (phutungBUS.isvalidPhuTung(row.Cells("TenPhuTung").Value) = False And
                 row.Cells("TenPhuTung").Value <> "") Then
                MessageBox.Show("Không có phụ tùng này")
                Return
            End If
        Next

        'Kiểm tra loại tiền công có trong danh sách loại tiền công hay không
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (loaitiencongBUS.isvalid_LoaiTienCong(row.Cells("TienCong").Value) = False And
                 row.Cells("TienCong").Value <> "") Then
                MessageBox.Show("Không có loại tiền công này")
                Return
            End If
        Next

        'Lấy đơn giá từ danh sách phụ tùng qua loại phụ tùng
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                row.Cells("DonGia").Value = phutungBUS.Select_DonGia(row.Cells("TenPhuTung").Value)
            End If
        Next

        'Lấy mức tiền từ danh sách tiền công qua loại tiền công và tính thành tiền
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                row.Cells("ThanhTien").Value = row.Cells("DonGia").Value * row.Cells("SoLuong").Value +
                    loaitiencongBUS.Select_MucTien(row.Cells("TienCong").Value)
            End If
        Next

        Dim TongThanhTien As Double
        TongThanhTien = 0
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                TongThanhTien = TongThanhTien + row.Cells("ThanhTien").Value
            End If
        Next
        'Insert Phiếu sửa chữa ứng với mã tiếp nhận
        phieusuachuaDTO.MaPhieuSC = tbMaPhieuSC.Text
        phieusuachuaDTO.MaPhieuTN = maphieutiepnhan
        phieusuachuaDTO.NgaySC = dtpNgaySuaChua.Value

        result = phieusuachuaBUS.Insert(phieusuachuaDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Lập phiếu sửa chữa thành công", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Dim nextMaPhieuSC = "1"
            phieusuachuaBUS.BuildMaPhieuSC(nextMaPhieuSC)
            tbMaPhieuSC.Text = nextMaPhieuSC
        Else
            MessageBox.Show("Lập phiếu sửa chữa không thành công", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        Dim i = 0
        'Insert Thông tin sửa chữa
        tt_phieusuachuaDTO.MaPhieuSC = phieusuachuaDTO.MaPhieuSC
        For Each row As DataGridViewRow In dgvTT_PhieuSC.Rows
            If (row.Cells("TenPhuTung").Value <> "") Then
                Dim nextMaTTPhieuSC = "1"
                tt_phieusuachuaBUS.BuildMaTTPhieuSC(nextMaTTPhieuSC)
                tt_phieusuachuaDTO.MaTTPhieuSuaChua = nextMaTTPhieuSC

                tt_phieusuachuaDTO.MaPhuTung = row.Cells("TenPhuTung").Value
                tt_phieusuachuaDTO.MaTienCong = row.Cells("TienCong").Value
                tt_phieusuachuaDTO.SoLuong = Convert.ToDouble(row.Cells("SoLuong").Value)
                tt_phieusuachuaDTO.NoiDung = row.Cells("NoiDung").Value
                If (i < ListofPhuTungDTO.Count) Then
                    ListofPhuTungDTO(i).SoLuongCon = ListofPhuTungDTO(i).SoLuongCon - tt_phieusuachuaDTO.SoLuong
                    i = i + 1
                End If
                result = tt_phieusuachuaBUS.Insert(tt_phieusuachuaDTO)
                If (result.FlagResult = True) Then
                    MessageBox.Show("Thêm thông tin phiếu sửa chữa thành công.", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Thêm thông tin phiếu sửa chữa không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Return
                End If
            End If
        Next
        i = 0

        'Cập nhật lại tiền nợ của khách hàng
        khachhangDTO = khachhangBUS.SelectMaKH_ByBienSo(tbBienSo.Text)
        khachhangDTO = New KhachHangDTO(khachhangDTO.MaKH, khachhangDTO.TenKH,
                                         khachhangDTO.DiaChi, khachhangDTO.DienThoai,
                                        khachhangDTO.TienNo + TongThanhTien)
        'Cập nhật lại SoLuonCon của Phụ tùng
        For Each phutung In ListofPhuTungDTO
            phutungBUS.Update(phutung)
        Next

        result = khachhangBUS.Update(khachhangDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Cập nhật tiền nợ khách hàng thành công", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cập nhật tiền nợ khách hàng thất bại", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        tbBienSo.Text = String.Empty
        Load_DgvTT_PhieuSC()
    End Sub
End Class