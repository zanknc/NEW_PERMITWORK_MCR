Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Data.Sql
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Net
Imports System.Net.IPHostEntry
Imports System.Text
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Linq
Imports System.Math
Imports System.IO.MemoryStream
Imports System.Globalization
Imports System.IO.Stream
Partial Class P_Admin_Login
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim strConnString, strSQL As String
    Dim OPCODE, OPPASS, OPSTATUS As String
    Dim reader As SqlDataReader


    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click


        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim cmd As New SqlCommand("SAFETY_PERMIT_LOGIN", con)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@VP_LOGIN", "SELECT")
            cmd.Parameters.AddWithValue("@LOGIN_EMPNO", txtUsername.Text)
            cmd.Parameters.AddWithValue("@LOGIN_EMPPASS", txtPassword.Text)

            con.Open()
            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    OPCODE = reader.Item("LOGIN_EMPNO")
                    OPPASS = reader.Item("LOGIN_EMPPASS")
                    OPSTATUS = reader.Item("LOGIN_REMARK")
                End If

                If OPCODE = txtUsername.Text.Trim() And OPPASS = txtPassword.Text.Trim() Then


                    If OPSTATUS = "ADMIN" Then
                    Session("EMPNO") = Me.txtUsername.Text
                    Session("EMPPASS") = Me.txtPassword.Text
                    Response.Redirect("Admin_Home.aspx")
                    End If

                Else
                    Me.lblStatus.Visible = True
                    Me.lblStatus.Text = "Username/Password is wrong."
                    Me.lblStatus.ForeColor = Color.Red
                End If
            End Using

    End Sub
End Class
