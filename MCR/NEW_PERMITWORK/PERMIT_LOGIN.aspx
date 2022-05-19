<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PERMIT_LOGIN.aspx.vb" Inherits="PERMIT_LOGIN" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=1,initial-scale=1,user-scalable=1" />
	<title>LogIn WoRk PerMit</title>
	
	<link href="Login/css/font.css" rel="stylesheet" type="text/css">
	<link rel="stylesheet" type="text/css" href="Login/bootstrap/css/bootstrap.min.css" />
	<link rel="stylesheet" type="text/css" href="Login/css/styles.css" />
	
	<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script>
        //var myVideo = iframe.getElementById('myVideo');
        //myVideo.mute();
       

        function popup(url) {
            var width = 1024;
            var height = 768;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            var newwin = window.open(url, 'windowname5', params);
            if (window.focus) { newwin.focus() }
            return false;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 35px;">
    <section class="container">
			<section class="login-form jumbotron ">
				<form method="post" action="" role="login">
				<div style="margin: 15px;" >
					<img src="Login/images/logo.png" class="img-responsive text-center " alt="" />
					</div>
							<div style="margin: 15px;">
					<asp:TextBox ID="txtempno" runat="server" placeholder="กรุณากรอกรหัสพนักงาน"  class="form-control input-lg input-group-lg " ></asp:TextBox>
					</div> 
<%--					<input type="password" name="password" placeholder="Password" required class="form-control input-lg" />--%>
				<div style="margin: 15px;">
				<asp:Button ID="btnsubmit" runat="server" Text="submit" class="btn btn-lg btn-primary btn-block"></asp:Button>
		
					</div> 
				    <div style="margin: 15px;" class="text-center">
				       <a href="javascript: void(0)" onclick="popup('PDF/Usermanual%20work%20permit%20online%20REV.02.pdf')" class="btn btn-success">คู่มือการใช้งานโปรแกรม<br/>User Manual</a>
	
				    </div> 
					
					<div class=" text-center ">                             <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/P_Admin_Login.aspx " 
            style="font-family: 'TH SarabunPSK'; font-size: medium; font-weight: bold; font-style: italic; color: #FF0000">FOR ADMIN</asp:HyperLink></div>
				</form>
				
			</section>
	</section>
	</div> 
	
	
	<script src="Login/bootstrap/js/jquery.min.js"></script>
	<script src="Login/bootstrap/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
