Option Explicit On
Option Strict On
Partial Class P_ELECTRIC_SAFETY_APPROVE
    Inherits System.Web.UI.Page
    Protected Property Scfno() As String
    Protected Property Emailsafety() As String
    Protected Property Safetyname() As String
    Protected Property Ipaddress() As String
    Private Sub P_ELECTRIC_SAFETY_APPROVE_Load(sender As Object, e As EventArgs) Handles Me.Load
     Scfno = Request.QueryString("scfeno")
        'Scfno = "18/11/00003"
       
       Ipaddress = CType(Session("IP_ADDRESS"), String)
       'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & Ipaddress & """);", True)
       BindGridSafetyDetail
    End Sub
    Protected Sub BindGridSafetyDetail
        Using db As New DBELECTRICALDataContext()
            gvsafetyapp.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                Where e.SCNO = Scfno And e.SCSAFETYNAME <> "APPROVED"
                Select New With {e.SCNO, e.SCNAME, e.SCWORKDIV, e.SCWORKDETAIL, e.SCWORKDATE, e.SCWORKDATEFROM, e.SCWORKDATETO, e.SCNAMECONTROL, e.SCEMAILCONTROL, e.SCWORKAREA, e.SCFLOOR, e.SCSTAMPCONTROL, e.SCAPPNAME,e.SCSAFETYNAME}
            gvsafetyapp.DataBind()
        End Using
    End Sub

    Protected Sub ApproveSafety()
        Using db As New DBELECTRICALDataContext

            Try
                Dim e As SAFETY_ELECTRICAL_TEST = (From u In db.SAFETY_ELECTRICAL_TESTs Where u.SCNO = Scfno Select u).FirstOrDefault()

                e.SCSAFETYNAME = "APPROVED"
                e.SCSAFETYDATE = DateTime.Now
                e.SCTITLESAFETYNAME = Safetyname
                e.SCSAFETYEMAILNAME = Emailsafety
                db.SubmitChanges()
                db.Dispose()
                ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Safety Approve OK. !!!');", True)
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
    Private Sub Getsafety()

        'get host area detail
        'Dim da As New DBELECTRICALDataContext
        'Dim getdiv = From d In da.SAFETY_ELECTRICAL_TESTs
        '             Where d.SCNO = Scfno
        '             Select New With {d.SCDIVNAME, d.SCSECTNAME}
        'For Each x In getdiv
        '    Divionname = x.SCDIVNAME
        '    Departname = x.SCSECTNAME
        'Next

        ''Get Email Host area
        Using db As New DBELECTRICALDataContext

            Dim chkmailsafety = From h In db.SAFETY_APPROVEEMAIL_ELECTRICALs
                    Where h.SAFETYEIPADDRESS = Ipaddress
                    Select h

            For Each n In chkmailsafety

                Emailsafety = n.SAFETYEMAIL
                Safetyname = n.SAFETYNAME
                ApproveSafety

            Next
            Response.Redirect("PERMIT_LOGIN.aspx")

        End Using

    End Sub
    Private Sub lnksafetyapprove_Click(sender As Object, e As EventArgs) Handles lnksafetyapprove.Click
        Getsafety()
        
    End Sub
End Class
