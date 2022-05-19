<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_ConfindeSpace.aspx.vb" Inherits="Admin_ConfindeSpace" %>

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
<%--              <li><a href="#">RIVISION ISSUE</a></li>--%>
          </ul>

          <ul class="nav navbar-nav navbar-right">
            <li style="margin-top: 15px;"><asp:Label ID="lblipaddress1" runat="server" Text=""></asp:Label></li>
            <li><a href="#" ><asp:Label ID="lblipaddress" runat="server" Text=""></asp:Label></a></li>
            <li><asp:HyperLink id="hplLogout" NavigateURL="Admin_Logout.aspx" Text="LOGOUT" runat="server"></asp:HyperLink></li>
          </ul>

        </div>
      </div>
</nav> 
<br />
<br />

<div class="container jumbotron" style=" margin-left: 300px;" >
              <div class="alert alert-dismissable" role="alert" style=" margin-top: -50px; margin-bottom: -10px;">
        <strong><div class="col-xs-12  col-sm-12  text-right "><asp:Label id="lblname" runat="server" CssClass="  fa"></asp:Label> | <asp:Label id="lbldiv" runat="server" CssClass="  fa"></asp:Label> | <asp:Label id="lbldivfix" runat="server" CssClass="  fa"></asp:Label></div></strong>
      </div>
<h2 class=" text-center ">Certificate Vendor</h2>



	     <br />
	<form class="form-horizontal" role="form">
		   <div class="form-group">
		   <label for="name" class ="control-label col-sm-5 text-right ">Certificate No :</label>
	   <asp:Label ID="lblcercode" runat="server" Text="Label" class ="control-label col-sm-6 text-left "></asp:Label>
<%--	      <label for="name" class ="control-label col-sm-2 text-right "></label>--%>
<%--         <div class="col-sm-6"></div>   --%>    
		<div class="col-sm-2">
		</div>
	    </div>
	    <br />
	     <br />
	     	     	   <div class="form-group">
	   <div class="col-sm-1"></div> 
	      <label for="name" class ="control-label col-sm-2 text-right ">Title Name</label>
		<div class="col-sm-6">
                                       <asp:DropDownList ID="ddlnametitle" runat="server" CssClass="form-control input-sm" Width="80px">
                                            <asp:ListItem Value="นาย"></asp:ListItem>
                                            <asp:ListItem Value="นาง"></asp:ListItem>
                                            <asp:ListItem Value="นางสาว"></asp:ListItem>
                                            <asp:ListItem Value="MR"></asp:ListItem>
                                            <asp:ListItem Value="MISS"></asp:ListItem>
                                            <asp:ListItem Value="MRS"></asp:ListItem>
                                        </asp:DropDownList>
		</div>
		
		
		
	    </div>
	    <br />
	     <br />
	   <div class="form-group">
	   <div class="col-sm-1"></div> 
	      <label for="name" class ="control-label col-sm-2 text-right ">Name</label>
		<div class="col-sm-6">
	      <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter name"></asp:TextBox>
		</div>
		
		
		
	    </div>
	    <br />
	     <br />

	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">Job Function</label>
		<div class="col-sm-6">
            <asp:CheckBox ID="Chk1"  CssClass=" checkbox-inline" runat="server" Text="ผู้อนุญาต" />
            <asp:CheckBox ID="chk2"  CssClass=" checkbox-inline" runat="server" Text="ผู้ควบคุม" />
            <asp:CheckBox ID="chk3"  CssClass=" checkbox-inline" runat="server" Text="ผู้ช่วยเหลือ" />
            <asp:CheckBox ID="chk4"  CssClass=" checkbox-inline" runat="server" Text="ผู้ปฎิบัติงาน" />
                	      
		
		</div>
	    </div>	   
    	    	    <br />
	     <br />
	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">File Certificate</label>
		<div class="col-sm-6">
    <asp:FileUpload ID="FileUpload1" runat="server" CssClass=" form-control " />
		</div>
	    </div>
	    <br />
	     <br />
	     	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">Email</label>
		<div class="col-sm-6">
	      <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
		</div>
	    </div>
	
	    	    	    	    <br />
	     <br />
	     	     	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">Tel</label>
		<div class="col-sm-6">
	      <asp:TextBox ID="txttel" runat="server" class="form-control" placeholder="Tel"></asp:TextBox>
		</div>
	    </div>
	
	    	    	    	    <br />
	     <br />
	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">Detail</label>
		<div class="col-sm-6">
	      <asp:TextBox ID="txtdetail" runat="server" class="form-control" placeholder="Detail"></asp:TextBox>
		</div>
	    </div>
	
	    	    	    	    <br />
	     <br />
	     	    <div class="form-group">
	    <div class="col-sm-1"></div> 
	      <label for="address" class ="control-label col-sm-2 text-right">Status</label>
		<div class="col-sm-6">
	                                              <asp:DropDownList ID="ddlcerstatus" runat="server" CssClass="form-control input-sm"   AutoPostBack="true" >
	                                        <asp:ListItem Value="Cerlicensor"></asp:ListItem>
                                            <asp:ListItem Value="CerVendor"></asp:ListItem>
                                        </asp:DropDownList>
		</div>
	    </div>
	
	    	    	    	    <br />
	     <br />
	     <div class="form-group">
	     	    <div class="col-sm-4"></div> 
		<div class="col-sm-2">
            <asp:Button ID="btnsave" runat="server"  CssClass=" btn btn-block btn-primary  " Text="SAVE" />

		</div>
		<div class="col-sm-2">
            <asp:Button ID="btnclear" runat="server"  CssClass=" btn btn-block btn-primary  " Text="CLEAR" />

		</div>
	     </div> 
	     
	    	    	    	    	    <br />
	     
	    	    	    	    	    <br />
	     <br /> 
	     
	     
	     <div class="row text-center ">  
                        <asp:GridView ID="GV_CER" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false"
                        AllowPaging="True"   CssClass="table table-bordered table-hover table-responsive " 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="Id" 
        CellPadding="3"  AutoGenerateColumns="False"  OnPageIndexChanging="OnPageIndexChanging"   
   
               PageSize="5" PagerStyle-CssClass="bs-pagination text-center">
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Width="100px"/>
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
        <Columns>
<%--                <asp:ButtonField Text="Print" CommandName="Print" ItemStyle-Width="100" />--%>
                                     <asp:BoundField DataField="Id" HeaderText="NO" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center "  />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="CerCode" HeaderText="CER CODE" 
                                                      HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                                            </asp:BoundField>                                    
                                     <asp:BoundField DataField="CerName" HeaderText="VENDOR NAME" 
                                                      HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="Name" HeaderText="CERTIFICATE NAME"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="NFunction1" HeaderText="JOB Function1"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="NFunction2" HeaderText="JOB Function2"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                                                              <asp:BoundField DataField="NFunction3" HeaderText="JOB Function3"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>   
                                            
                                           <asp:BoundField DataField="NFunction4" HeaderText="JOB Function4"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>  
                                                            <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                            CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </ItemTemplate>
                    

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                                                                           <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete"  OnClick="DeleteFile"
                            CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </ItemTemplate>
                    

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                                        </Columns>
    </asp:GridView>
                        </div>
</form>
</div> 
</form>  
</body> 
</html> 