Imports QLGARABUS
Imports QLGARADTO
Imports Utility
Public Class FrmTraCuu
    Private danhsachxeBUS As New DanhSachXeBUS()
    Private hieuxeBUS As New HieuXeBUS()

    Private Sub FrmTraCuu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListofHieuXe()
    End Sub

    Public Sub LoadListofHieuXe()
        Dim ListofHieuXe As New List(Of HieuXeDTO)()
        Dim result As Result
        result = hieuxeBUS.SelectAll(ListofHieuXe)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách hiệu xe sinh không thành công.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        cbHieuXe.DataSource = ListofHieuXe
        cbHieuXe.DisplayMember = "TenHX"
        cbHieuXe.ValueMember = "MaHX"
    End Sub
    Public Sub LoadListofDanhSachXe(ListofDanhSachXe As List(Of DanhSachXeDTO))
        dgvDanhSachXe.Columns.Clear()
        dgvDanhSachXe.DataSource = Nothing

        dgvDanhSachXe.AutoGenerateColumns = False
        dgvDanhSachXe.AllowUserToAddRows = False
        dgvDanhSachXe.DataSource = ListofDanhSachXe

        Dim clBienSo As New DataGridViewTextBoxColumn()
        clBienSo.Name = "BienSo"
        clBienSo.HeaderText = "Biển số"
        clBienSo.DataPropertyName = "BienSo"
        dgvDanhSachXe.Columns.Add(clBienSo)

        Dim clHieuXe As New DataGridViewTextBoxColumn()
        clHieuXe.Name = "TenHX"
        clHieuXe.HeaderText = "Hiệu xe"
        clHieuXe.DataPropertyName = "HieuXe"
        dgvDanhSachXe.Columns.Add(clHieuXe)

        Dim clChuXe As New DataGridViewTextBoxColumn()
        clChuXe.Name = "TenKH"
        clChuXe.HeaderText = "Chủ xe"
        clChuXe.DataPropertyName = "ChuXe"
        dgvDanhSachXe.Columns.Add(clChuXe)

        Dim clTienNo As New DataGridViewTextBoxColumn()
        clTienNo.Name = "TienNo"
        clTienNo.HeaderText = "Tiền nợ"
        clTienNo.DataPropertyName = "TienNo"
        dgvDanhSachXe.Columns.Add(clTienNo)


    End Sub

    Private Sub btTraCuu_Click(sender As Object, e As EventArgs) Handles btTraCuu.Click
        Dim ListofDanhSachXe As New List(Of DanhSachXeDTO)()
        Dim result As Result

        'If (tbBienSo.Text.Trim <> "") Then
        '    result = danhsachxeBUS.Select_By_BienSo(tbBienSo.Text, ListofDanhSachXe)
        'End If

        'If (cbHieuXe.SelectedValue <> "") Then
        '    result = danhsachxeBUS.Select_By_HieuXe(cbHieuXe.SelectedValue, ListofDanhSachXe)
        'End If

        'If (tbMaKH.Text.Trim <> "") Then
        '    result = danhsachxeBUS.Select_By_MaKH(tbMaKH.Text, ListofDanhSachXe)
        'End If

        'If (tbMaTTXe.Text.Trim <> "") Then
        '    result = danhsachxeBUS.Select_By_MaTTXe(tbMaTTXe.Text, ListofDanhSachXe)
        'End If

        'If (tbTenKH.Text.Trim <> "") Then
        '    result = danhsachxeBUS.Select_By_TenKH(tbTenKH.Text, ListofDanhSachXe)
        'End If

        If (tbTienNoMin.Text.Trim <> "" And tbTienNoMax.Text.Trim <> "") Then
            result = danhsachxeBUS.Select_By_TienNo(Convert.ToDouble(tbTienNoMin.Text),
                                                      Convert.ToDouble(tbTienNoMax.Text), ListofDanhSachXe)
        End If

        result = danhsachxeBUS.Select_DanhSachXe(tbMaTTXe.Text, tbBienSo.Text, cbHieuXe.SelectedValue,
                                                  tbTenKH.Text, tbMaKH.Text,
                                                   ListofDanhSachXe)

        If (result.FlagResult = False) Then
            MessageBox.Show("Không tìm được danh sách xe cần tìm ", "Error", MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        LoadListofDanhSachXe(ListofDanhSachXe)
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        Dim ListofDanhSachXe As New List(Of DanhSachXeDTO)()
        LoadListofDanhSachXe(ListofDanhSachXe)
    End Sub
End Class