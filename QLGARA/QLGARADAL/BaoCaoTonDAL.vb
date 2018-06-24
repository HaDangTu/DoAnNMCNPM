Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility


Public Class BaoCaoTonDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaBaoCaoTon(ByRef nextMaBaoCaoTon As String) As Result
        nextMaBaoCaoTon = String.Empty
        Dim prefix = "CT"
        nextMaBaoCaoTon = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaBaoCaoTon]"
        query &= " FROM [BAOCAOTON]"
        query &= " ORDER BY [MaBaoCaoTon] DESC"

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
                            msOnDB = Reader("MaBaoCaoTon")
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
                        nextMaBaoCaoTon = nextMaBaoCaoTon + tmp1 + tmp
                        System.Console.WriteLine(nextMaBaoCaoTon)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã báo cáo tồn kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(baocaoton As BaoCaoTonDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [BAOCAOTON]"
        query &= " ([MaBaoCaoTon], [Thang])"
        query &= " VALUES (@MaBaoCaoTon, @Thang)"

        Dim nextMaBaoCaoTon As String
        nextMaBaoCaoTon = "1"
        BuildMaBaoCaoTon(nextMaBaoCaoTon)
        baocaoton.MaBaoCaoTon = nextMaBaoCaoTon

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaBaoCaoTon", baocaoton.MaBaoCaoTon)
                    .Parameters.AddWithValue("@Thang", baocaoton.Thang)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm báo cáo tồn thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Tong_SL_DaSC(Thang As Integer, Nam As Integer, ByRef ListofTong_SL_DaSC As List(Of Integer)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT Sum (SoLuong) [SoLuongDaSuaChua] "
        query &= "FROM [PHUTUNG], [TT_PHIEUSUACHUA] , [PHIEUSUACHUA] "
        query &= "WHERE PHUTUNG.MAPHUTUNG = TT_PHIEUSUACHUA.MaPhuTung AND "
        query &= "TT_PHIEUSUACHUA .MaPhieuSC = PHIEUSUACHUA.MaPhieuSC AND "
        query &= "MONTH(NgaySC) = @Thang AND Year(NgaySC) = @Nam "
        query &= "GROUP BY PHUTUNG.MaPhuTung "
        query &= "ORDER BY PHUTUNG.MaPhuTung ASC "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", Thang)
                    .Parameters.AddWithValue("@Nam", Nam)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        ListofTong_SL_DaSC.Clear()
                        While reader.Read()
                            ListofTong_SL_DaSC.Add(reader("SoLuongDaSuaChua"))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả tổng số lượng phụ tùng từng loại đã đem ra sữa chữa không thành công",
                                      ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' 
    End Function

    Public Function Tong_SLPS(Thang As Integer, Nam As Integer, ByRef ListofTong_SLPS As List(Of Integer)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT Sum(SoLuongPS) [SoLuongPhatSinh] "
        query &= "FROM [PHUTUNG], [NHAPPHATSINH], [TT_PHATSINH] "
        query &= "WHERE PHUTUNG.MaPhuTung = TT_PHATSINH.MaPhuTung AND "
        query &= "TT_PHATSINH.MaPhieuNhapPS = NHAPPHATSINH.MaPhieuNhapPS AND "
        query &= "MONTH(NgayNhapPS) = @Thang AND YEAR(NgayNhapPS) = @Nam "
        query &= "GROUP BY PHUTUNG.MaPhuTung "
        query &= "ORDER BY PHUTUNG.MaPhuTung ASC "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", Thang)
                    .Parameters.AddWithValue("@Nam", Nam)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        ListofTong_SLPS.Clear()
                        While reader.Read()
                            ListofTong_SLPS.Add(reader("SoLuongPhatSinh"))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả số tổng lượng phụ tùng từng loại phát sinh không thành công",
                                      ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' 
    End Function

    Public Function Select_TonCuoi_ByThang(MaBaoCaoTon As String, ByRef ListofTonCuoi As List(Of Integer)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [TonCuoi] "
        query &= "FROM [TT_BAOCAOTON], [BAOCAOTON] "
        query &= "WHERE TT_BAOCAOTON.MaBaoCaoTon = BAOCAOTON.MaBaoCaoTon AND BAOCAOTON.MaBaoCaoTon = @MaBaoCaoTon "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaBaoCaoTon", MaBaoCaoTon)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        ListofTonCuoi.Clear()
                        While reader.Read()
                            ListofTonCuoi.Add(reader("TonCuoi"))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả số tồn cuối của từng loại phụ tùng không thành công",
                                      ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' 
    End Function
End Class
