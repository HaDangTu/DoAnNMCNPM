Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmLapBaoCaoDoanhSo
    Private doanhsoBUS As New DoanhSoBUS()
    Private ttdoanhsoBUS As New TTDoanhSoBUS()

    Public Sub LoadListofLuotSuaChua(thang As Integer, ByRef ListofLuotSuaChua As List(Of LuotSuaChuaDTO))
        ListofLuotSuaChua = doanhsoBUS.SoLuotSC_1_HieuXe(thang)
    End Sub

    Public Sub LoadListofThanhTien(thang As Integer, ByRef ListofThanhTien As List(Of ThanhTienDTO))
        ListofThanhTien = doanhsoBUS.ThanhTien(thang)
    End Sub

    Public Sub LoadDGVDoanhSo(ListofTT_DoanhSo As List(Of TTDoanhSoDTO))
        dgvDoanhSo.Columns.Clear()
        dgvDoanhSo.DataSource = Nothing

        dgvDoanhSo.AutoGenerateColumns = False
        dgvDoanhSo.AllowUserToAddRows = False
        dgvDoanhSo.DataSource = ListofTT_DoanhSo

        Dim clHieuXe As New DataGridViewTextBoxColumn()
        clHieuXe.Name = "HieuXe"
        clHieuXe.HeaderText = "Hiệu xe"
        clHieuXe.DataPropertyName = "HieuXe"
        dgvDoanhSo.Columns.Add(clHieuXe)

        Dim clSoLuotSua As New DataGridViewTextBoxColumn()
        clSoLuotSua.Name = "SoLuotSua"
        clSoLuotSua.HeaderText = "Số lượt sửa"
        clSoLuotSua.DataPropertyName = "SoLuotSua"
        dgvDoanhSo.Columns.Add(clSoLuotSua)

        Dim clThanhTien As New DataGridViewTextBoxColumn()
        clThanhTien.Name = "ThanhTien"
        clThanhTien.HeaderText = "Thành tiền"
        clThanhTien.DataPropertyName = "ThanhTien"
        dgvDoanhSo.Columns.Add(clThanhTien)

        Dim clTiLe As New DataGridViewTextBoxColumn()
        clTiLe.Name = "TiLe"
        clTiLe.HeaderText = "Tỉ lệ"
        clTiLe.DataPropertyName = "TiLe"
        dgvDoanhSo.Columns.Add(clTiLe)


    End Sub
    Private Sub btLapBaoCao_Click(sender As Object, e As EventArgs) Handles btLapBaoCao.Click
        Dim ListofThongTinDoanhSo As New List(Of TTDoanhSoDTO)()
        Dim doanhsoDTO As New DoanhSoDTO()
        Dim result As Result
        Dim i = 0
        Dim ListofLuotSuaChua As New List(Of LuotSuaChuaDTO)()
        Dim ListofThanhTien As New List(Of ThanhTienDTO)()
        LoadListofLuotSuaChua(Integer.Parse(tbThang.Text), ListofLuotSuaChua)
        LoadListofThanhTien(Integer.Parse(tbThang.Text), ListofThanhTien)

        doanhsoDTO.MaDoanhSo = tbMaDoanhSo.Text
        doanhsoDTO.Thang = Convert.ToInt16(tbThang.Text)
        doanhsoDTO.TongDoanhThu = doanhsoBUS.TongDoanhThu(doanhsoDTO.Thang)
        tbTongDoanhSo.Text = doanhsoDTO.TongDoanhThu.ToString()

        'Insert DOANHSO
        result = doanhsoBUS.Insert(doanhsoDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Lập báo cáo doanh số thành công ", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        Else
            MessageBox.Show("Lập báo cáo doanh số không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        'Insert TT_DOANHSO
        For Each Suachua As LuotSuaChuaDTO In ListofLuotSuaChua
            Dim nextMaTTDoanhSo = "1"
            result = ttdoanhsoBUS.BuildMaTTDoanhSo(nextMaTTDoanhSo)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy mã thông tin doanh số kế tiếp thất bại", "information", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If
            ListofThongTinDoanhSo.Add(New TTDoanhSoDTO(nextMaTTDoanhSo, Suachua.TenHX, Suachua.SoLuotSuaChua,
                                                       0, Suachua.SoLuotSuaChua / doanhsoBUS.TongSoLuotSua(doanhsoDTO.Thang),
                                                       doanhsoDTO.MaDoanhSo))

        Next

        For Each thanhtien As ThanhTienDTO In ListofThanhTien
            ListofThongTinDoanhSo.Item(i) = New TTDoanhSoDTO(
                ListofThongTinDoanhSo.ElementAt(i).MaTTDoanhSo,
                ListofThongTinDoanhSo.ElementAt(i).HieuXe,
                ListofThongTinDoanhSo.ElementAt(i).SoLuotSua,
                thanhtien.ThanhTien,
                ListofThongTinDoanhSo.ElementAt(i).TiLe,
                ListofThongTinDoanhSo.ElementAt(i).MaDoanhSo)
            i = i + 1
        Next
        i = 0
        For Each ttdoanhso As TTDoanhSoDTO In ListofThongTinDoanhSo
            result = ttdoanhsoBUS.Insert(ttdoanhso)
            If (result.FlagResult = True) Then
                MessageBox.Show("Nhập thông tin doanh số thành công", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nhập thông tin doanh số không thành công", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If
        Next

        LoadDGVDoanhSo(ListofThongTinDoanhSo)
    End Sub

    Private Sub FrmLapBaoCaoDoanhSo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nextMaDoanhSo = "1"
        Dim result As Result
        result = doanhsoBUS.BuildMaDoanhSo(nextMaDoanhSo)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã doanh số kế tiếp không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        tbMaDoanhSo.Text = nextMaDoanhSo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ListofThongTinDoanhSo As New List(Of TTDoanhSoDTO)()
        LoadDGVDoanhSo(ListofThongTinDoanhSo)
        Dim nextMaDoanhSo = "1"
        Dim result As Result
        result = doanhsoBUS.BuildMaDoanhSo(nextMaDoanhSo)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã doanh số kế tiếp không thành công ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        tbMaDoanhSo.Text = nextMaDoanhSo
    End Sub
End Class