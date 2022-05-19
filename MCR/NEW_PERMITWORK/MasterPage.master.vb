
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim IPADD As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        lblipaddress.Text = "IP : " & ipaddress

        Session("IP_ADDRESS") = ipaddress

        'Response.AppendHeader("Refresh", "10; ")
    End Sub
End Class

