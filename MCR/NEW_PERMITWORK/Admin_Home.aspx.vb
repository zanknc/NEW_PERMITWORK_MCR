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
Partial Class Admin_Home
    Inherits System.Web.UI.Page
    Dim ipaddress, SESSION_NO, EMP_NO, EMP_NAME, EMP_PASS As String

    Dim Getdataname, GetDivison As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("EMPNO") = "" Then
            Response.Redirect("P_Admin_Login.aspx")
            Response.End()
            Response.Clear()
            Exit Sub
        Else
            EMP_NO = Session("EMPNO")
            EMP_PASS = Session("EMPPASS")
            ChecKUsername()
            Me.lblname.Text = "Welcome To :" & Getdataname
            Me.lbldiv.Text = "Division :" & GetDivison
            'Me.lbldivfix.Text = " | " & Getdivfix
        End If



        Fix_ipadrees()

    End Sub

    Protected Sub Fix_ipadrees()
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        Session("IP_ADDRESS") = ipaddress

        lblipaddress.Text = ipaddress
    End Sub
    Protected Sub ChecKUsername()

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim cmd As New SqlCommand("SAFETY_PERMIT_LOGIN", con)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@VP_LOGIN", "SELECT")
        cmd.Parameters.AddWithValue("@LOGIN_EMPNO", EMP_NO)
        cmd.Parameters.AddWithValue("@LOGIN_EMPPASS", EMP_PASS)

        con.Open()
        Using reader = cmd.ExecuteReader()
            If reader.Read() Then
                Getdataname = reader.Item("LOGIN_EMPNAME")
                GetDivison = reader.Item("LOGIN_DIVISION").ToString()
            End If

        End Using

    End Sub
End Class




