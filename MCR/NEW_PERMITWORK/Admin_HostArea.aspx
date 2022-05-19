<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_HostArea.aspx.vb" Inherits="Admin_HostArea" %>

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
    <%--          <li><a href="#">RIVISION ISSUE</a></li>--%>
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
<h2 class=" text-center ">HOST AREA</h2>
	     <br />
	     <div align="center"> 
<table class=" text-center "><tr>                    
                                <th>ฝ่าย:&nbsp;&nbsp;</th>
                                <th>
                                    <asp:DropDownList ID="ddlareadiv" runat="server" CssClass=" form-control "  AutoPostBack="true" OnSelectedIndexChanged="ddlareadiv_SelectedIndexChanged"  >
                                    </asp:DropDownList>
                                </th>
                                <th>แผนก:&nbsp;&nbsp;</th>
                                <th>
                                    <asp:DropDownList ID="ddlareadep" runat="server" CssClass=" form-control "  >
                                    </asp:DropDownList>
                                </th>
                                                                <th></th>
                                <th> 
                                    &nbsp;&nbsp;<asp:Button ID="btnsearch" runat="server" CssClass=" btn btn-info" 
                                Text="ค้นหาข้อมูล" Width="100px" /> </th>
                            </tr>
                            </table>
                      
	     <div class="row">
	     <div class="col-lg-12">
	     <div class="table-responsive">                       
                            <asp:GridView ID="GRDHOSTAREA" runat="server"
                                        CssClass="table table-striped table-bordered table-hover" 
                                        AutoGenerateColumns="False" DataKeyNames="AREANO" 
                           onselectedindexchanged="GRDHOSTAREA_SelectedIndexChanged" 
                                        AutoGenerateSelectButton="True" AllowPaging="True" PageSize="5"  
                                        OnPageIndexChanging="OnPageIndexChanging"
                                          OnRowDataBound="OnRowDataBound"

                                          OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                                         PagerStyle-CssClass="bs-pagination text-center">
                                        <Columns> 
                                            <asp:CommandField ButtonType="Link" ShowDeleteButton="true"/>
                                           <asp:BoundField DataField="AREADIV" HeaderText="DIVISION" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>   
                            
                                            <asp:BoundField DataField="AREADEP" HeaderText="DEPARTMENT" ReadOnly="True"  SortExpression="HOSTAREA" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
           
                                            <asp:BoundField DataField="AREAEMPNAME" HeaderText="NAME"  ReadOnly="True" SortExpression="HOSTAREA" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AREAEMAIL" HeaderText="EMAIL"  ReadOnly="True" SortExpression="HOSTAREA" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AREACHECKNO" HeaderText="CHECK NO." ReadOnly="True" SortExpression="HOSTAREA" 
                                                   HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                        </Columns>  
                                        <SelectedRowStyle BorderStyle="None" Wrap="False" />
                                    </asp:GridView>
</div> 
	     </div>  
	     </div>  

                
                
<table class="table table-responsive " style=" margin-left: 50px; padding-left: 500px; width: 700px;"  >
                    <tr>
                        <th class="text-nowrap text-right ">
                            DIVISION </th>
                        <th colspan="3">
              <asp:TextBox ID="txtdivision" runat="server" CssClass=" form-control bg-info" 
                                ></asp:TextBox>
                                </th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            </th>
                        
                    </tr>
                    <tr>
                        <th class="text-nowrap text-right ">
                            DEPARTMENT</th>
                        <th colspan="3">
                            <asp:TextBox ID="txtdepart" runat="server" CssClass=" form-control bg-info" 
                                ></asp:TextBox>
                                </th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            &nbsp;</th>
                        
                        <th >
                            &nbsp;</th>
                        
                    </tr>
                    <tr>
                         <th class="text-nowrap text-right ">
                             EMP CODE</th>
                        <th class="text-left" colspan="3">
                            <asp:TextBox ID="txtempcode" runat="server" CssClass=" form-control bg-info" 
                                AutoPostBack="true"  ></asp:TextBox>
                        </th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                    </tr>
                    <tr>
                         <th class="text-nowrap text-right ">
                             NAME</th>
                        <th class="text-left" colspan="3">
                            <asp:TextBox ID="txtname" runat="server" CssClass=" form-control bg-info"  ></asp:TextBox>
                        </th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                    </tr>
                    <tr>
                        <th class="text-nowrap text-right ">
                            EMAIL</th>
                        <th class="text-left" colspan="3">
                            <asp:TextBox ID="txtemail" runat="server" CssClass=" form-control bg-info"  ></asp:TextBox>
                        </th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                    </tr>
                    <tr>
                        <th class="text-nowrap text-right ">
                            REMARK</th>
                        <th class="text-left" colspan="3">
                            <asp:TextBox ID="txtremark" runat="server" 
                                CssClass=" form-control bg-info" AutoPostBack="true"  ></asp:TextBox>
                        </th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            &nbsp;</th>
                        
                    </tr>
                    <tr  align="center">
                        <th colspan="8">
                                &nbsp; </th>
                        
                    </tr>
                    <tr>
                        <th>
                            </th>
                        <th class="text-left">
                            </th>
                        <th>
                                <asp:Button ID="btnsave" runat="server" CssClass=" btn btn-info" 
                                Text="เพิ่มข้อมูล" Width="100px" />&nbsp;<asp:Button ID="btnupdate" 
                                runat="server" CssClass=" btn btn-info" 
                                Text="แก้ไขข้อมูล" Width="100px" Visible="false" />&nbsp; <asp:Button ID="btnclear" runat="server" CssClass=" btn btn-info" 
                                Text="เคลียร์ข้อมุล" Width="100px" />
                            </th>
                        
                        <th>
                            &nbsp;</th>
                        
                        <th>
                            </th>
                        
                        <th>
                            </th>
                        
                        <th>
                            </th>
                        
                        <th>
                            </th>
                        
                    </tr>
                    </table>
</div>
 
 
 
       </div>  
<br />
 
 
</form>
</body> 
</html> 