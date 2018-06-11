Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class TTNhapPhuTungDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaTTNhapPT(ByRef nextMaTTNhapPT As String) As Result
        nextMaTTNhapPT = String.Empty
        Dim prefix = "NP"
        nextMaTTNhapPT = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTNhapPhuTung]"
        query &= " FROM [TT_NHAPPHUTUNG]"
        query &= " ORDER BY [MaTTNhapPhuTung] DESC"

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
                            msOnDB = Reader("MaTTNhapPhuTung")
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
                        nextMaTTNhapPT = nextMaTTNhapPT + tmp1 + tmp
                        System.Console.WriteLine(nextMaTTNhapPT)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã thông tin nhập phụ tùng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(ttnhapphutung As TTNhapPhuTungDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_NHAPPHUTUNG]"
        query &= " ([MaTTNhapPhuTung], [MaNhapPhuTung], [MaPhuTung], [SoLuongNhap], [DonGiaNhap])"
        query &= " VALUES (@MaTTNhapPhuTung, @MaNhapPhuTung, @MaPhuTung, @SoLuongNhap, @DonGiaNhap)"

        Dim nextMaTTNhapPT As String
        nextMaTTNhapPT = "1"
        BuildMaTTNhapPT(nextMaTTNhapPT)
        ttnhapphutung.MaTTNhapPhuTung = nextMaTTNhapPT

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTNhapPhuTung", ttnhapphutung.MaTTNhapPhuTung)
                    .Parameters.AddWithValue("@MaNhapPhuTung", ttnhapphutung.MaNhapPhuTung)
                    .Parameters.AddWithValue("@MaPhuTung", ttnhapphutung.MaPhuTung)
                    .Parameters.AddWithValue("@SoLuongNhap", ttnhapphutung.SoLuongNhap)
                    .Parameters.AddWithValue("@DonGiaNhap", ttnhapphutung.DonGiaNhap)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thông tin nhập phụ tùng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Select_SoLuongNhap(Thang As Integer, ByRef ListofTTNhapPhuTung As List(Of Integer)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT sum ([SoLuongNhap]) [SLNhap] "
        query &= "FROM [NHAPPHUTUNG], [TT_NHAPPHUTUNG] "
        query &= "WHERE month(NgayNhap) = @Thang "
        query &= "GROUP BY [MaPhuTung]"

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
                        ListofTTNhapPhuTung.Clear()
                        While reader.Read()
                            ListofTTNhapPhuTung.Add(reader("SLNhap"))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả số lượng nhập phụ tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' 
    End Function
End Class
