Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class PhieuThuTienDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaPhieuTT(ByRef nextMaphieuTT As String) As Result
        nextMaphieuTT = String.Empty
        Dim prefix = "MT"
        nextMaphieuTT = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhieuThuTien]"
        query &= "FROM [PHIEUTHUTIEN]"
        query &= "ORDER BY [MaPhieuThuTien] DESC"

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
                    msOnDB = Nothing
                    Reader = comm.ExecuteReader()
                    If (Reader.HasRows = True) Then
                        While Reader.Read()
                            msOnDB = Reader("MaPhieuThuTien")
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
                        tmp1.Substring(0, tmp1.Length - v.Length + 1)
                        tmp = converttodecimal.ToString()
                        nextMaphieuTT = nextMaphieuTT + tmp1 + tmp
                        System.Console.WriteLine(nextMaphieuTT)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã phiếu kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(phieuthutien As PhieuThuTienDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [PHIEUTHUTIEN]"
        query &= " ([MaPhieuThuTien], [MaPhieuTN],[NgayThuTien], [SoTienThu])"
        query &= "VALUES (@MaPhieuThuTien, @MaPhieuTN, @NgayThuTien, @SoTienThu)"

        Dim nextmaphieutt As String
        nextmaphieutt = "1"
        BuildMaPhieuTT(nextmaphieutt)
        phieuthutien.MaPhieuThuTien = nextmaphieutt

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuThuTien", phieuthutien.MaPhieuThuTien)
                    .Parameters.AddWithValue("@MaPhieuTN", phieuthutien.MaPhieuTN)
                    .Parameters.AddWithValue("@NgayThuTien", phieuthutien.NgayThuTien)
                    .Parameters.AddWithValue("@SoTienThu", phieuthutien.SoTienThu)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lập phiếu thu tiền thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(phieuthutien As PhieuThuTienDTO)
        Dim query As String
        query = String.Empty
        query &= "UPDATE [PHIEUTHUTIEN]"
        query &= "SET [MaPhieuTN] = @MaPhieuTN, [NgayThuTien] = @NgayThuTien, [SoTienThu] = @SoTienThu"
        query &= "WHERE [MaPhieuThuTien] = @MaPhieuThuTien"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query

                    .Parameters.AddWithValue("@MaPhieuTN", phieuthutien.MaPhieuTN)
                    .Parameters.AddWithValue("@NgayThuTien", phieuthutien.NgayThuTien)
                    .Parameters.AddWithValue("@SoTienThu", phieuthutien.SoTienThu)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa phiếu  thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maphieuthutien As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [PHIEUTHUTIEN]"
        query &= "WHERE [MaPhieuThuTien] =  @MaPhieuThuTien"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuThuTien", maphieuthutien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa phiếu thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function TimNoKhachhang(biensoxe As String) As Double
        Dim query As String
        Dim tienno As Double
        query = String.Empty
        query &= "SELECT [TienNo]"
        query &= " FROM [KHACHHANG], [TT_XE]"
        query &= " WHERE KHACHHANG.MaKH = TT_XE.MaKH"
        query &= " AND [BienSo] = @BienSo"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@BienSo", biensoxe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            tienno = reader("TienNo")
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return tienno
    End Function
End Class
