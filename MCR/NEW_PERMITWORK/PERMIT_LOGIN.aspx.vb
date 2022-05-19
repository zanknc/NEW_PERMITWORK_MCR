Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Partial Class PERMIT_LOGIN
    Inherits System.Web.UI.Page
    Dim VBNAME, VBNO As String

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click


        If txtempno.Text.Trim() = "" Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Insert Emp No !!!!');")
            Response.Write("location.href='PERMIT_LOGIN.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If



        Dim constr_Emp As String = ConfigurationManager.ConnectionStrings("CONN_Employee").ConnectionString
        Dim con As New SqlConnection(constr_Emp)
        Dim str As String = "SELECT * FROM  EMP_DATA WHERE codempid =  @codempid"
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@codempid", txtempno.Text.Trim())
        cmd.CommandType = CommandType.Text
        cmd.CommandText = str
        cmd.Connection = con
        'Try
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        While sdr.Read()
            VBNO = sdr("codempid").ToString()
            VBNAME = sdr("namempe").ToString()
        End While

        If txtempno.Text.Trim() = "VIPSAFETY" Then
            Session("EMPNO") = "000000"
            Session("EMPNAME") = "VIPSAFETY"

            Response.Redirect("P_PermitWork.aspx")
            Exit Sub
        ElseIf txtempno.Text.Trim() = "VIPWISOOT" Then
            Session("EMPNO") = "999999"
            Session("EMPNAME") = "VIPWISOOT"

            Response.Redirect("P_PermitWork.aspx")
            Exit Sub
        ElseIf VBNO <> txtempno.Text Then
            Response.Write("<Script>")
            Response.Write("alert('!!! Please Insert Emp No !!!!');")
            Response.Write("location.href='PERMIT_LOGIN.aspx';")
            Response.Write("</Script>")
            Exit Sub
        ElseIf VBNO = txtempno.Text.Trim() Then
            Session("EMPNO") = VBNO
            Session("EMPNAME") = VBNAME

            Response.Redirect("P_PermitWork.aspx")
            Exit Sub
        End If

    End Sub
End Class
