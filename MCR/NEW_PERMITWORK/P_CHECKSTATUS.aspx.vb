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
Partial Class P_CHECKSTATUS
    Inherits System.Web.UI.Page
    Dim SESSION_NO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMPNO") = "" Then
            Response.Redirect("PERMIT_LOGIN.aspx")
            Response.End()
            Response.Clear()
            Exit Sub
        End If

        SESSION_NO = Session("VPNO")
        Label2.Text = Session("EMPNO")
        Label3.Text = Session("EMPNAME")
    End Sub
#Region "AUTO VENDORNAME"
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
        Public Shared Function SearchSFNO(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = ConfigurationManager _
             .ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandText = "select TOP(20) SF_NO from SAFETY_PERMITWORK where SF_NO like @SearchText + '%' ORDER BY SF_NO DESC "

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
            Response.Write("<Script>")
            Response.Write("alert('!!!  Please Insert No    !!!!');")
            Response.Write("location.href='P_CHECKSTATUS.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT SF_NO,STAMP_Supervisor,STAMP_Supervisor_Status,STAMP_Recipient_Know,STAMP_Recipient_Know_Status,STAMP_Approvers,STAMP_Approvers_Status FROM SAFETY_PERMITWORK where SF_NO = '" & txtcheckno.Text & "'")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GVVIEWW.DataSource = dt
                        GVVIEWW.DataBind()
                    End Using
                End Using
            End Using

            Using cmd As New SqlCommand("SELECT SF_NO,PERMIT_Supervisor,PERMIT_Supervisor_Status,PERMIT_Approvers,PERMIT_Approvers_Status,PERMIT_Recipient_Know,PERMIT_Recipient_Know_Status FROM SAFETY_PERMITWORK where SF_NO = '" & txtcheckno.Text & "'")
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
        Label1.Visible = True
    End Sub
    'Protected Sub btncheckno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheckno.Click
    '    If txtcheckno.Text.Trim() = "" Then
    '        Response.Write("<Script>")
    '        Response.Write("alert('!!!  Please Insert No    !!!!');")
    '        Response.Write("location.href='P_CHECKSTATUS.aspx';")
    '        Response.Write("</Script>")
    '        Exit Sub
    '    End If
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand("SELECT SF_NO,STAMP_Supervisor,STAMP_Supervisor_Status,STAMP_Recipient_Know,STAMP_Recipient_Know_Status,STAMP_Approvers,STAMP_Approvers_Status FROM SAFETY_PERMITWORK where SF_NO = '" & txtcheckno.Text & "'")
    '            Using sda As New SqlDataAdapter()
    '                cmd.Connection = con
    '                sda.SelectCommand = cmd
    '                Using dt As New DataTable()
    '                    sda.Fill(dt)
    '                    GVVIEWW.DataSource = dt
    '                    GVVIEWW.DataBind()
    '                End Using
    '            End Using
    '        End Using

    '        Using cmd As New SqlCommand("SELECT SF_NO,PERMIT_Supervisor,PERMIT_Supervisor_Status,PERMIT_Approvers,PERMIT_Approvers_Status,PERMIT_Recipient_Know,PERMIT_Recipient_Know_Status FROM SAFETY_PERMITWORK where SF_NO = '" & txtcheckno.Text & "'")
    '            Using sda As New SqlDataAdapter()
    '                cmd.Connection = con
    '                sda.SelectCommand = cmd
    '                Using dt As New DataTable()
    '                    sda.Fill(dt)
    '                    GridView1.DataSource = dt
    '                    GridView1.DataBind()
    '                End Using
    '            End Using
    '        End Using
    '    End Using
    '    Label1.Visible = True
    'End Sub
End Class
