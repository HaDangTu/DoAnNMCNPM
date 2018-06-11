Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility

Public Class ThamSoDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function Update(thamso As ThamSoDTO)
        Dim query As String
        query = String.Empty
        query &= "UPDATE [THAMSO]"
        query &= " SET [SoXeSuaChua] = @SoXeSuaChua "


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@SoXeSuaChua", thamso.SoXeSuaChua)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa quy định thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function SelectALL(ByRef thamso As ThamSoDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [SoXeSuaChua] "
        query &= "FROM [THAMSO] "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query

                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            thamso = New ThamSoDTO(reader("SoXeSuaChua"))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy thông tin quy định thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
