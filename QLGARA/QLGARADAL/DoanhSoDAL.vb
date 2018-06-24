Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility

Public Class DoanhSoDAL
    Private connectionstring As String
    Public Sub New()
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(conn As String)
        connectionstring = conn
    End Sub

    Public Function BuildMaDoanhSo(ByRef nextMaDoanhSo As String) As Result
        nextMaDoanhSo = String.Empty
        Dim prefix = "DS"
        nextMaDoanhSo = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaDoanhSo]"
        query &= " FROM [DOANHSO]"
        query &= " ORDER BY [MaDoanhSo] DESC"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim Reader As SqlDataReader
                    Dim msOnDB As String
                    msOnDB = String.Empty
                    Reader = comm.ExecuteReader()
                    If (Reader.HasRows = True) Then
                        While Reader.Read()
                            msOnDB = Reader("MaDoanhSo")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        Dim tmp1 As String
                        tmp = msOnDB.Substring(2)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1
                        Dim v = converttodecimal.ToString()
                        tmp1 = tmp.Substring(0, tmp.Length - v.Length)
                        tmp = converttodecimal.ToString()
                        nextMaDoanhSo = nextMaDoanhSo + tmp1 + tmp
                        System.Console.WriteLine(nextMaDoanhSo)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã doanh số kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(doanhso As DoanhSoDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [DoanhSo]"
        query &= " ([MaDoanhSo], [Thang], [TongDoanhThu]) "
        query &= " VALUES (@MaDoanhSo, @Thang,@TongDoanhThu)"

        Dim nextMaDoanhSo As String
        nextMaDoanhSo = "1"
        BuildMaDoanhSo(nextMaDoanhSo)
        doanhso.MaDoanhSo = nextMaDoanhSo

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaDoanhSo", doanhso.MaDoanhSo)
                    .Parameters.AddWithValue("@Thang", doanhso.Thang)
                    .Parameters.AddWithValue("@TongDoanhThu", doanhso.TongDoanhThu)

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lập báo cáo doanh số thành công thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function TongDoanhThu(thang As Integer, nam As Integer) As Integer
        Dim query As String
        Dim Tong As Double
        query = String.Empty
        query &= "SELECT SUM ([SoLuong] * [DonGia] + [MucTien]) [TongThanhTien] "
        query &= "FROM (SELECT [SoLuong], [DonGia], [MucTien] "
        query &= "FROM [PHUTUNG], [TT_PHIEUSUACHUA], [LOAITIENCONG], [PHIEUSUACHUA] "
        query &= "WHERE PHUTUNG.MaPhuTung = TT_PHIEUSUACHUA.MaPhuTung AND "
        query &= "TT_PHIEUSUACHUA.MaTienCong = LOAITIENCONG.MaTienCong AND "
        query &= "PHIEUSUACHUA.MaPhieuSC = TT_PHIEUSUACHUA.MaPhieuSC AND "
        query &= "month(NgaySC) = @Thang AND year(NgaySC) = @Nam ) A "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", thang)
                    .Parameters.AddWithValue("@Nam", nam)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While (reader.Read())
                            Tong = reader("TongThanhTien")
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return Tong
    End Function

    Public Function TongSoLuotSua(thang As Integer, nam As Integer) As Integer
        Dim query As String
        query = String.Empty
        query &= "Select Count ([MaPhieuSC]) [TongSoLuotSua] "
        query &= "FROM [PHIEUSUACHUA] "
        query &= "WHERE month(NgaySC) = @Thang AND year(NgaySC) = @Nam "

        Dim Tong As Integer
        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", thang)
                    .Parameters.AddWithValue("@Nam", nam)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            Tong = reader("TongSoLuotSua")
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return Tong
    End Function

    Public Function SoLuotSC_1_HieuXe(thang As Integer, nam As Integer) As List(Of LuotSuaChuaDTO)
        Dim query As String
        Dim ListofLuotSuaChua As New List(Of LuotSuaChuaDTO)()
        query = String.Empty
        query &= "SELECT TenHX, count(PHIEUSUACHUA.MaPhieuSC) [SoLuotSua] "
        query &= "FROM [PHIEUSUACHUA], [PHIEUTIEPNHAN], [TT_XE], [HIEUXE] "
        query &= "WHERE PHIEUSUACHUA.MaPhieuTN = PHIEUTIEPNHAN.MaPhieuTN AND "
        query &= "PHIEUTIEPNHAN.MaTTXe = TT_XE.MaTTXe AND "
        query &= "TT_XE.MaHX = HIEUXE.MaHX AND "
        query &= "month(NgaySC) = @Thang AND year(NgaySC) = @Nam "
        query &= "Group By TenHX"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", thang)
                    .Parameters.AddWithValue("@Nam", nam)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While (reader.Read())
                            ListofLuotSuaChua.Add(New LuotSuaChuaDTO(reader("TenHX"), reader("SoLuotSua")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return ListofLuotSuaChua
    End Function

    Public Function ThanhTien(thang As Integer, nam As Integer) As List(Of ThanhTienDTO)
        Dim query As String
        Dim ListofThanhTien As New List(Of ThanhTienDTO)()
        query = String.Empty
        query &= "SELECT [TenHX], sum (SoLuong * DonGia + MucTien) [ThanhTien] "
        query &= "FROM (SELECT [TenHX], [SoLuong], [DonGia], [MucTien] "
        query &= "FROM [HIEUXE], [TT_XE], [PHIEUTIEPNHAN], [PHIEUSUACHUA], [TT_PHIEUSUACHUA],[PHUTUNG], [LOAITIENCONG] "
        query &= "WHERE HIEUXE.MaHX = TT_XE.MaHX AND "
        query &= "TT_XE.MaTTXe = PHIEUTIEPNHAN.MaTTXe AND "
        query &= "PHIEUTIEPNHAN.MaPhieuTN = PHIEUSUACHUA.MaPhieuTN AND "
        query &= "PHIEUSUACHUA.MaPhieuSC = TT_PHIEUSUACHUA.MaPhieuSC AND "
        query &= "TT_PHIEUSUACHUA.MaPhuTung = PHUTUNG.MaPhuTung AND "
        query &= "TT_PHIEUSUACHUA.MaTienCong = LOAITIENCONG.MaTienCong AND "
        query &= "month(NgaySC) = @Thang AND year(NgaySC) = @Nam) A "
        query &= "Group by [TenHX] "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", thang)
                    .Parameters.AddWithValue("@Nam", nam)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While (reader.Read())
                            ListofThanhTien.Add(New ThanhTienDTO(reader("TenHX"), reader("ThanhTien")))

                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return ListofThanhTien
    End Function
End Class

