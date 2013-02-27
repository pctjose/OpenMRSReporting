Imports MySql.Data.MySqlClient
Public Class HddDAO
    Public Shared Function getHddByOpenMRSID(ByVal openmrsid As Integer) As HddVO
        Dim hdd As New HddVO
        Dim rs As MySqlDataReader
        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandType = CommandType.Text
            .CommandText = "Select unidadeid,nomeus,distritoid,openmrs_id,dataabertura,sede from hdd where openmrs_id=" & openmrsid & ""
            rs = .ExecuteReader
            If rs.HasRows Then
                rs.Read()
                hdd.hddDataAbertura = dataMicrosoft(rs.GetMySqlDateTime("dataabertura"))
                hdd.hddDistrictID = rs.GetString("distritoid")
                hdd.hddID = rs.GetString("unidadeid")
                hdd.hddName = rs.GetString("nomeus")
                hdd.hddOpenMRSID = rs.GetInt32("openmrs_id")
                hdd.Sede = rs.GetBoolean("sede")

            End If
            FechaResultSet(rs)
            Return hdd
        End With
    End Function
    Public Shared Function getHddSedeByDistrito(ByVal distrito As String) As HddVO
        Dim hdd As New HddVO
        Dim rs As MySqlDataReader
        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandType = CommandType.Text
            .CommandText = "Select unidadeid,nomeus,distritoid,openmrs_id,dataabertura,sede from hdd where distritoID='" & distrito & "' and sede=1"
            rs = .ExecuteReader
            If rs.HasRows Then
                rs.Read()
                hdd.hddDataAbertura = dataMicrosoft(rs.GetMySqlDateTime("dataabertura"))
                hdd.hddDistrictID = rs.GetString("distritoid")
                hdd.hddID = rs.GetString("unidadeid")
                hdd.hddName = rs.GetString("nomeus")
                hdd.hddOpenMRSID = rs.GetInt32("openmrs_id")
                hdd.Sede = rs.GetBoolean("sede")

            End If
            FechaResultSet(rs)
            Return hdd
        End With
    End Function
End Class
