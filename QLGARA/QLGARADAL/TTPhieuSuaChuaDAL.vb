Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class TTPhieuSuaChuaDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub
    Public Function BuildMaTTPhieuSC(ByRef nextMaTTPhieuSC As String) As Result
        nextMaTTPhieuSC = String.Empty
        Dim prefix = "TS"
        nextMaTTPhieuSC = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTPhieuSuaChua]"
        query &= " FROM [TT_PhieuSuaChua]"
        query &= " ORDER BY [MaTTPhieuSuaChua] DESC"

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
                            msOnDB = Reader("MaTTPhieuSuaChua")
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
                        nextMaTTPhieuSC = nextMaTTPhieuSC + tmp1 + tmp
                        System.Console.WriteLine(nextMaTTPhieuSC)
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

    Public Function Insert(tt_phieusuachua As TTPhieuSuaChuaDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_PHIEUSUACHUA]"
        query &= " ([MaTTPhieuSuaChua], [MaPhieuSC], [MaPhuTung], [NoiDung], [SoLuong], [MaTienCong])"
        query &= " VALUES (@MaTTPhieuSuaChua, @MaPhieuSC, @MaPhuTung, @NoiDung, @SoLuong, @MaTienCong)"

        Dim nextMaTTPhieuSC As String
        nextMaTTPhieuSC = "1"
        BuildMaTTPhieuSC(nextMaTTPhieuSC)
        tt_phieusuachua.MaTTPhieuSuaChua = nextMaTTPhieuSC

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTPhieuSuaChua", tt_phieusuachua.MaTTPhieuSuaChua)
                    .Parameters.AddWithValue("@MaPhieuSC", tt_phieusuachua.MaPhieuSC)
                    .Parameters.AddWithValue("@MaPhuTung", tt_phieusuachua.MaPhuTung)
                    .Parameters.AddWithValue("@NoiDung", tt_phieusuachua.NoiDung)
                    .Parameters.AddWithValue("@SoLuong", tt_phieusuachua.SoLuong)
                    .Parameters.AddWithValue("@MaTienCong", tt_phieusuachua.MaTienCong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thông tin phiếu sửa chữa thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(tt_phieusuachua As TTPhieuSuaChuaDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [TT_PHIEUSUACHUA]"
        query &= " SET [MaPhieuSC] = @MaPhieuSC, [MaPhuTung] = @MaPhuTung, [NoiDung] = @NoiDung, [SoLuong] = @SoLuong, [MaTienCong] = @MaTienCong"
        query &= " WHERE [MaTTPhieuSuaChua] = @MaTTPhieuSuaChua"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTPhieuSuaChua", tt_phieusuachua.MaTTPhieuSuaChua)
                    .Parameters.AddWithValue("@MaPhieuSC", tt_phieusuachua.MaPhieuSC)
                    .Parameters.AddWithValue("@MaPhuTung", tt_phieusuachua.MaPhuTung)
                    .Parameters.AddWithValue("@NoiDung", tt_phieusuachua.NoiDung)
                    .Parameters.AddWithValue("@SoLuong", tt_phieusuachua.SoLuong)
                    .Parameters.AddWithValue("@MaTienCong", tt_phieusuachua.MaTienCong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin phiếu sửa chữa thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(mattphieusc As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [TT_PHIEUSUACHUA]"
        query &= " WHERE [MaTTPhieuSuaChua] = @MaTTPhieuSuaChua"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTPhieuSuaChua", mattphieusc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa thông tin phiếu sửa chữa thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
