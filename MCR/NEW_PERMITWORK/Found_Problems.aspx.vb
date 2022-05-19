Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Globalization
Imports CrystalDecisions.Shared
Imports System.IO
Imports System
Imports System.Data.Sql
Imports System.Web
Imports System.Net
Imports System.Net.IPHostEntry
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Linq
Imports System.Math
Imports System.IO.MemoryStream
Imports System.IO.Stream
Imports System.Web.Services
Imports System.Net.Mail
Imports System.Text
Imports System.Web.UI
Partial Class Found_Problems
    Inherits System.Web.UI.Page
    Dim IPADD As String
    Dim ipaddress, SESSION_NO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        IPADD = "IP : " & ipaddress

        Session("IP_ADDRESS") = ipaddress

        If Session("EMPNO") = "" Then
            Response.Redirect("PERMIT_LOGIN.aspx")
            Response.End()
            Response.Clear()
            Exit Sub
        End If
        SESSION_NO = Session("VPNO")
        Label1.Text = Session("EMPNO")
        Label2.Text = Session("EMPNAME")

    End Sub


    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtdetail.Text = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!!  Please Check Data OK    !!!!');")
            Response.Write("location.href='Found_Problems.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If
        Dim V1NAME As String = "SAFETY"
        Dim V1EMAIL As String = "WORK_PERMIT@rist.local"
        'Dim V2NAME As String = "Weerapat"
        'Dim V2EMAIL As String = "Weerapat.Bua@Rist.Local"
        'Dim V3NAME As String = "TONSIRIKUL"
        'Dim V3EMAIL As String = "ton.is@Rist.Local"
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)

        Using cmd As New SqlCommand("INSERT INTO SAFETY_FOUND (Name, detail , other , ipaddressname) VALUES (@Name, @detail , @other , @ipaddressname)")
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim())
            cmd.Parameters.AddWithValue("@detail", txtdetail.Text.Trim())
            cmd.Parameters.AddWithValue("@other", txtOther.Text.Trim())
            cmd.Parameters.AddWithValue("@ipaddressname", IPADD)
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If txtdetail.Text <> "" Then
                Response.Write("<Script>")
                Response.Write("alert('!!!  Insert Data OK    !!!!');")
                Response.Write("location.href='Found_Problems.aspx';")
                Response.Write("</Script>")
            End If
        End Using


        If V1EMAIL <> "" And V1NAME <> "" Then
            Dim Msg As New MailMessage()
            Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
            ' Sender e-mail address.
            Msg.From = fromMail
            ' Recipient e-mail address.
            Msg.[To].Add(New MailAddress(V1EMAIL))
            Msg.SubjectEncoding = System.Text.Encoding.UTF8

            Msg.BodyEncoding = System.Text.Encoding.UTF8


            Msg.Subject = "ปัญหาที่พบเจอและข้อมูลเพิ่มเติมอื่นๆ "
            Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + V1NAME & "</p>" + "<br/><br/>"
            Msg.Body += txtdetail.Text.Trim() + "<br/>"
            'Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"


            Msg.Body += "<br/>THANK YOU<br/>"
            Msg.Body += "WORK PERMIT ONLINE SYSTEM"


            Msg.IsBodyHtml = True
            Dim sSmtpServer As String = ""
            sSmtpServer = "10.29.1.240"
            Dim a As New SmtpClient()
            a.Host = sSmtpServer
            a.Send(Msg)
        End If

        'If V2EMAIL <> "" And V2NAME <> "" Then
        '    Dim Msg As New MailMessage()
        '    Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        '    ' Sender e-mail address.
        '    Msg.From = fromMail
        '    ' Recipient e-mail address.
        '    Msg.[To].Add(New MailAddress(V2EMAIL))

        '    Msg.SubjectEncoding = System.Text.Encoding.UTF8

        '    Msg.BodyEncoding = System.Text.Encoding.UTF8

        '    Msg.Subject = "ปัญหาที่พบเจอและข้อมูลเพิ่มเติมอื่นๆ "
        '    Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + V2NAME & "</p>" + "<br/><br/>"
        '    Msg.Body += txtdetail.Text.Trim() + "<br/>"
        '    'Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"


        '    Msg.Body += "<br/>THANK YOU<br/>"
        '    Msg.Body += "WORK PERMIT ONLINE SYSTEM"


        '    Msg.IsBodyHtml = True
        '    Dim sSmtpServer As String = ""
        '    sSmtpServer = "10.29.1.240"
        '    Dim a As New SmtpClient()
        '    a.Host = sSmtpServer
        '    a.Send(Msg)
        'End If

        'If V3EMAIL <> "" And V3NAME <> "" Then
        '    Dim Msg As New MailMessage()
        '    Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        '    ' Sender e-mail address.
        '    Msg.From = fromMail
        '    ' Recipient e-mail address.
        '    Msg.[To].Add(New MailAddress(V3EMAIL))
        '    Msg.SubjectEncoding = System.Text.Encoding.UTF8

        '    Msg.BodyEncoding = System.Text.Encoding.UTF8


        '    Msg.Subject = "ปัญหาที่พบเจอและข้อมูลเพิ่มเติมอื่นๆ "
        '    Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + V3NAME & "</p>" + "<br/><br/>"
        '    Msg.Body += txtdetail.Text.Trim() + "<br/>"
        '    'Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"


        '    Msg.Body += "<br/>THANK YOU<br/>"
        '    Msg.Body += "WORK PERMIT ONLINE SYSTEM"


        '    Msg.IsBodyHtml = True
        '    Dim sSmtpServer As String = ""
        '    sSmtpServer = "10.29.1.240"
        '    Dim a As New SmtpClient()
        '    a.Host = sSmtpServer
        '    a.Send(Msg)
        'End If

    End Sub


End Class
