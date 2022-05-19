Imports System.Data.SqlClient
Imports System.Data
Partial Class Admin_HostArea
    Inherits System.Web.UI.Page

    Dim ipaddress, CHECKDATA1, CHECKDATA2, CHECKDATA3, CHECKDATA4, CHECKDATA5 As String
    Dim CHECK_CODE, CHECK_NO, VIPNO, VIPCODE As String

    Dim SESSION_NO, EMP_NO, EMP_NAME, EMP_PASS, AABNO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("EMPNO") = "" Then
            Response.Redirect("P_Admin_Login.aspx")
            Response.End()
            Response.Clear()
            Exit Sub
        End If
        SESSION_NO = Session("VPNO")
        EMP_NO = Session("EMPNO")
        EMP_PASS = Session("EMPPASS")
        EMP_NAME = Session("EMPNAME")


        Fix_ipadrees()
        If Not Me.IsPostBack Then
            ChecKUsername()
            SFT_DIVISONNAMEWORK()
        End If
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
                lblname.Text = reader.Item("LOGIN_EMPNAME")
                lbldiv.Text = reader.Item("LOGIN_DIVISION").ToString()
                'Getdivfix = reader.Item("EMPFIXCODE").ToString()
            End If

        End Using

    End Sub
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
                    ddlareadiv.DataSource = dt
                    ddlareadiv.DataTextField = "AREADIV"
                    ddlareadiv.DataValueField = "AREADIV"
                    ddlareadiv.DataBind()
                End Using
            End Using
        End Using
        ddlareadiv.Items.Insert(0, New ListItem("--Select DivisionName--", "0"))
        DIVION_DATA()
    End Sub
    Private Sub DIVION_DATA()
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(ConStr_SAFETY)
            Using cmd As New SqlCommand("SELECT AREADIV,AREADEP   FROM SAFETY_AREA where AREADIV = '" + ddlareadiv.SelectedItem.Text + "'  GROUP BY AREADEP,AREADIV  Order by AREADEP asc")
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
        ddlareadep.Items.Insert(0, New ListItem("--Select DivisionName--", "0"))
    End Sub
    Protected Sub ddlareadiv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlareadiv.SelectedIndexChanged
        DIVION_DATA()
    End Sub
#End Region


    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        CLEARDATA()
        SeaechDATA()
        txtdivision.Text = ddlareadiv.SelectedItem.Value
        txtdepart.Text = ddlareadep.SelectedItem.Value
        btnsave.Visible = True
        'btnsearch.Visible = False
    End Sub
    Private Sub SeaechDATA()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT *  FROM SAFETY_AREA where AREADEP = '" + ddlareadep.SelectedItem.Text + "' and AREADIV = '" + ddlareadiv.SelectedItem.Text + "'")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    GRDHOSTAREA.DataSource = ds
                    GRDHOSTAREA.DataBind()
                    con.Close()
                End Using
            End Using
        End Using
    End Sub

    Protected Sub GRDHOSTAREA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRDHOSTAREA.SelectedIndexChanged
        ddlareadep.SelectedItem.Value = GRDHOSTAREA.DataKeys(GRDHOSTAREA.SelectedRow.RowIndex).Value.ToString()
        btnsave.Visible = False
        btnupdate.Visible = True
        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT *  FROM SAFETY_AREA where AREANO = '" & ddlareadep.SelectedItem.Value & "'"
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@HW_NO", con_SAFETY)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()

            txtdivision.Text = sdr("AREADIV").ToString()
            txtdepart.Text = sdr("AREADEP").ToString()
            txtname.Text = sdr("AREAEMPNAME").ToString()
            txtempcode.Text = sdr("AREAEMPCODE").ToString()
            txtemail.Text = sdr("AREAEMAIL").ToString()
            AABNO = sdr("AREANO").ToString()
        End While

    End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GRDHOSTAREA.PageIndex = e.NewPageIndex
        SeaechDATA()
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)

            Dim sqlinsert As StringBuilder
            sqlinsert = New StringBuilder
            sqlinsert.Append("INSERT INTO SAFETY_AREA")
            sqlinsert.Append("(AREADIV,AREADEP,AREAEMPCODE,AREAEMPNAME,AREAEMAIL,AREADATAIL )")
            sqlinsert.Append(" VALUES ")
            sqlinsert.Append("(@AREADIV,@AREADEP,@AREAEMPCODE,@AREAEMPNAME,@AREAEMAIL,@AREADATAIL )")
            Using cmd As New SqlCommand(sqlinsert.ToString(), con)
                cmd.Parameters.AddWithValue("@AREADIV", txtdivision.Text.Trim())
                cmd.Parameters.AddWithValue("@AREADEP", txtdepart.Text.Trim())
                cmd.Parameters.AddWithValue("@AREAEMPCODE", UCase(Trim(txtempcode.Text)))
                cmd.Parameters.AddWithValue("@AREAEMPNAME", UCase(Trim(txtname.Text)))
                cmd.Parameters.AddWithValue("@AREAEMAIL", txtemail.Text.Trim())
                cmd.Parameters.AddWithValue("@AREADATAIL", txtremark.Text.Trim())
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If txtdivision.Text <> "" And txtdepart.Text <> "" Then
                    Response.Write("<Script>")
                    Response.Write("alert('!!! Insert Data OK NA JA  !!!!');")
                    Response.Write("location.href='Admin_HostArea.aspx';")
                    Response.Write("</Script>")
                ElseIf txtdepart.Text = "" And txtdivision.Text = "" Then
                    Response.Write("<Script>")
                    Response.Write("alert('!!! Please Check Data !!!!');")
                    Response.Write("location.href='Admin_HostArea.aspx';")
                    Response.Write("</Script>")
                End If

            End Using
        End Using
    End Sub

    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)

            Dim sqlupdate As StringBuilder
            sqlupdate = New StringBuilder
            sqlupdate.Append(" UPDATE SAFETY_AREA ")
            sqlupdate.Append(" SET AREADIV=@AREADIV ")
            sqlupdate.Append(" ,AREADEP=@AREADEP ")
            sqlupdate.Append(" ,AREAEMPCODE=@AREAEMPCODE ")
            sqlupdate.Append(" ,AREAEMPNAME=@AREAEMPNAME ")
            sqlupdate.Append(" ,AREAEMAIL=@AREAEMAIL ")
            sqlupdate.Append(" ,AREADATAIL =@AREADATAIL ")
            sqlupdate.Append(" Where AREANO = '" & AABNO & "' ")
            Using cmd As New SqlCommand(sqlupdate.ToString(), con)
                cmd.Parameters.AddWithValue("@AREADIV", txtdivision.Text.Trim())
                cmd.Parameters.AddWithValue("@AREADEP", txtdepart.Text.Trim())
                cmd.Parameters.AddWithValue("@AREAEMPCODE", UCase(Trim(txtempcode.Text)))
                cmd.Parameters.AddWithValue("@AREAEMPNAME", UCase(Trim(txtname.Text)))
                cmd.Parameters.AddWithValue("@AREAEMAIL", txtemail.Text.Trim())
                cmd.Parameters.AddWithValue("@AREADATAIL", txtremark.Text.Trim())
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If txtdivision.Text <> "" And txtdepart.Text <> "" Then
                    Response.Write("<Script>")
                    Response.Write("alert('!!! Update Data OK NA JA  !!!!');")
                    Response.Write("location.href='Admin_HostArea.aspx';")
                    Response.Write("</Script>")
                ElseIf txtdepart.Text = "" And txtdivision.Text = "" Then
                    Response.Write("<Script>")
                    Response.Write("alert('!!! Please Check Data !!!!');")
                    Response.Write("location.href='Admin_HostArea.aspx';")
                    Response.Write("</Script>")
                End If
            End Using
        End Using
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        CLEARDATA()
    End Sub

    Private Sub CLEARDATA()
        txtdivision.Text = ""
        txtdepart.Text = ""
        txtemail.Text = ""
        txtname.Text = ""
        txtremark.Text = ""
        txtempcode.Text = ""

    End Sub

    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim Id As Integer = Convert.ToInt32(GRDHOSTAREA.DataKeys(e.RowIndex).Values(0))

        Using db As New DataPermitDataContext()
            Dim d As SAFETY_AREA = (From c In db.SAFETY_AREAs Where c.AREANO = Id Select c).FirstOrDefault()
            db.SAFETY_AREAs.DeleteOnSubmit(d)
            db.SubmitChanges()
        End Using
        SeaechDATA
    End Sub
    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowIndex <> GRDHOSTAREA.EditIndex Then
            TryCast(e.Row.Cells(1).Controls(0), LinkButton).Attributes("onclick") = "return confirm('Do you want to delete this row?');"
        End If
    End Sub
End Class

