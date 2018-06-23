Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class TTPhatSinhDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaTTNhapPS(ByRef nextMaTTNhapPS As String) As Result
        nextMaTTNhapPS = String.Empty
        Dim prefix = "TP"
        nextMaTTNhapPS = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTPhatSinh]"
        query &= " FROM [TT_PHATSINH]"
        query &= " ORDER BY [MaTTPhatSinh] DESC"

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
                            msOnDB = Reader("MaTTPhatSinh")
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
                        nextMaTTNhapPS = nextMaTTNhapPS + tmp1 + tmp
                        System.Console.WriteLine(nextMaTTNhapPS)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã thông tin phát sinh kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(ttphatsinh As TTPhatSinhDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_PHATSINH]"
        query &= " ([MaTTPhatSinh], [MaPhieuNhapPS], [MaPhuTung], [SoLuongPS], [DonGiaPS])"
        query &= " VALUES (@MaTTPhatSinh, @MaPhieuNhapPS, @MaPhuTung, @SoLuongPS, @DonGiaPS)"

        Dim nextMaTTNhapPS As String
        nextMaTTNhapPS = "1"
        BuildMaTTNhapPS(nextMaTTNhapPS)
        ttphatsinh.MaTTPhatSinh = nextMaTTNhapPS

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTPhatSinh", ttphatsinh.MaTTPhatSinh)
                    .Parameters.AddWithValue("@MaPhieuNhapPS", ttphatsinh.MaPhieuNhapPS)
                    .Parameters.AddWithValue("@MaPhuTung", ttphatsinh.MaPhuTung)
                    .Parameters.AddWithValue("@SoLuongPS", ttphatsinh.SoLuongPS)
                    .Parameters.AddWithValue("@DonGiaPS", ttphatsinh.DonGiaPS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thông tin nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(ttphatsinh As TTPhatSinhDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [TT_PHATSINH]"
        query &= " SET [MaPhieuNhapPS] = @MaPhieuNhapPS, [MaPhuTung] = @MaPhuTung,"
        query &= " [SoLuongPS] = @SoLuongPS, [DonGiaPS] = @DonGiaPS"
        query &= " WHERE [MaTTPhatSinh] = @MaTTPhatSinh"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTPhatSinh", ttphatsinh.MaTTPhatSinh)
                    .Parameters.AddWithValue("@MaPhieuNhapPS", ttphatsinh.MaPhieuNhapPS)
                    .Parameters.AddWithValue("@MaPhuTung", ttphatsinh.MaPhuTung)
                    .Parameters.AddWithValue("@SoLuongPS", ttphatsinh.SoLuongPS)
                    .Parameters.AddWithValue("@DonGiaPS", ttphatsinh.DonGiaPS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin phiếu nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maTTPhatSinh As String) As Result
        Dim query As String
        query = String.Empty
        query &= " DELETE FROM [TT_PHATSINH]"
        query &= " WHERE [MaTTPhatSinh] =  @MaTTPhatSinh"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaKH", maTTPhatSinh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa thông tin phiếu nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
