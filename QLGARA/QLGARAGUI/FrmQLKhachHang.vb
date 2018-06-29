Imports QLGARADTO
Imports QLGARABUS
Imports Utility
Public Class FrmQLKhachHang
    Dim khachhangBUS As New KhachHangBUS()
    Private Sub QLKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim nextMaKH = "1"
        khachhangBUS.BuildMaKH(nextMaKH)
        tbMaKH.Text = nextMaKH
        loadListofKhachHang()

    End Sub

    Private Sub btThem_Click(sender As Object, e As EventArgs) Handles btThem.Click
        Dim khachhangDTO As New KhachHangDTO()
        khachhangDTO.MaKH = tbMaKH.Text
        khachhangDTO.TenKH = tbTenKH.Text
        khachhangDTO.DiaChi = tbDiaChi.Text
        khachhangDTO.DienThoai = tbDienThoai.Text
        khachhangDTO.TienNo = Convert.ToInt64(tbTienNo.Text)

        If (khachhangBUS.isValidThongTin(tbTenKH.Text, tbDienThoai.Text, tbDiaChi.Text, tbTienNo.Text) = False) Then
            MessageBox.Show("Thiếu thông tin ", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If (khachhangBUS.isValidName(tbTenKH.Text) = False) Then
            MessageBox.Show("Tên tối thiểu 2 tiếng, không chứa các kí tự đặc biệt và số ", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If (khachhangBUS.isValidSoDienThoai(tbDienThoai.Text) = False) Then
            MessageBox.Show("Số điện thoại không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
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
        loadListofKhachHang()

    End Sub

    Public Sub loadListofKhachHang()
        Dim ListofKhachHang As New List(Of KhachHangDTO)()
        ListofKhachHang = khachhangBUS.SelectALL()
        dgvDanhSachKH.Columns.Clear()
        dgvDanhSachKH.DataSource = Nothing

        dgvDanhSachKH.AutoGenerateColumns = False
        dgvDanhSachKH.AllowUserToAddRows = False
        dgvDanhSachKH.DataSource = ListofKhachHang

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

        Dim currentRowIndex As Integer = dgvDanhSachKH.CurrentCellAddress.Y 'current row selected

        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachKH.RowCount) Then
            Try
                Dim khachhangDTO As New KhachHangDTO()
                khachhangDTO.MaKH = tbMaKH.Text
                khachhangDTO.TenKH = tbTenKH.Text
                khachhangDTO.DiaChi = tbDiaChi.Text
                khachhangDTO.DienThoai = tbDienThoai.Text
                khachhangDTO.TienNo = Convert.ToInt64(tbTienNo.Text)

                Dim result As Result
                result = khachhangBUS.Update(khachhangDTO)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadListofKhachHang()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachKH.Rows(currentRowIndex).Selected = True
                    Try
                        khachhangDTO = CType(dgvDanhSachKH.Rows(currentRowIndex).DataBoundItem, KhachHangDTO)
                        tbMaKH.Text = khachhangDTO.MaKH
                        tbTenKH.Text = khachhangDTO.TenKH
                        tbDienThoai.Text = khachhangDTO.DienThoai
                        tbDiaChi.Text = khachhangDTO.DiaChi
                        tbTienNo.Text = khachhangDTO.TienNo

                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật khách hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật khách hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
            loadListofKhachHang()
        End If

    End Sub

    Private Sub btXoa_Click(sender As Object, e As EventArgs) Handles btXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachKH.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachKH.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa khách hàng có mã: " + tbMaKH.Text,
                               MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = khachhangBUS.Delete(tbMaKH.Text)
                        If (result.FlagResult = True) Then

                            ' reload Khahhang list
                            loadListofKhachHang()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachKH.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachKH.Rows(currentRowIndex).Selected = True
                                Try
                                    Dim lkh = CType(dgvDanhSachKH.Rows(currentRowIndex).DataBoundItem,
                                        KhachHangDTO)
                                    tbMaKH.Text = lkh.MaKH
                                    tbTenKH.Text = lkh.TenKH
                                    tbDiaChi.Text = lkh.DiaChi
                                    tbDienThoai.Text = lkh.DienThoai
                                    tbTienNo.Text = lkh.TienNo.ToString()

                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa khách hàng thành công.", "Information", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa khách hàng không thành công.", "Error", MessageBoxButtons.OK,
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