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

    Public Function Insert(tt_phieusuachua As TTPhieuSuaChuaDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_PHIEUSUACHUA]"
        query &= "([MaPhieuSC], [MaPhuTung], [NoiDung], [SoLuong], [MaTienCong])"
        query &= "VALUES (@MaPhieuSC, @MaPhuTung, @NoiDung, @SoLuong, @MaTienCong)"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
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
        query &= " SET [NoiDung] = @NoiDung, [SoLuong] = @SoLuong, [MaTienCong] = @MaTienCong"
        query &= " WHERE [MaPhieuSC] = @MaPhieuSC, [MaPhuTung] = @MaPhuTung"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
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
                    Return New Result(False, "Sửa thông tin khách hàng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maphieusc As String, maphutung As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [TT_PHIEUSUACHUA]"
        query &= " WHERE [MaPhieuSC] =  @MaPhieuSC, [MaPhuTung] = @MaPhuTung"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuSC", maphieusc)
                    .Parameters.AddWithValue("@MaPhuTung", maphutung)
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
