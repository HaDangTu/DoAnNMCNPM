Imports QLGARADTO
Imports QLGARABUS
Imports Utility

Public Class FrmQLHieuXe
    Private hieuxeBUS As New HieuXeBUS()

    Public Function loadListofHieuXe(ByRef ListofHieuXe As List(Of HieuXeDTO))
        hieuxeBUS.SelectAll(ListofHieuXe)
    End Function
    Private Sub FrmQLHieuXe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'load danh sách hiệu xe
        Dim ListofHieuXe As New List(Of HieuXeDTO)()
        loadListofHieuXe(ListofHieuXe)
        dgvDSHX.Columns.Clear()
        dgvDSHX.DataSource = Nothing

        dgvDSHX.AutoGenerateColumns = False
        dgvDSHX.AllowUserToAddRows = False
        dgvDSHX.DataSource = ListofHieuXe

        Dim clMaHX As New DataGridViewTextBoxColumn()
        clMaHX.Name = "MaHX"
        clMaHX.HeaderText = "Mã hiệu xe"
        clMaHX.DataPropertyName = "MaHX"
        dgvDSHX.Columns.Add(clMaHX)

        Dim clTenHX As New DataGridViewTextBoxColumn()
        clTenHX.Name = "TenHX"
        clTenHX.HeaderText = "Tên hiệu xe"
        clTenHX.DataPropertyName = "TenHX"
        dgvDSHX.Columns.Add(clTenHX)

        Dim cLNhanSua As New DataGridViewTextBoxColumn()
        cLNhanSua.Name = "NhanSua"
        cLNhanSua.HeaderText = "Nhận sửa"
        cLNhanSua.DataPropertyName = "NhanSua"
        dgvDSHX.Columns.Add(cLNhanSua)

        'build next MaHX
        Dim nextMaHX = "1"
        hieuxeBUS.BuildMaHX(nextMaHX)
        tbMaHX.Text = nextMaHX

    End Sub

    Private Sub btThem_Click(sender As Object, e As EventArgs) Handles btThem.Click
        Dim hieuxeDTO As New HieuXeDTO()
        hieuxeDTO.MaHX = tbMaHX.Text
        hieuxeDTO.TenHX = tbTenHX.Text

        If (rbYes.Checked = True) Then
            hieuxeDTO.NhanSua = rbYes.Text
        Else
            hieuxeDTO.NhanSua = rbNo.Text
        End If

        Dim result As Result
        result = hieuxeBUS.Insert(hieuxeDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm hiệu xe thành công.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim nextMaHX = "1"
            result = hieuxeBUS.BuildMaHX(nextMaHX)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy tự động mã hiệu xe không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            tbMaHX.Text = nextMaHX
            tbTenHX.Text = String.Empty

            'Reload List HIEU XE
            Dim ListofHieuXe As New List(Of HieuXeDTO)
            loadListofHieuXe(ListofHieuXe)
            dgvDSHX.Columns.Clear()
            dgvDSHX.DataSource = Nothing

            dgvDSHX.AutoGenerateColumns = False
            dgvDSHX.AllowUserToAddRows = False
            dgvDSHX.DataSource = ListofHieuXe

            Dim clMaHX As New DataGridViewTextBoxColumn()
            clMaHX.Name = "MaHX"
            clMaHX.HeaderText = "Mã hiệu xe"
            clMaHX.DataPropertyName = "MaHX"
            dgvDSHX.Columns.Add(clMaHX)

            Dim clTenHX As New DataGridViewTextBoxColumn()
            clTenHX.Name = "TenHX"
            clTenHX.HeaderText = "Tên hiệu xe"
            clTenHX.DataPropertyName = "TenHX"
            dgvDSHX.Columns.Add(clTenHX)

            Dim cLNhanSua As New DataGridViewTextBoxColumn()
            cLNhanSua.Name = "NhanSua"
            cLNhanSua.HeaderText = "Nhận sửa"
            clTenHX.DataPropertyName = "NhanSua"
            dgvDSHX.Columns.Add(cLNhanSua)

        Else
            MessageBox.Show("Thêm hiệu xe không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If


    End Sub
End Class