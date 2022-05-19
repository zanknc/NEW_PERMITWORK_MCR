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
Imports System.Web.Services
Imports System.Diagnostics
Partial Class Electrical_Apporve
    Inherits System.Web.UI.Page
    Dim OPNO As String
    Dim NAME, TITLENAME, aa As String
    Dim PERMIT, VIPADDRESS, CheckOpea, SAFETYNAME As String
    Dim DDATEDTART, TIMESTART, TIMEEND, EXTRASTART, EXTRAEND As String
    Dim CER_APPNAME, CER_APPEMAIL, CER_APPDATE, CER_SAFETYNAME, CER_SAFETYEMAIL, CER_SAFETYDATE As String
    Dim Email As String = "WORK_PERMIT@rist.local"
    Dim SNAME, SEmail, SSTATUS, PERMITCHECK, SAFETYEMAIL, SAFETYTITLE As String
    Dim CHKExtimeFrom, CHKExtimeTo, ExtimeFrom, ExtimeTo As String
    Dim STAMP_APP, STAMP_APPEMAIL, STAMP_APPSTATUS, STAMP_Supervisor, STAMP_SuperEMAIL, STAMP_SuperStatus As String

    Dim Equipment_E1, Equipment_E2, Equipment_E3, Equipment_E4, Equipment_E5, CHECKAREAR As New ListItem() ' ListItemName
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        VIPADDRESS = ipaddress

        Session("IP_ADDRESS") = ipaddress


        OPNO = Request.QueryString("op")
        PERMIT = Request.QueryString("PSTATUS")


        Session("OPNO") = Request.QueryString("op")
        Session("PERMIT") = Request.QueryString("PSTATUS")

        lb_opno.Text = OPNO
        Label1.Text = Request.QueryString("op")
        aa = Session.Timeout.ToString

        Session("VPNO") = lb_opno.Text

        If PERMIT = "Cerlicensor" Then
            lblheadname.Text = "Warrantor APPORVE"
        ElseIf PERMIT = "CerSAFETY" Then
            lblheadname.Text = "SAFETY APPORVE"
        End If

        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from SAFETY_ELECTRICAL WHERE SCNO =  '" & lb_opno.Text & "'")

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
    Private Sub CHECKSTAMP()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim cmd As New SqlCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SAFETY_ELECTRICAL_SELECT"

        cmd.Parameters.AddWithValue("@SCNO", lb_opno.Text)
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()


            CER_APPNAME = sdr("SCAPPNAME").ToString()
            CER_APPEMAIL = sdr("SCEMAILAPPNAME").ToString()
            CER_APPDATE = sdr("SCCREATEDATE").ToString()

            CER_SAFETYNAME = sdr("SCSAFETYNAME").ToString()
            CER_SAFETYEMAIL = sdr.Item("SCSAFETYEMAILNAME").ToString()
            CER_SAFETYDATE = sdr.Item("SCSAFETYDATE").ToString()
        End While

    End Sub
    Private Sub CHECKIPAPPROVE()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM  SAFETY_CERELECTRICAL WHERE StatusCer  =  '" & "Cerlicensor" & "'"
        '_ & " AREADEP = @AREADEP"
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@AREADEP", ddlareadep.SelectedItem.Text)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        While sdr.Read()
            TITLENAME = sdr("CerTitle").ToString()
            NAME = sdr("CerName").ToString()
            Email = sdr("EmailCer").ToString()
        End While
    End Sub


    Private Sub SAFETYAPPROVE()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM  SAFETY_APPROVEEMAIL WHERE SAFETYEIPADDRESS =  '" & VIPADDRESS & "'"
        '_ & " AREADEP = @AREADEP"
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@AREADEP", ddlareadep.SelectedItem.Text)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        While sdr.Read()
            SAFETYTITLE = sdr("SAFETYTITLENAME").ToString()
            SAFETYNAME = sdr("SAFETYNAMETH").ToString()
            SAFETYEMAIL = sdr("SAFETYEMAIL").ToString()
        End While
    End Sub



    Protected Sub btnapp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnapp.Click
        CHECKSTAMP()
        CHECKIPAPPROVE()
        SAFETYAPPROVE()
        If CER_APPNAME = "WAITING APPROVE" And PERMIT = "Cerlicensor" Then

            If CER_APPNAME <> "WAITING APPROVE" Then
                Response.Write("<Script>")
                Response.Write("alert('!!! PERMIT TO WORK ALREADY STAMP OK   !!!');")
                Response.Write("location.href='P_ELECTRICAL.aspx';")
                Response.Write("</Script>")
                Exit Sub
            End If

            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Dim cmd As New SqlCommand("UPDATE SAFETY_ELECTRICAL SET SCTITLEAPPNAME =@SCTITLEAPPNAME , SCAPPNAME = @SCAPPNAME, SCEMAILAPPNAME = @SCEMAILAPPNAME, " _
            & "SCCREATEDATE = @SCCREATEDATE  WHERE SCNO = @SCNO")

            cmd.Parameters.AddWithValue("@SCTITLEAPPNAME", Trim(TITLENAME))
            cmd.Parameters.AddWithValue("@SCAPPNAME", Trim(NAME))
            cmd.Parameters.AddWithValue("@SCEMAILAPPNAME", Trim(Email))
            cmd.Parameters.AddWithValue("@SCCREATEDATE", DateTime.Now.ToString())
            cmd.Parameters.AddWithValue("@SCNO", lb_opno.Text.Trim())

            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Response.Write("<Script>")
            Response.Write("alert('!!! Electrical Work  STAMP OK   !!!');")
            Response.Write("location.href='P_ELECTRICAL.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        If CER_SAFETYNAME = "WAITING APPROVE" And PERMIT = "CerSAFETY" Then
            If CER_SAFETYNAME <> "WAITING APPROVE" Then
                Response.Write("<Script>")
                Response.Write("alert('!!! PERMIT TO WORK ALREADY STAMP OK   !!!');")
                Response.Write("location.href='P_ELECTRICAL.aspx';")
                Response.Write("</Script>")
                Exit Sub
            End If



            Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Dim con As New SqlConnection(ConStr_SAFETY)
            Dim cmd As New SqlCommand("UPDATE SAFETY_ELECTRICAL SET SCTITLESAFETYNAME = @SCTITLESAFETYNAME ,  SCSAFETYNAME = @SCSAFETYNAME, SCSAFETYEMAILNAME = @SCSAFETYEMAILNAME, " _
            & "SCSAFETYDATE = @SCSAFETYDATE  WHERE SCNO = @SCNO")

            cmd.Parameters.AddWithValue("@SCTITLESAFETYNAME", Trim(SAFETYTITLE))
            cmd.Parameters.AddWithValue("@SCSAFETYNAME", Trim(SAFETYNAME))
            cmd.Parameters.AddWithValue("@SCSAFETYEMAILNAME", Trim(SAFETYEMAIL))
            cmd.Parameters.AddWithValue("@SCSAFETYDATE", DateTime.Now.ToString())
            cmd.Parameters.AddWithValue("@SCNO", lb_opno.Text.Trim())

            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Response.Write("<Script>")
            Response.Write("alert('!!! Electrical Work  STAMP OK   !!!');")
            Response.Write("location.href='P_ELECTRICAL.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If
    End Sub

End Class
