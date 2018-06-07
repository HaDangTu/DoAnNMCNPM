Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmPhieuSuaChua
    Private phieusuachuaBUS As New PhieuSuaChuaBUS()
    Private phieutiepnhanBUS As New PhieuTiepNhanBUS()
    Private phutungBUS As New PhuTungBUS()
    Private loaitiencongBUS As New LoaiTienCongBUS()
    Private khachhangBUS As New KhachHangBUS()
    Private tt_phieusuachuaBUS As New TTPhieuSuaChuaBUS()

    Public Function LoadListofPhuTung(ByRef ListofPhuTung As List(Of PhuTungDTO))
        ListofPhuTung = phutungBUS.Sellect_All()
    End Function

    Public Function LoadListofTienCong(ByRef ListofTienCong As List(Of LoaiTienCongDTO))
        ListofTienCong = loaitiencongBUS.SelectALL()
    End Function

    Private Sub FrmPhieuSuaChua_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Lấy danh sách phụ tùng
        'Dim ListofPhuTung As New List(Of PhuTungDTO)()
        'LoadListofPhuTung(ListofPhuTung)

        ''Lấy danh sách tiền công
        'Dim ListofTienCong As New List(Of LoaiTienCongDTO)()
        'LoadListofTienCong(ListofTienCong)

        dgvTT_PhieuSC.Columns.Clear()
        dgvTT_PhieuSC.DataSource = Nothing

        dgvTT_PhieuSC.AutoGenerateColumns = False
        dgvTT_PhieuSC.AllowUserToAddRows = True

        Dim clNoiDung As New DataGridViewTextBoxColumn()
        clNoiDung.Name = "NoiDung"
        clNoiDung.HeaderText = "Nội dung"
        dgvTT_PhieuSC.Columns.Add(clNoiDung)

        Dim cbVatTuPhuTung As New DataGridViewComboBoxColumn()
        cbVatTuPhuTung.Name = "MaPhuTung"
        cbVatTuPhuTung.HeaderText = "Vật tư phụ tùng"
        'cbVatTuPhuTung.DataSource = New BindingSource(ListofPhuTung, String.Empty)
        'cbVatTuPhuTung.DisplayMember = "TenPhuTung"
        'cbVatTuPhuTung.ValueMember = "MaPhuTung"
        dgvTT_PhieuSC.Columns.Add(cbVatTuPhuTung)

        Dim clSoLuong As New DataGridViewTextBoxColumn()
        clSoLuong.Name = "SoLuong"
        clSoLuong.HeaderText = "Số lượng"
        dgvTT_PhieuSC.Columns.Add(clSoLuong)

        Dim clDonGia As New DataGridViewTextBoxColumn()
        clDonGia.Name = "DonGia"
        clDonGia.HeaderText = "Đơn giá"
        dgvTT_PhieuSC.Columns.Add(clDonGia)

        Dim cbTienCong As New DataGridViewComboBoxColumn()
        cbTienCong.Name = "MaTienCong"
        cbTienCong.HeaderText = "Tiền công"
        'cbTienCong.DataSource = New BindingSource(ListofTienCong, String.Empty)
        'cbTienCong.DisplayMember = "TenLoaiTienCong"
        'cbTienCong.ValueMember = "MaTienCong"
        dgvTT_PhieuSC.Columns.Add(cbTienCong)

        Dim clThanhTien As New DataGridViewTextBoxColumn()
        clThanhTien.Name = "ThanhTien"
        clThanhTien.HeaderText = "Thành Tiền"
        dgvTT_PhieuSC.Columns.Add(clThanhTien)


    End Sub

    ' Sub btLapPhieu_Click(sender As Object, e As EventArgs) Handles btLapPhieu.Click
    '    Dim phieusuachuaDTO As New PhieuSuaChuaDTO()
    '    Dim tt_phieusuachuaDTO As New TTPhieuSuaChuaDTO()
    '    Dim khachhangDTO As New KhachHangDTO()
    '    Dim result As Result

    '    'Tìm mã phiếu tiếp nhận thông qua biển số
    '    Dim maphieutiepnhan As String
    '    maphieutiepnhan = phieutiepnhanBUS.SelectPhieutiepnhan_ByBienso(tbBienSo.Text).MaPhieu

    '    'Kiểm tra loại vật tư phụ tùng có nằm trong danh sách vật tư phụ tùng hay không
    '    If (phutungBUS.isvalidPhuTung(cbVatTuPT.SelectedValue) = False) Then
    '        MessageBox.Show("Không có loại phụ tùng này")
    '        Return
    '    End If

    '    'Kiểm tra loại tiền công có trong danh sách loại tiền công hay không
    '    If (loaitiencongBUS.isvalid_LoaiTienCong(cbLoaiTC.SelectedValue) = False) Then
    '        MessageBox.Show("Không có loại tiền công này")
    '        Return
    '    End If

    '    'Lấy đơn giá từ danh sách phụ tùng qua loại phụ tùng
    '    Dim DonGia As String
    '    DonGia = phutungBUS.Select_DonGia(cbVatTuPT.SelectedValue)

    '    'Lấy mức tiền từ danh sách tiền công qua loại tiền công
    '    Dim MucTien As Double
    '    MucTien = loaitiencongBUS.Select_MucTien(cbLoaiTC.SelectedValue)

    '    'Tính thành tiền
    '    Dim ThanhTien As Double
    '    ThanhTien = Convert.ToDouble(tbSoLuong.Text) * DonGia + MucTien

    '    'Mapping data
    '    phieusuachuaDTO.MaPhieuSC = tbMaPhieuSC.Text
    '    phieusuachuaDTO.MaPhieuTN = maphieutiepnhan
    '    phieusuachuaDTO.NgaySC = dtpNgaySuaChua.Value

    '    tt_phieusuachuaDTO.MaPhieuSC = phieusuachuaDTO.MaPhieuSC
    '    tt_phieusuachuaDTO.MaPhuTung = cbVatTuPT.SelectedValue
    '    tt_phieusuachuaDTO.MaTienCong = cbLoaiTC.SelectedValue
    '    tt_phieusuachuaDTO.SoLuong = Convert.ToDouble(tbSoLuong.Text)
    '    tt_phieusuachuaDTO.NoiDung = tbNoiDung.Text

    '    'Cập nhật lại tiền nợ của khách hàng
    '    khachhangDTO = khachhangBUS.SelectMaKH_ByBienSo(tbBienSo.Text)
    '    khachhangDTO = New KhachHangDTO(khachhangDTO.MaKH, khachhangDTO.TenKH,
    '                                     khachhangDTO.DiaChi, khachhangDTO.DienThoai, ThanhTien)

    '    result = khachhangBUS.Update(khachhangDTO)
    '    If (result.FlagResult = True) Then
    '        MessageBox.Show("Cập nhật tiền nợ khách hàng thành công", "Information", MessageBoxButtons.OK,
    '                        MessageBoxIcon.Information)
    '    Else
    '        MessageBox.Show("Cập nhật tiền nợ khách hàng thất bại", "Error", MessageBoxButtons.OK,
    '                        MessageBoxIcon.Error)
    '        Return
    '    End If

    '    'Insert

    '    result = phieusuachuaBUS.Insert(phieusuachuaDTO)
    '    If (result.FlagResult = True) Then
    '        MessageBox.Show("Lập phiếu sửa chữa thành công.", "Information", MessageBoxButtons.OK,
    '                        MessageBoxIcon.Information)
    '        'set MSSH auto
    '        Dim nextMaPhieuSC = "1"
    '        result = phieusuachuaBUS.BuildMaPhieuSC(nextMaPhieuSC)
    '        If (result.FlagResult = False) Then
    '            MessageBox.Show("Lấy mã phiếu sửa chữa kế tiếp không thành công.", "Error",
    '                            MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return
    '        End If
    '        tbMaPhieuSC.Text = nextMaPhieuSC
    '    Else
    '        MessageBox.Show("Lập phiếu sửa chữa không thành công không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        System.Console.WriteLine(result.SystemMessage)
    '    End If

    '    result = tt_phieusuachuaBUS.Insert(tt_phieusuachuaDTO)
    '    If (result.FlagResult = True) Then
    '        MessageBox.Show("Thêm thông tin phiếu sửa chữa thành công.", "Information", MessageBoxButtons.OK,
    '                        MessageBoxIcon.Information)
    '    Else
    '        MessageBox.Show("Thêm thông tin phiếu sửa chữa không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        System.Console.WriteLine(result.SystemMessage)
    '    End If

    'End Sub
End Class