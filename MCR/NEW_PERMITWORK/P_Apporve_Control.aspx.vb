Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq
Imports System.Web.UI
Imports System.Math
Imports System.IO.MemoryStream
Imports System.Globalization
Imports System.IO.Stream
Imports System.Text
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Net
Imports System.Net.IPHostEntry

Partial Class P_Apporve_Control
    Inherits System.Web.UI.Page
    Dim OPNO As String
    Dim NAME As String
    Dim Email As String
    Dim PERMITWORK As String = "WORKTIME"
    Dim aa As String
    Dim PERMIT, VIPADDRESS, CheckOpea As String
    Dim DDATEDTART, TIMESTART, TIMEEND, EXTRASTART, EXTRAEND As String ' DATE

    Dim SNAME, SEmail, SSTATUS, SDIVISON, SDEPARTMENT As String
    Dim DAREADIV, DAREAEMPNAME, DAREAEMAIL, DAREADEP As String
    Dim DAREANO As Integer
    Dim CHECKAREA, CHECKALL As String
    Dim VNAME, VEMAIL, VNO As String ' SAFETY APPORVE
    Dim CHKExtimeFrom, CHKExtimeTo, ExtimeFrom, ExtimeTo As String
    Dim Equipment_E1, Equipment_E2, Equipment_E3, Equipment_E4, Equipment_E5, CHECKAREAR As New ListItem() ' ListItemName

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OPNO = Request.QueryString("op")
        NAME = Request.QueryString("Name")
        Email = Request.QueryString("Email")
        PERMIT = Request.QueryString("PERMIT")

        Session("OPNO") = Request.QueryString("op")
        Session("Name") = Request.QueryString("Name")
        Session("Email") = Request.QueryString("Email")
        Session("PERMIT") = Request.QueryString("PERMIT")

        lb_opno.Text = OPNO
        Label1.Text = Request.QueryString("op")
        aa = Session.Timeout.ToString

        Session("VPNO") = lb_opno.Text


        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from SAFETY_PERMITWORK WHERE SF_NO =  '" & lb_opno.Text & "'")

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
        CHECKDATA()
    End Sub
    Private Sub CHECKSTAMP()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim cmd As New SqlCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SAFETY_PERMITWORK_STO"

        cmd.Parameters.AddWithValue("@SF_NO", lb_opno.Text)
        cmd.Parameters.AddWithValue("@SF_SAFETY", "SELECT")
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            SNAME = sdr("STAMP_Supervisor").ToString()
            SEmail = sdr("STAMP_Supervisor_EMAIL").ToString()
            SSTATUS = sdr("STAMP_Supervisor_Status").ToString()

            CHKExtimeFrom = sdr("PERMIT_DATEFROM").ToString()

            ExtimeFrom = DateTime.Parse(CHKExtimeFrom).ToString("HH:mm:ss")

            CHKExtimeTo = sdr.Item("PERMIT_DATETO").ToString()

            ExtimeTo = DateTime.Parse(CHKExtimeTo).ToString("HH:mm:ss")

            SDEPARTMENT = sdr.Item("SF_The_work_Dep").ToString()

            SDIVISON = sdr.Item("SF_The_work_Div").ToString()

            CHECKALL = sdr.Item("SF_The_work_area").ToString()

            CHECKAREA = sdr.Item("SF_The_work_Floor").ToString()

        End While

    End Sub
    Protected Sub btnapp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnapp.Click
        CHECKSTAMP()

        If PERMIT = "PERMITOVERTIME" Then
            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("UPDATE SAFETY_PERMITWORK SET PERMIT_Supervisor = @PERMIT_Supervisor, PERMIT_Supervisor_Date = @PERMIT_Supervisor_Date, " _
            & "PERMIT_Supervisor_EMAIL = @PERMIT_Supervisor_EMAIL , PERMIT_Supervisor_Status = @PERMIT_Supervisor_Status WHERE SF_NO = @SF_NO")

                Using sda As New SqlDataAdapter()
                    cmd.Parameters.AddWithValue("@PERMIT_Supervisor", UCase(Trim(NAME)))
                    cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Date", DateTime.Now.ToString())
                    cmd.Parameters.AddWithValue("@PERMIT_Supervisor_EMAIL", Email)
                    cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Status", "STAMP OK")
                    cmd.Parameters.AddWithValue("@SF_NO", lb_opno.Text)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Response.Write("<Script>")
                    Response.Write("alert('!!! PERMIT TO WORK OVERTIME STAMP OK   !!!');")
                    Response.Write("location.href='P_PermitWork.aspx';")
                    Response.Write("</Script>")
                    CHECKRecipient_Know()
                    ApporveEmail()
                End Using
            End Using

            Exit Sub
        End If


        If SNAME = "" Or SSTATUS.Trim() = "STAMP OK" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Check STAMP ALREADY  !!!');")
            Response.Write("location.href='P_PermitWork.aspx';")
            Response.Write("</Script>")
            Exit Sub
        ElseIf ExtimeFrom = "00:00:00" Or ExtimeTo = "00:00:00" Then
            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SAFETY_PERMITWORK_CONUPDATE")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SF_SAFETY_CONUPDATE", "CONUPDATE")
                cmd.Parameters.AddWithValue("@STAMP_Supervisor", UCase(Trim(NAME)))
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", Email)
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Status", "STAMP OK")
                cmd.Parameters.AddWithValue("@SF_NO", lb_opno.Text.Trim())
                cmd.Connection = con

                Response.Write("<Script>")
                Response.Write("alert('!!! PERMIT WORK STAMP OK   !!!');")
                Response.Write("location.href='P_PermitWork.aspx';")
                Response.Write("</Script>")


                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                CHECKRecipient_Know()
                ApporveEmail()
            End Using
        Else

            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SAFETY_PERMITWORK_CONUPDATE")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SF_SAFETY_CONUPDATE", "CONUPDATE")
                cmd.Parameters.AddWithValue("@STAMP_Supervisor", UCase(Trim(NAME)))
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", Email)
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Status", "STAMP OK")
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor", UCase(Trim(NAME)))
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_EMAIL", Email)
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Status", "STAMP OK")
                cmd.Parameters.AddWithValue("@SF_NO", lb_opno.Text.Trim())
                cmd.Connection = con

                Response.Write("<Script>")
                Response.Write("alert('!!! PERMIT WORK STAMP OK   !!!');")
                Response.Write("location.href='P_PermitWork.aspx';")
                Response.Write("</Script>")

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                CHECKRecipient_Know()
                ApporveEmail()
            End Using
        End If
    End Sub

#Region "BindGridview"
    Protected Sub BindGridview()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from SAFETY_PERMITWORK WHERE SF_NO =  '" & lb_opno.Text & "'")

                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView3.DataSource = dt
                        GridView3.DataBind()
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
        Me.GridView3.Visible = False
    End Sub
#End Region
#Region "APPROVE SAFETY"
    Protected Sub CHECKRecipient_Know()

        BindGridview()
        GridView3.Visible = True
        Dim Msg As New MailMessage()
        Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
        Dim VEMAIL As String = "WORK_PERMIT@rist.local"
        Dim VNAME As String = "SAFETY"
                ' Sender e-mail address.
        Msg.From = fromMail

                ' Recipient e-mail address.
        Msg.[To].Add(New MailAddress(VEMAIL))

        Dim VIP_REMARK As String
        Dim bb As String
        If CHECKAREA.Trim() = "ALL" Or CHECKALL.Trim() = "ALL" Then

            bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Safety.aspx?op=" & Trim(lb_opno.Text) & "&NAME=" & VNAME & "&PERMIT=" & PERMITWORK & """"
            VIP_REMARK = " **** Special Case Work ***** "
            Msg.Subject = "WORK PERMIT ONLINE APPROVE"
            Msg.Body += "Please Check Below Data <br/><br/>"
            Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + VNAME & "</p>" + "<br/><br/>"
            Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
            Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
            Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"


            Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

            Msg.Body += GetGridviewData(GridView3)


            Msg.Body += "<br/>THANK YOU<br/>"
            Msg.Body += "WORK PERMIT ONLINE SYSTEM"


            Msg.IsBodyHtml = True
            Dim sSmtpServer As String = ""
            sSmtpServer = "10.29.1.240"
            Dim a As New SmtpClient()
            a.Host = sSmtpServer
            a.Send(Msg)

        Else
            bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Safety.aspx?op=" & Trim(lb_opno.Text) & "&NAME=" & VNAME & "&PERMIT=" & PERMITWORK & """"

            Msg.Subject = "WORK PERMIT ONLINE APPROVE"
            Msg.Body += "Please Check Below Data <br/><br/>"
            Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + VNAME & "</p>" + "<br/><br/>"
            Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
            Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
            Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

            Msg.Body += GetGridviewData(GridView3)


            Msg.Body += "<br/>THANK YOU<br/>"
            Msg.Body += "WORK PERMIT ONLINE SYSTEM"


            Msg.IsBodyHtml = True
            Dim sSmtpServer As String = ""
            sSmtpServer = "10.29.1.240"
            Dim a As New SmtpClient()
            a.Host = sSmtpServer
            a.Send(Msg)

        End If



    End Sub
#End Region
#Region "APPROVE HOST"
    Private Sub ApporveEmail()
        CHECKSTAMP()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM  SAFETY_AREA WHERE" _
                               & " AREADEP = @AREADEP AND" _
                               & " AREADIV = @AREADIV" 
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@AREADEP", SDEPARTMENT)
        cmd.Parameters.AddWithValue("@AREADIV", SDIVISON)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        While sdr.Read()
            DAREADIV = sdr("AREADIV").ToString()
            DAREAEMPNAME = sdr("AREAEMPNAME").ToString()
            DAREAEMAIL = sdr("AREAEMAIL").ToString()
            DAREADEP = sdr("AREADEP").ToString()
            'DAREANO = sdr("AREANO").ToString()
            'DAREANO = sdr("AREACHECKNO").ToString()

            Try
                If DAREADEP = SDEPARTMENT Then


                    BindGridview()
                    GridView3.Visible = True
                    Dim Msg As New MailMessage()
                    Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
                    ' Sender e-mail address.
                    Msg.From = fromMail
                    ' Recipient e-mail address.
                    Msg.[To].Add(New MailAddress(DAREAEMAIL))
                    ' Subject of e-mail
                    Dim VIP_REMARK As String
                    Dim bb As String

                    If CHECKAREA.Trim() = "ALL" Or CHECKALL.Trim() = "ALL" Then
                        bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_App.aspx?op=" & Trim(lb_opno.Text) & "&Name=" & DAREAEMPNAME & "&Email=" & DAREAEMAIL & "&PERMIT=" & PERMITWORK & """"
                        VIP_REMARK = " **** Special Case Work ***** "
                        Msg.Subject = "WORK PERMIT ONLINE APPROVE"
                        Msg.Body += "Please Check Below Data <br/><br/>"
                        Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + DAREAEMPNAME & "</p>" + "<br/><br/>"
                        Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
                        Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
                        Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"


                        Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

                        Msg.Body += GetGridviewData(GridView3)


                        Msg.Body += "<br/>THANK YOU<br/>"
                        Msg.Body += "WORK PERMIT ONLINE SYSTEM"


                        Msg.IsBodyHtml = True
                        Dim sSmtpServer As String = ""
                        sSmtpServer = "10.29.1.240"
                        Dim a As New SmtpClient()
                        a.Host = sSmtpServer
                        a.Send(Msg)
                    Else
                        bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_App.aspx?op=" & Trim(lb_opno.Text) & "&Name=" & DAREAEMPNAME & "&Email=" & DAREAEMAIL & "&PERMIT=" & PERMITWORK & """"

                        Msg.Subject = "WORK PERMIT ONLINE APPROVE"
                        Msg.Body += "Please Check Below Data <br/><br/>"
                        Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + DAREAEMPNAME & "</p>" + "<br/><br/>"
                        Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
                        Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
                        Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"


                        Msg.Body += GetGridviewData(GridView3)


                        Msg.Body += "<br/>THANK YOU<br/>"
                        Msg.Body += "WORK PERMIT ONLINE SYSTEM"


                        Msg.IsBodyHtml = True
                        Dim sSmtpServer As String = ""
                        sSmtpServer = "10.29.1.240"
                        Dim a As New SmtpClient()
                        a.Host = sSmtpServer
                        a.Send(Msg)
                    End If
                End If

            Catch ex As Exception
                Response.Write("<Script>")
                Response.Write("alert('!!! Please Contact 4724 MR.WEERAPAT  !!!');")
                Response.Write("location.href='P_PermitWork.aspx';")
                Response.Write("</Script>")
            End Try

        End While
    End Sub
#End Region
    Private Sub CHECKDATA()
        'DIVION_DATA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_PERMITWORK WHERE" _
                               & " SF_NO = @SF_NO"
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@SF_NO", lb_opno.Text)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            CHK_Contruction.Checked = sdr.Item("SF_Contruction")
            CHK_Work_High.Checked = sdr.Item("SF_Work_on_a_high")
            CHK_Work_Chemical.Checked = sdr.Item("SF_Work_in_a_chemical")
            CHK_Work_Glass.Checked = sdr.Item("SF_Work_Glass")
            CHK_Lifting_More.Checked = sdr.Item("SF_Lifting_More_100")
            CHK_Related_System.Checked = sdr.Item("SF_Related_to_the_power_system")
            CHK_Install.Checked = sdr.Item("SF_Installation_and_mainten")
            CHK_Work_others.Checked = sdr.Item("SF_Work_others")
            txtWorkother.Text = sdr.Item("SF_Work_others_Details").ToString()

            ddlworkarea.SelectedItem.Text = sdr.Item("SF_The_work_area").ToString()
            ddlworkfloor.SelectedItem.Text = sdr.Item("SF_The_work_Floor").ToString()

            ddlareadiv.Text = sdr.Item("SF_The_work_Div").ToString()
            ddlareadep.Text = sdr.Item("SF_The_work_Dep").ToString()


            txtWorkother.Text = sdr.Item("SF_The_work_Other").ToString()


            DDATEDTART = sdr.Item("SF_WorkDate").ToString()
            tb_date_wk.Text = DateTime.Parse(DDATEDTART).ToString("yyyy-MM-dd")
            tb_date_wk.BackColor = Drawing.Color.LightBlue


            TIMESTART = sdr.Item("SF_Time_str1").ToString()
            tb_time_start.Text = DateTime.Parse(TIMESTART).ToString("HH:mm:ss")
            tb_time_start.BackColor = Drawing.Color.LightBlue



            TIMEEND = sdr.Item("SF_Time_end1").ToString()
            tb_time_end.Text = DateTime.Parse(TIMEEND).ToString("HH:mm:ss")
            tb_time_end.BackColor = Drawing.Color.LightBlue



            txtDetailWork.Text = sdr.Item("SF_WORK_Details").ToString()

            Try

                CheckOpea = sdr.Item("SF_Operator").ToString()
                If CheckOpea = False Then
                    ChkOperator1.Checked = True
                    txtddldivion.Text = sdr.Item("SF_EMP_ROHM_DIV")
                    txtddldepartment.Text = sdr.Item("SF_EMP_ROHM_DEP")

                ElseIf CheckOpea = True Then
                    ChkOperator2.Checked = True
                    txtSearch.Text = sdr.Item("SP_EMP_CONTRACTOR").ToString()
                    txtname.Text = sdr.Item("SP_EMP_CONTRACTOR_NAME").ToString()
                    txtsumname.Text = sdr.Item("SP_EMP_CONTRACTOR_TEAM").ToString()
                End If

                txtEquipment_E1.Text = sdr.Item("SQ_Equipment_E1").ToString()
                txtEquipment_E1_Detail.Text = sdr.Item("SQ_Equipment_E1_NG").ToString()
                txtEquipment_E2.Text = sdr.Item("SQ_Equipment_E2").ToString()
                txtEquipment_E2_Detail.Text = sdr.Item("SQ_Equipment_E2_NG").ToString()
                txtEquipment_E3.Text = sdr.Item("SQ_Equipment_E3").ToString()
                txtEquipment_E3_Detail.Text = sdr.Item("SQ_Equipment_E3_NG").ToString()
                txtEquipment_E4.Text = sdr.Item("SQ_Equipment_E4").ToString()
                txtEquipment_E4_Detail.Text = sdr.Item("SQ_Equipment_E4_NG").ToString()
                txtEquipment_E5.Text = sdr.Item("SQ_Equipment_E5").ToString()
                txtEquipment_E5_Detail.Text = sdr.Item("SQ_Equipment_E5_NG").ToString()


                Equipment_E1.Value = sdr("SQ_Equipment_E1_CHK").ToString()
                If Equipment_E1.Value = 1 Then
                    CHK_Equipment_E1.Items.FindByValue("1").Selected = True
                Else
                    CHK_Equipment_E1.Items.FindByValue("0").Selected = True
                End If

                Equipment_E2.Value = sdr("SQ_Equipment_E2_CHK").ToString()
                If Equipment_E2.Value = 1 Then
                    CHK_Equipment_E2.Items.FindByValue("1").Selected = True
                Else
                    CHK_Equipment_E2.Items.FindByValue("0").Selected = True
                End If

                Equipment_E3.Value = sdr("SQ_Equipment_E3_CHK").ToString()
                If Equipment_E3.Value = 1 Then
                    CHK_Equipment_E3.Items.FindByValue("1").Selected = True
                Else
                    CHK_Equipment_E3.Items.FindByValue("0").Selected = True
                End If

                Equipment_E4.Value = sdr("SQ_Equipment_E4_CHK").ToString()
                If Equipment_E4.Value = 1 Then
                    CHK_Equipment_E4.Items.FindByValue("1").Selected = True
                Else
                    CHK_Equipment_E4.Items.FindByValue("0").Selected = True
                End If

                Equipment_E5.Value = sdr("SQ_Equipment_E5_CHK").ToString()
                If Equipment_E5.Value = 1 Then
                    CHK_Equipment_E5.Items.FindByValue("1").Selected = True
                Else
                    CHK_Equipment_E5.Items.FindByValue("0").Selected = True
                End If

            Catch ex As Exception

            End Try
            Try



                ChkFire_safety.Checked = sdr.Item("ST_Fire_safety")

                ChkStandand_alone.Checked = sdr.Item("ST_Standand_alone")

                CHK_Warning_Sign.Checked = sdr.Item("ST_Warning_Sign")

                CHK_Fire_Wash.Checked = sdr.Item("ST_Fire_Wash")

                CHK_The_Barrier.Checked = sdr.Item("ST_The_Barrier")

                CHK_Signal_man.Checked = sdr.Item("ST_Signal_man")

                CHK_Certified_By_Engineer.Checked = sdr.Item("ST_Certified_By_Engineer")

                CHK_Other.Checked = sdr.Item("ST_Other")

                txtCHK_Detail.Text = sdr.Item("ST_Detail")


                CHK_Safety_Shoes.Checked = sdr.Item("SPE_Safety_Shoes")

                CHK_Chemical_Clothing.Checked = sdr.Item("SPE_Chemical_Protective_Clothing")
                CHK_Chemical_Gloves.Checked = sdr.Item("SPE_Chemical_Resistant_Gloves")
                CHK_Helmet.Checked = sdr.Item("SPE_Helmet")
                CHK_Safety_belt.Checked = sdr.Item("SPE_Safety_belt")

                CHK_Earplugs.Checked = sdr.Item("SPE_Earplugs")
                CHK_Respirator.Checked = sdr.Item("SPE_Respirator")
                CHK_Safety_glasses_dimming.Checked = sdr.Item("SPE_Safety_glasses_dimming")

                CHK_Shieldother.Checked = sdr.Item("SPE_Shield_the_light_bounce_off_each_other")
                CHK_OtherEquipment.Checked = sdr.Item("SPE_Other_protective_equipment")
                txtequipment_Details.Text = sdr.Item("SPE_Other_protective_equipment_Details")

            Catch ex As Exception

            End Try
            Try


                CHECKAREAR.Value = sdr("PERMIT_CHECK").ToString()
                If CHECKAREAR.Value = 1 Then
                    chkchekarea.Items.FindByValue("1").Selected = True
                Else
                    chkchekarea.Items.FindByValue("0").Selected = True
                End If

                txtfinishdetail.Text = sdr.Item("PERMIT_DETAIL")
            Catch ex As Exception

            End Try
            Try
                txtAApplicant.Text = sdr.Item("STAMP_Applicant")
                txtControl.Text = sdr.Item("STAMP_Supervisor")
                txtControlEmail.Text = sdr.Item("STAMP_Supervisor_EMAIL").ToString()


                EXTRASTART = sdr.Item("PERMIT_DATEFROM").ToString()
                txtPermit_Start.Text = DateTime.Parse(EXTRASTART).ToString("HH:mm:ss")
                txtPermit_Start.BackColor = Drawing.Color.LightBlue

                EXTRAEND = sdr.Item("PERMIT_DATETO").ToString()
                txtPermit_End.Text = DateTime.Parse(EXTRAEND).ToString("HH:mm:ss")
                txtPermit_End.BackColor = Drawing.Color.LightBlue
                txtPermitRemark.Text = sdr.Item("PERMIT_REMARK").ToString()
            Catch ex As Exception

            End Try




        End While
    End Sub

End Class
