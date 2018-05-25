Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class KhachhangDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaKH(ByRef nextMaKH As String) As Result
        nextMaKH = String.Empty
        Dim prefix = "KH"
        nextMaKH = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaKH]"
        query &= "FROM [KHACHHANG]"
        query &= "ORDER BY [MaKH] DESC"

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
                            msOnDB = Reader("MaKH")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        Dim tmp1 As String
                        tmp = msOnDB.Substring(2)
                        tmp1 = msOnDB.Substring(2, 5)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1
                        Dim v = converttodecimal.ToString()
                        tmp1 = tmp1.Substring(0, tmp1.Length - v.Length + 1)
                        tmp = converttodecimal.ToString()
                        nextMaKH = nextMaKH + tmp1 + tmp
                        System.Console.WriteLine(nextMaKH)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã khách hàng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(khachhang As KhachHangDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [KHACHHANG]"
        query &= "([MaKH], [TenKH], [DiaChi], [DienThoai], [TienNo])"
        query &= "VALUES (@MaKH, @TenKH, @DiaChi, @DienThoai, @TienNo)"

        Dim nextMaKH As String
        nextMaKH = "1"
        BuildMaKH(nextMaKH)
        khachhang.MaKH = nextMaKH

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaKH", khachhang.MaKH)
                    .Parameters.AddWithValue("@TenKH", khachhang.TenKH)
                    .Parameters.AddWithValue("@DiaChi", khachhang.DiaChi)
                    .Parameters.AddWithValue("@DienThoai", khachhang.DienThoai)
                    .Parameters.AddWithValue("@TienNo", khachhang.TienNo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm khách hàng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(khachhang As KhachHangDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [KHACHHANG]"
        query &= " SET [TenKH] = @TenKH, [DiaChi] = @DiaChi, [DienThoai] = @DienThoai, [TienNo] = @TienNo"
        query &= " WHERE [MaKH] = @MaKH"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaKH", khachhang.MaKH)
                    .Parameters.AddWithValue("@TenKH", khachhang.TenKH)
                    .Parameters.AddWithValue("@DiaChi", khachhang.DiaChi)
                    .Parameters.AddWithValue("@DienThoai", khachhang.DienThoai)
                    .Parameters.AddWithValue("@TienNo", khachhang.TienNo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin khách hàng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(makh As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [KHACHHANG]"
        query &= "WHERE [MaKH] =  @MaKH"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaKH", makh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa khách hàng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function SelectAll() As List(Of KhachHangDTO)
        Dim query As String
        Dim ListofKhachhang As New List(Of KhachHangDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [KHACHHANG]"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            ListofKhachhang.Add(New KhachHangDTO(reader("MaKH"), reader("TenKH"),
                                             reader("DiaChi"), reader("DienThoai"), reader("TienNo")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return ListofKhachhang
                End Try
            End Using
        End Using
        Return ListofKhachhang
    End Function

    Public Function SelectMaKH_byBienso(bienso As String) As KhachHangDTO
        Dim Khachhang As New KhachHangDTO()
        Dim query As String
        query = String.Empty
        query &= "SELECT [KHACHHANG].[MaKH], [TenKH], [DiaChi], [DienThoai], [TienNo]"
        query &= " FROM [KHACHHANG], [TT_XE]"
        query &= " WHERE KHACHHANG.MaKH = TT_XE.MaKH AND [BienSo] = @BienSo"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@BienSo", bienso)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            Khachhang = New KhachHangDTO(reader("MaKH"), reader("TenKH"),
                                                         reader("DiaChi"), reader("DienThoai"),
                                                         reader("TienNo"))

                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return Khachhang
    End Function
End Class
