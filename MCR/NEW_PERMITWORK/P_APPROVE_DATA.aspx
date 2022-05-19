<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_APPROVE_DATA.aspx.vb" Inherits="P_APPROVE_DATA" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <br />
                    <br />
                    <br />
<div align="center">
<table class="table-condensed">
            <tr>
                <th class="text-center">
                <Header><h3 align="center">APPROVE MANUAL</h3></Header>
                </th>  
            </tr>
        </table>
        <hr />    
        <table><tr>                    
                                <th>&nbsp; WORK NO:&nbsp;&nbsp;</th>
                                <th>
                                    <asp:TextBox ID="txtworkno" runat="server" CssClass=" form-control "></asp:TextBox>
                                </th>
                                <th>&nbsp; &nbsp;</th>
                                <th>
                                    &nbsp;</th>
                                <th> 
                                    &nbsp;&nbsp;<asp:Button ID="btnsearch" runat="server" CssClass=" btn btn-info" 
                                Text="ค้นหาข้อมูล" Width="100px" /> </th>
                            </tr>
                            </table>
         <br />
         <br />
  <div class="container ">
    <div class="row">
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">CONTROL NAME:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txtcontrolname" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            CONTROL STATUS:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txtcontrolstatus" runat="server" CssClass=" form-control "  Enabled="false"></asp:TextBox></div></div></div>
    </div>
    <div class="row" style="margin-top: 10px;">
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">CONTROL EMAIL:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txtcontrolemail" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            TIME APPROVE:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txtcontroldate" runat="server" CssClass=" form-control " Enabled="false"></asp:TextBox></div></div></div>
    </div>
    <div class="row" style="margin-top: 10px;">
        <hr />
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">SAFETY NAME:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txtsafetyname" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            SAFETY STATUS:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txtsafetystatus" runat="server" CssClass=" form-control " Enabled="false"></asp:TextBox></div></div></div>
    </div>
    <div class="row" style="margin-top: 10px;">
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">SAFETY EMAIL:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txtsafetyemail" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            TIME APPROVE:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txtsafetydate" runat="server" CssClass=" form-control "  Enabled="false"></asp:TextBox></div></div></div>
    </div>
    <div class="row" style="margin-top: 10px;">
        <hr />
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">HOSTAREA NAME:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txthostname" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            HOSTAREA STATUS:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txthoststatus" runat="server" CssClass=" form-control "  Enabled="false"></asp:TextBox></div></div></div>
    </div>
    <div class="row" style="margin-top: 10px;">
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right "><div class="item">HOSTAREA EMAIL:</div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"><asp:TextBox ID="txthostemail" runat="server" CssClass=" form-control "></asp:TextBox></div></div></div>
        <div class="col-xs-6 col-sm-2 col-centered col-min text-right"><div class="item"><div class="content">
            TIME APPROVE:</div></div></div>
        <div class="col-xs-6 col-sm-3 col-centered col-min text-left "><div class="item"><div class="content"> <asp:TextBox ID="txttmeapp" runat="server" CssClass=" form-control "  Enabled="false"></asp:TextBox></div></div></div>
    </div>
    

    
                    <table class="table-condensed">
                <tr>
                    <th><asp:Button ID="BtnSave" runat="server" CssClass=" btn btn-info"  Text="APPROVE" />
                    </th>&nbsp;&nbsp;<th><asp:Button ID="BtnUpdate" runat="server" CssClass=" btn btn-info"  Text="CLAER"  /></th>
                </tr>
            </table>
    </div> 
    

 </div> 
</asp:Content>

