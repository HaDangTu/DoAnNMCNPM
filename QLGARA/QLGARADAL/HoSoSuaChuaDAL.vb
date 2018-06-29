Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class HoSoSuaChuaDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function Sellect_All(ngaynhan As DateTime, ByRef listHoSoSuaChua As List(Of HoSoSuaChuaDTO)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [BienSo], [TenKH], [DienThoai], [DiaChi], [TenHX] "
        query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE], [PHIEUTIEPNHAN] "
        query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_XE.MaHX = HIEUXE.MaHX AND  "
        query &= "PHIEUTIEPNHAN.MaTTXe = TT_XE.MaTTXe AND MONTH(NgayNhan) = @Thang "
        query &= "AND DAY(NgayNhan) = @Ngay AND YEAR(NgayNhan) = @Nam "
        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", ngaynhan.Month)
                    .Parameters.AddWithValue("@Ngay", ngaynhan.Day)
                    .Parameters.AddWithValue("@Nam", ngaynhan.Year)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim Reader As SqlDataReader
                    Reader = comm.ExecuteReader()
                    If (Reader.HasRows) Then
                        While Reader.Read()
                            listHoSoSuaChua.Add(New HoSoSuaChuaDTO(Reader("BienSo"), Reader("TenKH"),
                                       Reader("DienThoai"), Reader("DiaChi"), Reader("TenHX")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy hồ sơ sửa chữa thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
