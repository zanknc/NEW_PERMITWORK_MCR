Option Explicit On
Option Strict On
Imports System.IO
Imports System.Net.Mail

Partial Class P_ELECTRIC_CTRL_APPROVE
    Inherits System.Web.UI.Page
    Protected Property Scfno() As String
    Protected Property Divionname() As String
    Protected Property Departname() As String
    Protected Property Hostname() As String
    Protected Property Emailhostname() As string
    Protected Sub BindGridControlDetail
        Using db As New DBELECTRICALDataContext()
            gvctrlapp.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                                   Where e.SCNO = Scfno And e.SCSTAMPCONTROL <> "APPROVED"
                                   Select New With {e.SCNO, e.SCNAME, e.SCWORKDIV, e.SCWORKDETAIL, e.SCWORKDATE, e.SCWORKDATEFROM, e.SCWORKDATETO, e.SCNAMECONTROL, e.SCEMAILCONTROL, e.SCWORKAREA, e.SCFLOOR, e.SCSTAMPCONTROL}

            gvctrlapp.DataBind()
        End Using
    End Sub

    Private Sub P_ELECTRIC_CTRL_APPROVE_Load(sender As Object, e As EventArgs) Handles Me.Load

        Scfno = Request.QueryString("scfeno")

        BindGridControlDetail

    End Sub

    Protected Sub ApproveControl()
        Using db As New DBELECTRICALDataContext

            Try
                Dim e As SAFETY_ELECTRICAL_TEST = (From u In db.SAFETY_ELECTRICAL_TESTs Where u.SCNO = Scfno Select u).FirstOrDefault()

                e.SCSTAMPCONTROL = "APPROVED"
                e.SCCONTROLAPRDATE = DateTime.Now
                db.SubmitChanges()
                db.Dispose()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Control Approve OK. !!!');", True)
                'Response.Redirect("PERMIT_LOGIN.aspx")
            Catch ex As Exception

                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()
            End Try

        End Using
    End Sub
    Protected Sub BindGridForHostArea
        Using db As New DBELECTRICALDataContext()
            gvhostarea.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                                   Where e.SCNO = Scfno
                                   Select New With {e.SCNO, e.SCNAME, e.SCWORKDIV, e.SCWORKDETAIL, e.SCWORKDATE, e.SCWORKDATEFROM, e.SCWORKDATETO, e.SCNAMECONTROL, e.SCEMAILCONTROL, e.SCWORKAREA, e.SCFLOOR, e.SCSTAMPCONTROL, e.SCAPPNAME}
            gvhostarea.DataBind()
        End Using
    End Sub
    Private Sub getarea()
       
        'get host area detail
        dim da As New DBELECTRICALDataContext
        dim getdiv = From d In da.SAFETY_ELECTRICAL_TESTs
                where d.SCNO = Scfno
                Select New With{d.SCDIVNAME,d.SCSECTNAME}
        For Each x In getdiv
            Divionname = x.SCDIVNAME
            Departname = x.SCSECTNAME
        Next
        
        ''Get Email Host area
        Using db As New DataPermitDataContext

            
            
            Dim chkmailhost = From h In db.SAFETY_AREAs
                              Where h.AREADIV = Divionname And h.AREADEP = Departname
                              Select h

            For Each n In chkmailhost

                emailhostname = n.AREAEMAIL
                hostname = n.AREAEMPNAME
                SendMailHost
            Next
            Response.Redirect("PERMIT_LOGIN.aspx")

        End Using

    End Sub

    Protected Sub SendmailHost()
        BindGridForHostArea()
        gvhostarea.Visible = True
        Dim Msg As New MailMessage()
        Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        ' Sender e-mail address.
        Msg.From = fromMail
        ' Recipient e-mail address.
        Msg.[To].Add(New MailAddress(emailhostname))
        ' Subject of e-mail
        Dim bb, VIP_REMARK As String
        Msg.SubjectEncoding = System.Text.Encoding.UTF8

        Msg.BodyEncoding = System.Text.Encoding.UTF8
        
        bb = "http://10.29.1.39/PERMITONLINE/P_ELECTRIC_HOST_APPROVE.aspx?scfeno=" & Scfno & "&Email=" & Emailhostname & "&Hostname=" & Hostname & """"
        VIP_REMARK = " **** Special Case Work ***** "
        Msg.Subject = "WORK PERMIT ONLINE APPROVE (ELECTRICAL WORK) "
        Msg.Body += "Please Check Below Data <br/><br/>"
        Msg.Body = "<p style='font-family:Tahoma; font-size:18'>" & "To :" + hostname & "</p>" + "<br/><br/>"
        Msg.Body += " You have Work Permt  waiting for your Host Area approve " + "<br/>"
        Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
        Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

        Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

        Msg.Body += GetGridviewData(gvhostarea)


        Msg.Body += "<br/>THANK YOU<br/>"

        Msg.Body += "WORK PERMIT ONLINE SYSTEM"

        Msg.IsBodyHtml = True
        'Msg.SubjectEncoding = System.Text.Encoding.GetEncoding("tis-620")
        Dim sSmtpServer As String = ""
        sSmtpServer = "10.29.1.240"
        Dim a As New SmtpClient()
        a.Host = sSmtpServer
        a.Send(Msg)

        gvhostarea.Visible = True
    End Sub
    Public Function GetGridviewData(ByVal gv As GridView) As String
        Dim strBuilder As New StringBuilder()
        Dim strWriter As New StringWriter(strBuilder)
        Dim htw As New HtmlTextWriter(strWriter)
        gv.RenderControl(htw)
        Return strBuilder.ToString()
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Me.gvhostarea.Visible = False
    End Sub

    Private Sub lnkctrlapprove_Click(sender As Object, e As EventArgs) Handles lnkctrlapprove.Click
        ApproveControl
        getarea()
    End Sub
End Class
