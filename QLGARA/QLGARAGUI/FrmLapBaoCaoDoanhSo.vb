Imports QLGARABUS
Imports QLGARADTO
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports Utility

Public Class FrmLapBaoCaoDoanhSo
    Private doanhsoBUS As New DoanhSoBUS()
    Private ttdoanhsoBUS As New TTDoanhSoBUS()

    Public Sub LoadListofLuotSuaChua(thang As Integer, nam As Integer, ByRef ListofLuotSuaChua As List(Of LuotSuaChuaDTO))
        ListofLuotSuaChua = doanhsoBUS.SoLuotSC_1_HieuXe(thang, nam)
    End Sub

    Public Sub LoadListofThanhTien(thang As Integer, nam As Integer, ByRef ListofThanhTien As List(Of ThanhTienDTO))
        ListofThanhTien = doanhsoBUS.ThanhTien(thang, nam)
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
        LoadListofLuotSuaChua(dtpThang.Value.Month, dtpThang.Value.Year, ListofLuotSuaChua)
        LoadListofThanhTien(dtpThang.Value.Month, dtpThang.Value.Year, ListofThanhTien)

        doanhsoDTO.MaDoanhSo = tbMaDoanhSo.Text
        doanhsoDTO.Thang = Convert.ToInt16(dtpThang.Value.Month)
        doanhsoDTO.TongDoanhThu = doanhsoBUS.TongDoanhThu(doanhsoDTO.Thang, dtpThang.Value.Year)


        'kiểm tra tháng có hợp lệ hay không
        If (doanhsoBUS.isvalidMonth(doanhsoDTO.Thang, dtpThang.Value.Year) = False) Then
            MessageBox.Show("Tháng không hợp lệ ", "Error", MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            Return
        End If

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
                                                       0, Suachua.SoLuotSuaChua / doanhsoBUS.TongSoLuotSua(doanhsoDTO.Thang, dtpThang.Value.Year),
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
        tbTongDoanhSo.Text = doanhsoDTO.TongDoanhThu.ToString()
        LoadDGVDoanhSo(ListofThongTinDoanhSo)
    End Sub

    Private Sub FrmLapBaoCaoDoanhSo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ListofThongTinDoanhSo As New List(Of TTDoanhSoDTO)()
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
        LoadDGVDoanhSo(ListofThongTinDoanhSo)
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

    Private Sub btPrint_Click(sender As Object, e As EventArgs) Handles btPrint.Click
        If (dgvDoanhSo.ColumnCount = 0 Or dgvDoanhSo.RowCount = 0) Then
            MessageBox.Show("DataGridView trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim dataset As New DataSet
        Dim i = 0, j = 0
        dataset.Tables.Add()

        For i = 0 To dgvDoanhSo.ColumnCount - 1
            dataset.Tables(0).Columns.Add(dgvDoanhSo.Columns(i).HeaderText)
        Next

        Dim datarow As DataRow
        For i = 0 To dgvDoanhSo.RowCount - 1
            datarow = dataset.Tables(0).NewRow

            For j = 0 To dgvDoanhSo.ColumnCount - 1
                datarow(j) = dgvDoanhSo.Rows(i).Cells(j).Value
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
        Dim rowIndex As Integer = 3

        Excel.Cells(1, 3) = "BÁO CÁO DOANH SỐ"

        Excel.Cells(2, 2) = "Tháng"
        Excel.Cells(2, 3) = dtpThang.Value.Month

        Excel.Cells(3, 2) = "Tổng doanh số"
        Excel.Cells(3, 3) = tbTongDoanhSo.Text

        For Each datacolumn In datatable.Columns
            colIndex = colIndex + 1
            Excel.Cells(4, colIndex) = datacolumn.ColumnName
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
        Dim fileName As String = "F:\Nhập môn CNPM\Thực hành\DoAN\DoAnNMCNPM\QLGARA\BaoCaoDoanhSo.xlsx"
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