Imports QLGARADTO
Imports QLGARABUS
Imports Utility

Public Class FrmQLHieuXe
    Private hieuxeBUS As New HieuXeBUS()

    Public Sub loadListofHieuXe(ByRef ListofHieuXe As List(Of HieuXeDTO))
        hieuxeBUS.SelectAll(ListofHieuXe)
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


    End Sub
    Private Sub FrmQLHieuXe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ListofHieuXe As New List(Of HieuXeDTO)()
        loadListofHieuXe(ListofHieuXe)
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

        If (hieuxeBUS.isValidTenHieuXe(tbTenHX.Text) = False) Then
            MessageBox.Show("Tên hiệu xe bị thiếu.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
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

        Else
            MessageBox.Show("Thêm hiệu xe không thành công.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If


    End Sub

    Private Sub btCapnhat_Click(sender As Object, e As EventArgs) Handles btCapnhat.Click
        Dim currentRowIndex As Integer = dgvDSHX.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDSHX.RowCount) Then
            Try
                Dim hieuxe As HieuXeDTO
                hieuxe = New HieuXeDTO()

                '1. Mapping data from GUI control
                hieuxe.MaHX = tbMaHX.Text
                hieuxe.TenHX = tbTenHX.Text
                If (rbYes.Checked = True) Then
                    hieuxe.NhanSua = rbYes.Text
                Else
                    hieuxe.NhanSua = rbNo.Text
                End If
                '2. Business .....


                '3. Insert to DB
                Dim ListofHieuXe As New List(Of HieuXeDTO)()
                Dim result As Result
                result = hieuxeBUS.Update(hieuxe)
                If (result.FlagResult = True) Then
                    ' Re-Load HIEUXE list
                    loadListofHieuXe(ListofHieuXe)
                    ' Hightlight the row has been updated on table
                    dgvDSHX.Rows(currentRowIndex).Selected = True
                    Try
                        hieuxe = CType(dgvDSHX.Rows(currentRowIndex).DataBoundItem, HieuXeDTO)
                        tbMaHX.Text = hieuxe.MaHX
                        tbTenHX.Text = hieuxe.TenHX

                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật hiệu xe thành công.", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật hiệu xe không thành công.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub btXoa_Click(sender As Object, e As EventArgs) Handles btXoa.Click
        Dim currentRowIndex As Integer = dgvDSHX.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDSHX.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa loại học sinh có mã: " + tbMaHX.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim ListofHieuXe As New List(Of HieuXeDTO)()
                        Dim result As Result
                        result = hieuxeBUS.Delete(Convert.ToInt32(tbMaHX.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListofHieuXe(ListofHieuXe)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDSHX.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDSHX.Rows(currentRowIndex).Selected = True
                                Try
                                    Dim hieuxe = CType(dgvDSHX.Rows(currentRowIndex).DataBoundItem, HieuXeDTO)
                                    tbMaHX.Text = hieuxe.MaHX
                                    tbTenHX.Text = hieuxe.TenHX
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa hiệu xe thành công.", "Information", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa hiệu xe không thành công.", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error)
                            System.Console.WriteLine(result.SystemMessage)
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                Case MsgBoxResult.No
                    Return
            End Select

        End If
    End Sub
End Class