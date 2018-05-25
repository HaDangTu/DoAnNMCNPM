Imports QLGARABUS
Imports QLGARADTO
Imports Utility
Public Class FrmPhieuTiepNhan
    Private phieutiepnhanBUS As New PhieuTiepNhanBUS()
    Private khachhangBUS As New KhachHangBUS()
    Private thongtinxeBUS As New ThongTinXeBUS()
    Private hieuxeBUS As New HieuXeBUS()
    Private hososuachuaBUS As New HoSoSuaChuaBUS()

    Public Function LoadListofthongtinxe(ByRef listofthongtinxe As List(Of ThongTinXeDTO)) As List(Of ThongTinXeDTO)
        listofthongtinxe = thongtinxeBUS.SelectALL()
        Return listofthongtinxe
    End Function
    Private Sub FrmPhieuTiepNhan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Build ma phieu tiep nhan

        Dim listofhieuxe As List(Of HieuXeDTO)
        Dim nextmaphieu = "1"
        Dim result As Result
        result = phieutiepnhanBUS.BuildMaPhieuTN(nextmaphieu)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã phiếu kế tiếp không thành công",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        tbMaphieu.Text = nextmaphieu
        'tạo ComboBox Hiệu xe

        listofhieuxe = New List(Of HieuXeDTO)()
        result = hieuxeBUS.SelectAll(listofhieuxe)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách hiệu xe không thành công",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbHieuxe.DataSource = New BindingSource(listofhieuxe, String.Empty)
        cbHieuxe.DisplayMember = "TenHX"
        cbHieuxe.ValueMember = "MaHX"

        'build ma chu xe

        Dim nextMaKH = "1"
        result = khachhangBUS.BuildMaKH(nextMaKH)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã khách hàng kế tiếp không thành công",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        tbMaCxe.Text = nextMaKH

        'tạo DataGridView hồ sơ sửa chữa

        Dim listofHoSoSuaChua As List(Of HoSoSuaChuaDTO)
        listofHoSoSuaChua = New List(Of HoSoSuaChuaDTO)()
        result = hososuachuaBUS.SelectALL(listofHoSoSuaChua)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy hồ sơ sửa chữa không thành công",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        dtgvDanhsach.Columns.Clear()
        dtgvDanhsach.DataSource = Nothing

        dtgvDanhsach.AutoGenerateColumns = False
        dtgvDanhsach.AllowUserToAddRows = False
        dtgvDanhsach.DataSource = listofHoSoSuaChua

        Dim clbienso = New DataGridViewTextBoxColumn()
        clbienso.Name = "BienSo"
        clbienso.HeaderText = "Biển số"
        clbienso.DataPropertyName = "BienSo"
        dtgvDanhsach.Columns.Add(clbienso)

        Dim cltenchuxe = New DataGridViewTextBoxColumn()
        cltenchuxe.Name = "TenChuXe"
        cltenchuxe.HeaderText = "Tên chủ xe"
        cltenchuxe.DataPropertyName = "TenChuXe"
        dtgvDanhsach.Columns.Add(cltenchuxe)

        Dim cldiachi = New DataGridViewTextBoxColumn()
        cldiachi.Name = "DiaChi"
        cldiachi.HeaderText = "Địa chỉ"
        cldiachi.DataPropertyName = "DiaChi"
        dtgvDanhsach.Columns.Add(cldiachi)

        Dim cldienthoai = New DataGridViewTextBoxColumn()
        cldienthoai.Name = "DienThoai"
        cldienthoai.HeaderText = "Điện thoại"
        cldienthoai.DataPropertyName = "DienThoai"
        dtgvDanhsach.Columns.Add(cldienthoai)

        Dim clhieuxe = New DataGridViewTextBoxColumn()
        clhieuxe.Name = "HieuXe"
        clhieuxe.HeaderText = "Hiệu xe"
        clhieuxe.DataPropertyName = "HieuXe"
        dtgvDanhsach.Columns.Add(clhieuxe)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'button tiep nhan
        Dim khachhangDTO As New KhachHangDTO()
        Dim thongtinxeDTO As New ThongTinXeDTO()
        Dim phieutiepnhanDTO As New PhieuTiepNhanDTO()
        Dim result As Result
        'thông tin khách hàng
        khachhangDTO.TenKH = tbTenCxe.Text
        khachhangDTO.DiaChi = tbDiaChi.Text
        khachhangDTO.DienThoai = tbDienThoai.Text
        'thông tin xe
        thongtinxeDTO.BienSo = tbBsoxe.Text
        'thông tin phiếu tiếp nhận

        phieutiepnhanDTO.MaPhieu = tbMaphieu.Text
        phieutiepnhanDTO.NgayTiepNhan = dtpNgTiepNhan.Value

        'kiểm tra số lượng xe tiếp nhận
        If (phieutiepnhanBUS.isvalidNumber() = False) Then
            MessageBox.Show("Vượt quá số lượng xe tiếp nhận sửa chữa trong ngày")
            Return
        End If

        'kiểm tra khách hàng đã có trong danh sách hay chưa
        'nếu chưa có thì lưu thông tin khách hàng
        If (khachhangBUS.isvalidKhachHang(khachhangDTO) = False) Then
            khachhangDTO.MaKH = tbMaCxe.Text
            khachhangDTO.TienNo = 0
            result = khachhangBUS.Insert(khachhangDTO)
            If (result.FlagResult = True) Then
                MessageBox.Show("Thêm khách hàng thành công.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Thêm khách hàng không thành công.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If
        End If

        'kiểm tra đã biển số xe này đã có chưa 
        'nếu chưa có thì lưu lại đồng thời lưu phiếu tiếp nhận mới
        If (thongtinxeBUS.isvalidthongtinxe(thongtinxeDTO) = False) Then
            Dim nextmattxe = "1"
            thongtinxeBUS.BuildMaTTXe(nextmattxe)
            thongtinxeDTO.MaTTXe = nextmattxe
            thongtinxeDTO.MaKH = khachhangDTO.MaKH
            thongtinxeDTO.MaHX = cbHieuxe.SelectedValue
            result = thongtinxeBUS.Insert(thongtinxeDTO)
            If (result.FlagResult = True) Then
                MessageBox.Show("Thêm thông tin xe thành công.", "Information",
                               MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Thêm thông tin xe không thành công.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

        Else
            Dim listofthongtinxe As New List(Of ThongTinXeDTO)()
            LoadListofthongtinxe(listofthongtinxe)
            For i As Integer = 0 To listofthongtinxe.Count
                If (listofthongtinxe.ElementAt(i).BienSo = tbBsoxe.Text) Then
                    phieutiepnhanDTO.MaTTXe = listofthongtinxe.ElementAt(i).MaTTXe
                    Exit For
                End If
            Next
        End If

        'insert PHIEUTN
        result = phieutiepnhanBUS.Insert(phieutiepnhanDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm phiếu tiếp nhận thành công.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim nextMaphieu = "1"
            result = phieutiepnhanBUS.BuildMaPhieuTN(nextMaphieu)
            tbMaphieu.Text = nextMaphieu

        Else
            MessageBox.Show("Thêm phiếu tiếp nhận không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)

        End If

        'Cập nhật danh sách hồ sơ sửa chữa
        Dim listofHoSoSuaChua As List(Of HoSoSuaChuaDTO)
        listofHoSoSuaChua = New List(Of HoSoSuaChuaDTO)()
        result = hososuachuaBUS.SelectALL(listofHoSoSuaChua)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy hồ sơ sửa chữa không thành công",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        dtgvDanhsach.Columns.Clear()
        dtgvDanhsach.DataSource = Nothing

        dtgvDanhsach.AutoGenerateColumns = False
        dtgvDanhsach.AllowUserToAddRows = False
        dtgvDanhsach.DataSource = listofHoSoSuaChua

        Dim clbienso = New DataGridViewTextBoxColumn()
        clbienso.Name = "BienSo"
        clbienso.HeaderText = "Biển số"
        clbienso.DataPropertyName = "BienSo"
        dtgvDanhsach.Columns.Add(clbienso)

        Dim cltenchuxe = New DataGridViewTextBoxColumn()
        cltenchuxe.Name = "TenChuXe"
        cltenchuxe.HeaderText = "Tên chủ xe"
        cltenchuxe.DataPropertyName = "TenChuXe"
        dtgvDanhsach.Columns.Add(cltenchuxe)

        Dim cldiachi = New DataGridViewTextBoxColumn()
        cldiachi.Name = "DiaChi"
        cldiachi.HeaderText = "Địa chỉ"
        cldiachi.DataPropertyName = "DiaChi"
        dtgvDanhsach.Columns.Add(cldiachi)

        Dim cldienthoai = New DataGridViewTextBoxColumn()
        cldienthoai.Name = "DienThoai"
        cldienthoai.HeaderText = "Điện thoại"
        cldienthoai.DataPropertyName = "DienThoai"
        dtgvDanhsach.Columns.Add(cldienthoai)

        Dim clhieuxe = New DataGridViewTextBoxColumn()
        clhieuxe.Name = "HieuXe"
        clhieuxe.HeaderText = "Hiệu xe"
        clhieuxe.DataPropertyName = "HieuXe"
        dtgvDanhsach.Columns.Add(clhieuxe)
    End Sub
End Class
