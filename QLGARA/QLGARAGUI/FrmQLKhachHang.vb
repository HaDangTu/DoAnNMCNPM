﻿Imports QLGARADTO
Imports QLGARABUS
Imports Utility
Public Class FrmQLKhachHang
    Dim khachhangBUS As New KhachHangBUS()
    Private Sub QLKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim nextMaKH = "1"
        khachhangBUS.BuildMaKH(nextMaKH)
        tbMaKH.Text = nextMaKH


        Dim listofkhachhang As New List(Of KhachHangDTO)()
        listofkhachhang = khachhangBUS.SelectALL()

        dgvDanhSachKH.Columns.Clear()
        dgvDanhSachKH.DataSource = Nothing

        dgvDanhSachKH.AutoGenerateColumns = False
        dgvDanhSachKH.AllowUserToAddRows = False
        dgvDanhSachKH.DataSource = listofkhachhang

        Dim clMaKH = New DataGridViewTextBoxColumn()
        clMaKH.Name = "MaKH"
        clMaKH.HeaderText = " Mã khách hàng"
        clMaKH.DataPropertyName = "MaKH"
        dgvDanhSachKH.Columns.Add(clMaKH)

        Dim clTenKH = New DataGridViewTextBoxColumn()
        clTenKH.Name = "TenKH"
        clTenKH.HeaderText = "Tên khách hàng"
        clTenKH.DataPropertyName = "TenKH"
        dgvDanhSachKH.Columns.Add(clTenKH)

        Dim cldiachi = New DataGridViewTextBoxColumn()
        cldiachi.Name = "DiaChi"
        cldiachi.HeaderText = "Địa chỉ"
        cldiachi.DataPropertyName = "DiaChi"
        dgvDanhSachKH.Columns.Add(cldiachi)

        Dim cldienthoai = New DataGridViewTextBoxColumn()
        cldienthoai.Name = "DienThoai"
        cldienthoai.HeaderText = "Điện thoại"
        cldienthoai.DataPropertyName = "DienThoai"
        dgvDanhSachKH.Columns.Add(cldienthoai)

        Dim clTienNo = New DataGridViewTextBoxColumn()
        clTienNo.Name = "TienNo"
        clTienNo.HeaderText = "Tiền nợ"
        clTienNo.DataPropertyName = "TienNo"
        dgvDanhSachKH.Columns.Add(clTienNo)
    End Sub

    Private Sub btThem_Click(sender As Object, e As EventArgs) Handles btThem.Click
        Dim khachhangDTO As New KhachHangDTO()
        khachhangDTO.MaKH = tbMaKH.Text
        khachhangDTO.TenKH = tbTenKH.Text
        khachhangDTO.DiaChi = tbDiaChi.Text
        khachhangDTO.DienThoai = tbDienThoai.Text
        khachhangDTO.TienNo = Convert.ToInt64(tbTienNo.Text)

        Dim result As Result
        result = khachhangBUS.Insert(khachhangDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm khách hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'set MSSH auto
            Dim nextMaKH = "1"
            result = khachhangBUS.BuildMaKH(nextMaKH)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh tự động mã khách hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            tbMaKH.Text = nextMaKH
            tbTenKH.Text = String.Empty
            tbDiaChi.Text = String.Empty
            tbDienThoai.Text = String.Empty
            tbTienNo.Text = String.Empty
        Else
            MessageBox.Show("Thêm khách hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        Dim listofkhachhang As New List(Of KhachHangDTO)()
        listofkhachhang = khachhangBUS.SelectALL()

        dgvDanhSachKH.Columns.Clear()
        dgvDanhSachKH.DataSource = Nothing

        dgvDanhSachKH.AutoGenerateColumns = False
        dgvDanhSachKH.AllowUserToAddRows = False
        dgvDanhSachKH.DataSource = listofkhachhang

        Dim clMaKH = New DataGridViewTextBoxColumn()
        clMaKH.Name = "MaKH"
        clMaKH.HeaderText = " Mã khách hàng"
        clMaKH.DataPropertyName = "MaKH"
        dgvDanhSachKH.Columns.Add(clMaKH)

        Dim clTenKH = New DataGridViewTextBoxColumn()
        clTenKH.Name = "TenKH"
        clTenKH.HeaderText = "Tên khách hàng"
        clTenKH.DataPropertyName = "TenKH"
        dgvDanhSachKH.Columns.Add(clTenKH)

        Dim cldiachi = New DataGridViewTextBoxColumn()
        cldiachi.Name = "DiaChi"
        cldiachi.HeaderText = "Địa chỉ"
        cldiachi.DataPropertyName = "DiaChi"
        dgvDanhSachKH.Columns.Add(cldiachi)

        Dim cldienthoai = New DataGridViewTextBoxColumn()
        cldienthoai.Name = "DienThoai"
        cldienthoai.HeaderText = "Điện thoại"
        cldienthoai.DataPropertyName = "DienThoai"
        dgvDanhSachKH.Columns.Add(cldienthoai)

        Dim clTienNo = New DataGridViewTextBoxColumn()
        clTienNo.Name = "TienNo"
        clTienNo.HeaderText = "Tiền nợ"
        clTienNo.DataPropertyName = "TienNo"
        dgvDanhSachKH.Columns.Add(clTienNo)
    End Sub

    Private Sub btcapnhat_Click(sender As Object, e As EventArgs) Handles btcapnhat.Click
        Dim khachhangDTO As New KhachHangDTO()
        khachhangDTO.MaKH = tbMaKH.Text
        khachhangDTO.TenKH = tbTenKH.Text
        khachhangDTO.DiaChi = tbDiaChi.Text
        khachhangDTO.DienThoai = tbDienThoai.Text
        khachhangDTO.TienNo = Convert.ToInt64(tbTienNo.Text)

        Dim result As Result
        result = khachhangBUS.Update(khachhangDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Cập nhật khách hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'set MSSH auto
            Dim nextMaKH = "1"
            result = khachhangBUS.BuildMaKH(nextMaKH)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh tự động mã khách hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            tbMaKH.Text = nextMaKH
            tbTenKH.Text = String.Empty
            tbDiaChi.Text = String.Empty
            tbDienThoai.Text = String.Empty
            tbTienNo.Text = String.Empty
        Else
            MessageBox.Show("Thêm khách hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        Dim listofkhachhang As New List(Of KhachHangDTO)()
        listofkhachhang = khachhangBUS.SelectALL()

        dgvDanhSachKH.Columns.Clear()
        dgvDanhSachKH.DataSource = Nothing

        dgvDanhSachKH.AutoGenerateColumns = False
        dgvDanhSachKH.AllowUserToAddRows = False
        dgvDanhSachKH.DataSource = listofkhachhang

        Dim clMaKH = New DataGridViewTextBoxColumn()
        clMaKH.Name = "MaKH"
        clMaKH.HeaderText = " Mã khách hàng"
        clMaKH.DataPropertyName = "MaKH"
        dgvDanhSachKH.Columns.Add(clMaKH)

        Dim clTenKH = New DataGridViewTextBoxColumn()
        clTenKH.Name = "TenKH"
        clTenKH.HeaderText = "Tên khách hàng"
        clTenKH.DataPropertyName = "TenKH"
        dgvDanhSachKH.Columns.Add(clTenKH)

        Dim cldiachi = New DataGridViewTextBoxColumn()
        cldiachi.Name = "DiaChi"
        cldiachi.HeaderText = "Địa chỉ"
        cldiachi.DataPropertyName = "DiaChi"
        dgvDanhSachKH.Columns.Add(cldiachi)

        Dim cldienthoai = New DataGridViewTextBoxColumn()
        cldienthoai.Name = "DienThoai"
        cldienthoai.HeaderText = "Điện thoại"
        cldienthoai.DataPropertyName = "DienThoai"
        dgvDanhSachKH.Columns.Add(cldienthoai)

        Dim clTienNo = New DataGridViewTextBoxColumn()
        clTienNo.Name = "TienNo"
        clTienNo.HeaderText = "Tiền nợ"
        clTienNo.DataPropertyName = "TienNo"
        dgvDanhSachKH.Columns.Add(clTienNo)
    End Sub

    Private Sub btXoa_Click(sender As Object, e As EventArgs) Handles btXoa.Click

    End Sub
End Class