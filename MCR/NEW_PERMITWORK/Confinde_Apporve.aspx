<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Confinde_Apporve.aspx.vb" Inherits="Confinde_Apporve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     

     <style type="text/css">
      .autocomplete_completionListElement
{
	margin: 0px !important;
	border-width: 1px;
	border-style:  solid dashed ;
	overflow: auto;
	height: 170px;
	font-family: Tahoma;
	font-size: small;
	text-align: left;
	width: 600px !important;
	background-color:#ffffff;
}
  
/* AutoComplete highlighted item */
.autocomplete_highlightedListItem
{
	background-color: #fffff8;
	color: green;
	padding: 1px;
}

    /* AutoComplete item */
.autocomplete_listItem
   {
    border-width: 1px;
    border-style:  solid ;
    background-color:#D8D8D8  ;
    width:600px!important;
    padding : 1px ;
   }

   .mycheckbox input[type="checkbox"] 
    { 
        margin-right: 5px; 
    }
              .form-CHECK {
  display: block;
  width: 100%;
  height: 34px;

  color: #555;
  background-color: #fff;
  background-image: none;
  border: 1px solid #ccc;



    }

         .contentclass { margin: 1em; border-collapse: collapse; }
         .headerclass { border: 1px #ccc solid; background: #FBFBEF; }
         .mycheckbox input[type="checkbox"] 
    { 
        margin-right: 5px; 
    }


            .accordion {
            width:500px;
        } 
            .accordionHeader {
            border:1pxsolid#2F4F4F;
            color:white;
            background-color:#002e62;
            font-family:Arial,Sans-Serif;
            font-size:12px;
            font-weight:bold;
            padding:5px;
            margin-top:5px;
            cursor:pointer;
        } 
        .accordionHeaderSelected {
            border:1pxsolid#2F4F4F;
            color:white;
            background-color:gray;
            font-family:Arial,Sans-Serif;
            font-size:12px;
            font-weight:bold;
            padding:5px;
            margin-top:5px;
            cursor:pointer;
        } 

    
</style> 

</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   
   
    <div align="center">
                 <br />
                 <br />
                 <br />   

<table class="table-condensed">
            <tr>
                <th class="text-center">
                <Header><h3 align="center"><asp:Label ID="lblheadname" runat="server" Text=""></asp:Label></h3></Header>
                </th>  
            </tr>
        </table>
<hr />   
    <asp:Label ID="Label1" runat="server" Text="" Visible="false" ></asp:Label>            
    &nbsp;&nbsp; NO :            
    <asp:Label ID="lb_opno" runat="server" Text=""></asp:Label>
    &nbsp;&nbsp; <asp:Button ID="btnapp" runat="server" CssClass=" btn btn-primary " Text="APPORVE" />
                 <br />
                 <br />
<div class="text-center">
   <asp:GridView ID="GridView1" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-bordered table-hover table-responsive " 
        CellPadding="3"  AutoGenerateColumns="False">
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
        <Columns>

                                     <asp:BoundField DataField="SCNO" HeaderText="CONFINDE NO" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center "  />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " />
                                            </asp:BoundField>                                    
                                     <asp:BoundField DataField="SCNAME" HeaderText="NAME" 
                                                      HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " >
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SCWORKDIV" HeaderText="DIVISION"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SCWORKDETAIL" HeaderText="WORK DETAIL"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SCWORKDATE" HeaderText="WORK DATE"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                         <asp:BoundField DataField="SCCOMPANY" HeaderText="COMPANY BY"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                         
                                            
                                      
                                        </Columns>
    </asp:GridView>
</div>

</div> 

</asp:Content>