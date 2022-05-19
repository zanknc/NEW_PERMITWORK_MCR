Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Net
Imports System.Net.IPHostEntry
Imports System.Net.Mail
Imports System.Web
Imports System.Text
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Linq
Imports System.Math
Imports System.IO.MemoryStream
Imports System.Globalization
Imports System.IO.Stream
Imports System.Text.RegularExpressions
Partial Class P_License_Operate
    Inherits System.Web.UI.Page
    Dim timestart, timeEnd As String
    Dim PERMITWORK As String = "PERMITOVERTIME"
    Dim checkcontrolname, checkcontrolemail, checkareaname, checkareaemail, checkknowrepname, checkknowrepemail As String
    Dim STAMPSUPERNAME, STAMPSUPEREMAIL, STAMPRecipient_Know, STAMPRecipient_Email, STAMPApprovers, STAMPApprovers_Email As String
    Dim SESSION_NO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("EMPNO") = "" Then
            Response.Redirect("PERMIT_LOGIN.aspx")
            Response.End()
            Response.Clear()
            Exit Sub
        End If
        SESSION_NO = Session("VPNO")
        Label1.Text = Session("EMPNO")
        Label2.Text = Session("EMPNAME")
        'If Not Me.IsPostBack Then
        '    CheckDateNo()
        'End If
    End Sub
#Region "AUTO NO"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
        Public Shared Function SearchSFNO(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select TOP(20) SF_NO from SAFETY_PERMITWORK where SF_NO like @SearchText + '%'  GROUP BY SF_NO  ORDER BY SF_NO DESC "

        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("SF_NO").ToString)
        End While
        conn.Close()
        Return customers
    End Function
#End Region

    Protected Sub txtcheckno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcheckno.TextChanged
        If txtcheckno.Text.Trim() = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check New  NAJA !!!');", True)
        End If

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_PERMITWORK WHERE" _
                               & " SF_NO = @SF_NO"
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@SF_NO", txtcheckno.Text)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            Try
                timestart = sdr.Item("PERMIT_DATEFROM").ToString()
                txtPermit_Start.Text = DateTime.Parse(timestart).ToString("HH:mm:ss")

                timeEnd = sdr.Item("PERMIT_DATETO").ToString()
                txtPermit_End.Text = DateTime.Parse(timeEnd).ToString("HH:mm:ss")
                txtPermitRemark.Text = sdr.Item("PERMIT_REMARK").ToString()

                checkcontrolname = sdr.Item("STAMP_Supervisor").ToString()
                checkcontrolemail = sdr.Item("STAMP_Supervisor_EMAIL").ToString()


                checkknowrepname = sdr.Item("STAMP_Recipient_Know").ToString()
                checkknowrepemail = sdr.Item("STAMP_Recipient_Know_EMAIL").ToString()

                checkareaname = sdr.Item("STAMP_Approvers").ToString()
                checkareaemail = sdr.Item("STAMP_Approvers_EMAIL").ToString()

            Catch ex As Exception

            End Try
        End While
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        CHECK_APPORVEEMAIL()
        If txtcheckno.Text = "" Or txtPermit_Start.Text = "" And txtPermit_End.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check New  NAJA !!!');", True)
            Exit Sub
        End If

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("SAFETY_WORK")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PERMIT_DATEFROM", txtPermit_Start.Text)
            cmd.Parameters.AddWithValue("@PERMIT_DATETO", txtPermit_End.Text)
            cmd.Parameters.AddWithValue("@PERMIT_REMARK", txtPermitRemark.Text)


            cmd.Parameters.AddWithValue("@PERMIT_Supervisor", "WAITING STMAP")
            cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Date", DateTime.Now.ToString())

            cmd.Parameters.AddWithValue("@PERMIT_Approvers", "WAITING STMAP")
            cmd.Parameters.AddWithValue("@PERMIT_Approvers_Date", DateTime.Now.ToString())

            cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know", "WAITING STMAP")
            cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know_Date", DateTime.Now.ToString())

            cmd.Parameters.AddWithValue("@SF_NO", txtcheckno.Text)
            cmd.Connection = con

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If STAMPSUPERNAME <> "" Or STAMPSUPEREMAIL <> "" Then
                BindGridview()
                GridView1.Visible = True
                Dim Msg As New MailMessage()
                Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
                ' Sender e-mail address.
                Msg.From = fromMail
                ' Recipient e-mail address.
                Msg.[To].Add(New MailAddress(STAMPSUPEREMAIL))
                ' Subject of e-mail
                Dim bb As String
                bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Control.aspx?op=" & Trim(txtcheckno.Text) & "&Name=" & STAMPSUPERNAME & "&Email=" & STAMPSUPEREMAIL & "&PERMIT=" & PERMITWORK & """"
                Msg.Subject = "OVERTIME WORK PERMIT APPROVE"


                Msg.Body += "Please check below data <br/><br/>"
                Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + STAMPSUPERNAME & "</p>" + "<br/><br/>"
                Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
                Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
                Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

                Msg.Body += GetGridviewData(GridView1)

                Msg.Body += "<br/>THANK YOU<br/>"

                Msg.Body += "WORK PERMIT ONLINE SYSTEM"


                Msg.IsBodyHtml = True
                Dim sSmtpServer As String = ""
                sSmtpServer = "10.29.1.240"
                Dim a As New SmtpClient()
                a.Host = sSmtpServer
                a.Send(Msg)
                CHECKRecipient_Know()
                ApporveEmail()
            End If

            Response.Write("<Script>")
            Response.Write("alert('!!! WORK PERMIT  INSERT TIME   !!!');")
            Response.Write("location.href='P_License_Operate.aspx';")
            Response.Write("</Script>")
        End Using

    End Sub
#Region "BindGridview"
    Protected Sub BindGridview()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from SAFETY_PERMITWORK WHERE SF_NO =  '" & txtcheckno.Text & "'")

                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        End Using

    End Sub
    Public Function GetGridviewData(ByVal gv As GridView) As String
        Dim strBuilder As New StringBuilder()
        Dim strWriter As New StringWriter(strBuilder)
        Dim htw As New HtmlTextWriter(strWriter)
        gv.RenderControl(htw)
        Return strBuilder.ToString()
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Me.GridView1.Visible = False
    End Sub
#End Region
#Region "PRINT DATA "
    Protected Sub Btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnprint.Click
        If txtcheckno.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check Data !!!');", True)
            Exit Sub
        End If
        Dim dtAdapter As New SqlDataAdapter
        Dim V_PERMITWORK As DataTable
        Dim ds As New DataSet

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_PERMITWORK WHERE  SF_NO = '" & txtcheckno.Text.Trim() & "'  "

        dtAdapter = New SqlDataAdapter(strQuery, ConStr_SAFETY)

        If ds.Tables.Contains("V_PERMITWORK") Then
            ds.Tables("V_PERMITWORK").Rows.Clear()
            ds.Tables("V_PERMITWORK").Columns.Clear()
        End If

        dtAdapter.Fill(ds, "V_PERMITWORK")

        V_PERMITWORK = ds.Tables("V_PERMITWORK")

        If ds.Tables("V_PERMITWORK").Rows.Count = 0 Then
            Response.Write("<Script>")
            Response.Write("alert('!!! NO DATA  NAJA !!!!');")
            Response.Write("location.href='P_License_Operate.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        Dim rpt As New ReportDocument()
        rpt.Load(Server.MapPath("Safety_Report.rpt"))
        rpt.SetDataSource(V_PERMITWORK)
        Me.CrystalReportViewer1.ReportSource = rpt
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        formatType = ExportFormatType.PortableDocFormat
        rpt.ExportToHttpResponse(formatType, Response, True, "EXTRA TIME" + "-" + txtcheckno.Text.Trim())
        Response.[End]()
    End Sub
#End Region
    Protected Sub CHECK_APPORVEEMAIL()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using con
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SAFETY_PERMITWORK_STO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SF_NO", txtcheckno.Text)
            cmd.Parameters.AddWithValue("@SF_SAFETY", "SELECT")
            Using vipr = cmd.ExecuteReader()
                If vipr.Read() Then
                    Try
                        STAMPSUPERNAME = vipr.Item("STAMP_Supervisor")
                        STAMPSUPEREMAIL = vipr.Item("STAMP_Supervisor_EMAIL")

                        STAMPRecipient_Know = vipr.Item("STAMP_Recipient_Know")
                        STAMPRecipient_Email = vipr.Item("STAMP_Recipient_Know_EMAIL")


                        STAMPApprovers = vipr.Item("STAMP_Approvers")
                        STAMPApprovers_Email = vipr.Item("STAMP_Approvers_EMAIL")
                    Catch ex As Exception

                    End Try

                End If
            End Using
        End Using
    End Sub
    Protected Sub CHECKRecipient_Know()
        BindGridview()
        GridView1.Visible = True
        Dim Msg As New MailMessage()
        Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        Dim VEMAIL As String = "WORK_PERMIT@rist.local"
        Dim VNAME As String = "SAFETY"
        ' Sender e-mail address.
        Msg.From = fromMail
        ' Recipient e-mail address.
        Msg.[To].Add(New MailAddress(VEMAIL))


        Dim bb As String
        bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Safety.aspx?op=" & Trim(txtcheckno.Text) & "&NAME=" & VNAME & "&PERMIT=" & PERMITWORK & """"
        Msg.Subject = "OVERTIME WORK PERMIT APPROVE"
        Msg.Body += "Please Check Below Data <br/><br/>"
        Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + VNAME & "</p>" + "<br/><br/>"
        Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
        Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
        Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

        Msg.Body += GetGridviewData(GridView1)


        Msg.Body += "<br/>THANK YOU<br/>"
        Msg.Body += "WORK PERMIT ONLINE SYSTEM"


        Msg.IsBodyHtml = True
        Dim sSmtpServer As String = ""
        sSmtpServer = "10.29.1.240"
        Dim a As New SmtpClient()
        a.Host = sSmtpServer
        a.Send(Msg)

    End Sub
    Private Sub ApporveEmail()
        CHECK_APPORVEEMAIL()

        BindGridview()
        GridView1.Visible = True
        Try
            Dim Msg As New MailMessage()
            Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
            ' Sender e-mail address.
            Msg.From = fromMail
            ' Recipient e-mail address.
            Msg.[To].Add(New MailAddress(STAMPApprovers_Email))
            ' Subject of e-mail


            Dim bb As String
            bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_App.aspx?op=" & Trim(txtcheckno.Text) & "&Name=" & STAMPApprovers & "&Email=" & STAMPApprovers_Email & """"
            Msg.Subject = "OVERTIME WORK PERMIT APPROVE"


            Msg.Body += "Please check below data <br/><br/>"
            Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + STAMPApprovers & "</p>" + "<br/><br/>"
            Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
            Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
            Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"


            Msg.Body += GetGridviewData(GridView1)

            Msg.Body += "<br/>THANK YOU<br/>"

            Msg.Body += "WORK PERMIT ONLINE SYSTEM"


            Msg.IsBodyHtml = True
            Dim sSmtpServer As String = ""
            sSmtpServer = "10.29.1.240"
            Dim a As New SmtpClient()
            a.Host = sSmtpServer
            a.Send(Msg)
        Catch ex As Exception

        End Try

    End Sub
End Class
