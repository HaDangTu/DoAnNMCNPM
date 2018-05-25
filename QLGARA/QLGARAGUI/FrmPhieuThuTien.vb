Imports QLGARABUS
Imports QLGARADTO
Imports Utility
Public Class FrmPhieuThuTien
    Dim phieuthutienBUS As New PhieuThuTienBUS()
    Dim phieutiepnhanBUS As New PhieuTiepNhanBUS()
    Dim khachhangBUS As New KhachHangBUS()
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

        Dim phieutiepnhan As New PhieuTiepNhanDTO()
        phieutiepnhan = phieutiepnhanBUS.SelectPhieutiepnhan_ByBienso(tbBiensoxe.Text)
        phieuthutienDTO.MaPhieuTN = phieutiepnhan.MaPhieu

        phieuthutienDTO.NgayThuTien = dtpNgaythutien.Value
        phieuthutienDTO.SoTienThu = Convert.ToInt64(tbSotienthu)

        Dim result As Result

        If (phieuthutienBUS.isvalidbienso(tbBiensoxe.Text) = False) Then
            MessageBox.Show("Không có xe này")
            tbBiensoxe.Focus()
            Return
        End If

        If (phieuthutienBUS.isvalidtenchuxe(tbTenchuxe.Text) = False) Then
            MessageBox.Show("Không có chủ xe này")
            tbTenchuxe.Focus()
            Return
        End If

        If (phieuthutienBUS.isvalidTienThu(phieuthutienDTO, tbBiensoxe.Text) = False) Then
            MessageBox.Show("Số tiền thu vượt quá số tiền nợ")
            tbSotienthu.Focus()
            Return
        End If

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
            khachhangBUS.Update(KhachhangDTO)

        Else
            MessageBox.Show("Lập phiếu thu không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class