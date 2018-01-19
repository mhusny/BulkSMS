Imports System.Data.SqlClient
Imports System.Net
Imports System.IO
Public Class Form1


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim DS As New DataSet
        Dim sSQL As String
        Dim objSQL As New clsSqlConn
        With objSQL
            sSQL = " SELECT Account, Name, Title, Telephone FROM Client WHERE LEN(Telephone) = 10 "
            DS = New DataSet
            DS = .Get_Data_Sql(sSQL)
            If DS.Tables(0).Rows.Count > 0 Then
                'If MessageBox.Show("Are you sure you want to send " & DS.Tables(0).Rows.Count & " messages", "PastelEvolutionAddOn", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = True Then
                Dim dr As DataRow
                For Each dr In DS.Tables(0).Rows
                    sendSMS(dr("Telephone").ToString())
                Next
                'End If
            End If
        End With


    End Sub

    Private Sub sendSMS(ByVal no As String)
        'Dim name As String
        'If cmbCustomer.SelectedRow.Cells("Title").Value.ToString().Length > 0 And cmbCustomer.SelectedRow.Cells("Name").Value.ToString().Length > 0 Then
        '    name = cmbCustomer.SelectedRow.Cells("Title").Value.ToString() & " " & cmbCustomer.SelectedRow.Cells("Name").Value.ToString()
        'Else
        'name = " Valued Customer "
        'End If

        'Dim msg As String = "Dear " & name & ", How would you rate the service done on your vehicle no. " & cmbCustomer.SelectedRow.Cells("Account").Value & " at Udawatta Automobile Navinna? Please rate 5(Excellent), 4(Very Good), 3(Good), 2(Fair), 1(Poor) to 0773933789. Thank You!"
        Dim msg As String = txtmsg.Text
        'Dim no As String = DS.Tables(0).Rows.Cells("Telephone").Value

        If msg.Length > 0 And no.Length = 10 Then
            Dim client = New WebClient()
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
            Dim baseurl As String = "https://cpsolutions.dialog.lk/index.php/cbs/sms/send?destination=" & no & "&q=14727200434668&message=" & msg & ""
            Dim Data As Stream = client.OpenRead(baseurl)
            Dim reader As StreamReader = New StreamReader(Data)
            Dim s As String = reader.ReadToEnd()
            Data.Close()
            reader.Close()

            'no = "0777224425"
            'client = New WebClient()
            'client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
            'baseurl = "https://cpsolutions.dialog.lk/index.php/cbs/sms/send?destination=" & no & "&q=14727200434668&message=" & msg & ""
            'Data = client.OpenRead(baseurl)
            'reader = New StreamReader(Data)
            's = reader.ReadToEnd()
            'Data.Close()
            'reader.Close()
        End If
    End Sub

    Private Sub txttest_Click(sender As Object, e As EventArgs) Handles txttest.Click
        Dim msg As String = txtmsg.Text
        Dim no As String = TextBox1.Text

        If msg.Length > 0 And TextBox1.Text.Length = 10 Then
            Dim client = New WebClient()
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
            Dim baseurl As String = "https://cpsolutions.dialog.lk/index.php/cbs/sms/send?destination=" & no & "&q=14727200434668&message=" & msg & ""
            Dim Data As Stream = client.OpenRead(baseurl)
            Dim reader As StreamReader = New StreamReader(Data)
            Dim s As String = reader.ReadToEnd()
            Data.Close()
            reader.Close()

            'no = "0777224425"
            'client = New WebClient()
            'client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
            'baseurl = "https://cpsolutions.dialog.lk/index.php/cbs/sms/send?destination=" & no & "&q=14727200434668&message=" & msg & ""
            'Data = client.OpenRead(baseurl)
            'reader = New StreamReader(Data)
            's = reader.ReadToEnd()
            'Data.Close()
            'reader.Close()
        End If
    End Sub
End Class
