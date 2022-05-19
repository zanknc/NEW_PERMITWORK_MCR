<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_Home.aspx.vb" Inherits="Admin_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SAFETY ADMIN</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<link rel="stylesheet" href="BootstrapNew/css/bootstrap.css" media="screen">
    <link rel="stylesheet" href="BootstrapNew/css/custom.min.css">
    
    <script src="BootstrapNew/BB/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="BootstrapNew/BB/bs.pagination.js" type="text/javascript"></script>
    <link href="BootstrapNew/css/font-awesome.css" rel="stylesheet" type="text/css" />
    
     <link href="BootstrapNew/Script/jquery-ui.css" rel="stylesheet"  type="text/css"/>
    <script src="BootstrapNew/Scripts/jquery-ui-1.11.4.js" type="text/javascript"></script>--%>
    
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/P_CSS.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bs.pagination.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top ">
      <div class="container">
        <div class="navbar-header">
          <a href="#" class="navbar-brand">SAFETY ADMIN</a>
          <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
        <div class="navbar-collapse collapse" id="navbar-main">
          <ul class="nav navbar-nav">
                <li><a href="Admin_Home.aspx">ADMIN HOME</a></li>
<%--              <li><a href="O_Rivision_Issue.aspx">RIVISION ISSUE</a></li>--%>
          </ul>

          <ul class="nav navbar-nav navbar-right">
            <li style="margin-top: 15px;"><asp:Label ID="lblipaddress1" runat="server" Text=""></asp:Label></li>
            <li><a href="#" ><asp:Label ID="lblipaddress" runat="server" Text=""></asp:Label></a></li>
            <li><asp:HyperLink id="hplLogout" NavigateURL="Admin_Logout.aspx" Text="LOGOUT" runat="server"></asp:HyperLink></li>
          </ul>

        </div>
      </div>
</nav> 

<div class=" container jumbotron" style=" margin-top: 50px;">
<%--      <div class="alert alert-dismissable" role="alert" style=" margin-top: -50px; margin-bottom: -10px;">
        <strong><p class="text-right"><asp:Label id="lblStatus" runat="server"></asp:Label></p></strong>
      </div>--%>
              <div class="alert alert-dismissable" role="alert" style=" margin-top: -50px; margin-bottom: -10px;">
        <strong><div class="col-xs-12  col-sm-12  text-right "><asp:Label id="lblname" runat="server" CssClass="  fa"></asp:Label> | <asp:Label id="lbldiv" runat="server" CssClass="  fa"></asp:Label> | <asp:Label id="lbldivfix" runat="server" CssClass="  fa"></asp:Label></div></strong>
      </div>

      <%--<div class="page-header">
      </div>--%>
      <div class="row">
       
        <div class="col-md-offset-3 col-md-6">
          <div class="list-group">
            <a href="#" class="list-group-item">
                          <p class="list-group-item-text"></p>
              <h3 class="list-group-item-heading"><asp:Button ID="Button1" 
                      runat="server" Text="CONFINDE SPACE" 
                      CssClass="btn  btn-block btn-lg btn-default" 
                      PostBackUrl="~/Admin_ConfindeSpace.aspx" />
              </h3>
                            <p class="list-group-item-text"></p>
            </a>
            <a href="#" class="list-group-item">
                          <p class="list-group-item-text"></p>
              <h3 class="list-group-item-heading"><asp:Button ID="Button2" 
                      runat="server" Text="ELECTRICAL WORK" CssClass="btn  btn-block btn-lg btn-default" PostBackUrl="~/Admin_Electrical.aspx" />
              </h3>
                            <p class="list-group-item-text"></p>
            </a> 
            <a href="#" class="list-group-item">
                          <p class="list-group-item-text"></p>
              <h3 class="list-group-item-heading"><asp:Button ID="Button3" 
                      runat="server" Text="HOST AREA" CssClass="btn  btn-block btn-lg btn-default" PostBackUrl="~/Admin_HostArea.aspx"   />
              </h3>
                            <p class="list-group-item-text"></p>
            </a>
           <a href="#" class="list-group-item">
                          <p class="list-group-item-text"></p>
              <h3 class="list-group-item-heading"><asp:Button ID="Button4" 
                      runat="server" Text="EXPORT TO EXCEL" CssClass="btn  btn-block btn-lg btn-default" />
              </h3>
                            <p class="list-group-item-text"></p>
            </a>
          </div>
        </div>
       

      </div>
</div> 
    </form>
        <%--<script src="BootstrapNew/Scripts/bootstrap.js"  type="text/javascript"></script>
    <script src="BootstrapNew/Scripts/JSCLOCK.js"  type="text/javascript"></script>
    <script src="BootstrapNew/js/bootstrap.min.js" type="text/javascript"></script>--%>
    <script src="bootstrap/bootstrap.js"></script>
</body>
</html>
