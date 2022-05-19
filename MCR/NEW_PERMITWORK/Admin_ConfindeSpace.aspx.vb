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
Partial Class Admin_ConfindeSpace
    Inherits System.Web.UI.Page

    Dim ipaddress, CHECKDATA1, CHECKDATA2, CHECKDATA3, CHECKDATA4, CHECKDATA5 As String
    Dim CHECK_CODE, CHECK_NO, VIPNO, VIPCODE As String

    Dim SESSION_NO, EMP_NO, EMP_NAME, EMP_PASS As String
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
            GGVVIEW()
            CHECKNO()
            ChecKUsername()
        End If
        CHECKNO()
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

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Chk1.Checked = True Then
            CHECKDATA1 = "ผู้อนุญาต"
        Else
            CHECKDATA1 = ""
        End If
        If chk2.Checked = True Then
            CHECKDATA2 = "ผู้ควบคุม"
        Else
            CHECKDATA2 = ""
        End If
        If chk3.Checked = True Then
            CHECKDATA3 = "ผู้ช่วยเหลือ"
        Else
            CHECKDATA3 = ""
        End If
        If chk4.Checked = True Then
            CHECKDATA4 = "ผู้ปฎิบัติการ"
        Else
            CHECKDATA4 = ""
        End If

        CODE_Function()
        Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim contentType As String = FileUpload1.PostedFile.ContentType
        Using fs As Stream = FileUpload1.PostedFile.InputStream
            Using br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(DirectCast(fs.Length, Long))
                Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
                Using con As New SqlConnection(constr)
                    Dim query As String = "insert into SAFETY_CERTIFICATE values (@CerCode,@Certitle,@CerName,@Name,@NFunction1,@NFunction2,@NFunction3,@NFunction4,@ContentType, @Data , @EmailCer,@TelCer,@StatusCer,@Detail ,@IpAddress,@AddBy,@Createdate)"

                    Using cmd As New SqlCommand(query)
                        cmd.Connection = con
                        cmd.Parameters.Add("@CerCode", SqlDbType.VarChar).Value = lblcercode.Text.Trim()
                        cmd.Parameters.Add("@Certitle", SqlDbType.VarChar).Value = ddlnametitle.SelectedValue
                        cmd.Parameters.Add("@CerName", SqlDbType.VarChar).Value = txtname.Text
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename
                        cmd.Parameters.Add("@NFunction1", SqlDbType.Char).Value = CHECKDATA1
                        cmd.Parameters.Add("@NFunction2", SqlDbType.Char).Value = CHECKDATA2
                        cmd.Parameters.Add("@NFunction3", SqlDbType.Char).Value = CHECKDATA3
                        cmd.Parameters.Add("@NFunction4", SqlDbType.Char).Value = CHECKDATA4
                        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType
                        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
                        cmd.Parameters.Add("@EmailCer", SqlDbType.VarChar).Value = txtEmail.Text
                        cmd.Parameters.Add("@TelCer", SqlDbType.VarChar).Value = txttel.Text
                        cmd.Parameters.Add("@StatusCer", SqlDbType.VarChar).Value = ddlcerstatus.SelectedValue
                        cmd.Parameters.Add("@Detail", SqlDbType.VarChar).Value = txtdetail.Text
                        cmd.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = ipaddress
                        cmd.Parameters.Add("@AddBy", SqlDbType.VarChar).Value = lblname.Text.Trim()
                        cmd.Parameters.Add("@Createdate", SqlDbType.DateTime).Value = DateTime.Now()
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        Response.Write("<Script>")
                        Response.Write("alert('!!! INSERT DATA OK  !!!');")
                        Response.Write("location.href='Admin_ConfindeSpace.aspx';")
                        Response.Write("</Script>")
                        GV_CER.Visible = True
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Response.Redirect("Admin_ConfindeSpace.aspx")
    End Sub


    Private Sub GGVVIEW()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT *   FROM SAFETY_CERTIFICATE ORDER BY Createdate ASC ")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GV_CER.DataSource = dt
                        GV_CER.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim bytes As Byte()
        Dim fileName As String, contentType As String
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select Name, Data, ContentType from SAFETY_CERTIFICATE where    Id=@Id"
                'cmd.Parameters.AddWithValue("@ConfiderNo", lblno.Text)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    bytes = DirectCast(sdr("Data"), Byte())
                    contentType = sdr("ContentType").ToString()
                    fileName = sdr("Name").ToString()
                End Using
                con.Close()
            End Using
        End Using
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub
    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "Delete from SAFETY_CERTIFICATE where    Id=@Id"
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                End Using
                con.Close()
                GGVVIEW()
                CHECKNO()
            End Using
        End Using
    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GV_CER.PageIndex = e.NewPageIndex
        GGVVIEW()
    End Sub

    Private Sub CHECKNO()

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT Max(CerCode) as CerCode FROM SAFETY_CERTIFICATE "
        Dim cmd As New SqlCommand()
        'cmd.Parameters.AddWithValue("@HW_NO", con_SAFETY)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        While sdr.Read()
            CHECK_CODE = sdr("CerCode").ToString()
            CHECK_NO = Mid(CHECK_CODE, 2, 5)
        End While


        If CHECK_CODE <> "" Then
            VIPNO = 1 + CHECK_NO
            If Len(VIPNO) = 1 Then
                VIPCODE = "0000" + VIPNO
            ElseIf Len(VIPNO) = 2 Then
                VIPCODE = "000" + VIPNO
            ElseIf Len(VIPNO) = 3 Then
                VIPCODE = "00" + VIPNO
            ElseIf Len(VIPNO) = 4 Then
                VIPCODE = "0" + VIPNO
            ElseIf Len(VIPNO) > 4 Then
                VIPCODE = VIPNO
            End If

            lblcercode.Text = "C" + VIPCODE
            Exit Sub
        ElseIf CHECK_CODE = "" Then
            lblcercode.Text = "C" + "00001"
        End If
    End Sub

    Private Sub CODE_Function()
        If CHECKDATA1 <> "" Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Using con As New SqlConnection(constr)
                Dim query As String = "insert into SAFETY_JOBFunction values (@CerCode,@CerFunction)"
                Using cmd As New SqlCommand(query)
                    cmd.Connection = con
                    cmd.Parameters.Add("@CerCode", SqlDbType.VarChar).Value = lblcercode.Text.Trim()
                    cmd.Parameters.Add("@CerFunction", SqlDbType.VarChar).Value = CHECKDATA1
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If
        If CHECKDATA2 <> "" Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Using con As New SqlConnection(constr)
                Dim query As String = "insert into SAFETY_JOBFunction values (@CerCode,@CerFunction)"
                Using cmd As New SqlCommand(query)
                    cmd.Connection = con
                    cmd.Parameters.Add("@CerCode", SqlDbType.VarChar).Value = lblcercode.Text.Trim()
                    cmd.Parameters.Add("@CerFunction", SqlDbType.VarChar).Value = CHECKDATA2
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If
        If CHECKDATA3 <> "" Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Using con As New SqlConnection(constr)
                Dim query As String = "insert into SAFETY_JOBFunction values (@CerCode,@CerFunction)"
                Using cmd As New SqlCommand(query)
                    cmd.Connection = con
                    cmd.Parameters.Add("@CerCode", SqlDbType.VarChar).Value = lblcercode.Text.Trim()
                    cmd.Parameters.Add("@CerFunction", SqlDbType.VarChar).Value = CHECKDATA3
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If
        If CHECKDATA4 <> "" Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
            Using con As New SqlConnection(constr)
                Dim query As String = "insert into SAFETY_JOBFunction values (@CerCode,@CerFunction)"
                Using cmd As New SqlCommand(query)
                    cmd.Connection = con
                    cmd.Parameters.Add("@CerCode", SqlDbType.VarChar).Value = lblcercode.Text.Trim()
                    cmd.Parameters.Add("@CerFunction", SqlDbType.VarChar).Value = CHECKDATA4
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If

    End Sub
End Class

