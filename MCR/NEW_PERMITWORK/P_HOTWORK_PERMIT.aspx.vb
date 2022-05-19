Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web
Imports System.Windows.Forms
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
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Web.Services
Imports System.Diagnostics
Partial Class P_HOTWORK_PERMIT
    Inherits System.Web.UI.Page
    Dim DateNow, CDYEAR, CDMONTH, CDATENOW As String 'DateTimeSetCDDATE
    Dim DATECHECK_SF, DMIDDATA, DCHECKYEAR, SESSION_NO As String ' checkno
    Dim Vipdata, DDateNO, DNODATA As String
    Dim items1, items2, items3, items4, items5, items6, items7, items8 As New ListItem() ' ListItemName
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
        If Not Me.IsPostBack Then
            CheckDateNo()
        End If
    End Sub
    Private Sub CheckDateNo()
        DateNow = DateTime.Now.ToString("yyyyMMdd")
        CDYEAR = Mid(DateNow, 3, 2)
        CDMONTH = Mid(DateNow, 5, 2)
        CDATENOW = CDYEAR + "/" + CDMONTH
        CHECKNO()
    End Sub
#Region "AUTO NO"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
        Public Shared Function SearchSFNO(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select TOP(20) HW_NO from SAFETY_HOTWORK where HW_NO like @SearchText + '%'  GROUP BY HW_NO  ORDER BY HW_NO DESC "

        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("HW_NO").ToString)
        End While
        conn.Close()
        Return customers
    End Function
#End Region
    Private Sub CHECKNO()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT MaX(HW_NO) as HW_NO  FROM SAFETY_HOTWORK  "
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@HW_NO", con_SAFETY)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            DATECHECK_SF = sdr("HW_NO").ToString()
            DMIDDATA = Mid(DATECHECK_SF, 1, 5)
            DCHECKYEAR = Mid(DATECHECK_SF, 1, 2)
        End While

        If DCHECKYEAR <> CDYEAR Then
            lblno.Text = CDYEAR + "/" + CDMONTH + "/" + "00001"
            Exit Sub
        End If
		
		 'new modify 20180803 pu
        If Mid(DATECHECK_SF, 7, 11).Trim() = ""  Then
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

            DNODATA = 1 + Mid(DATECHECK_SF, 7, 11).Trim

            If Len(DNODATA) = 1 Then
                DDateNO = "0000" + DNODATA
            ElseIf Len(DNODATA) = 2 Then
                DDateNO = "000" + DNODATA
                'by pu
            ElseIf Len(DNODATA) = 4 Then
                DDateNO = "0" + DNODATA
                '/////////////
            ElseIf Len(Vipdata) = 3 Then
                DDateNO = "00" + DNODATA
            ElseIf Len(Vipdata) = 4 Then
                DDateNO = "0" + DNODATA
            ElseIf Len(Vipdata) > 4 Then
                DDateNO = DNODATA
            End If

            'by pu
            lblno.Text = CDATENOW + "/" + DDateNO
            'lblno.Text = CDATENOW + "/" + DDateNO + DNODATA
            Exit Sub
            'ElseIf DCHECKYEAR <> DMIDDATA Then
            '    lblno.Text = DCHECKYEAR + "/" + CDMONTH + "/" + DDateNO
        End If
    End Sub
    Protected Sub btncheckno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheckno.Click
        Dim CHWOP As String = "OP NO"
        'Dim dateString, timestart, timeEnd As String
        Dim dateString As String
        BtnSave.Visible = True
        'BtnUpdate.Visible = True
        If txtcheckno.Text.Trim() = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check New : " & CHWOP & "  NAJA !!!');", True)
        End If

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_HOTWORK WHERE" _
                               & " HW_NO = @HW_NO"
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@HW_NO", txtcheckno.Text)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            txtdepname.Text = sdr.Item("HW_DEPNAME").ToString()
            txtworktype.Text = sdr.Item("HW_WORKDETAIL").ToString()
            dateString = sdr.Item("HW_DATE").ToString()

            tb_date_wk.BackColor = Drawing.Color.LightBlue
            tb_time_start.BackColor = Drawing.Color.LightBlue
            tb_time_end.BackColor = Drawing.Color.LightBlue

            'tb_date_wk.Text = DateTime.Parse(dateString).ToString("yyyy-MM-dd")

            'timestart = sdr.Item("HW_DATEFROM").ToString()
            'tb_time_start.Text = DateTime.Parse(timestart).ToString("HH:mm:ss")

            'timeEnd = sdr.Item("HW_DATETO").ToString()
            'tb_time_end.Text = DateTime.Parse(timeEnd).ToString("HH:mm:ss")

            txtareaname.Text = sdr.Item("HW_AREA").ToString()
            txtinvoive.Text = sdr.Item("HW_InvoiceNo").ToString()
            txtworknamecontrol.Text = sdr.Item("HW_SupervisorName").ToString()

            If sdr("HW_TArea_Normal") = 0 Then
                ChkNormal.Checked = False
            Else
                ChkNormal.Checked = True
            End If

            If sdr("HW_StayHigh") = 0 Then
                ChkInhigh.Checked = False
            Else
                ChkInhigh.Checked = True
            End If

            If sdr("HW_Dusty") = 0 Then
                ChkDusty.Checked = False
            Else
                ChkDusty.Checked = True
            End If

            If sdr("HW_Chemicals") = 0 Then
                ChkChemicals.Checked = False
            Else
                ChkChemicals.Checked = True
            End If

            If sdr("HW_Type") = 0 Then
                ChkType.Checked = False
            Else
                ChkType.Checked = True
            End If

            txtTypedetail.Text = sdr.Item("HW_TypeDetail").ToString()

            If sdr("HW_Equipment_Welding_machine") = 0 Then
                ChkWelding_machine.Checked = False
            Else
                ChkWelding_machine.Checked = True
            End If

            If sdr("HW_Equipment_Electric_Drill") = 0 Then
                ChkElectric_Drill.Checked = False
            Else
                ChkElectric_Drill.Checked = True
            End If

            If sdr("HW_Equipment_Grinder") = 0 Then
                ChkGrinder.Checked = False
            Else
                ChkGrinder.Checked = True
            End If

            If sdr("HW_Equipment_Gas_Cylinders") = 0 Then
                ChkGas_Cylinders.Checked = False
            Else
                ChkGas_Cylinders.Checked = True
            End If

            If sdr("HW_Equipment_Drills") = 0 Then
                ChkDrills.Checked = False
            Else
                ChkDrills.Checked = True
            End If

            If sdr("HW_Equipment_Cutter") = 0 Then
                ChkCutter.Checked = False
            Else
                ChkCutter.Checked = True
            End If

            If sdr("HW_Equipment_Other") = 0 Then
                ChkOther.Checked = False
            Else
                ChkOther.Checked = True
            End If
            txtOtherDetail.Text = sdr.Item("HW_Equipment_OtherDetail").ToString()

            Try

                items1.Value = sdr("HW_SafetyItems_S1").ToString()
                If items1.Value = 1 Then
                    CHK_Items_S1.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S1.Items.FindByValue("0").Selected = True
                End If
                txtItems_S1.Text = sdr.Item("HW_SafetyItems_S1_Remark").ToString()

                items2.Value = sdr("HW_SafetyItems_S2").ToString()
                If items2.Value = 1 Then
                    CHK_Items_S2.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S2.Items.FindByValue("0").Selected = True
                End If
                txtItems_S2.Text = sdr.Item("HW_SafetyItems_S2_Remark").ToString()

                items3.Value = sdr("HW_SafetyItems_S3").ToString()
                If items3.Value = 1 Then
                    CHK_Items_S3.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S3.Items.FindByValue("0").Selected = True
                End If
                txtItems_S3.Text = sdr.Item("HW_SafetyItems_S3_Remark").ToString()

                items4.Value = sdr("HW_SafetyItems_S4").ToString()
                If items4.Value = 1 Then
                    CHK_Items_S4.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S4.Items.FindByValue("0").Selected = True
                End If
                txtItems_S4.Text = sdr.Item("HW_SafetyItems_S4_Remark").ToString()

                items5.Value = sdr("HW_SafetyItems_S5").ToString()
                If items5.Value = 1 Then
                    CHK_Items_S5.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S5.Items.FindByValue("0").Selected = True
                End If
                txtItems_S5.Text = sdr.Item("HW_SafetyItems_S5_Remark").ToString()

                items6.Value = sdr("HW_SafetyItems_S6").ToString()
                If items6.Value = 1 Then
                    CHK_Items_S6.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S6.Items.FindByValue("0").Selected = True
                End If
                txtItems_S6.Text = sdr.Item("HW_SafetyItems_S6_Remark").ToString()

                items7.Value = sdr("HW_SafetyItems_S7").ToString()
                If items7.Value = 1 Then
                    CHK_Items_S7.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S7.Items.FindByValue("0").Selected = True
                End If
                txtItems_S7.Text = sdr.Item("HW_SafetyItems_S7_Remark").ToString()

                items8.Value = sdr("HW_SafetyItems_S8").ToString()
                If items8.Value = 1 Then
                    CHK_Items_S8.Items.FindByValue("1").Selected = True
                Else
                    CHK_Items_S8.Items.FindByValue("0").Selected = True
                End If
                txtItems_S8_Detail.Text = sdr.Item("HW_SafetyItems_S8_Detail").ToString()
                txtItems_S8.Text = sdr.Item("HW_SafetyItems_S8_Remark").ToString()

            Catch ex As Exception

            End Try

            If sdr("HW_Pro_Safety_Eyewear") = 0 Then
                ChkEyewear.Checked = False
            Else
                ChkEyewear.Checked = True
            End If

            If sdr("HW_Pro_Safety_Welding_Helmets") = 0 Then
                ChkWelding_Helmets.Checked = False
            Else
                ChkWelding_Helmets.Checked = True
            End If
            If sdr("HW_Pro_Safety_Shoes") = 0 Then
                ChkShoes.Checked = False
            Else
                ChkShoes.Checked = True
            End If

            If sdr("HW_Pro_Safety_Glove") = 0 Then
                ChkGlove.Checked = False
            Else
                ChkGlove.Checked = True
            End If

            If sdr("HW_Pro_Fire_Extinguisher") = 0 Then
                ChkExtinguisher.Checked = False
            Else
                ChkExtinguisher.Checked = True
            End If

            If sdr("HW_Pro_Ear_Plugs") = 0 Then
                ChkEar_Plugs.Checked = False
            Else
                ChkEar_Plugs.Checked = True
            End If

            If sdr("HW_Pro_Other") = 0 Then
                ChkPro_Other.Checked = False
            Else
                ChkPro_Other.Checked = True
            End If

            txtPro_OtherDetail.Text = sdr.Item("HW_Pro_OtherDetail").ToString()

            txtbeforework.Text = sdr.Item("HW_Before_Operations").ToString()
            txtbeforecontrol.Text = sdr.Item("HW_Before_Control").ToString()
            txtbeforearea.Text = sdr.Item("HW_Before_Area").ToString()
            txtbeforesafety.Text = sdr.Item("HW_Before_Safety").ToString()

            If sdr("HW_CHECK_Area") = 0 Then
                CHECK_Area.Checked = False
            Else
                CHECK_Area.Checked = True
            End If
            If sdr("HW_CHECK_Release") = 0 Then
                CHECK_Release.Checked = False
            Else
                CHECK_Release.Checked = True
            End If
            If sdr("HW_CHECK_No_fuel_left") = 0 Then
                CHECK_No_fuel_left.Checked = False
            Else
                CHECK_No_fuel_left.Checked = True
            End If
            If sdr("HW_CHECK_Equipment") = 0 Then
                CHECK_Equipmen.Checked = False
            Else
                CHECK_Equipmen.Checked = True
            End If
            If sdr("HW_CHECK_Other") = 0 Then
                CHECK_Other.Checked = False
            Else
                CHECK_Other.Checked = True
            End If
            txtCHECK_OtherDetail.Text = sdr.Item("HW_CHECK_OtherDetail").ToString()
            txtafterwork.Text = sdr.Item("HW_After_Operations").ToString()
            txtafercontrol.Text = sdr.Item("HW_After_Control").ToString()
            txtafterarea.Text = sdr.Item("HW_After_Area").ToString()


            txtafertime.Text = sdr.Item("HW_After_time").ToString()
            txtaftersafety.Text = sdr.Item("HW_After_Safety").ToString()
        End While

        If txtdepname.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check Data !!!');", True)
            Exit Sub
        End If

    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If CHK_Items_S1.Text = "" Or CHK_Items_S2.Text = "" Or CHK_Items_S3.Text = "" Or CHK_Items_S4.Text = "" Or CHK_Items_S5.Text = "" Or CHK_Items_S6.Text = "" Or CHK_Items_S7.Text = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('โปรดเลือกรายการความปลอดภัยที่ต้องดำเนิน !!!');", True)
            Exit Sub
        End If
        If tb_date_wk.Text = "" And tb_time_start.Text = "" And tb_time_end.Text = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!!Please Check Date And Time !!!!');")
            Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        Try


            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SAFETY_HOTWORK_ACT")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@HW_HOTWORK", "INSERT")

                Dim datesave, timestartsave, timeendsave As String

                datesave = DateTime.Parse(tb_date_wk.Text).ToString("yyyy-MM-dd")

                timestartsave = DateTime.Parse(tb_time_start.Text).ToString("HH:mm:ss")

                timeendsave = DateTime.Parse(tb_time_end.Text).ToString("HH:mm:ss")


                cmd.Parameters.AddWithValue("@HW_DATE", datesave)
                cmd.Parameters.AddWithValue("@HW_DATEFROM", timestartsave)
                cmd.Parameters.AddWithValue("@HW_DATETO", timeendsave)
                cmd.Parameters.AddWithValue("@HW_DEPNAME", txtdepname.Text)
                cmd.Parameters.AddWithValue("@HW_WORKDETAIL", txtworktype.Text)
                cmd.Parameters.AddWithValue("@HW_AREA", txtareaname.Text)
                cmd.Parameters.AddWithValue("@HW_InvoiceNo", lblno.Text)
                cmd.Parameters.AddWithValue("@HW_SupervisorName", txtworknamecontrol.Text)

                cmd.Parameters.AddWithValue("@HW_TArea_Normal", ChkNormal.Checked)
                cmd.Parameters.AddWithValue("@HW_StayHigh", ChkInhigh.Checked)
                cmd.Parameters.AddWithValue("@HW_Dusty", ChkDusty.Checked)
                cmd.Parameters.AddWithValue("@HW_Chemicals", ChkChemicals.Checked)
                cmd.Parameters.AddWithValue("@HW_Type", ChkType.Checked)
                cmd.Parameters.AddWithValue("@HW_TypeDetail", txtTypedetail.Text)


                cmd.Parameters.AddWithValue("@HW_Equipment_Welding_machine", ChkWelding_machine.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Electric_Drill", ChkElectric_Drill.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Grinder", ChkGrinder.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Gas_Cylinders", ChkGas_Cylinders.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Drills", ChkDrills.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Cutter", ChkCutter.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_Other", ChkOther.Checked)
                cmd.Parameters.AddWithValue("@HW_Equipment_OtherDetail", txtOtherDetail.Text)


                cmd.Parameters.AddWithValue("@HW_SafetyItems_S1", CHK_Items_S1.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S1_Remark", txtItems_S1.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S2", CHK_Items_S2.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S2_Remark", txtItems_S2.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S3", CHK_Items_S3.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S3_Remark", txtItems_S3.Text)

                cmd.Parameters.AddWithValue("@HW_SafetyItems_S4", CHK_Items_S4.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S4_Remark", txtItems_S4.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S5", CHK_Items_S5.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S5_Remark", txtItems_S5.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S6", CHK_Items_S6.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S6_Remark", txtItems_S6.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S7", CHK_Items_S7.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S7_Remark", txtItems_S7.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S8", CHK_Items_S8.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S8_Detail", txtItems_S8_Detail.Text)
                cmd.Parameters.AddWithValue("@HW_SafetyItems_S8_Remark", txtItems_S8.Text)

                cmd.Parameters.AddWithValue("@HW_Pro_Safety_Eyewear", ChkEyewear.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Safety_Welding_Helmets", ChkWelding_Helmets.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Safety_Shoes", ChkShoes.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Safety_Glove", ChkGlove.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Fire_Extinguisher", ChkExtinguisher.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Ear_Plugs", ChkEar_Plugs.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_Other", ChkPro_Other.Checked)
                cmd.Parameters.AddWithValue("@HW_Pro_OtherDetail", txtPro_OtherDetail.Text)

                cmd.Parameters.AddWithValue("@HW_Before_Operations", txtbeforework.Text)
                cmd.Parameters.AddWithValue("@HW_Before_Control", txtbeforecontrol.Text)
                cmd.Parameters.AddWithValue("@HW_Before_Area", txtbeforearea.Text)
                cmd.Parameters.AddWithValue("@HW_Before_Safety", txtbeforesafety.Text)

                cmd.Parameters.AddWithValue("@HW_CHECK_Area", CHECK_Area.Checked)
                cmd.Parameters.AddWithValue("@HW_CHECK_Release", CHECK_Release.Checked)
                cmd.Parameters.AddWithValue("@HW_CHECK_No_fuel_left", CHECK_No_fuel_left.Checked)
                cmd.Parameters.AddWithValue("@HW_CHECK_Equipment", CHECK_Equipmen.Checked)
                cmd.Parameters.AddWithValue("@HW_CHECK_Other", CHECK_Other.Checked)
                cmd.Parameters.AddWithValue("@HW_CHECK_OtherDetail", txtCHECK_OtherDetail.Text)

                cmd.Parameters.AddWithValue("@HW_After_Operations", txtafterwork.Text)
                cmd.Parameters.AddWithValue("@HW_After_Control", txtafercontrol.Text)
                cmd.Parameters.AddWithValue("@HW_After_Area", txtafterarea.Text)

                cmd.Parameters.AddWithValue("@HW_After_time", txtafertime.Text)
                cmd.Parameters.AddWithValue("@HW_After_Safety", txtaftersafety.Text)
                cmd.Parameters.AddWithValue("@HW_NO", lblno.Text)

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            If txtworknamecontrol.Text <> "" Or txtbeforearea.Text <> "" Or txtaftersafety.Text <> "" Then
                Dim message As String = "!!! INSERT DATA OK !!! " + "</br></br>" + "Please Remember NO  " + lblno.Text + "</br></br>" + "Work controller approve in your E-mai"
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "' ); ", True)
                Exit Sub
            Else
                Response.Write("<Script>")
                Response.Write("alert('!!! Please Insert New Data  !!!!');")
                Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
                Response.Write("</Script>")
            End If

        Catch ex As Exception
            Dim message As String = "!!! PLEASE CHECK DATA !!! " + "</br></br>" + "Please Contact Mr.Weerapat  " + "</br></br>" + "TEL :: 4724 " + "</br></br>" + " THANK YOU "
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "VPPopup('" + message + "' ); ", True)
            Exit Sub
        End Try


    End Sub
    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("SAFETY_HOTWORK_ACT")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@HW_HOTWORK", "UPDATE")

            Dim datesave, timestartsave, timeendsave As String

            datesave = DateTime.Parse(tb_date_wk.Text).ToString("yyyy-MM-dd")

            timestartsave = DateTime.Parse(tb_time_start.Text).ToString("HH:mm:ss")

            timeendsave = DateTime.Parse(tb_time_end.Text).ToString("HH:mm:ss")

            cmd.Parameters.AddWithValue("@HW_DEPNAME", txtdepname.Text)
            cmd.Parameters.AddWithValue("@HW_WORKDETAIL", txtworktype.Text)
            cmd.Parameters.AddWithValue("@HW_AREA", txtareaname.Text)
            cmd.Parameters.AddWithValue("@HW_InvoiceNo", txtinvoive.Text)
            cmd.Parameters.AddWithValue("@HW_SupervisorName", txtworknamecontrol.Text)

            cmd.Parameters.AddWithValue("@HW_DATE", datesave)
            cmd.Parameters.AddWithValue("@HW_DATEFROM", timestartsave)
            cmd.Parameters.AddWithValue("@HW_DATETO", timeendsave)


            cmd.Parameters.AddWithValue("@HW_TArea_Normal", ChkNormal.Checked)
            cmd.Parameters.AddWithValue("@HW_StayHigh", ChkInhigh.Checked)
            cmd.Parameters.AddWithValue("@HW_Dusty", ChkDusty.Checked)
            cmd.Parameters.AddWithValue("@HW_Chemicals", ChkChemicals.Checked)
            cmd.Parameters.AddWithValue("@HW_Type", ChkType.Checked)
            cmd.Parameters.AddWithValue("@HW_TypeDetail", txtTypedetail.Text)


            cmd.Parameters.AddWithValue("@HW_Equipment_Welding_machine", ChkWelding_machine.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Electric_Drill", ChkElectric_Drill.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Grinder", ChkGrinder.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Gas_Cylinders", ChkGas_Cylinders.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Drills", ChkDrills.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Cutter", ChkCutter.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_Other", ChkOther.Checked)
            cmd.Parameters.AddWithValue("@HW_Equipment_OtherDetail", txtOtherDetail.Text)


            cmd.Parameters.AddWithValue("@HW_SafetyItems_S1", CHK_Items_S1.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S1_Remark", txtItems_S1.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S2", CHK_Items_S2.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S2_Remark", txtItems_S2.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S3", CHK_Items_S3.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S3_Remark", txtItems_S3.Text)

            cmd.Parameters.AddWithValue("@HW_SafetyItems_S4", CHK_Items_S4.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S4_Remark", txtItems_S4.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S5", CHK_Items_S5.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S5_Remark", txtItems_S5.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S6", CHK_Items_S6.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S6_Remark", txtItems_S6.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S7", CHK_Items_S7.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S7_Remark", txtItems_S7.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S8", CHK_Items_S8.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S8_Detail", txtItems_S8_Detail.Text)
            cmd.Parameters.AddWithValue("@HW_SafetyItems_S8_Remark", txtItems_S8.Text)

            cmd.Parameters.AddWithValue("@HW_Pro_Safety_Eyewear", ChkEyewear.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Safety_Welding_Helmets", ChkWelding_Helmets.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Safety_Shoes", ChkShoes.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Safety_Glove", ChkGlove.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Fire_Extinguisher", ChkExtinguisher.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Ear_Plugs", ChkEar_Plugs.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_Other", ChkPro_Other.Checked)
            cmd.Parameters.AddWithValue("@HW_Pro_OtherDetail", txtPro_OtherDetail.Text)

            cmd.Parameters.AddWithValue("@HW_Before_Operations", txtbeforework.Text)
            'cmd.Parameters.AddWithValue("@HW_Before_Chk_Repair_Staff", chkbeforerepair.Checked)
            cmd.Parameters.AddWithValue("@HW_Before_Control", txtbeforecontrol.Text)
            cmd.Parameters.AddWithValue("@HW_Before_Area", txtbeforearea.Text)
            'cmd.Parameters.AddWithValue("@HW_Before_Chk_Head", chkbeforehead.Checked)
            cmd.Parameters.AddWithValue("@HW_Before_Safety", txtbeforesafety.Text)

            cmd.Parameters.AddWithValue("@HW_CHECK_Area", CHECK_Area.Checked)
            cmd.Parameters.AddWithValue("@HW_CHECK_Release", CHECK_Release.Checked)
            cmd.Parameters.AddWithValue("@HW_CHECK_No_fuel_left", CHECK_No_fuel_left.Checked)
            cmd.Parameters.AddWithValue("@HW_CHECK_Equipment", CHECK_Equipmen.Checked)
            cmd.Parameters.AddWithValue("@HW_CHECK_Other", CHECK_Other.Checked)
            cmd.Parameters.AddWithValue("@HW_CHECK_OtherDetail", txtCHECK_OtherDetail.Text)

            cmd.Parameters.AddWithValue("@HW_After_Operations", txtafterwork.Text)
            'cmd.Parameters.AddWithValue("@HW_After_Chk_Repair_Staff", chkafterrepair.Checked)
            'cmd.Parameters.AddWithValue("@HW_After_Chk_Control", chkaftercontrol.Checked)
            cmd.Parameters.AddWithValue("@HW_After_Control", txtafercontrol.Text)
            cmd.Parameters.AddWithValue("@HW_After_Area", txtafterarea.Text)
            'cmd.Parameters.AddWithValue("@HW_After_Chk_work", chkafterwork.Checked)

            'cmd.Parameters.AddWithValue("@HW_After_Chk_Head", chkafterhead.Checked)
            'cmd.Parameters.AddWithValue("@HW_After_Chk_time", chkaftertime.Checked)
            cmd.Parameters.AddWithValue("@HW_After_time", txtafertime.Text)
            cmd.Parameters.AddWithValue("@HW_After_Safety", txtaftersafety.Text)
            cmd.Parameters.AddWithValue("@HW_NO", txtcheckno.Text.Trim())
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            If txtworknamecontrol.Text <> "" Or txtbeforearea.Text <> "" Or txtaftersafety.Text <> "" Then
                Response.Write("<Script>")
                Response.Write("alert('!!! Update Data OK NA JA  !!!!');")
                Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
                Response.Write("</Script>")
                Exit Sub
            Else
                Response.Write("<Script>")
                Response.Write("alert('!!! Please Edit New Data  !!!!');")
                Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
                Response.Write("</Script>")
            End If
        End Using

    End Sub
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
        If txtcheckno.Text.Trim() = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Insert Work No  !!!!');")
            Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If


        Dim dtAdapter As New SqlDataAdapter
        Dim V_REC_ACC_DATA As DataTable
        Dim ds As New DataSet

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_HOTWORK WHERE  HW_NO = '" & txtcheckno.Text.Trim() & "'  "

        dtAdapter = New SqlDataAdapter(strQuery, ConStr_SAFETY)

        If ds.Tables.Contains("V_REC_ACC_DATA") Then
            ds.Tables("V_REC_ACC_DATA").Rows.Clear()
            ds.Tables("V_REC_ACC_DATA").Columns.Clear()
        End If

        dtAdapter.Fill(ds, "V_REC_ACC_DATA")

        V_REC_ACC_DATA = ds.Tables("V_REC_ACC_DATA")

        If ds.Tables("V_REC_ACC_DATA").Rows.Count = 0 Then
            Response.Write("<Script>")
            Response.Write("alert('!!! NO DATA  NAJA !!!!');")
            Response.Write("location.href='P_HOTWORK_PERMIT.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        Dim rpt As New ReportDocument()
        rpt.Load(Server.MapPath("P_HotWork.rpt"))
        rpt.SetDataSource(V_REC_ACC_DATA)
        Me.CrystalReportViewer1.ReportSource = rpt
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        formatType = ExportFormatType.PortableDocFormat
        rpt.ExportToHttpResponse(formatType, Response, True, "HOTWORK" + "-" + txtcheckno.Text.Trim())
        Response.[End]()
    End Sub

    Private Sub ChkOther_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOther.CheckedChanged
        'txtOtherDetail
        If ChkOther.Checked = True Then
            txtOtherDetail.Enabled = True
            txtOtherDetail.Focus()
        Else
            txtOtherDetail.Enabled = False
        End If
    End Sub

    Private Sub ChkType_CheckedChanged(sender As Object, e As EventArgs) Handles ChkType.CheckedChanged
        If ChkType.Checked = True Then
            txtTypedetail.Enabled = True
            txtTypedetail.Focus()
        Else
            txtTypedetail.Enabled = False
        End If
    End Sub
End Class




