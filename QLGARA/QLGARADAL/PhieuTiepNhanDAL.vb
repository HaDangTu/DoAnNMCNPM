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

    Public Function BuildMaPhieu(nextMaphieu As String) As Result
        nextMaphieu = String.Empty
        Dim prefix = "MP"
        nextMaphieu = prefix + "00000"

        Dim query As String
        query = String.Empty
        query &= "SELECT [MaPhieuTN]"
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
                    msOnDB = String.Empty
                    Reader = comm.ExecuteReader()
                    If (Reader.HasRows = True) Then
                        While Reader.Read()
                            msOnDB = Reader("[MaPhieuTN]")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        tmp = msOnDB.Substring(msOnDB.Length - 6, 5)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1

                        tmp = converttodecimal.ToString()
                        nextMaphieu = nextMaphieu + tmp
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
        query &= "INSERT INTO [PhieuTiepNhan]"
        query &= " ([MaPhieuTN], [MaTTXe],[NgayTiepNhan])"
        query &= "VALUE (@MaPhieuTN, @MaTTXe, @NgayTiepNhan"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuTN", phieutiepnhan.MaPhieu)
                    .Parameters.AddWithValue("@MaTTxe", phieutiepnhan.MaTTXe)
                    .Parameters.AddWithValue("@NgayTiepNhan", phieutiepnhan.NgayTiepNhan)
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
End Class
