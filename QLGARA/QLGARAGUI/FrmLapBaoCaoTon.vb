﻿Imports QLGARABUS
Imports QLGARADTO
Imports Utility

Public Class FrmLapBaoCaoTon
    Private baocaotonBUS As New BaoCaoTonBUS()
    Private ttbaocaotonBUS As New TTBaoCaoTonBUS()
    Private ttnhapphutung As New TTNhapPhuTungBUS()
    Public Sub LoadListofPhuTung(ByRef ListofPhuTung As List(Of PhuTungDTO))
        Dim phutungbus As New PhuTungBUS()
        ListofPhuTung = phutungbus.Sellect_All()
    End Sub

    Public Sub LoadListofTong_SL_DaSC(Thang As Integer, ByRef ListofTong_SL_DaSC As List(Of Integer))
        Dim result As Result
        result = baocaotonBUS.Tong_SL_DaSC(Thang, ListofTong_SL_DaSC)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy tổng số lượng đã sửa chữa của từng loại phụ tùng thất bại", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
    End Sub

    Public Sub LoadListofTong_SLPS(Thang As Integer, ByRef ListofTong_SLPS As List(Of Integer))
        Dim result As Result
        result = baocaotonBUS.Tong_SLPS(Thang, ListofTong_SLPS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy tổng số lượng phát sinh của từng loại phụ tùng thất bại", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
    End Sub

    Public Sub LoadListofTonCuoi(Thang As Integer, ByRef ListofTonCuoi As List(Of Integer))
        Dim result As Result
        result = baocaotonBUS.Select_TonCuoi_byThang(Thang, ListofTonCuoi)
        If (result.FlagResult = False) Then
            'MessageBox.Show("Lấy số lượng tồn cuối của từng loại phụ tùng thất bại", "Error",
            '                MessageBoxButtons.OK, MessageBoxIcon.Error)
            'System.Console.WriteLine(result.SystemMessage)
            'Return
            ListofTonCuoi = Nothing
        End If
    End Sub

    Public Sub LoadListofSLNhap(Thang As Integer, ByRef ListofSoLuongNhap As List(Of Integer))
        Dim result As Result
        result = ttnhapphutung.Select_SoLuongNhap(Thang, ListofSoLuongNhap)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy số lượng nhập của từng loại phụ tùng thất bại", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
    End Sub

    Public Sub loaddgvBaoCaoTon(ListofTTBaocaoton As List(Of TTBaoCaoTonDTO))
        dgvBaoCaoTon.Columns.Clear()
        dgvBaoCaoTon.DataSource = Nothing

        dgvBaoCaoTon.AutoGenerateColumns = False
        dgvBaoCaoTon.AllowUserToAddRows = False
        dgvBaoCaoTon.DataSource = ListofTTBaocaoton

        Dim clVatTuPhuTung As New DataGridViewTextBoxColumn()
        clVatTuPhuTung.Name = "VatTuPhuTung"
        clVatTuPhuTung.HeaderText = "Vật tư, phụ tùng"
        clVatTuPhuTung.DataPropertyName = "TenPhuTung"
        dgvBaoCaoTon.Columns.Add(clVatTuPhuTung)

        Dim clTonDau As New DataGridViewTextBoxColumn()
        clTonDau.Name = "TonDau"
        clTonDau.HeaderText = "Tồn đầu"
        clTonDau.DataPropertyName = "TonDau"
        dgvBaoCaoTon.Columns.Add(clTonDau)

        Dim clPhatSinh As New DataGridViewTextBoxColumn()
        clPhatSinh.Name = "PhatSinh"
        clPhatSinh.HeaderText = "Phát sinh"
        clPhatSinh.DataPropertyName = "PhatSinh"
        dgvBaoCaoTon.Columns.Add(clPhatSinh)

        Dim clTonCuoi As New DataGridViewTextBoxColumn()
        clTonCuoi.Name = "TonCuoi"
        clTonCuoi.HeaderText = "Tồn cuối"
        clTonCuoi.DataPropertyName = "TonCuoi"
        dgvBaoCaoTon.Columns.Add(clTonCuoi)
    End Sub

    Private Sub btLapBaoCao_Click(sender As Object, e As EventArgs) Handles btLapBaoCao.Click
        Dim baocaotonDTO As New BaoCaoTonDTO()
        Dim ListofPhuTung As New List(Of PhuTungDTO)()
        Dim ListofTong_SL_DaSC As New List(Of Integer)()
        Dim ListofTong_SLPS As New List(Of Integer)()
        Dim ListofTTbaocaotonDTO As New List(Of TTBaoCaoTonDTO)()
        Dim ListofSoLuongNhap As New List(Of Integer)()
        Dim ListofTonCuoi As New List(Of Integer)()
        Dim i = 0, j = 0

        'loadList
        LoadListofPhuTung(ListofPhuTung)
        LoadListofTong_SL_DaSC(Integer.Parse(tbThang.Text), ListofTong_SL_DaSC)
        LoadListofTong_SLPS(Integer.Parse(tbThang.Text), ListofTong_SLPS)
        LoadListofSLNhap(Integer.Parse(tbThang.Text), ListofSoLuongNhap)
        LoadListofTonCuoi(Integer.Parse(tbThang.Text) - 1, ListofTonCuoi) 'Tồn cuối của tháng trước

        'Mapping Data
        baocaotonDTO.MaBaoCaoTon = tbMaBaoCaoTon.Text
        baocaotonDTO.Thang = Integer.Parse(tbThang.Text)

        For Each phutung As PhuTungDTO In ListofPhuTung
            Dim nextMaTTBaoCaoTon = "1"
            ttbaocaotonBUS.BuildMaTTBaoCaoTon(nextMaTTBaoCaoTon)
            ListofTTbaocaotonDTO.Add(New TTBaoCaoTonDTO(nextMaTTBaoCaoTon, phutung.TenPhuTung, 0, 0, 0,
                                                        baocaotonDTO.MaBaoCaoTon))
        Next

        'Tính Tồn đầu
        For n As Integer = 0 To ListofTTbaocaotonDTO.Count - 1

            If (IsNothing(ListofTonCuoi) = False) Then
                If (i < ListofTonCuoi.Count And
                    j < ListofSoLuongNhap.Count) Then
                    ListofTTbaocaotonDTO.Item(n) = New TTBaoCaoTonDTO(ListofTTbaocaotonDTO.ElementAt(n).MaTTBaoCaoTon,
                                                                      ListofTTbaocaotonDTO.ElementAt(n).TenPhuTung,
    ListofTonCuoi.ElementAt(i) + ListofSoLuongNhap.ElementAt(j), 0, 0, ListofTTbaocaotonDTO.ElementAt(n).MaBaoCaoTon)
                    i = i + 1
                    j = j + 1
                End If
            Else
                If (j < ListofSoLuongNhap.Count) Then
                    ListofTTbaocaotonDTO.Item(n) = New TTBaoCaoTonDTO(ListofTTbaocaotonDTO.ElementAt(n).MaTTBaoCaoTon,
                                                                      ListofTTbaocaotonDTO.ElementAt(n).TenPhuTung,
    ListofSoLuongNhap.ElementAt(j), 0, 0, ListofTTbaocaotonDTO.ElementAt(n).MaBaoCaoTon)
                    j = j + 1
                End If
            End If

        Next
        i = 0
        j = 0
        'Tính Phát sinh + TonCuoi
        For n As Integer = 0 To ListofTTbaocaotonDTO.Count - 1
            If (i < ListofTong_SLPS.Count Or j < ListofTong_SL_DaSC.Count) Then
                ListofTTbaocaotonDTO.Item(n) = New TTBaoCaoTonDTO(ListofTTbaocaotonDTO.ElementAt(n).MaTTBaoCaoTon,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).TenPhuTung,
                                             ListofTTbaocaotonDTO.ElementAt(n).TonDau, ListofTong_SLPS.ElementAt(i),
                                             ListofTTbaocaotonDTO.ElementAt(n).TonDau + ListofTong_SLPS.ElementAt(i) -
                                             ListofTong_SL_DaSC.ElementAt(j),
                                             ListofTTbaocaotonDTO.ElementAt(i).MaBaoCaoTon)
                i = i + 1
                j = j + 1
            End If
        Next
        i = 0
        j = 0
        'Kiểm tra tháng nhập vào có hợp lệ hay không
        If (baocaotonBUS.isValidThang(baocaotonDTO.Thang) = False) Then
            MessageBox.Show("Tháng không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Insert BAOCAOTON + TTBAOCAOTON
        Dim result As Result
        result = baocaotonBUS.Insert(baocaotonDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Lập báo cáo tồn thành công", "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Dim nextMaBaoCaoTon = "1"
            result = baocaotonBUS.BuildMaBaoCaoTon(nextMaBaoCaoTon)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy mã báo cáo tồn kế tiếp không thành công", "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If
            tbMaBaoCaoTon.Text = nextMaBaoCaoTon
        Else
            MessageBox.Show("Lập báo cáo tồn không thành công", "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        For Each ttbaocaoton As TTBaoCaoTonDTO In ListofTTbaocaotonDTO
            result = ttbaocaotonBUS.Insert(ttbaocaoton)
            If (result.FlagResult = True) Then
                MessageBox.Show("Nhập thông tin báo cáo tồn thành công", "Infomation", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nhập thông tin báo cáo tồn không thành công", "Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If
        Next

        'loadListBaocaoton
        loaddgvBaoCaoTon(ListofTTbaocaotonDTO)

    End Sub

    Private Sub FrmLapBaoCaoTon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ListofTTBaocaoton As New List(Of TTBaoCaoTonDTO)()
        loaddgvBaoCaoTon(ListofTTBaocaoton)
        Dim nextMaBaoCaoTon = "1"
        Dim result = baocaotonBUS.BuildMaBaoCaoTon(nextMaBaoCaoTon)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy mã báo cáo tồn kế tiếp không thành công", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
        tbMaBaoCaoTon.Text = nextMaBaoCaoTon
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Dim ListofTTBaocaoton As New List(Of TTBaoCaoTonDTO)()
        loaddgvBaoCaoTon(ListofTTBaocaoton)
        tbThang.Text = String.Empty
    End Sub
End Class