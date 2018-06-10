Imports QLGARABUS
Imports QLGARADTO
Imports Utility
Public Class FrmLapPhieuThuTien
    Dim phieuthutienBUS As New PhieuThuTienBUS()
    Dim phieutiepnhanBUS As New PhieuTiepNhanBUS()
    Dim khachhangBUS As New KhachHangBUS()
    Dim thongtinxeBus As New ThongTinXeBUS()
    Private Sub FrmLapPhieuThuTien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nextmaphieuTT = "1"
        phieuthutienBUS.BuildMaPhieutt(nextmaphieuTT)
        tbMaphieu.Text = nextmaphieuTT

    End Sub

    Private Sub btLapphieu_Click(sender As Object, e As EventArgs) Handles btLapphieu.Click
        Dim phieuthutienDTO As New PhieuThuTienDTO

        'phieuthutienDTO.MaPhieuThuTien = tbTenchuxe.Text
        'Dim listofphieutiepnhan As New List(Of PhieuTiepNhanDTO)()
        'listofphieutiepnhan = phieutiepnhanBUS.SelectAll()
        'phieuthutienDTO.MaPhieuTN = listofphieutiepnhan.ElementAt(listofphieutiepnhan.Count - 1).MaPhieu
        phieuthutienDTO.MaPhieuThuTien = tbMaphieu.Text

        Dim phieutiepnhan As PhieuTiepNhanDTO
        phieutiepnhan = thongtinxeBus.SelectPhieutiepnhan_byBienso(tbBiensoxe.Text)
        phieuthutienDTO.MaPhieuTN = phieutiepnhan.MaPhieu

        phieuthutienDTO.NgayThuTien = dtpNgaythutien.Value
        phieuthutienDTO.SoTienThu = Double.Parse(tbSotienthu.Text)

        Dim result As Result

        'kiểm tra đã có biển số chưa
        If (phieuthutienBUS.isvalidbienso(tbBiensoxe.Text) = False) Then
            MessageBox.Show("Không có xe này")
            tbBiensoxe.Focus()
            Return
        End If
        'Kiểm tra tên chủ xe đã có chưa

        If (phieuthutienBUS.isvalidtenchuxe(tbTenchuxe.Text) = False) Then
            MessageBox.Show("Không có chủ xe này")
            tbTenchuxe.Focus()
            Return
        End If
        'dựa vào biển số để tìm nợ khách hàng và kiểm tra 
        'tiền nợ có lớn hơn tiền thu hay ko
        If (phieuthutienBUS.isvalidTienThu(phieuthutienDTO, tbBiensoxe.Text) = False) Then
            MessageBox.Show("Số tiền thu vượt quá số tiền nợ")
            tbSotienthu.Focus()
            Return
        End If

        'lập phiếu
        result = phieuthutienBUS.Insert(phieuthutienDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Lập phiếu thu thành công.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim nextmaphieuTT = "1"
            phieuthutienBUS.BuildMaPhieutt(nextmaphieuTT)
            tbMaphieu.Text = nextmaphieuTT

            'Cap nhat lai tien no khach hang
            'Tim ma khach hang theo bien so
            Dim KhachhangDTO As KhachHangDTO
            KhachhangDTO = khachhangBUS.SelectMaKH_ByBienSo(tbBiensoxe.Text)
            KhachhangDTO = New KhachHangDTO(KhachhangDTO.MaKH, KhachhangDTO.TenKH,
                                            KhachhangDTO.DiaChi, KhachhangDTO.DienThoai,
                                            KhachhangDTO.TienNo - phieuthutienDTO.SoTienThu)

            result = khachhangBUS.Update(KhachhangDTO)
            If (result.FlagResult = False) Then
                MessageBox.Show("Cập nhật khách hàng không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            Else
                MessageBox.Show("Cập nhật khách hàng thành công.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("Lập phiếu thu không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        tbBiensoxe.Text = String.Empty
        tbDienThoai.Text = String.Empty
        tbEmail.Text = String.Empty
        tbSotienthu.Text = String.Empty
        tbTenchuxe.Text = String.Empty

        Dim nextMaPhieuTT = "1"
        Dim result As Result
        result = phieuthutienBUS.BuildMaPhieutt(nextMaPhieuTT)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu thu tiền kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        tbMaphieu.Text = nextMaPhieuTT
    End Sub
End Class