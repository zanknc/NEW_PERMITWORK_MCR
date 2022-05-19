Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web
Imports System.Drawing
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Math
Imports System.IO
Imports System.IO.MemoryStream
Imports System.Globalization
Imports System.IO.Stream
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Web.Services
Imports System.Diagnostics
Partial Class P_APPROVE_DATA
    Inherits System.Web.UI.Page
    Dim DATECONTROL, DATESAFETY, APPON, DATEAPPROVE As String

    Dim PERMIT_CONTROL, PERMIT_SAFETY, PERMIT_APPROVE As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        SEARCHDATA()
    End Sub
    Private Sub SEARCHDATA()
        If txtworkno.Text = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Insert Data   !!!!');")
            Response.Write("location.href='P_APPROVE_DATA.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)

        Dim strQuery As String = "SELECT * FROM SAFETY_PERMITWORK WHERE SF_NO = @SF_NO "
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@SF_NO", txtworkno.Text.Trim())
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()

            APPON = sdr.Item("SF_NO").ToString()
            txtcontrolname.Text = sdr.Item("STAMP_Supervisor").ToString()
            txtcontrolstatus.Text = sdr.Item("STAMP_Supervisor_Status").ToString()
            txtcontrolemail.Text = sdr.Item("STAMP_Supervisor_EMAIL").ToString()


            txtsafetyname.Text = sdr.Item("STAMP_Recipient_Know").ToString()
            txtsafetystatus.Text = sdr.Item("STAMP_Recipient_Know_Status").ToString()
            txtsafetyemail.Text = sdr.Item("STAMP_Recipient_Know_EMAIL").ToString()


            txthostname.Text = sdr.Item("STAMP_Approvers").ToString()
            txthoststatus.Text = sdr.Item("STAMP_Approvers_Status").ToString()
            txthostemail.Text = sdr.Item("STAMP_Approvers_EMAIL").ToString()

            PERMIT_CONTROL = sdr.Item("PERMIT_Supervisor").ToString()
            PERMIT_SAFETY = sdr.Item("PERMIT_Recipient_Know").ToString()
            PERMIT_APPROVE = sdr.Item("PERMIT_Approvers").ToString()

            Try
                DATECONTROL = sdr.Item("STAMP_Supervisor_Date").ToString()
                txtcontroldate.Text = DateTime.Parse(DATECONTROL).ToString("yyyy-MM-dd")

                DATESAFETY = sdr.Item("STAMP_Recipient_Know_Date").ToString()
                txtsafetydate.Text = DateTime.Parse(DATESAFETY).ToString("yyyy-MM-dd")

                DATEAPPROVE = sdr.Item("STAMP_Approvers_Date").ToString()
                txttmeapp.Text = DateTime.Parse(DATEAPPROVE).ToString("yyyy-MM-dd")
            Catch ex As Exception

            End Try


            Exit Sub
        End While
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'SEARCHDATA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Using cmd As New SqlCommand("APPROVE_MANUAL")
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@SF_APPROVE", "UPDATE")

            If txtcontrolname.Text <> "" And txtcontrolemail.Text <> "" Then
                cmd.Parameters.AddWithValue("@STAMP_Supervisor", txtcontrolname.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_EMAIL", txtcontrolemail.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Supervisor_Status", "STAMP OK")
            End If

            If txtsafetyname.Text <> "" And txtsafetyemail.Text <> "" Then
                cmd.Parameters.AddWithValue("@STAMP_Recipient_Know", txtsafetyname.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Recipient_Know_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Recipient_Know_EMAIL", txtsafetyemail.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Recipient_Know_Status", "STAMP OK")
            End If
           
            If txthostname.Text <> "" And txthostemail.Text <> "" Then
                cmd.Parameters.AddWithValue("@STAMP_Approvers", txthostname.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Approvers_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@STAMP_Approvers_EMAIL", txthostemail.Text.Trim())
                cmd.Parameters.AddWithValue("@STAMP_Approvers_Status", "STAMP OK")
            End If




            If PERMIT_CONTROL <> "" Then
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor", txtcontrolname.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_EMAIL", txtcontrolemail.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Supervisor_Status", "STAMP OK")
            End If

            If PERMIT_SAFETY <> "" Then
                cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know", txtsafetyname.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know_EMAIL", txtsafetyemail.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Recipient_Know_Status", "STAMP OK")
            End If


            If PERMIT_APPROVE <> "" Then
                cmd.Parameters.AddWithValue("@PERMIT_Approvers", txthostname.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Approvers_Date", DateTime.Now.ToString())
                cmd.Parameters.AddWithValue("@PERMIT_Approvers_EMAIL", txthostemail.Text)
                cmd.Parameters.AddWithValue("@PERMIT_Approvers_Status", "STAMP OK")
            End If


            cmd.Parameters.AddWithValue("@SF_NO", txtworkno.Text.Trim())
            cmd.Connection = con
            con.Open()

            Response.Write("<Script>")
            Response.Write("alert('!!! Approve Data OK   !!!!');")
            Response.Write("location.href='P_APPROVE_DATA.aspx';")
            Response.Write("</Script>")
            cmd.ExecuteNonQuery()
            con.Close()
        End Using


    End Sub
End Class
