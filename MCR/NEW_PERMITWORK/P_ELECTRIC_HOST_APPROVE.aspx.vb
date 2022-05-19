Option Explicit On
Option Strict On
Imports System.IO
Imports System.Net.Mail

Partial Class P_ELECTRIC_HOST_APPROVE
    Inherits System.Web.UI.Page
    Protected Property Scfno() As String
    Protected Property Emailsafety() As String
    Protected Property Safetyname() As String
    Protected Property Hostname() As String
    Protected Property Emailhostname() As string

    Private Sub P_ELECTRIC_HOST_APPROVE_Load(sender As Object, e As EventArgs) Handles Me.Load
        Scfno = Request.QueryString("scfeno")
        Hostname = Request.QueryString("Hostname")
        Emailhostname = Request.QueryString("Email")

        BindGridHostDetail

    End Sub

    Protected Sub BindGridHostDetail
        Using db As New DBELECTRICALDataContext()
            gvhostapp.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                                   Where e.SCNO = Scfno And e.SCAPPNAME <> "APPROVED"
                                   Select New With {e.SCNO, e.SCNAME, e.SCWORKDIV, e.SCWORKDETAIL, e.SCWORKDATE, e.SCWORKDATEFROM, e.SCWORKDATETO, e.SCNAMECONTROL, e.SCEMAILCONTROL, e.SCWORKAREA, e.SCFLOOR, e.SCSTAMPCONTROL, e.SCAPPNAME}

            gvhostapp.DataBind()
        End Using
    End Sub

    Protected Sub ApproveHost()
        Using db As New DBELECTRICALDataContext

            Try
                Dim e As SAFETY_ELECTRICAL_TEST = (From u In db.SAFETY_ELECTRICAL_TESTs Where u.SCNO = Scfno Select u).FirstOrDefault()

                e.SCAPPNAME = "APPROVED"
                e.SCHOSTAPRDATE = DateTime.Now
                e.SCTITLEAPPNAME = Hostname
                e.SCEMAILAPPNAME = Emailhostname
                db.SubmitChanges()
                db.Dispose()

                SendmailSafety()
                'ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Host Approve OK. !!!');", True)
                Response.Redirect("PERMIT_LOGIN.aspx")
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

    Protected Sub BindGridForSafety
        Using db As New DBELECTRICALDataContext()
            gvsafety.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                                  Where e.SCNO = Scfno
                                  Select New With {e.SCNO, e.SCNAME, e.SCWORKDIV, e.SCWORKDETAIL, e.SCWORKDATE, e.SCWORKDATEFROM, e.SCWORKDATETO, e.SCNAMECONTROL, e.SCEMAILCONTROL, e.SCWORKAREA, e.SCFLOOR, e.SCSTAMPCONTROL, e.SCAPPNAME, e.SCSAFETYNAME}
            gvsafety.DataBind()
        End Using
    End Sub
    

    Protected Sub SendmailSafety()
        BindGridForSafety()
        gvsafety.Visible = True
        Dim Msg As New MailMessage()
        Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        ' Sender e-mail address.
        Msg.From = fromMail
        ' Recipient e-mail address.
        Msg.[To].Add(New MailAddress("WORK_PERMIT@rist.local"))
        ' Subject of e-mail
        Dim bb, VIP_REMARK As String
        Msg.SubjectEncoding = System.Text.Encoding.UTF8

        Msg.BodyEncoding = System.Text.Encoding.UTF8

        bb = "http://10.29.1.39/PERMITONLINE/P_ELECTRIC_SAFETY_APPROVE.aspx?scfeno=" & Scfno & """"
        VIP_REMARK = " **** Special Case Work ***** "
        Msg.Subject = "WORK PERMIT ONLINE APPROVE (ELECTRICAL WORK) "
        Msg.Body += "Please Check Below Data <br/><br/>"
        Msg.Body = "<p style='font-family:Tahoma; font-size:18'>" & "To :SAFETY</p>" + "<br/><br/>"
        Msg.Body += " You have Work Permt  waiting for your Safety approve " + "<br/>"
        Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
        Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

        Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

        Msg.Body += GetGridviewData(gvsafety)


        Msg.Body += "<br/>THANK YOU<br/>"

        Msg.Body += "WORK PERMIT ONLINE SYSTEM"

        Msg.IsBodyHtml = True
        'Msg.SubjectEncoding = System.Text.Encoding.GetEncoding("tis-620")
        Dim sSmtpServer As String = ""
        sSmtpServer = "10.29.1.240"
        Dim a As New SmtpClient()
        a.Host = sSmtpServer
        a.Send(Msg)

        gvsafety.Visible = True
    End Sub
    Public Function GetGridviewData(ByVal gv As GridView) As String
        Dim strBuilder As New StringBuilder()
        Dim strWriter As New StringWriter(strBuilder)
        Dim htw As New HtmlTextWriter(strWriter)
        gv.RenderControl(htw)
        Return strBuilder.ToString()
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Me.gvsafety.Visible = False
    End Sub

    Private Sub lnkhostapprove_Click(sender As Object, e As EventArgs) Handles lnkhostapprove.Click
        ApproveHost()
        'SendmailSafety()
    End Sub
End Class
