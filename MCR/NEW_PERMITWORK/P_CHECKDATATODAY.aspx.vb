Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports OfficeOpenXml
Partial Class P_CHECKDATATODAY
    Inherits System.Web.UI.Page
    Dim aa As String
    Dim SESSION_NO As String
    Dim ConStr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
    Dim Conn As New SqlConnection(ConStr)
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
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        GGVVIEW()
    End Sub

    Private Sub GGVVIEW()
        Dim constr As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT *   FROM SAFETY_PERMITWORK where SF_WorkDate between  '" & txtDateFrom.Text & "' and  '" & txtDateTo.Text & "' ORDER BY SF_NO DESC ")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GVVIEW.DataSource = dt
                        GVVIEW.DataBind()
                        Cache("dt") = dt
                        'The first sorting combination saved here
                        ViewState("Column_Name") = "Name"
                        ViewState("Sort_Order") = "ASC"

                        btn_export_excel.Visible = True
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Protected Sub GVVIEW_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GVVIEW.SelectedIndexChanged
        aa = GVVIEW.DataKeys(GVVIEW.SelectedRow.RowIndex).Value.ToString()

        Dim dtAdapter As New SqlDataAdapter
        Dim V_PERMITWORK As DataTable
        Dim ds As New DataSet

        Dim ConStr_SAFETY As String = ConfigurationManager.ConnectionStrings("CONN_SAFETY").ConnectionString
        Dim con As New SqlConnection(ConStr_SAFETY)
        Dim strQuery As String = "SELECT * FROM zzzSAFETY_PERMITWORK WHERE  SF_NO = '" & aa.Trim() & "'  "

        dtAdapter = New SqlDataAdapter(strQuery, ConStr_SAFETY)

        If ds.Tables.Contains("V_PERMITWORK") Then
            ds.Tables("V_PERMITWORK").Rows.Clear()
            ds.Tables("V_PERMITWORK").Columns.Clear()
        End If

        dtAdapter.Fill(ds, "V_PERMITWORK")

        V_PERMITWORK = ds.Tables("V_PERMITWORK")

        If ds.Tables("V_PERMITWORK").Rows.Count = 0 Then
            Response.Write("<Script>")
            Response.Write("alert('!!! NO DATA  NAJA !!!!');")
            Response.Write("location.href='P_PermitWork.aspx';")
            Response.Write("</Script>")
            Exit Sub
        End If

        Dim rpt As New ReportDocument()
        rpt.Load(Server.MapPath("Safety_Report.rpt"))
        rpt.SetDataSource(V_PERMITWORK)
        Me.CrystalReportViewer1.ReportSource = rpt
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        formatType = ExportFormatType.PortableDocFormat
        rpt.ExportToHttpResponse(formatType, Response, True, "WORKPERMIT" + "-" + aa.Trim())
        Response.[End]()


    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVVIEW.PageIndex = e.NewPageIndex
        GGVVIEW()
    End Sub

    Protected Sub GVVIEW_Sorting(sender As Object, e As GridViewSortEventArgs)
        If e.SortExpression = ViewState("Column_Name").ToString() Then
            If ViewState("Sort_Order").ToString() = "ASC" Then
                RebindData(e.SortExpression, "DESC")
            Else
                RebindData(e.SortExpression, "ASC")
            End If

        Else
            RebindData(e.SortExpression, "ASC")
        End If
    End Sub

    Private Sub RebindData(sColimnName As String, sSortOrder As String)
        Dim dt As DataTable = CType(Cache("dt"), DataTable)
        dt.DefaultView.Sort = sColimnName + " " + sSortOrder
        GVVIEW.DataSource = dt
        GVVIEW.DataBind()
        ViewState("Column_Name") = sColimnName
        ViewState("Sort_Order") = sSortOrder
    End Sub

    Private Sub Export_Excel()
        Dim pck As New ExcelPackage()
        Dim ws = pck.Workbook.Worksheets.Add("CheckData")

        ws.Cells("A1").LoadFromDataTable(GETSQL, True)
        'ws.Cells("A1").Style.Font.Bold = True
        'Dim shape = ws.Drawings.AddShape("Shape1", eShapeStyle.Rect)
        'shape.SetPosition(50, 200)
        'shape.SetSize(200, 100)
        'shape.Text = "Sample 1 saves to the Response.OutputStream"

        'pck.SaveAs(Response.OutputStream)
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("content-disposition", "attachment;  filename=Export_Excel.xlsx")
        Using MyMemoryStream As New MemoryStream()
            pck.SaveAs(MyMemoryStream)
            MyMemoryStream.WriteTo(Response.OutputStream)
            Response.Flush()
            Response.End()
        End Using
    End Sub

    Protected Function GETSQL() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(ConStr)
            con.Open()
            Dim cmd As New SqlCommand("SELECT SF_NO, CONVERT(VARCHAR(10), SF_WorkDate, 103) AS WORK_DATE, CONVERT(char(5), SF_Time_str1, 108) AS Start_time, CONVERT(char(5), SF_Time_end1, 108) AS End_time, SF_WORK_Details,STAMP_Applicant, CONVERT(VARCHAR(10), STAMP_Applicant_Date, 103) AS Applicant_Date, STAMP_Supervisor, SP_EMP_CONTRACTOR_NAME, CONVERT(char(5), PERMIT_DATEFROM, 108) AS OVERTIME_FROM,CONVERT(char(5), PERMIT_DATETO, 108) AS OVERTIME_TO , PERMIT_REMARK, SF_The_work_area, SF_The_work_Floor, SF_The_work_Other, SP_EMP_CONTRACTOR, SF_Tel_Internal, SF_Tel_External FROM SAFETY_PERMITWORK where SF_WorkDate between  '" & txtDateFrom.Text & "' and  '" & txtDateTo.Text & "' ORDER BY SF_NO DESC ", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            con.Close()
        End Using
        Return dt
    End Function

    Private Sub btn_export_excel_Click(sender As Object, e As EventArgs) Handles btn_export_excel.Click
        Export_Excel()
    End Sub
End Class
