Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class TTDoanhSoDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub


    Public Function BuildMaTTDoanhSo(ByRef nextMaTTDoanhSo As String) As Result
        nextMaTTDoanhSo = String.Empty
        Dim prefix = "TD"
        nextMaTTDoanhSo = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTDoanhSo]"
        query &= " FROM [TT_DOANHSO]"
        query &= " ORDER BY [MaTTDoanhSo] DESC"

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
                            msOnDB = Reader("MaTTDoanhSo")
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
                        nextMaTTDoanhSo = nextMaTTDoanhSo + tmp1 + tmp
                        System.Console.WriteLine(nextMaTTDoanhSo)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã thông tin doanh số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(ttdoanhso As TTDoanhSoDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_DOANHSO]"
        query &= " ([MaTTDoanhSo], [HieuXe], [SoLuotSua], [ThanhTien], [TiLe], [MaDoanhSo])"
        query &= " VALUES (@MaTTDoanhSo, @HieuXe, @SoLuotSua, @ThanhTien, @TiLe, @MaDoanhSo)"

        Dim nextMaTTDoanhSo As String
        nextMaTTDoanhSo = "1"
        BuildMaTTDoanhSo(nextMaTTDoanhSo)
        ttdoanhso.MaTTDoanhSo = nextMaTTDoanhSo

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTDoanhSo", ttdoanhso.MaTTDoanhSo)
                    .Parameters.AddWithValue("@HieuXe", ttdoanhso.HieuXe)
                    .Parameters.AddWithValue("@SoLuotSua", ttdoanhso.SoLuotSua)
                    .Parameters.AddWithValue("@ThanhTien", ttdoanhso.ThanhTien)
                    .Parameters.AddWithValue("@TiLe", ttdoanhso.TiLe)
                    .Parameters.AddWithValue("@MaDoanhSo", ttdoanhso.MaDoanhSo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thông tin doanh số thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Sellect_TTDoanhSo_byThang(Thang As Integer) As List(Of TTDoanhSoDTO)
        Dim ListofTTDoanhSo As New List(Of TTDoanhSoDTO)()
        Dim query As String
        query = String.Empty
        query &= "SELECT TT_DoanhSo.MaTTDoanhSo, [HieuXe], [SoLuotSua], [ThanhTien], [TiLe]  "
        query &= "FROM [TT_DOANHSO], [DOANHSO] "
        query &= "WHERE TT_DONHSO.MaDoanhSo = DOANHSO.MaDoanhSo "
        query &= "AND Thang = @Thang"
        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Thang", Thang)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While (reader.Read())
                            ListofTTDoanhSo.Add(New TTDoanhSoDTO(reader("MaTTDoanhSo"), reader("HieuXe"),
                                                                 reader("SoLuotSua"), reader("ThanhTien"),
                                                                 reader("TiLe"), reader("MaDoanhSo")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return ListofTTDoanhSo
    End Function
End Class
