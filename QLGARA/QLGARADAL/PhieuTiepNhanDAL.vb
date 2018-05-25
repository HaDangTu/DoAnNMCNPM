Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class PhieuTiepNhanDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaPhieu(ByRef nextMaphieu As String) As Result
        nextMaphieu = String.Empty
        Dim prefix = "MP"
        nextMaphieu = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhieuTN]"
        query &= "FROM [PHIEUTIEPNHAN]"
        query &= "ORDER BY [MaPhieuTN] DESC"

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
                            msOnDB = Reader("MaPhieuTN")
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
                        nextMaphieu = nextMaphieu + tmp1 + tmp
                        System.Console.WriteLine(nextMaphieu)
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

    Public Function Insert(phieutiepnhan As PhieuTiepNhanDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [PHIEUTIEPNHAN]"
        query &= " ([MaPhieuTN], [MaTTXe],[NgayNhan])"
        query &= "VALUES (@MaPhieuTN, @MaTTXe, @NgayNhan)"

        Dim nextMaphieu As String
        nextMaphieu = "1"
        BuildMaPhieu(nextMaphieu)
        phieutiepnhan.MaPhieu = nextMaphieu

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuTN", phieutiepnhan.MaPhieu)
                    .Parameters.AddWithValue("@MaTTxe", phieutiepnhan.MaTTXe)
                    .Parameters.AddWithValue("@NgayNhan", phieutiepnhan.NgayTiepNhan)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Tiếp nhận xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(phieutiepnhan As PhieuTiepNhanDTO)
        Dim query As String
        query = String.Empty
        query &= "UPDATE [PHIEUTIEPNHAN]"
        query &= "SET [MaTTXe] = @MaTTXe, [NgayNhan] = @NgayNhan"
        query &= "WHERE [MaPhieuTN] = @MaPhieuTN"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTxe", phieutiepnhan.MaTTXe)
                    .Parameters.AddWithValue("@NgayNhan", phieutiepnhan.NgayTiepNhan)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa phiếu tiếp nhận thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maphieutn As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [PHIEUTIEPNHAN]"
        query &= "WHERE [MaPhieuTN] =  @MaPhieuTN"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuTN", maphieutn)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa phiếu tiếp nhận thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Count() As Integer
        Dim query As String
        query = String.Empty
        query &= "SELECT Count * [Soluongxe] FROM [PHIEUTIEPNHAN] "
        query &= "GROUP BY [NgayTiepNhan]"

        Dim Soluongxe As Integer
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
                    If (reader.HasRows = True) Then
                        Soluongxe = reader("Soluongxe")
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return Soluongxe
    End Function

    Public Function SelectALL() As List(Of PhieuTiepNhanDTO)
        Dim query As String
        Dim listofphieutiepnhan As New List(Of PhieuTiepNhanDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [PHIEUTIEPNHAN]"

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
                            listofphieutiepnhan.Add(New PhieuTiepNhanDTO(reader("MaPhieuTN"), reader("MaTTXe"),
                                             reader("NgayTiepNhan")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return listofphieutiepnhan
                End Try
            End Using
        End Using
        Return listofphieutiepnhan
    End Function

    Public Function SelectPhieutiepNhan_ByBienso(bienso As String) As PhieuTiepNhanDTO
        Dim Phieutiepnhan As New PhieuTiepNhanDTO()
        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhieuTN], [TT_XE.MaTTXe], [NgayTiepNhan]"
        query &= "FROM [PHIEUTIEPNHAN], [TT_XE]"
        query &= "WHERE KHACHHANG.MaTTXe = TT_XE.MaTTXe AND [BienSo] = @BienSo"
        query &= "ORDER BY [MaPhieuTN] DESC"

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
                            Phieutiepnhan = New PhieuTiepNhanDTO(reader("MaPhieuTN"),
                                                                 reader("PHIEUTIEPNHAN.MaTTXe"),
                                                                 reader("NgayTiepNhan"))

                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return Phieutiepnhan
    End Function
End Class
