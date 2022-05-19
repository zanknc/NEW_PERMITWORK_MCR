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
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Net.Mail
Imports System.Net
Imports System.Net.IPHostEntry
Imports System.Text.RegularExpressions
Partial Class P_ELECTRICAL
    Inherits System.Web.UI.Page
    Protected Property Namereq() As String

    Dim DateNow, CDYEAR, CDMONTH, CDATENOW As String 'DateTimeSetCDDATE
    Dim DATECHECK_SF, DMIDDATA, Vipdata, DDateNO, DNODATA, DTB_DATE As String ' checkno
    Dim DateString, timestart, timeEnd, DATECHCCK, DCHECKYEAR, SESSION_NO As String
    Dim CK_EMAIL, CK_NAME, SAFETY_NAME, VIPADDRESS As String 'SENT EMAIL 
    Dim Equipment_E1, Equipment_E2, Equipment_E3, Equipment_E4, Equipment_E5, CHECKAREAR As New ListItem() ' ListItemName
    Dim SCEquipment_S1, SCEquipment_S2, SCEquipment_S3, SCEquipment_S4, SCEquipment_S5, SCEquipment_S6, SCEquipment_S7 As New ListItem() ' ListItemName
    Dim SCCHECKWORK_S1, SCCHECKWORK_S2, SCCHECKWORK_S3, SCCHECKWORK_S4, SCCHECKWORK_S5, SCCHECKWORK_S6, SCCHECKWORK_S7, SCCHECKWORK_S8, SCCHECKWORK_S9, SCCHECKWORK_S10 As New ListItem() ' ListItemName
    Dim SCCHKSCMeasures1, SCCHKSCMeasures2, SCCHKSCMeasures3, SCCHKSCMeasures4, SCCHKSCMeasures5, SCCHKSCMeasures6, SCCHKSCMeasures7, SCCHKSCMeasures8, SCCHKSCMeasures9, SCCHKSCMeasures10 As New ListItem()
    Dim SCCHKSCMeasures11, SCCHKSCMeasures12, SCCHKSCMeasures13, SCCHKSCMeasures14, SCCHKSCMeasures15, SCCHKSCMeasures16, SCCHKSCMeasures17, SCCHKSCMeasures18, SCCHKSCMeasures19 As New ListItem()

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
            DDL_CERTIFICATE()
            CheckDateNo()
            SFT_DIVISONNAMEAREA()
        End If

        
        CheckDateNo()
    End Sub
#Region "AUTO NO"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
        Public Shared Function SearchSFNO(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select TOP(20) SCNO from SAFETY_ELECTRICAL_TEST where SCNO like @SearchText + '%'  GROUP BY SCNO  ORDER BY SCNO DESC "

        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("SCNO").ToString)
        End While
        conn.Close()
        Return customers
    End Function
#End Region
    Private Sub CheckDateNo()
        DateNow = DateTime.Now.ToString("yyyyMMdd")
        lblyear.Text = Mid(DateNow, 1, 4)
        CDYEAR = Mid(DateNow, 3, 2)
        CDMONTH = Mid(DateNow, 5, 2)
        CDATENOW = CDYEAR + "/" + CDMONTH
        CHECKNO()
    End Sub
    Private Sub CHECKNO()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT MaX(SCNO) as SCNO  FROM SAFETY_ELECTRICAL_TEST  "
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@HW_NO", con_SAFETY)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            DATECHECK_SF = sdr("SCNO").ToString()
            DMIDDATA = Mid(DATECHECK_SF, 1, 5)
            DCHECKYEAR = Mid(DATECHECK_SF, 1, 2)
        End While


        'If DATECHECK_SF.Trim() = "" Then
        '    lblcheckno.Text = CDATENOW + "/" + "00001"
        '    Exit Sub
        'End If
If DCHECKYEAR <> CDYEAR Then
            lblcheckno.Text = CDYEAR + "/" + CDMONTH + "/" + "00001"
            Exit Sub
        End If
        If CDATENOW = DMIDDATA Then
            Vipdata = CType((1 + Mid(DATECHECK_SF, 7, 11)), String)
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
            lblcheckno.Text = CDATENOW + "/" + DDateNO
            Exit Sub
        ElseIf CDATENOW <> DMIDDATA Then
            DNODATA = CType((1 + Mid(DATECHECK_SF, 7, 11).ToString()), String)

            If Len(DNODATA) = 1 Then
                DDateNO = "0000" + DNODATA
            ElseIf Len(DNODATA) = 2 Then
                DDateNO = "000" + DNODATA
            ElseIf Len(Vipdata) = 3 Then
                DDateNO = "00" + DNODATA
            ElseIf Len(Vipdata) = 4 Then
                DDateNO = "0" + DNODATA
            ElseIf Len(Vipdata) > 4 Then
                DDateNO = DNODATA
            End If
            lblcheckno.Text = CDATENOW + "/" + DDateNO
            Exit Sub
            'ElseIf DCHECKYEAR <> DMIDDATA Then
            '    lblcheckno.Text = DCHECKYEAR + "/" + CDMONTH + "/" + DDateNO
            '    Exit Sub
        End If




    End Sub
    'Protected Sub btncheckno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheckno.Click
    '    If txtcheckno.Text = "" Then
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Please Check New  NAJA !!!');", True)
    '        Exit Sub
    '    End If
    '    BtnSave.Visible = True

    '    Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
    '    Dim con As New SqlConnection(ConStr_SAFETY)
    '    Using con
    '        con.Open()
    '        Dim cmd As SqlCommand = New SqlCommand("SAFETY_ELECTRICAL_SELECT", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.AddWithValue("@SCNO", txtcheckno.Text)
    '        Using vipr = cmd.ExecuteReader()
    '            If vipr.Read() Then
    '                lblcheckno.Text = txtcheckno.Text
    '                ddlnametitle.SelectedItem.Text = vipr.Item("SCNAMETITLE")
    '                lblyear.Text = vipr.Item("SCYEAR")

    '                txtname.Text = vipr.Item("SCNAME")
    '                txtnamesum.Text = vipr.Item("SCPERMITSESS")
    '                ddlcername1.SelectedItem.Text = vipr.Item("SCPERMITNAME1")
    '                ddlcername2.SelectedItem.Text = vipr.Item("SCPERMITNAME2")
    '                ddlcername3.SelectedItem.Text = vipr.Item("SCPERMITNAME3")
    '                ddlcername4.SelectedItem.Text = vipr.Item("SCPERMITNAME4")
    '                ddlcername5.SelectedItem.Text = vipr.Item("SCPERMITNAME5")
    '                ddlcername6.SelectedItem.Text = vipr.Item("SCPERMITNAME6")
    '                'ddlcername7.SelectedItem.Text = vipr.Item("SCPERMITNAME7")



    '                'txtdivdep.Text = vipr.Item("SCWORKDIV")
    '                'txtworkdetail.Text = vipr.Item("SCWORKDETAIL")
    '                'txtlocation.Text = vipr.Item("SCWORKAREA")
    '                'TB_DATE.Text = vipr.Item("SCWORKDATE")
    '                'tb_time_start.Text = vipr.Item("SCWORKDATEFROM")
    '                'tb_time_end.Text = vipr.Item("SCWORKDATETO")


    '                'DateString = vipr.Item("SCWORKDATE").ToString()
    '                'TB_DATE.Text = DateTime.Parse(DateString).ToString("yyyy-MM-dd")

    '                'timestart = vipr.Item("SCWORKDATEFROM").ToString()
    '                'tb_time_start.Text = DateTime.Parse(timestart).ToString("HH:mm:ss")

    '                'timeEnd = vipr.Item("SCWORKDATETO").ToString()
    '                'tb_time_end.Text = DateTime.Parse(timeEnd).ToString("HH:mm:ss")

    '                'tb_date.BackColor = Drawing.Color.LightBlue
    '                'tb_time_start.BackColor = Drawing.Color.LightBlue
    '                'tb_time_end.BackColor = Drawing.Color.LightBlue

    '                'txtcompany.Text = vipr.Item("SCCOMPANY")
    '                'ddlnametitlepermit.SelectedItem.Text = vipr.Item("SCPERMITWORKNAMETITLE")
    '                'txtnamepermit.Text = vipr.Item("SCPERMITWORKNAME")


    '                'txtsumpermit.Text = vipr.Item("SCPERMITWORKSUM")
    '                'txtEQUIPMENT1.Text = vipr.Item("SCEQUIPMENT1")
    '                'txtEQUIPMENT2.Text = vipr.Item("SCEQUIPMENT2")
    '                'txtEQUIPMENT3.Text = vipr.Item("SCEQUIPMENT3")
    '                'txtEQUIPMENT4.Text = vipr.Item("SCEQUIPMENT4")
    '                'txtEQUIPMENT5.Text = vipr.Item("SCEQUIPMENT5")
    '                'txtEQUIPMENT6.Text = vipr.Item("SCEQUIPMENT6")

    '                'txtnameEQUIPMENT.Text = vipr.Item("SCAPPNAME")

    '                DTB_DATE = vipr.Item("SCCREATEDATE")
    '                'tb_date_2.Text = DateTime.Parse(DTB_DATE).ToString("dd-MMM-yyyy")
    '                'timeEnd = vipr.Item("SCWORKDATETO").ToString()
    '                'tb_time_end.Text = DateTime.Parse(timeEnd).ToString("HH:mm:ss")
    '               '/20181122pumodify
    '                'SCEquipment_S1.Text = vipr("SCCHECKSAFETY1").ToString()
    '                'If SCEquipment_S1.Text = True Then
    '                '    CHK_Items_S1.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S1.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCEquipment_S2.Text = vipr("SCCHECKSAFETY2").ToString()
    '                'If SCEquipment_S2.Text = True Then
    '                '    CHK_Items_S2.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S2.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCEquipment_S3.Text = vipr("SCCHECKSAFETY3").ToString()
    '                'If SCEquipment_S3.Text = True Then
    '                '    CHK_Items_S3.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S3.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCEquipment_S4.Text = vipr("SCCHECKSAFETY4").ToString()
    '                'If SCEquipment_S4.Text = True Then
    '                '    CHK_Items_S4.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S4.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCEquipment_S5.Text = vipr("SCCHECKSAFETY5").ToString()
    '                'If SCEquipment_S5.Text = True Then
    '                '    CHK_Items_S5.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S5.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCEquipment_S6.Text = vipr("SCCHECKSAFETY6").ToString()
    '                'If SCEquipment_S6.Text = True Then
    '                '    CHK_Items_S6.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S6.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCEquipment_S7.Text = vipr("SCCHECKSAFETY7").ToString()
    '                'If SCEquipment_S7.Text = True Then
    '                '    CHK_Items_S7.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHK_Items_S7.Items.FindByValue("0").Selected = True
    '                'End If



    '                'SCCHECKWORK_S1.Text = vipr("SCCHECKWORK1").ToString()
    '                'If SCCHECKWORK_S1.Text = True Then
    '                '    Chk_Safety1.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety1.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S2.Text = vipr("SCCHECKWORK2").ToString()
    '                'If SCCHECKWORK_S2.Text = True Then
    '                '    Chk_Safety2.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety2.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S3.Text = vipr("SCCHECKWORK3").ToString()
    '                'If SCCHECKWORK_S3.Text = True Then
    '                '    Chk_Safety3.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety3.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S4.Text = vipr("SCCHECKWORK4").ToString()
    '                'If SCCHECKWORK_S4.Text = True Then
    '                '    Chk_Safety4.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety4.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S5.Text = vipr("SCCHECKWORK5").ToString()
    '                'If SCCHECKWORK_S5.Text = True Then
    '                '    Chk_Safety5.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety5.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCCHECKWORK_S6.Text = vipr("SCCHECKWORK6").ToString()
    '                'If SCCHECKWORK_S6.Text = True Then
    '                '    Chk_Safety6.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety6.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S7.Text = vipr("SCCHECKWORK7").ToString()
    '                'If SCCHECKWORK_S7.Text = True Then
    '                '    Chk_Safety7.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety7.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S8.Text = vipr("SCCHECKWORK8").ToString()
    '                'If SCCHECKWORK_S8.Text = True Then
    '                '    Chk_Safety8.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety8.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S9.Text = vipr("SCCHECKWORK9").ToString()
    '                'If SCCHECKWORK_S9.Text = True Then
    '                '    Chk_Safety9.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety9.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHECKWORK_S10.Text = vipr("SCCHECKWORK10").ToString()
    '                'If SCCHECKWORK_S10.Text = True Then
    '                '    Chk_Safety10.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    Chk_Safety10.Items.FindByValue("0").Selected = True
    '                'End If


    '                'txtchemicals1.Text = vipr.Item("SCCHECKFlammable")
    '                'txtchemicals2.Text = vipr.Item("SCCHECKOxygen")
    '                'txtchemicals31.Text = vipr.Item("SCchemicals11")
    '                'txtchemicals32.Text = vipr.Item("SCchemicals12")
    '                'txtchemicals33.Text = vipr.Item("SCchemicals21")
    '                'txtchemicals34.Text = vipr.Item("SCchemicals22")
    '                'txtchemicals35.Text = vipr.Item("SCchemicals31")
    '                'txtchemicals36.Text = vipr.Item("SCchemicals32")

    '                'txtnamechek.Text = vipr.Item("SCCHECKNAME")

    '                'DATECHCCK = vipr.Item("SCCHECKDATE").ToString()
    '                'txtdatechek.Text = DateTime.Parse(DATECHCCK).ToString("yy-MM-dd")
    '                '/20181122puend

    '                'SCCHKSCMeasures1.Text = vipr("SCMeasures1").ToString()
    '                'If SCCHKSCMeasures1.Text = True Then
    '                '    CHKSCMeasures1.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures1.Items.FindByValue("0").Selected = True
    '                'End If
    '                'SCCHKSCMeasures2.Text = vipr("SCMeasures2").ToString()
    '                'If SCCHKSCMeasures2.Text = True Then
    '                '    CHKSCMeasures2.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures2.Items.FindByValue("0").Selected = True
    '                'End If
    '                'SCCHKSCMeasures3.Text = vipr("SCMeasures3").ToString()
    '                'If SCCHKSCMeasures3.Text = True Then
    '                '    CHKSCMeasures3.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures3.Items.FindByValue("0").Selected = True
    '                'End If
    '                'SCCHKSCMeasures4.Text = vipr("SCMeasures4").ToString()
    '                'If SCCHKSCMeasures4.Text = True Then
    '                '    CHKSCMeasures4.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures4.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures5.Text = vipr("SCMeasures5").ToString()
    '                'If SCCHKSCMeasures5.Text = True Then
    '                '    CHKSCMeasures5.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures5.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures6.Text = vipr("SCMeasures6").ToString()
    '                'If SCCHKSCMeasures6.Text = True Then
    '                '    CHKSCMeasures6.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures6.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures7.Text = vipr("SCMeasures7").ToString()
    '                'If SCCHKSCMeasures7.Text = True Then
    '                '    CHKSCMeasures7.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures7.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures8.Text = vipr("SCMeasures8").ToString()
    '                'If SCCHKSCMeasures8.Text = True Then
    '                '    CHKSCMeasures8.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures8.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCCHKSCMeasures9.Text = vipr("SCMeasures9").ToString()
    '                'If SCCHKSCMeasures9.Text = True Then
    '                '    CHKSCMeasures9.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures9.Items.FindByValue("0").Selected = True
    '                'End If


    '                'SCCHKSCMeasures10.Text = vipr("SCMeasures10").ToString()
    '                'If SCCHKSCMeasures10.Text = True Then
    '                '    CHKSCMeasures10.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures10.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures11.Text = vipr("SCMeasures11").ToString()
    '                'If SCCHKSCMeasures11.Text = True Then
    '                '    CHKSCMeasures11.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures11.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures12.Text = vipr("SCMeasures12").ToString()
    '                'If SCCHKSCMeasures12.Text = True Then
    '                '    CHKSCMeasures12.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures12.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures13.Text = vipr("SCMeasures13").ToString()
    '                'If SCCHKSCMeasures13.Text = True Then
    '                '    CHKSCMeasures13.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures13.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures14.Text = vipr("SCMeasures14").ToString()
    '                'If SCCHKSCMeasures14.Text = True Then
    '                '    CHKSCMeasures14.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures14.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures15.Text = vipr("SCMeasures15").ToString()
    '                'If SCCHKSCMeasures15.Text = True Then
    '                '    CHKSCMeasures15.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures15.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures16.Text = vipr("SCMeasures16").ToString()
    '                'If SCCHKSCMeasures16.Text = True Then
    '                '    CHKSCMeasures16.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures16.Items.FindByValue("0").Selected = True
    '                'End If
    '                'SCCHKSCMeasures17.Text = vipr("SCMeasures17").ToString()
    '                'If SCCHKSCMeasures17.Text = True Then
    '                '    CHKSCMeasures17.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures17.Items.FindByValue("0").Selected = True
    '                'End If

    '                'SCCHKSCMeasures18.Text = vipr("SCMeasures18").ToString()
    '                'If SCCHKSCMeasures18.Text = True Then
    '                '    CHKSCMeasures18.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures18.Items.FindByValue("0").Selected = True
    '                'End If
    '                'SCCHKSCMeasures19.Text = vipr("SCMeasures19").ToString()
    '                'If SCCHKSCMeasures19.Text = True Then
    '                '    CHKSCMeasures19.Items.FindByValue("1").Selected = True
    '                'Else
    '                '    CHKSCMeasures19.Items.FindByValue("0").Selected = True
    '                'End If

    '                'txtMeasures19.Text = vipr.Item("SCMeasuresOther")
    '            End If
    '        End Using
    '    End Using


    'End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'tb_date_2.Text = DateTime.Now.ToString("yyyy-MM-dd")
        CheckDateNo()
        If txtname.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Name !!!');", True)
            Exit Sub
        End If
        If txtnamesum.Text.Trim = "" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Namesum !!!');", True)
            Exit Sub
        End If
        'If txtdivdep.Text.Trim() = "" And txtworkdetail.Text.Trim() = "" And txtlocation.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Namesum !!!');", True)
        '    Exit Sub
        'End If
        'If txtworkdetail.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Work Detail !!!');", True)
        '    Exit Sub
        'End If
        'If txtlocation.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Location !!!');", True)
        '    Exit Sub
        'End If
        'If TB_DATE.Text = "" And tb_time_start.Text = "" And tb_time_end.Text = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Data Date And Time !!!');", True)
        '    Exit Sub
        'End If

        'If txtcompany.Text.Trim() = "" And txtnamepermit.Text.Trim() = "" And txtsumpermit.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert txtcompany !!!');", True)
        '    Exit Sub
        'End If
        'If txtnamepermit.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Name Work Permit !!!');", True)
        '    Exit Sub
        'End If
        'If txtsumpermit.Text.Trim() = "" Then
        '    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Insert Sum Work Permit !!!');", True)
        '    Exit Sub
        'End If


        Using db As New DBELECTRICALDataContext

            Dim chkeq1 as Integer
            Dim chkeq2 as Integer
            Dim chkeq3 as Integer
            Dim chkeq4 as Integer
            Dim chkeq5 as Integer        

            For i As Integer = 0 To CHK_Equipment_E1.Items.Count - 2
                If CHK_Equipment_E1.Items(i).Selected Then
                    chkeq1 += CInt(CHK_Equipment_E1.Items(i).Value.ToString())
                End If
            Next

            For i As Integer = 0 To CHK_Equipment_E2.Items.Count - 2
                If CHK_Equipment_E2.Items(i).Selected Then
                    chkeq2 += CInt(CHK_Equipment_E2.Items(i).Value.ToString())
                End If
            Next

            For i As Integer = 0 To CHK_Equipment_E3.Items.Count - 2
                If CHK_Equipment_E3.Items(i).Selected Then
                    chkeq3 += CInt(CHK_Equipment_E3.Items(i).Value.ToString())
                End If
            Next

            For i As Integer = 0 To CHK_Equipment_E4.Items.Count - 2
                If CHK_Equipment_E4.Items(i).Selected Then
                    chkeq4 += CInt(CHK_Equipment_E4.Items(i).Value.ToString())
                End If
            Next

            For i As Integer = 0 To CHK_Equipment_E5.Items.Count - 2
                If CHK_Equipment_E5.Items(i).Selected Then
                    chkeq5 += CInt(CHK_Equipment_E5.Items(i).Value.ToString())
                End If

            Next

            
               

                Dim spname As String() = Label2.Text.Split(New Char() {" "c})
            Select Case spname.Length
                Case 2
                    Dim n As String = String.Empty
                    n = spname(0).ToUpper()
                    Dim np As String() = n.Split(New Char() {"."c})
                    Namereq = np(1).ToUpper()
               
                Case 3
               
                    Namereq = spname(1).ToUpper()
               
            End Select
            
            Try
                Dim insertEC as New SAFETY_ELECTRICAL_TEST with {
                    .SCNO = lblcheckno.Text,
                    .SCYEAR = lblyear.Text,
                    .SCNAMETITLE = ddlnametitle.SelectedItem.Text,
                    .SCNAME = txtname.Text.Trim(),
                    .SCTELMOBILE = tbtelmobile.Text.Trim(),
                    .SCTELCOMPANY = tbtelcompany.Text.Trim(),
                    .SCPERMITSESS = txtnamesum.Text.Trim(),
                    .SCPERMITNAME1 = ddlcername1.SelectedValue.Trim(),
                    .SCPERMITNAME2 = ddlcername2.SelectedValue.Trim(),
                    .SCPERMITNAME3 = ddlcername3.SelectedValue.Trim(),
                    .SCPERMITNAME4 = ddlcername4.SelectedValue.Trim(),
                    .SCPERMITNAME5 = ddlcername5.SelectedValue.Trim(),
                    .SCPERMITNAME6 = ddlcername6.SelectedValue.Trim(),
                    .SCWORKDATE = tb_date.Value,
                    .SCWORKDATEFROM = tb_time_start.Value,
                    .SCWORKDATETO = tb_time_end.Value,
                    .SCWORKAREA = ddlworkarea.SelectedItem.Text,
                    .SCFLOOR = ddlworkfloor.SelectedItem.Text,
                    .SCWORKOTHER = tb_areaother.Value,
                    .SCDIVNAME = ddlareadiv.SelectedItem.Text,
                    .SCSECTNAME = ddlareadep.SelectedItem.Text,
                    .SCWORKDETAIL = tb_workdetail.Value,
                    .SCVOLTE = tb_height_volte.Value,
                    .SCNAMECONTROL = tb_name_control.Value.ToUpper(),
                    .SCEMAILCONTROL = tb_emailcontrol_company.Value,
                    .SCEQUIPMENT1 = txtEquipment_E1.Text.Trim(),
                    .SCEQUIPMENT1CHECK = CBool(chkeq1),
                    .SCEQUIPMENT2 = txtEquipment_E2.Text.Trim(),
                    .SCEQUIPMENT2CHECK = CBool(chkeq2),
                    .SCEQUIPMENT3 = txtEquipment_E3.Text.Trim(),
                    .SCEQUIPMENT3CHECK = CBool(chkeq3),
                    .SCEQUIPMENT4 = txtEquipment_E4.Text.Trim(),
                    .SCEQUIPMENT4CHECK = CBool(chkeq4),
                    .SCEQUIPMENT5 = txtEquipment_E5.Text.Trim(),
                    .SCEQUIPMENT5CHECK = CBool(chkeq5),
                    .SCREQNAME = Namereq,
                    .SCAPPNAME = "WAITING APPROVE",
                    .SCSAFETYNAME = "WAITING APPROVE",
                    .SCSTAMPCONTROL = "WAITING APPROVE", 
                    .CREATEDATE = DateTime.Now
                    }
                db.SAFETY_ELECTRICAL_TESTs.InsertOnSubmit(insertEC)
                db.SubmitChanges()
                db.Dispose()
                'send mail to request entry for preview details
                'SendEmailToRequest
                'Session.Remove("opnologin")
                Sent_Email_ControlWork
                'Sent_Email_lisicor()
                'Sent_Email_Safety()

                Dim message As String = "!!! INSERT DATA OK !!! " + "</br></br>" + "Please Remember NO  " + lblcheckno.Text + "</br></br>" + ""
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "' ); ", True)
                
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

        'Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        'Dim con As New SqlConnection(ConStr_SAFETY)
        'Using cmd As New SqlCommand("SAFETY_ELECTRICAL_INSERT")
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Parameters.AddWithValue("@SCNO", lblcheckno.Text.Trim())
        '    cmd.Parameters.AddWithValue("@SCYEAR", lblyear.Text.Trim())
        '    cmd.Parameters.AddWithValue("@SCNAMETITLE", ddlnametitle.SelectedItem.Text)
        '    cmd.Parameters.AddWithValue("@SCNAME ", txtname.Text.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITSESS", txtnamesum.Text.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME1", ddlcername1.SelectedValue.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME2", ddlcername2.SelectedValue.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME3", ddlcername3.SelectedValue.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME4", ddlcername4.SelectedValue.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME5", ddlcername5.SelectedValue.Trim())
        '    cmd.Parameters.AddWithValue("@SCPERMITNAME6", ddlcername6.SelectedValue.Trim())
        '    'cmd.Parameters.AddWithValue("@SCPERMITNAME7", ddlcername7.SelectedValue.Trim())


        '    'cmd.Parameters.AddWithValue("@SCWORKDIV", txtdivdep.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCWORKDETAIL", txtworkdetail.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCWORKAREA", txtlocation.Text.Trim())

        '    'cmd.Parameters.AddWithValue("@SCWORKDATE", TB_DATE.Text)
        '    'cmd.Parameters.AddWithValue("@SCWORKDATEFROM", tb_time_start.Text)
        '    'cmd.Parameters.AddWithValue("@SCWORKDATETO", tb_time_end.Text)

        '    'cmd.Parameters.AddWithValue("@SCCOMPANY", txtcompany.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCPERMITWORKNAMETITLE", ddlnametitle.SelectedItem.Text)
        '    'cmd.Parameters.AddWithValue("@SCPERMITWORKNAME", txtnamepermit.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCPERMITWORKSUM", txtsumpermit.Text.Trim())

        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT1", txtEQUIPMENT1.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT2", txtEQUIPMENT2.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT3", txtEQUIPMENT3.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT4", txtEQUIPMENT4.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT5", txtEQUIPMENT5.Text.Trim())
        '    'cmd.Parameters.AddWithValue("@SCEQUIPMENT6", txtEQUIPMENT6.Text.Trim())

        '    '/20181122pumodify
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY1 ", CHK_Items_S1.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY2 ", CHK_Items_S2.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY3 ", CHK_Items_S3.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY4 ", CHK_Items_S4.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY5", CHK_Items_S5.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY6", CHK_Items_S6.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKSAFETY7", CHK_Items_S7.Text)
          

        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK1", Chk_Safety1.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK2", Chk_Safety2.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK3", Chk_Safety3.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK4", Chk_Safety4.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK5", Chk_Safety5.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK6", Chk_Safety6.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK7", Chk_Safety7.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK8", Chk_Safety8.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK9", Chk_Safety9.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKWORK10", Chk_Safety10.Text)

        '    'cmd.Parameters.AddWithValue("@SCCHECKFlammable", txtchemicals1.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKOxygen", txtchemicals2.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals11", txtchemicals31.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals12", txtchemicals32.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals21", txtchemicals33.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals22", txtchemicals34.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals31", txtchemicals35.Text)
        '    'cmd.Parameters.AddWithValue("@SCchemicals32", txtchemicals36.Text)

        '    'cmd.Parameters.AddWithValue("@SCCHECKNAME", txtnamechek.Text)
        '    'cmd.Parameters.AddWithValue("@SCCHECKDATE", txtdatechek.Text)
        '    '/20181122puend

        '    'cmd.Parameters.AddWithValue("@SCMeasures1 ", CHKSCMeasures1.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures2", CHKSCMeasures2.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures3", CHKSCMeasures3.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures4", CHKSCMeasures4.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures5", CHKSCMeasures5.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures6", CHKSCMeasures6.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures7", CHKSCMeasures7.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures8", CHKSCMeasures8.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures9", CHKSCMeasures9.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures10", CHKSCMeasures10.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures11", CHKSCMeasures11.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures12", CHKSCMeasures12.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures13", CHKSCMeasures13.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures14", CHKSCMeasures14.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures15", CHKSCMeasures15.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures16", CHKSCMeasures16.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures17", CHKSCMeasures17.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures18", CHKSCMeasures18.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasures19", CHKSCMeasures19.Text)
        '    'cmd.Parameters.AddWithValue("@SCMeasuresOther", txtMeasures19.Text)



        '    cmd.Parameters.AddWithValue("@SCAPPNAME", "WAITING APPROVE")
        '    cmd.Parameters.AddWithValue("@SCSAFETYNAME", "WAITING APPROVE")

        '    cmd.Connection = con
        '    con.Open()
        '    cmd.ExecuteNonQuery()
        '    con.Close()

        '    Sent_Email_lisicor()
        '    Sent_Email_Safety()
        '    'If lblcheckno.Text = "" Or TB_DATE.Text = "" Or tb_time_end.Text = "" Then
        '    '    Response.Write("<Script>")
        '    '    Response.Write("alert('!!! Please Check Data Before Insert   !!!!');")
        '    '    Response.Write("location.href='P_ELECTRICAL.aspx';")
        '    '    Response.Write("</Script>")

        '    '    Exit Sub
        '    'ElseIf lblcheckno.Text <> "" Or TB_DATE.Text <> "" Or tb_time_end.Text <> "" Then
        '    '    Dim message As String = "!!! INSERT DATA OK !!! " + "</br></br>" + "Please Remember NO  " + lblcheckno.Text + "</br></br>" + ""
        '    '    ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "' ); ", True)
        '    '    Exit Sub
        '    'End If
        'End Using


    End Sub
    Protected Sub txtnamesum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnamesum.TextChanged
        CheckName_no()
    End Sub
    Private Sub CheckName_no()
        If txtnamesum.Text = "1" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = False
            ddlcername3.Enabled = False
            ddlcername4.Enabled = False
            ddlcername5.Enabled = False
            ddlcername6.Enabled = False
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "2" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = False
            ddlcername4.Enabled = False
            ddlcername5.Enabled = False
            ddlcername6.Enabled = False
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "3" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = True
            ddlcername4.Enabled = False
            ddlcername5.Enabled = False
            ddlcername6.Enabled = False
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "4" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = True
            ddlcername4.Enabled = True
            ddlcername5.Enabled = False
            ddlcername6.Enabled = False
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "5" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = True
            ddlcername4.Enabled = True
            ddlcername5.Enabled = True
            ddlcername6.Enabled = False
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "6" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = True
            ddlcername4.Enabled = True
            ddlcername5.Enabled = True
            ddlcername6.Enabled = True
            'ddlcername7.Enabled = False
            Exit Sub
        ElseIf txtnamesum.Text = "7" Then
            ddlcername1.Enabled = True
            ddlcername2.Enabled = True
            ddlcername3.Enabled = True
            ddlcername4.Enabled = True
            ddlcername5.Enabled = True
            ddlcername6.Enabled = True
            'ddlcername7.Enabled = True
            Exit Sub
        ElseIf txtnamesum.Text > "7" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Sum Name !!!');", True)
            txtnamesum.Text = ""
            txtnamesum.Focus()
            txtnamesum.ForeColor = Color.Brown
            Exit Sub
        Else
            ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('!!! Please Check Sum Name !!!');", True)
            txtnamesum.Text = ""
            txtnamesum.Focus()
            txtnamesum.ForeColor = Color.Brown
            Exit Sub
        End If
    End Sub
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
        Dim dtAdapter As New SqlDataAdapter
        Dim V_REC_ACC_DATA As DataTable
        Dim ds As New DataSet

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM SAFETY_ELECTRICAL_TEST WHERE  SCNO = '" & txtcheckno.Text.Trim() & "'  "

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
            Response.Write("location.href='P_ELECTRICAL.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        Dim rpt As New ReportDocument()
        rpt.Load(Server.MapPath("Electrical_Work.rpt"))
        rpt.SetDataSource(V_REC_ACC_DATA)
        Me.CrystalReportViewer1.ReportSource = rpt
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        formatType = ExportFormatType.PortableDocFormat
        rpt.ExportToHttpResponse(formatType, Response, True, "THE ELECTRICAL" + "-" + txtcheckno.Text.Trim())
        Response.[End]()
    End Sub
    Private Sub DDL_CERTIFICATE()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT CerName,Name,EmailCer  FROM SAFETY_CERELECTRICAL Where StatusCer = '" & "Cerlicensor" & "'  ORDER BY CerName ASC   ")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddlcername1.DataSource = ds.Tables(0)
                    ddlcername1.DataTextField = "CerName"
                    ddlcername1.DataValueField = "CerName"
                    ddlcername1.DataBind()

                    ddlcername2.DataSource = ds.Tables(0)
                    ddlcername2.DataTextField = "CerName"
                    ddlcername2.DataValueField = "CerName"
                    ddlcername2.DataBind()

                    ddlcername3.DataSource = ds.Tables(0)
                    ddlcername3.DataTextField = "CerName"
                    ddlcername3.DataValueField = "CerName"
                    ddlcername3.DataBind()

                    ddlcername4.DataSource = ds.Tables(0)
                    ddlcername4.DataTextField = "CerName"
                    ddlcername4.DataValueField = "CerName"
                    ddlcername4.DataBind()

                    ddlcername5.DataSource = ds.Tables(0)
                    ddlcername5.DataTextField = "CerName"
                    ddlcername5.DataValueField = "CerName"
                    ddlcername5.DataBind()

                    ddlcername6.DataSource = ds.Tables(0)
                    ddlcername6.DataTextField = "CerName"
                    ddlcername6.DataValueField = "CerName"
                    ddlcername6.DataBind()

                    'ddlcername7.DataSource = ds.Tables(0)
                    'ddlcername7.DataTextField = "CerName"
                    'ddlcername7.DataValueField = "CerName"
                    'ddlcername7.DataBind()
                End Using
            End Using

            ddlcername1.Items.Insert(0, New ListItem("-- Select Cername 1 --", ""))
            ddlcername2.Items.Insert(0, New ListItem("-- Select Cername 2 --", ""))
            ddlcername3.Items.Insert(0, New ListItem("-- Select Cername 3 --", ""))
            ddlcername4.Items.Insert(0, New ListItem("-- Select Cername 4 --", ""))
            ddlcername5.Items.Insert(0, New ListItem("-- Select Cername 5 --", ""))
            ddlcername6.Items.Insert(0, New ListItem("-- Select Cername 6 --", ""))
            'ddlcername7.Items.Insert(0, New ListItem("-- Select Cername 7 --", ""))



        End Using
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
   
#Region "SEND EMAIL"
    Private Sub Sent_Email_ControlWork()

        'Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        'Dim con As New SqlConnection(ConStr_SAFETY)
        'Dim strQuery As String = "SELECT * FROM SAFETY_CERELECTRICAL WHERE" _
        '                       & " StatusCer = @StatusCer"
        'Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@StatusCer", "Cerlicensor")
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = strQuery
        'cmd.Connection = con
        ''Try
        'con.Open()
        'Dim sdr As SqlDataReader = cmd.ExecuteReader()
        'While sdr.Read()
        '    CK_EMAIL = sdr.Item("EmailCer").ToString()
        '    CK_NAME = sdr.Item("CerName").ToString()
        'End While

        ''Get Email Host area
        'Using db As New DataPermitDataContext
        '    Dim emailhost As String
        '    Dim chkmailhost = From h in db.SAFETY_AREAs
        '            Where h.AREADIV = ddlareadiv.SelectedItem.Text And h.AREADEP = ddlareadep.SelectedItem.Text
        '            Select h
                   
        '    For Each n In chkmailhost

        '        emailhost = n.AREAEMAIL

        '    Next
        'End Using


        If tb_emailcontrol_company.Value.Trim() <> "" Then

            BindGridview()
            GridView1.Visible = True
            Dim Msg As New MailMessage()


            Dim fromMail As New MailAddress("WORK_PERMIT@rist.local")
            ' Sender e-mail address.
            Msg.From = fromMail
            ' Recipient e-mail address.
            Msg.[To].Add(New MailAddress(tb_emailcontrol_company.Value.Trim()))
            ' Subject of e-mail
            Dim bb, VIP_REMARK As String
            Msg.SubjectEncoding = System.Text.Encoding.UTF8

            Msg.BodyEncoding = System.Text.Encoding.UTF8
            
            bb = "http://10.29.1.39/PERMITONLINE/P_ELECTRIC_CTRL_APPROVE.aspx?scfeno=" & Trim(lblcheckno.Text) & "&PSTATUS=" & "Cerlicensor" & """"
            VIP_REMARK = " **** Special Case Work ***** "
            Msg.Subject = "WORK PERMIT ONLINE APPROVE (ELECTRICAL WORK) "
            Msg.Body += "Please Check Below Data <br/><br/>"
            Msg.Body = "<p style='font-family:Tahoma; font-size:18'>" & "To :" + tb_name_control.Value.Trim() & "</p>" + "<br/><br/>"
            Msg.Body += " You have Work Permt  waiting for your approve " + "<br/>"
            Msg.Body += " Please check your remain Data Follow this " + "<br/><br/>"
            Msg.Body += "<a href=" + bb + ">WORK PERMIT ONLINE APPROVE</a> " + "<br/><br/>"

            Msg.Body += "<p style='font-family:calibri; color:Red; font-size:18'>" & VIP_REMARK & "</p>" + "<br/><br/>"

            Msg.Body += GetGridviewData(GridView1)


            Msg.Body += "<br/>THANK YOU<br/>"

            Msg.Body += "WORK PERMIT ONLINE SYSTEM"

            Msg.IsBodyHtml = True
            'Msg.SubjectEncoding = System.Text.Encoding.GetEncoding("tis-620")
            Dim sSmtpServer As String = ""
            sSmtpServer = "10.29.1.240"
            Dim a As New SmtpClient()
            a.Host = sSmtpServer
            a.Send(Msg)

            GridView1.Visible = True

        End If

    End Sub
    Private Sub Sent_Email_Safety()
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

        Dim bb, VIP_REMARK As String
        Msg.SubjectEncoding = System.Text.Encoding.UTF8

        Msg.BodyEncoding = System.Text.Encoding.UTF8

        bb = "http://10.29.1.39/PERMITONLINE/P_Electrical_Apporve.aspx?op=" & Trim(lblcheckno.Text) & "&Email=" & Trim(VEMAIL) & "&PSTATUS=" & "CerSAFETY" & """"
        VIP_REMARK = " **** Special Case Work ***** "
        Msg.Subject = "WORK PERMIT ONLINE APPROVE (ELECTRICAL WORK) "
        Msg.Body += "Please Check Below Data <br/><br/>"
        Msg.Body = "<p style='font-family:calibri; font-size:18'>" & "To :" + VNAME & "</p>" + "<br/><br/>"
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

    End Sub
#End Region
#Region "BindGridview"
    Protected Sub BindGridview()

        Using db As New DBELECTRICALDataContext()
            GridView1.DataSource = From e In db.SAFETY_ELECTRICAL_TESTs
                                   Where e.SCNO = lblcheckno.Text
                Select New With {e.SCNO, e.SCNAME,e.SCWORKDIV,e.SCWORKDETAIL,e.SCWORKDATE,e.SCWORKDATEFROM,e.SCWORKDATETO,e.SCNAMECONTROL,e.SCEMAILCONTROL,e.SCWORKAREA,e.SCFLOOR}
               
            GridView1.DataBind()
        End Using
        'Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand("select * from SAFETY_ELECTRICAL WHERE SCNO =  '" & lblcheckno.Text & "'")

        '        Using sda As New SqlDataAdapter()
        '            cmd.Connection = con
        '            sda.SelectCommand = cmd
        '            Using dt As New DataTable()
        '                sda.Fill(dt)
        '                GridView1.DataSource = dt
        '                GridView1.DataBind()
        '            End Using
        '        End Using
        '    End Using
        'End Using

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

    Private Sub CHK_Equipment_E1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHK_Equipment_E1.SelectedIndexChanged
        if CHK_Equipment_E1.SelectedItem.Text = "NG" Then
                txtEquipment_E1_Detail.Enabled = True
            Else 
                txtEquipment_E1_Detail.Enabled = False
        End If
    End Sub

    Private Sub CHK_Equipment_E2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHK_Equipment_E2.SelectedIndexChanged
        if CHK_Equipment_E2.SelectedItem.Text = "NG" Then
            txtEquipment_E2_Detail.Enabled = True
        Else 
            txtEquipment_E2_Detail.Enabled = False
        End If
    End Sub

    Private Sub CHK_Equipment_E3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHK_Equipment_E3.SelectedIndexChanged
        if CHK_Equipment_E3.SelectedItem.Text = "NG" Then
            txtEquipment_E3_Detail.Enabled = True
        Else 
            txtEquipment_E3_Detail.Enabled = False
        End If
    End Sub

    Private Sub CHK_Equipment_E4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHK_Equipment_E4.SelectedIndexChanged
        if CHK_Equipment_E4.SelectedItem.Text = "NG" Then
            txtEquipment_E4_Detail.Enabled = True
        Else 
            txtEquipment_E4_Detail.Enabled = False
        End If
    End Sub

    Private Sub CHK_Equipment_E5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHK_Equipment_E5.SelectedIndexChanged
        if CHK_Equipment_E5.SelectedItem.Text = "NG" Then
            txtEquipment_E5_Detail.Enabled = True
        Else 
            txtEquipment_E5_Detail.Enabled = False
        End If
    End Sub





#End Region
End Class
