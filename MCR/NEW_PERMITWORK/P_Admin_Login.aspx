<%@ Page Language="VB" AutoEventWireup="false" CodeFile="P_Admin_Login.aspx.vb" Inherits="P_Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<meta name="generator" content="Bootply" />
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
 		<title>LOGIN ADMIN SYSTEM</title>
<%--    <link rel="stylesheet" type="text/css" href="BootstrapNew/LOGIN/bootstrap/css/bootstrap.min.css" />
	<link rel="stylesheet" type="text/css" href="BootstrapNew/LOGIN/css/styles.css" />--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
<!--login modal-->
<div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true" style="margin-top: 150px;">
  <div class="modal-dialog">
  <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
          
          <h1 class="text-center">Login</h1>
      </div>
      <div class="modal-body">
          <form class="form col-md-12 center-block">
            <div class="form-group">
            
    <asp:TextBox ID="txtUsername" runat="server" class="form-control input-lg" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ChkUsername" runat="server" 
                                ControlToValidate="txtUsername" ErrorMessage="* Username"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">

                    <asp:TextBox ID="txtPassword" runat="server"  class="form-control input-lg" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">

<%--              <span class="pull-right"><a href="#">Register</a></span><span><a href="#">Need help?</a></span>--%>
<asp:Button ID="btnLogin" runat="server" Text="Sign In" class="btn btn-primary btn-lg btn-block" />
            </div>
          </form>
          
          <div class="col-md-12 text-center">
                  <asp:Label id="lblStatus" runat="server" visible="False"></asp:Label>
                  </div>
                  <br />
      </div>
     <div class="modal-footer">
          <div class="col-md-12 text-center">
              Developer By : Ton IS  For Support System
		  </div>	
      </div>
  </div>
  </div>
</div> 
    </form>
</body>
</html>
