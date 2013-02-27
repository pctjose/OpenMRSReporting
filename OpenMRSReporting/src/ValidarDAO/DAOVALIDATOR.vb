Imports MySql.Data.MySqlClient
Public Class DAOVALIDATOR
    Public Shared Sub FillFRIDATRACK()

        Dim rs As MySqlDataReader
        Dim comando As New MySqlCommand
        comando.CommandType = CommandType.Text
        comando.Connection = ConexaoOpenMRSReporting2
        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandType = CommandType.Text
            .CommandText = "select 	p.patient_id,e.encounter_id,e.encounter_datetime," & _
                            "	o.concept_id,o.value_coded " & _
                            "from 	openmrs.patient p " & _
                            "	inner join openmrs.encounter e on e.patient_id=p.patient_id " & _
                            "	inner join openmrs.obs o on o.encounter_id=e.encounter_id " & _
                            "where 	p.voided=0 and e.voided=0 and o.voided=0 and " & _
                            "	e.encounter_type in (18,6,9) and " & _
                            "	o.concept_id=1255 " & _
                            "order by p.patient_id,e.encounter_datetime asc"
            rs = .ExecuteReader
            If rs.HasRows Then

                Dim pAnterior As Integer = 0
                Dim cAnterior As Integer = 0
                Dim dAnterior As String = ""
                Dim vAnterior As Integer = 0

                Dim pActual As Integer = 0
                Dim cActual As Integer = 0
                Dim dActual As String = ""
                Dim vActual As Integer = 0
                Dim problema As String = ""

                comando.CommandText = "Delete from frida_track"
                comando.ExecuteNonQuery()


                While rs.Read
                    pActual = rs.GetInt32("patient_id")
                    cActual = rs.GetInt32("encounter_id")
                    dActual = rs.GetDateTime("encounter_datetime")
                    vActual = rs.GetInt32("value_coded")



                    If pActual = pAnterior Then
                        Select Case vAnterior
                            Case 1708
                                If vActual = 1257 Or vActual = 1256 Or vActual = 1259 Or vActual = 1708 Then
                                    problema = "Inconsistencia entre FRIDA de " & dAnterior & " que vem " & getMovimento(vAnterior) & " e a FRIDA de " & dActual & " que vem " & getMovimento(vActual)
                                    comando.CommandText = "Insert into frida_track(patient_id,encounter_id,encounter_datetime," & _
                                                    "value_coded_ant,value_coded_act,desc_error) values(" & _
                                                    "" & pActual & "," & cActual & ",'" & dataMySQL(dActual) & "'," & vAnterior & "," & vActual & ",'" & problema & "')" 'Erro Saida sem entrada
                                    comando.ExecuteNonQuery()
                                End If
                            Case 1257, 1256, 1259, 1369, 1705
                                If vActual = 1256 Or vActual = 1705 Or vActual = 1369 Then
                                    problema = "Inconsistencia entre FRIDA de " & dAnterior & " que vem " & getMovimento(vAnterior) & " e a FRIDA de " & dActual & " que vem " & getMovimento(vActual)
                                    comando.CommandText = "Insert into frida_track(patient_id,encounter_id,encounter_datetime," & _
                                                    "value_coded_ant,value_coded_act,desc_error) values(" & _
                                                    "" & pActual & "," & cActual & ",'" & dataMySQL(dActual) & "'," & vAnterior & "," & vActual & ",'" & problema & "')" 'Erro Saida sem entrada
                                    comando.ExecuteNonQuery()
                                End If

                        End Select

                    Else
                        If vActual = 1257 Or vActual = 1259 Or vActual = 1705 Or vActual = 1708 Then
                            problema = "A primeira FRIDA de " & dActual & " vem " & getMovimento(vActual) & " enquanto devia ser INICIO ou TRANSFERIDO DE"
                            comando.CommandText = "Insert into frida_track(patient_id,encounter_id,encounter_datetime," & _
                                            "value_coded_ant,value_coded_act,desc_error) values(" & _
                                            "" & pActual & "," & cActual & ",'" & dataMySQL(dActual) & "'," & vAnterior & "," & vActual & ",'" & problema & "')" 'Erro Saida sem entrada
                            'MsgBox(comando.CommandText)
                            comando.ExecuteNonQuery()
                        End If
                    End If

                    pAnterior = pActual
                    cAnterior = cActual 'As Integer = 0
                    dAnterior = dActual 'As String = ""
                    vAnterior = vActual ' As Integer = 0

                End While


            End If
            FechaResultSet(rs)

        End With
    End Sub
    Private Shared Function getMovimento(ByVal mov As Integer) As String
        Select Case mov
            Case 1257
                Return "MANTER"
            Case 1256
                Return "INICIO"
            Case 1259
                Return "ALTERAR"
            Case 1369
                Return "TRANSFERIDO DE"
            Case 1705
                Return "REINICIO"
            Case 1708
                Return "SAIDA"
            Case Else
                Return ""
        End Select
    End Function
    Public Shared Sub FillCOHOOTPERIODICO(ByVal data1 As Date, ByVal data2 As Date, ByVal dist As String)

        Dim comando As New MySqlCommand
        comando.CommandType = CommandType.Text
        comando.Connection = ConexaoOpenMRSReporting2
        Dim dataInicial As String = dataMySQL(data1)
        Dim dataFinal As String = dataMySQL(data2)

        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandType = CommandType.Text
            .CommandText = "Call COHOORTPERIODICO('" & dataInicial & "','" & dataFinal & "','" & dist & "')"
            .ExecuteNonQuery()
        End With

    End Sub

    
End Class
