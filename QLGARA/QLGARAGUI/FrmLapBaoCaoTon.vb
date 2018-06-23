Imports QLGARABUS
Imports QLGARADTO
Imports Microsoft.Office.Interop.Excel
Imports System.IO
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
        LoadListofTong_SL_DaSC(Integer.Parse(cbThang.SelectedValue), ListofTong_SL_DaSC)
        LoadListofTong_SLPS(Integer.Parse(cbThang.SelectedValue), ListofTong_SLPS)
        LoadListofSLNhap(Integer.Parse(cbThang.SelectedValue), ListofSoLuongNhap)
        LoadListofTonCuoi(Integer.Parse(cbThang.SelectedValue) - 1, ListofTonCuoi) 'Tồn cuối của tháng trước

        'Mapping Data
        baocaotonDTO.MaBaoCaoTon = tbMaBaoCaoTon.Text
        baocaotonDTO.Thang = Integer.Parse(cbThang.SelectedValue)

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
            If (i < ListofTong_SLPS.Count) Then
                ListofTTbaocaotonDTO.Item(n) = New TTBaoCaoTonDTO(ListofTTbaocaotonDTO.ElementAt(n).MaTTBaoCaoTon,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).TenPhuTung,
                                             ListofTTbaocaotonDTO.ElementAt(n).TonDau, ListofTong_SLPS.ElementAt(i),
                                             ListofTTbaocaotonDTO.ElementAt(n).TonDau + ListofTong_SLPS.ElementAt(i) -
                                             0,
                                             ListofTTbaocaotonDTO.ElementAt(i).MaBaoCaoTon)
                i = i + 1
            End If
            If (j < ListofTong_SL_DaSC.Count) Then
                ListofTTbaocaotonDTO.Item(n) = New TTBaoCaoTonDTO(ListofTTbaocaotonDTO.ElementAt(n).MaTTBaoCaoTon,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).TenPhuTung,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).TonDau,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).PhatSinh,
                                                                  ListofTTbaocaotonDTO.ElementAt(n).TonDau +
                                                                  ListofTTbaocaotonDTO.ElementAt(n).PhatSinh -
                                                                  ListofTong_SL_DaSC.ElementAt(j),
                                                                  ListofTTbaocaotonDTO.ElementAt(i).MaBaoCaoTon)
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

        Dim ListofMonth As New List(Of Integer)()
        ListofMonth.Add(1)
        ListofMonth.Add(2)
        ListofMonth.Add(3)
        ListofMonth.Add(4)
        ListofMonth.Add(5)
        ListofMonth.Add(6)
        ListofMonth.Add(7)
        ListofMonth.Add(8)
        ListofMonth.Add(9)
        ListofMonth.Add(10)
        ListofMonth.Add(11)
        ListofMonth.Add(12)

        cbThang.DataSource = ListofMonth
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Dim ListofTTBaocaoton As New List(Of TTBaoCaoTonDTO)()
        loaddgvBaoCaoTon(ListofTTBaocaoton)

        'tbThang.Text = String.Empty
    End Sub

    Private Sub btPrint_Click(sender As Object, e As EventArgs) Handles btPrint.Click
        If (dgvBaoCaoTon.ColumnCount = 0 Or dgvBaoCaoTon.RowCount = 0) Then
            MessageBox.Show("DataGridView trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim dataset As New DataSet
        Dim i = 0, j = 0
        dataset.Tables.Add()

        For i = 0 To dgvBaoCaoTon.ColumnCount - 1
            dataset.Tables(0).Columns.Add(dgvBaoCaoTon.Columns(i).HeaderText)
        Next

        Dim datarow As DataRow
        For i = 0 To dgvBaoCaoTon.RowCount - 1
            datarow = dataset.Tables(0).NewRow

            For j = 0 To dgvBaoCaoTon.ColumnCount - 1
                datarow(j) = dgvBaoCaoTon.Rows(i).Cells(j).Value
            Next

            dataset.Tables(0).Rows.Add(datarow)
        Next

        Dim Excel As New ApplicationClass
        Dim WBook As Workbook
        Dim WSheet As Worksheet

        WBook = Excel.Workbooks.Add()
        WSheet = WBook.ActiveSheet()

        Dim datatable As Data.DataTable = dataset.Tables(0)
        Dim datacolumn As DataColumn
        Dim datarow1 As DataRow

        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 2

        Excel.Cells(1, 3) = "BÁO CÁO TỒN"

        Excel.Cells(2, 1) = "Tháng"
        Excel.Cells(2, 2) = cbThang.SelectedValue

        For Each datacolumn In datatable.Columns
            colIndex = colIndex + 1
            Excel.Cells(3, colIndex) = datacolumn.ColumnName
        Next

        For Each datarow1 In datatable.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each datacolumn In datatable.Columns
                colIndex = colIndex + 1
                Excel.Cells(rowIndex + 1, colIndex) = datarow1(datacolumn.ColumnName)
            Next
        Next

        WSheet.Columns.AutoFit()
        Dim fileName As String = "F:\Nhập môn CNPM\Thực hành\DoAN\DoAnNMCNPM\QLGARA\BaoCaoTon.xlsx"
        Dim FileOpen As Boolean = False

        Try
            Dim filetmp As FileStream = File.OpenWrite(fileName)
            filetmp.Close()
        Catch ex As Exception
            FileOpen = False
        End Try

        If File.Exists(fileName) Then
            File.Delete(fileName)
        End If

        WBook.SaveAs(fileName)
        Excel.Workbooks.Open(fileName)
        Excel.Visible = True
    End Sub
End Class