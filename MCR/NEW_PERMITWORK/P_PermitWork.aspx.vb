Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Partial Class P_PermitWork
    Inherits System.Web.UI.Page
    Dim rpt As New ReportDocument()
    Dim DateNow, CDYEAR, CDMONTH, CDATENOW As String 'DateTimeSetCDDATE
    Dim DATECHECK_SF, DMIDDATA As String ' checkno
    Dim Vipdata, DDateNO, DNODATA As String
    Dim AAA, DateString, timestart, timeEnd, CheckOpea, CHECKTEXT As String
    Dim PERMITWORK As String = "WORKTIME"
    Dim DAREADIV, DAREAEMPNAME, DAREAEMAIL, DAREADEP, SESSION_NO, DCHECKYEAR, DATEMONTH As String
    Dim DAREANO As Integer
    Dim ipaddress As String
    Dim Equipment_E1, Equipment_E2, Equipment_E3, Equipment_E4, Equipment_E5, CHECKAREAR As New ListItem() ' ListItemName
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

        GETIPADDRESS()
        If SESSION_NO <> "" Then
            SearchDATANAJA()
        End If
        If Not Me.IsPostBack Then
            'CHECK_ENABLE()
            SFT_DIVISONNAMEAREA()
            SFT_DIVISONNAMEWORK()
        End If
        CHECK_ENABLE()

        CheckDateNo()
        'pu modify send mail 20170420
        Accordion_Mail.Visible = False
        checkuser_formail()



    End Sub
    'enable accordian mail
    Private Sub checkuser_formail()

        Select Case Label1.Text

            Case "007328"
                Accordion_Mail.Visible = True
            Case "007564"
                Accordion_Mail.Visible = True
            Case "002255"
                Accordion_Mail.Visible = True
            Case "000838"
                Accordion_Mail.Visible = True

        End Select
    End Sub
    Private Sub send_mail_check()

        Select Case Label1.Text

            Case "007328"
                If txtTo.Text.Trim <> "" Then
                    SENDMAIL()
                End If
            Case "007564"
                If txtTo.Text.Trim <> "" Then
                    SENDMAIL()
                End If
            Case "002255"
                If txtTo.Text.Trim <> "" Then
                    SENDMAIL()
                End If
            Case "000838"
                If txtTo.Text.Trim <> "" Then
                    SENDMAIL()
                End If


        End Select
    End Sub
    Private Sub SENDMAIL()
        Dim [to] As String = txtTo.Text
        'Dim from As String = txtEmail.Text
        Dim subject As String = txtSubject.Text
        Dim body As String = txtBody.Text

        Using mm As New MailMessage("Work_Permit@rist.local", txtTo.Text)



            mm.Subject = txtSubject.Text
            mm.Body = txtBody.Text
            If fuAttachment.HasFile Then
                Dim FileName As String = Path.GetFileName(fuAttachment.PostedFile.FileName)
                mm.Attachments.Add(New Attachment(fuAttachment.PostedFile.InputStream, FileName))
            End If
            mm.IsBodyHtml = False
            Dim smtp As New SmtpClient()
            smtp.Host = "10.29.1.240"
            smtp.EnableSsl = False
            Dim NetworkCred As New NetworkCredential()
            NetworkCred.UserName = "Work_Permit@rist.local"
            NetworkCred.Password = "Per16"
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 25
            smtp.Send(mm)
            'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)







        End Using

    End Sub
#Region "CHECKDATA AND GIVE IP Address"
    Protected Sub CHECK_ENABLE()
        If CHK_Work_others.Checked = True Then
            txtWorkother.Enabled = True
        Else
            txtWorkother.Enabled = False
        End If

        If CHK_Other.Checked = True Then
            txtCHK_Detail.Enabled = True
        Else
            txtCHK_Detail.Enabled = False
        End If

        If CHK_OtherEquipment.Checked = True Then
            txtequipment_Details.Enabled = True
        Else
            txtequipment_Details.Enabled = False
        End If

        If CHK_Equipment_E1.Text = "0" Then
            txtEquipment_E1_Detail.Enabled = True
        ElseIf CHK_Equipment_E2.Text = "0" Then
            txtEquipment_E2_Detail.Enabled = True
        ElseIf CHK_Equipment_E3.Text = "0" Then
            txtEquipment_E3_Detail.Enabled = True
        ElseIf CHK_Equipment_E4.Text = "0" Then
            txtEquipment_E4_Detail.Enabled = True
        ElseIf CHK_Equipment_E5.Text = "0" Then
            txtEquipment_E5_Detail.Enabled = True
        End If


    End Sub
    Private Sub GETIPADDRESS()

        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SAFETY_CHECKIP"
        cmd.Parameters.Add("@IPADDRESS", SqlDbType.Char).Value = ipaddress
        cmd.Parameters.Add("@NAME", SqlDbType.Char).Value = Label1.Text

        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
#End Region
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
#Region "AUTO EMAIL"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
    Public Shared Function SearchEMAIL(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select  LOWER(SUPER_EMAIL) AS SUPER_EMAIL  from V_EMAIL where SUPER_EMAIL like @SearchText + '%'  "

        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("SUPER_EMAIL").ToString)
        End While
        conn.Close()
        Return customers
    End Function
#End Region
#Region "SEARCH DATA"
    Private Sub SearchDATANAJA()

        SFT_DIVISONNAMEAREA()
        SFT_DIVISONNAMEWORK()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_PERMITWORK WHERE" _
                               & " SF_NO = @SF_NO"
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@SF_NO", SESSION_NO)
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

            ddlareadiv.SelectedItem.Text = sdr.Item("SF_The_work_Div").ToString()
            ddlareadep.SelectedItem.Text = sdr.Item("SF_The_work_Dep").ToString()
            ddlworkarea.SelectedItem.Text = sdr.Item("SF_The_work_area").ToString()
            ddlworkfloor.SelectedItem.Text = sdr.Item("SF_The_work_Floor").ToString()




            txtWorkother.Text = sdr.Item("SF_The_work_Other").ToString()

            '*20170508*'
            txt_tel_mobile.Text = sdr.Item("SF_Tel_External").ToString()
            txt_tel_in_company.Text = sdr.Item("SF_Tel_Internal").ToString()

            tb_date_wk.BackColor = Drawing.Color.LightBlue

            tb_time_start.BackColor = Drawing.Color.LightBlue

            tb_time_end.BackColor = Drawing.Color.LightBlue

            txtDetailWork.Text = sdr.Item("SF_WORK_Details").ToString()

            Try

                CheckOpea = sdr.Item("SF_Operator").ToString()
                If CheckOpea = False Then
                    ChkOperator1.Checked = True
                    ddldepartment.Enabled = True
                    ddldivion.Enabled = True
                    ddldivion.SelectedItem.Text = sdr.Item("SF_EMP_ROHM_DIV")
                    ddldepartment.SelectedItem.Text = sdr.Item("SF_EMP_ROHM_DEP")

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


            CHECKAREAR.Value = sdr("PERMIT_CHECK").ToString()
            If CHECKAREAR.Value = 1 Then
                chkchekarea.Items.FindByValue("1").Selected = True
            Else
                chkchekarea.Items.FindByValue("0").Selected = True
            End If

            txtfinishdetail.Text = sdr.Item("PERMIT_DETAIL")


            txtAApplicant.Text = sdr.Item("STAMP_Applicant")
            txtControl.Text = sdr.Item("STAMP_Supervisor")
            txtControlEmail.Text = sdr.Item("STAMP_Supervisor_EMAIL").ToString()

            'txtPermit_Start.Text = sdr.Item("PERMIT_DATEFROM")
            'txtPermit_End.Text = sdr.Item("PERMIT_DATETO")
            'txtPermitRemark.Text = sdr.Item("PERMIT_REMARK").ToString()



        End While

        If Not Me.IsPostBack Then
            SFT_DIVISONNAMEAREA()
            SFT_DIVISONNAMEWORK()
        End If
    End Sub
#End Region
#Region "AUTO VENDORNAME"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
    Public Shared Function SearchVendor(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select VENDOR_CODE, VENDOR_NAME from VENDORNAME where VENDOR_CODE like @SearchText + '%' OR VENDOR_NAME like @SearchText + '%'"

        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("VENDOR_NAME").ToString)
        End While
        conn.Close()
        Return customers
    End Function
#End Region
#Region "CHECK NO"
    Private Sub CheckDateNo()
        DateNow = DateTime.Now.ToString("yyyyMMdd")
        CDYEAR = Mid(DateNow, 3, 2)
        CDMONTH = Mid(DateNow, 5, 2)
        CDATENOW = CDYEAR + "/" + CDMONTH
        CHECKNO()
    End Sub
    Private Sub CHECKNO()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT MaX(SF_NO) as SF_NO  FROM SAFETY_PERMITWORK  "
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@HW_NO", con_SAFETY)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            DATECHECK_SF = sdr("SF_NO").ToString()
            DMIDDATA = Mid(DATECHECK_SF, 1, 5)
            DCHECKYEAR = Mid(DATECHECK_SF, 1, 2)
        End While


        If DCHECKYEAR <> CDYEAR Then
            lblno.Text = CDYEAR + "/" + CDMONTH + "/" + "00001"
            Exit Sub
        End If
        If CDATENOW = DMIDDATA Then
            Vipdata = 1 + Mid(DATECHECK_SF, 7, 11)
            If Len(Vipdata) = 1 Then
                DDateNO = "0000" + Vipdata
            ElseIf Len(Vipdata) = 2 Then
                DDateNO = "000" + Vipdata
            ElseIf Len(Vipdata) = 3 Then
                DDateNO = "00" + Vipdata
            ElseIf Len(Vipdata) = 4 Then
                DDateNO = "0" + Vipdata
            ElseIf Len(Vipdata) > 4 Then
                DDateNO = Vipdata
            End If
            lblno.Text = CDATENOW + "/" + DDateNO
            Exit Sub
        ElseIf CDATENOW <> DMIDDATA Then
            DNODATA = 1 + Mid(DATECHECK_SF, 7, 11)

            If Len(DNODATA) = 1 Then
                DDateNO = "0000" + DNODATA
            ElseIf Len(DNODATA) = 2 Then
                DDateNO = "000" + DNODATA
            ElseIf Len(DNODATA) = 3 Then
                DDateNO = "00" + DNODATA
            ElseIf Len(DNODATA) = 4 Then
                DDateNO = "0" + DNODATA
            ElseIf Len(DNODATA) > 4 Then
                DDateNO = DNODATA
            End If
            lblno.Text = CDATENOW + "/" + DDateNO
            Exit Sub
            'ElseIf DCHECKYEAR <> DMIDDATA Then
            '    lblno.Text = DCHECKYEAR + "/" + CDMONTH + "/" + DDateNO
        End If
    End Sub
    Protected Sub btncheckno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheckno.Click
        If txtcheckno.Text.Trim() = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Data !!!');", True)
            Exit Sub
        End If

        BtnUpdate.Visible = True

        txtSearch.Enabled = True
        txtname.Enabled = True
        txtsumname.Enabled = True

        SFT_DIVISONNAMEAREA()
        SFT_DIVISONNAMEWORK()
        'DIVION_DATA()
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
                CHK_Contruction.Checked = sdr.Item("SF_Contruction")
                CHK_Work_High.Checked = sdr.Item("SF_Work_on_a_high")
                CHK_Work_Chemical.Checked = sdr.Item("SF_Work_in_a_chemical")
                CHK_Work_Glass.Checked = sdr.Item("SF_Work_Glass")
                CHK_Lifting_More.Checked = sdr.Item("SF_Lifting_More_100")
                CHK_Related_System.Checked = sdr.Item("SF_Related_to_the_power_system")
                CHK_Install.Checked = sdr.Item("SF_Installation_and_mainten")
                CHK_Work_others.Checked = sdr.Item("SF_Work_others")
                txtWorkother.Text = sdr.Item("SF_Work_others_Details").ToString()

                ddlareadiv.SelectedItem.Text = sdr.Item("SF_The_work_Div").ToString()
                ddlareadep.SelectedItem.Text = sdr.Item("SF_The_work_Dep").ToString()
                ddlworkarea.SelectedItem.Text = sdr.Item("SF_The_work_area").ToString()
                ddlworkfloor.SelectedItem.Text = sdr.Item("SF_The_work_Floor").ToString()

                txtWorkother.Text = sdr.Item("SF_The_work_Other").ToString()

                '*20170508*'
                txt_tel_mobile.Text = sdr.Item("SF_Tel_External").ToString()
                txt_tel_in_company.Text = sdr.Item("SF_Tel_Internal").ToString()

                tb_date_wk.BackColor = Drawing.Color.LightBlue

                tb_time_start.BackColor = Drawing.Color.LightBlue

                tb_time_end.BackColor = Drawing.Color.LightBlue



                txtDetailWork.Text = sdr.Item("SF_WORK_Details").ToString()




                CheckOpea = sdr.Item("SF_Operator").ToString()
                If CheckOpea = False Then
                    ChkOperator1.Checked = True
                    ddldepartment.Enabled = True
                    ddldivion.Enabled = True
                    ddldivion.SelectedItem.Text = sdr.Item("SF_EMP_ROHM_DIV")
                    ddldepartment.SelectedItem.Text = sdr.Item("SF_EMP_ROHM_DEP")

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
                'ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Contact 4724 MR.WEERAPAT !!!');", True)
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


                CHECKAREAR.Value = sdr("PERMIT_CHECK").ToString()
                If CHECKAREAR.Value = 1 Then
                    chkchekarea.Items.FindByValue("1").Selected = True
                Else
                    chkchekarea.Items.FindByValue("0").Selected = True
                End If

                txtfinishdetail.Text = sdr.Item("PERMIT_DETAIL")


                txtAApplicant.Text = sdr.Item("STAMP_Applicant")
                txtControl.Text = sdr.Item("STAMP_Supervisor")
                txtControlEmail.Text = sdr.Item("STAMP_Supervisor_EMAIL").ToString()

                'txtPermit_Start.Text = sdr.Item("PERMIT_DATEFROM")
                'txtPermit_End.Text = sdr.Item("PERMIT_DATETO")
                'txtPermitRemark.Text = sdr.Item("PERMIT_REMARK").ToString()
            Catch ex As Exception

            End Try


        End While

    End Sub
#End Region
#Region "SAVE PERMITWORK"
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        CheckDateNo()
        If ChkOperator1.Checked Then
            CheckOpea = 0
        ElseIf ChkOperator2.Checked Then
            CheckOpea = 1
        End If

        If txtAApplicant.Text = "" Or txtControl.Text = "" Or txtControlEmail.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check User And Control And Email !!!');", True)
            Exit Sub
        End If

        If CHK_Contruction.Checked = False And CHK_Work_High.Checked = False And CHK_Work_Chemical.Checked = False And CHK_Lifting_More.Checked = False And CHK_Work_Glass.Checked = False And CHK_Related_System.Checked = False And CHK_Install.Checked = False And CHK_Work_others.Checked = False Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check New Data  !!!');", True)
            Exit Sub
        End If
        If ddlareadep.SelectedItem.Text = "--Select Department--" Or ddlareadiv.SelectedItem.Text = "--Select DivisionName--" Then

            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Division And Department  !!!');", True)
            Exit Sub
        End If

        If tb_date_wk.Text = "" Or tb_time_start.Text = "" Or tb_time_end.Text = "" Then

            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Data Date And Time  !!!');", True)
            Exit Sub
        End If

        If txtDetailWork.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Detail !!!');", True)
            Exit Sub
        End If

        If ChkOperator1.Checked = False And ChkOperator2.Checked = False Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Select Operator !!!');", True)
            Exit Sub
        End If

        If ChkFire_safety.Checked = False And CHK_Warning_Sign.Checked = False And CHK_The_Barrier.Checked = False And CHK_Certified_By_Engineer.Checked = False And CHK_Fire_Wash.Checked = False And CHK_Signal_man.Checked = False And ChkStandand_alone.Checked = False And CHK_Other.Checked = False Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Safety System !!!');", True)
            Exit Sub
        End If

        If CHK_Safety_Shoes.Checked = False And CHK_Chemical_Clothing.Checked = False And CHK_Chemical_Gloves.Checked = False And CHK_Helmet.Checked = False And CHK_Safety_belt.Checked = False And CHK_Earplugs.Checked = False And CHK_Respirator.Checked = False And CHK_Safety_glasses_dimming.Checked = False And CHK_Shieldother.Checked = False And CHK_OtherEquipment.Checked = False Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Safety System !!!');", True)
            Exit Sub
        End If

        If txt_tel_in_company.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Tel. No !!!');", True)
            txt_tel_in_company.Focus()
            txt_tel_in_company.BorderColor = Drawing.Color.OrangeRed
            Exit Sub
        End If

        If txt_tel_mobile.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Mobile No !!!');", True)
            txt_tel_mobile.Focus()
            txt_tel_mobile.BorderColor = Drawing.Color.OrangeRed
            Exit Sub
        End If

        If txtMoreDetail.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Detail !!!');", True)
            txt_tel_mobile.Focus()
            txt_tel_mobile.BorderColor = Drawing.Color.OrangeRed
            Exit Sub
        End If

        If AlertFire.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check conflagration  !!!');", True)
            Exit Sub
        End If

        Try
            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("zzzSAFETY_PERMITWORK_STO")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SF_SAFETY", "INSERT")
                cmd.Parameters.AddWithValue("@SF_NO", lblno.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_Contruction", CHK_Contruction.Checked)
                cmd.Parameters.AddWithValue("@SF_Work_on_a_high", CHK_Work_High.Checked)
                cmd.Parameters.AddWithValue("@SF_Work_in_a_chemical", CHK_Work_Chemical.Checked)
                cmd.Parameters.AddWithValue("@SF_Work_Glass", CHK_Work_Glass.Checked)
                cmd.Parameters.AddWithValue("@SF_Lifting_More_100", CHK_Lifting_More.Checked)
                cmd.Parameters.AddWithValue("@SF_Related_to_the_power_system", CHK_Related_System.Checked)
                cmd.Parameters.AddWithValue("@SF_Installation_and_mainten", CHK_Install.Checked)
                cmd.Parameters.AddWithValue("@SF_Work_others", CHK_Work_others.Checked)
                cmd.Parameters.AddWithValue("@SF_Work_others_Details", txtWorkother.Text.Trim())

                cmd.Parameters.AddWithValue("@SF_The_work_Div", ddlareadiv.SelectedItem.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_The_work_Dep", ddlareadep.SelectedItem.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_The_work_area", ddlworkarea.SelectedItem.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_The_work_Floor", ddlworkfloor.SelectedItem.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_The_work_Other", txtOtherDetails.Text.Trim())


                '*20170508*'
                cmd.Parameters.AddWithValue("@SF_Tel_External", txt_tel_mobile.Text.Trim())
                cmd.Parameters.AddWithValue("@SF_Tel_Internal", txt_tel_in_company.Text.Trim())


                cmd.Parameters.AddWithValue("@SF_WorkDate", tb_date_wk.Text)
                cmd.Parameters.AddWithValue("@SF_Time_str1", tb_time_start.Text)
                cmd.Parameters.AddWithValue("@SF_Time_end1", tb_time_end.Text)


                cmd.Parameters.AddWithValue("@SF_WORK_Details", txtDetailWork.Text.Trim())

                cmd.Parameters.AddWithValue("@SQ_Equipment_E1", txtEquipment_E1.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E1_CHK", CHK_Equipment_E1.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E1_NG", txtEquipment_E1_Detail.Text)

                cmd.Parameters.AddWithValue("@SQ_Equipment_E2", txtEquipment_E2.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E2_CHK", CHK_Equipment_E2.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E2_NG", txtEquipment_E2_Detail.Text)

                cmd.Parameters.AddWithValue("@SQ_Equipment_E3", txtEquipment_E3.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E3_CHK", CHK_Equipment_E3.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E3_NG", txtEquipment_E3_Detail.Text)

                cmd.Parameters.AddWithValue("@SQ_Equipment_E4", txtEquipment_E4.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E4_CHK", CHK_Equipment_E4.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E4_NG", txtEquipment_E4_Detail.Text)

                cmd.Parameters.AddWithValue("@SQ_Equipment_E5", txtEquipment_E5.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E5_CHK", CHK_Equipment_E5.Text)
                cmd.Parameters.AddWithValue("@SQ_Equipment_E5_NG", txtEquipment_E5_Detail.Text)

                cmd.Parameters.AddWithValue("@SF_Operator", CheckOpea)

                If CheckOpea = 0 Then
                    cmd.Parameters.AddWithValue("@SF_EMP_ROHM_DIV", ddldivion.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@SF_EMP_ROHM_DEP", ddldepartment.SelectedItem.Text)
                ElseIf CheckOpea = 1 Then
                    cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR", txtSearch.Text)
                    cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR_NAME", txtname.Text)
                    cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR_TEAM", txtsumname.Text)
                End If



                cmd.Parameters.AddWithValue("@ST_Fire_safety", ChkFire_safety.Checked)
                cmd.Parameters.AddWithValue("@ST_Warning_Sign", CHK_Warning_Sign.Checked)
                cmd.Parameters.AddWithValue("@ST_The_Barrier", CHK_The_Barrier.Checked)
                cmd.Parameters.AddWithValue("@ST_Certified_By_Engineer", CHK_Certified_By_Engineer.Checked)
                cmd.Parameters.AddWithValue("@ST_Fire_Wash", CHK_Fire_Wash.Checked)
                cmd.Parameters.AddWithValue("@ST_Signal_man", CHK_Signal_man.Checked)
                cmd.Parameters.AddWithValue("@ST_Standand_alone", ChkStandand_alone.Checked)
                cmd.Parameters.AddWithValue("@ST_Other", CHK_Other.Checked)
                cmd.Parameters.AddWithValue("@ST_Detail", txtCHK_Detail.Text)

                cmd.Parameters.AddWithValue("@SPE_Safety_Shoes", CHK_Safety_Shoes.Checked)
                cmd.Parameters.AddWithValue("@SPE_Chemical_Protective_Clothing", CHK_Chemical_Clothing.Checked)
                cmd.Parameters.AddWithValue("@SPE_Chemical_Resistant_Gloves", CHK_Chemical_Gloves.Checked)
                cmd.Parameters.AddWithValue("@SPE_Helmet", CHK_Helmet.Checked)
                cmd.Parameters.AddWithValue("@SPE_Safety_belt", CHK_Safety_belt.Checked)
                cmd.Parameters.AddWithValue("@SPE_Earplugs", CHK_Earplugs.Checked)
                cmd.Parameters.AddWithValue("@SPE_Respirator", CHK_Respirator.Checked)
                cmd.Parameters.AddWithValue("@SPE_Safety_glasses_dimming", CHK_Safety_glasses_dimming.Checked)
                cmd.Parameters.AddWithValue("@SPE_Shield_the_light_bounce_off_each_other", CHK_Shieldother.Checked)
                cmd.Parameters.AddWithValue("@SPE_Other_protective_equipment", CHK_OtherEquipment.Checked)
                cmd.Parameters.AddWithValue("@SPE_Other_protective_equipment_Details", txtequipment_Details.Text)

                cmd.Parameters.AddWithValue("PERMIT_CHECK", chkchekarea.Text)

                If chkchekarea.Text = "" Then
                    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Area  !!!');", True)
                    Exit Sub
                End If


                cmd.Parameters.AddWithValue("PERMIT_DETAIL", txtfinishdetail.Text)

                cmd.Parameters.AddWithValue("@STAMP_Applicant", txtAApplicant.Text)
                cmd.Parameters.AddWithValue("@STAMP_Applicant_Date", DateTime.Now.ToString())

                cmd.Parameters.AddWithValue("@PERMIT_DATEFROM", txtPermit_Start.Text.Trim())
                cmd.Parameters.AddWithValue("@PERMIT_DATETO", txtPermit_End.Text.Trim())
                cmd.Parameters.AddWithValue("@PERMIT_REMARK", txtPermitRemark.Text.Trim())


                cmd.Parameters.AddWithValue("@STAMP_Supervisor", UCase(txtControl.Text.Trim()) + "(WAITING STAMP)")
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", txtControlEmail.Text.Trim())


                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Status", "WAITING STAMP")


                cmd.Parameters.AddWithValue("@AlertFire", AlertFire.Text)
                cmd.Parameters.AddWithValue("@txtMoreDetail", txtMoreDetail.Text)

                'If txtControlEmail.Text.Trim() <> "" Then
                '    Dim aa As String = txtControlEmail.Text
                '    Dim subString As String = Microsoft.VisualBasic.Right(aa, 11)

                '    If subString <> "@rist.local" Then

                '        cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", txtControlEmail.Text + lblrist.Text.Trim())
                '    Else
                '        cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", txtControlEmail.Text.Trim())
                '    End If

                'End If



                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'pu modify 20170420
                'send_mail_check()

                'SAFETY_SAVEUSERONLINE()
            End Using
        Catch ex As Exception
            Dim message As String = "!!! PLEASE CHECK DATA !!! " + "</br></br>" + " Please Contact Mr.Weerapat " + "</br></br>" + " TEL :: 4724 " + "</br></br>" + " THANK YOU  "
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "VPPopup('" + message + "' ); ", True)
        End Try



        If txtControl.Text.Length > 1000 Or txtControlEmail.Text.Length > 1000 Then
            'If txtControl.Text <> "" Or txtControlEmail.Text <> "" Then
            BindGridview()
            GridView1.Visible = True
            AAA = lblno.Text
            Dim Msg As New MailMessage()
            Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
            ' Sender e-mail address.
            Msg.From = fromMail
            ' Recipient e-mail address.
            Msg.[To].Add(New MailAddress(txtControlEmail.Text))
            ' Subject of e-mail

            Msg.SubjectEncoding = System.Text.Encoding.UTF8

            Msg.BodyEncoding = System.Text.Encoding.UTF8
            Dim bb As String
            Dim VIP_REMARK As String

            If ddlworkarea.SelectedItem.Text = "ALL" Or ddlworkfloor.SelectedItem.Text = "ALL" Then
                bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Control.aspx?op=" & Trim(lblno.Text) & "&Name=" & Trim(txtControl.Text) & "&Email=" & Trim(txtControlEmail.Text) & "&PERMIT=" & PERMITWORK & """"
                VIP_REMARK = " **** Special Case Work ***** "
                Msg.Subject = "WORK PERMIT ONLINE APPROVE"
                Msg.Body += "Please Check Below Data <br/><br/>"
                Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + txtControl.Text & "</p>" + "<br/><br/>"
                Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
                Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
                Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

                Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

                Msg.Body += GetGridviewData(GridView1)


                Msg.Body += "<br/>THANK YOU<br/>"

                Msg.Body += "WORK PERMIT ONLINE SYSTEM"

                Msg.IsBodyHtml = True
                Dim sSmtpServer As String = ""
                sSmtpServer = "10.29.1.240"
                Dim a As New SmtpClient()
                a.Host = sSmtpServer
                a.Send(Msg)
            Else

                bb = "http://10.29.1.39/PERMITONLINE/P_Apporve_Control.aspx?op=" & Trim(lblno.Text) & "&Name=" & Trim(txtControl.Text) & "&Email=" & Trim(txtControlEmail.Text) & "&PERMIT=" & PERMITWORK & """"
                VIP_REMARK = " **** Special Case Work ***** "
                Msg.Subject = "WORK PERMIT ONLINE APPROVE"
                Msg.Body += "Please Check Below Data <br/><br/>"
                Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + txtControl.Text & "</p>" + "<br/><br/>"
                Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
                Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
                Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

                'Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

                Msg.Body += GetGridviewData(GridView1)


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
        If tb_date_wk.Text <> "" And tb_time_start.Text <> "" Then
            Dim message As String = "!!! INSERT DATA OK !!! " + "</br></br>" + "Please Remember NO  " + lblno.Text + "</br></br>" + "Work controller approve in your E-mai"
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "' ); ", True)
            Exit Sub
        ElseIf tb_date_wk.Text = "" And tb_time_start.Text = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Check Data OK   !!!!');")
            Response.Write("location.href='P_PermitWork.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If
    End Sub
#End Region
#Region "BindGridview"
    Protected Sub BindGridview()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from SAFETY_PERMITWORK WHERE SF_NO =  '" & lblno.Text & "'")

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
#Region "CHK WORK CHECKBOX"
    Protected Sub ChkOperator1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOperator1.CheckedChanged
        SFT_DIVISONNAMEWORK()
        If ChkOperator1.Checked Then
            ChkOperator2.Checked = False
        End If
        ddldepartment.Enabled = True
        ddldivion.Enabled = True
        txtSearch.Enabled = False
        txtname.Enabled = False
        txtsumname.Enabled = False
        txtSearch.Text = ""
    End Sub
    Protected Sub ChkOperator2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOperator2.CheckedChanged

        If ChkOperator2.Checked Then
            ChkOperator1.Checked = False
        Else
            txtSearch.Text = ""
        End If
        ddldepartment.Enabled = False
        ddldivion.Enabled = False
        txtSearch.Enabled = True
        txtname.Enabled = True
        txtsumname.Enabled = True
        ddldepartment.Items.Clear()
        ddldivion.Items.Clear()

    End Sub
#End Region
#Region "DIVISION AREA"
    Private Sub SFT_DIVISONNAMEAREA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("CHECK_DEP_DIV")
                cmd.Parameters.AddWithValue("@CK_DIVISION", "SELECT")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        ddlareadiv.DataSource = dt
                        ddlareadiv.DataTextField = "AREADIV"
                        ddlareadiv.DataValueField = "AREADIV"
                        ddlareadiv.DataBind()
                    End Using
                End Using
            End Using
        End Using
        ddlareadiv.Items.Insert(0, New ListItem("--Select DivisionName--", "0"))
        DEPART_AREA()
    End Sub
    Protected Sub ddlareadiv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlareadiv.SelectedIndexChanged
        DEPART_AREA()
    End Sub
    Private Sub DEPART_AREA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SELECT AREADIV,AREADEP   FROM SAFETY_AREA where AREADIV  = '" + ddlareadiv.SelectedItem.Text + "'  GROUP BY AREADEP,AREADIV  Order by AREADEP asc")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddlareadep.DataSource = ds.Tables(0)
                    ddlareadep.DataTextField = "AREADEP"
                    ddlareadep.DataValueField = "AREADEP"
                    ddlareadep.DataBind()
                End Using
            End Using
        End Using
        ddlareadep.Items.Insert(0, New ListItem("--Select Department--", "0"))
    End Sub
#End Region
#Region "DIVISION WORK"
    Private Sub SFT_DIVISONNAMEWORK()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("CHECK_DEP_DIV")
            cmd.Parameters.AddWithValue("@CK_DIVISION", "SELECT")
            Using sda As New SqlDataAdapter()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using dt As New DataTable()
                    sda.Fill(dt)
                    ddldivion.DataSource = dt
                    ddldivion.DataTextField = "AREADIV"
                    ddldivion.DataValueField = "AREADIV"
                    ddldivion.DataBind()
                End Using
            End Using
        End Using
        ddldivion.Items.Insert(0, New ListItem("--Select DivisionName--", "0"))
        DIVION_DATA()
    End Sub
    Private Sub DIVION_DATA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SELECT AREADIV,AREADEP   FROM SAFETY_AREA where AREADIV = '" + ddldivion.SelectedItem.Text + "'  GROUP BY AREADEP,AREADIV  Order by AREADEP asc")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddldepartment.DataSource = ds.Tables(0)
                    ddldepartment.DataTextField = "AREADEP"
                    ddldepartment.DataValueField = "AREADEP"
                    ddldepartment.DataBind()
                End Using
            End Using
        End Using
        ddldepartment.Items.Insert(0, New ListItem("--Select DivisionName--", "0"))
    End Sub
    Protected Sub ddldivion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldivion.SelectedIndexChanged
        DIVION_DATA()
    End Sub
#End Region
#Region "PRINT PERMIT"
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
        If txtcheckno.Text = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Insert Workno  !!!!');")
            Response.Write("location.href='P_PermitWork.aspx';")
            Response.Write("</Script>")
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
            Response.Write("location.href='P_PermitWork.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If


        'ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        'crystalReport.Load(Server.MapPath("~/CrystalPersonInfo.rpt")); // path of report 
        'crystalReport.SetDataSource(datatable); // binding datatable
        'CrystalReportViewer1.ReportSource = crystalReport;


        rpt.Load(Server.MapPath("~/Safety_Report.rpt"))
        rpt.SetDataSource(V_PERMITWORK)

        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True,"WORKPERMIT")
        Response.[End]()
        ' Me.CrystalReportViewer1.ReportSource = rpt
        'Dim formatType = ExportFormatType.NoFormat
        'formatType = ExportFormatType.PortableDocFormat
        'rpt.ExportToHttpResponse(formatType, Response, True, "WORKPERMIT" + "-" + txtcheckno.Text.Trim())
        'rpt.Dispose()
        'Response.[End]()

        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub
#End Region
#Region "UPDATE PERMITWORK"
    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("SAFETY_PERMITWORK_STO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SF_SAFETY", "UPDATE")
            cmd.Parameters.AddWithValue("@SF_Contruction", CHK_Contruction.Checked)
            cmd.Parameters.AddWithValue("@SF_Work_on_a_high", CHK_Work_High.Checked)
            cmd.Parameters.AddWithValue("@SF_Work_in_a_chemical", CHK_Work_Chemical.Checked)
            cmd.Parameters.AddWithValue("@SF_Work_Glass", CHK_Work_Glass.Checked)
            cmd.Parameters.AddWithValue("@SF_Lifting_More_100", CHK_Lifting_More.Checked)
            cmd.Parameters.AddWithValue("@SF_Related_to_the_power_system", CHK_Related_System.Checked)
            cmd.Parameters.AddWithValue("@SF_Installation_and_mainten", CHK_Install.Checked)
            cmd.Parameters.AddWithValue("@SF_Work_others", CHK_Work_others.Checked)
            cmd.Parameters.AddWithValue("@SF_Work_others_Details", txtWorkother.Text.Trim())

            cmd.Parameters.AddWithValue("@SF_The_work_Div", ddlareadiv.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@SF_The_work_Dep", ddlareadep.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@SF_The_work_area", ddlworkarea.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@SF_The_work_Floor", ddlworkfloor.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@SF_The_work_Other", txtWorkother.Text.Trim())


            cmd.Parameters.AddWithValue("@SF_WorkDate", tb_date_wk.Text)
            cmd.Parameters.AddWithValue("@SF_Time_str1", tb_time_start.Text)
            cmd.Parameters.AddWithValue("@SF_Time_end1", tb_time_end.Text)


            cmd.Parameters.AddWithValue("@SF_WORK_Details", txtDetailWork.Text.Trim())

            cmd.Parameters.AddWithValue("@SQ_Equipment_E1", txtEquipment_E1.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E1_CHK", CHK_Equipment_E1.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E1_NG", txtEquipment_E1_Detail.Text)

            cmd.Parameters.AddWithValue("@SQ_Equipment_E2", txtEquipment_E2.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E2_CHK", CHK_Equipment_E2.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E2_NG", txtEquipment_E2_Detail.Text)

            cmd.Parameters.AddWithValue("@SQ_Equipment_E3", txtEquipment_E3.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E3_CHK", CHK_Equipment_E3.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E3_NG", txtEquipment_E3_Detail.Text)

            cmd.Parameters.AddWithValue("@SQ_Equipment_E4", txtEquipment_E4.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E4_CHK", CHK_Equipment_E4.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E4_NG", txtEquipment_E4_Detail.Text)

            cmd.Parameters.AddWithValue("@SQ_Equipment_E5", txtEquipment_E5.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E5_CHK", CHK_Equipment_E5.Text)
            cmd.Parameters.AddWithValue("@SQ_Equipment_E5_NG", txtEquipment_E5_Detail.Text)

            cmd.Parameters.AddWithValue("@SF_Operator", CheckOpea)

            If CheckOpea = 0 Then
                cmd.Parameters.AddWithValue("@SF_EMP_ROHM_DIV", ddldivion.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@SF_EMP_ROHM_DEP", ddldepartment.SelectedItem.Text)
            ElseIf CheckOpea = 1 Then
                cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR", txtSearch.Text)
                cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR_NAME", txtname.Text)
                cmd.Parameters.AddWithValue("@SP_EMP_CONTRACTOR_TEAM", txtsumname.Text)
            End If

            cmd.Parameters.AddWithValue("@ST_Fire_safety", ChkFire_safety.Checked)
            cmd.Parameters.AddWithValue("@ST_Warning_Sign", CHK_Warning_Sign.Checked)
            cmd.Parameters.AddWithValue("@ST_The_Barrier", CHK_The_Barrier.Checked)
            cmd.Parameters.AddWithValue("@ST_Certified_By_Engineer", CHK_Certified_By_Engineer.Checked)
            cmd.Parameters.AddWithValue("@ST_Fire_Wash", CHK_Fire_Wash.Checked)
            cmd.Parameters.AddWithValue("@ST_Signal_man", CHK_Signal_man.Checked)
            cmd.Parameters.AddWithValue("@ST_Standand_alone", ChkStandand_alone.Checked)
            cmd.Parameters.AddWithValue("@ST_Other", CHK_Other.Checked)
            cmd.Parameters.AddWithValue("@ST_Detail", txtCHK_Detail.Text)


            cmd.Parameters.AddWithValue("@SPE_Safety_Shoes", CHK_Safety_Shoes.Checked)


            cmd.Parameters.AddWithValue("@SPE_Chemical_Protective_Clothing", CHK_Chemical_Clothing.Checked)
            cmd.Parameters.AddWithValue("@SPE_Chemical_Resistant_Gloves", CHK_Chemical_Gloves.Checked)
            cmd.Parameters.AddWithValue("@SPE_Helmet", CHK_Helmet.Checked)
            cmd.Parameters.AddWithValue("@SPE_Safety_belt", CHK_Safety_belt.Checked)
            cmd.Parameters.AddWithValue("@SPE_Earplugs", CHK_Earplugs.Checked)
            cmd.Parameters.AddWithValue("@SPE_Respirator", CHK_Respirator.Checked)
            cmd.Parameters.AddWithValue("@SPE_Safety_glasses_dimming", CHK_Safety_glasses_dimming.Checked)
            cmd.Parameters.AddWithValue("@SPE_Shield_the_light_bounce_off_each_other", CHK_Shieldother.Checked)
            cmd.Parameters.AddWithValue("@SPE_Other_protective_equipment", CHK_OtherEquipment.Checked)
            cmd.Parameters.AddWithValue("@SPE_Other_protective_equipment_Details", txtequipment_Details.Text)
            cmd.Parameters.AddWithValue("PERMIT_CHECK", chkchekarea.Text)
            cmd.Parameters.AddWithValue("PERMIT_DETAIL", txtfinishdetail.Text)


            cmd.Parameters.AddWithValue("@SF_NO", lblno.Text.Trim())
            cmd.Connection = con
            con.Open()

            If tb_date_wk.Text <> "" And tb_time_start.Text <> "" And lblno.Text <> "" Then
                Response.Write("<Script>")
                Response.Write("alert('!!! Update Data OK   !!!!');")
                Response.Write("location.href='P_PermitWork.aspx';")
                Response.Write("</Script>")
            ElseIf tb_date_wk.Text = "" And tb_time_start.Text = "" And lblno.Text = "" Then
                Response.Write("<Script>")
                Response.Write("alert('!!! Please Check Data OK   !!!!');")
                Response.Write("location.href='P_PermitWork.aspx';")
                Response.Write("</Script>")
            End If

            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub
#End Region
#Region "SAVE USER"
    Private Sub SAFETY_SAVEUSERONLINE()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("SAFETY_USER")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@WORKNO", lblno.Text)
            cmd.Parameters.AddWithValue("@EMPNO", Label1.Text)
            cmd.Parameters.AddWithValue("@EMPNAME", Label2.Text)
            cmd.Parameters.AddWithValue("@IPADDRESS", ipaddress)
            cmd.Parameters.AddWithValue("@EMPDETAIL", "SAVE WORKPERMIT")
            cmd.Connection = con

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub
#End Region

    Protected Overrides Sub OnUnload(e As EventArgs)
        MyBase.OnUnload(e)

        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub

    Private Sub P_PermitWork_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    SENDMAIL()
    'End Sub
End Class
