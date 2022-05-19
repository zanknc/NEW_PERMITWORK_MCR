<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_CHECKSTATUS.aspx.vb" Inherits="P_CHECKSTATUS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
                    
                    
                    <br />
                    <br />
                    <br />
<div align="center">
<table class="table-condensed">
            <tr>
                <th class="text-center">
                <Header><h3 align="center">CHECK STATUS WORK APPORVE</h3></Header>
                </th>  
            </tr>
        </table>
        <hr />         
<div style="width: 1000px;"  >
    <asp:Accordion   
    ID="MyAccordion"
    runat="Server"
    SelectedIndex="0"
    HeaderCssClass="accordionHeader"
    HeaderSelectedCssClass="accordionHeaderSelected"
    ContentCssClass="contentclass"
    AutoSize="None"
    FadeTransitions="true"
    TransitionDuration="100"
    FramesPerSecond="60"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">
            <Panes>
            <asp:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">สถานะการขออนุญาตให้ทำงาน / สถานะการต่อใบอนุญาตให้ทำงาน</h4></Header>
                    <Content>
                 <h5>Welecome : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> | <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h5>
                        <hr />
                        <div align="center">
                            <table class="table-condensed">
                                <tr>
                                    <th></th>
                                    <td>
                                    </td>
                                    <th>เลขที่</th>
                                    <td colspan="2">
                                                                        <th colspan="3"> <asp:TextBox ID="txtcheckno" runat="server"  CssClass="form-control" AutoPostBack="true" ></asp:TextBox></th>
                     <asp:AutoCompleteExtender ServiceMethod="SearchSFNO"
    MinimumPrefixLength="1"
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="txtcheckno"
    ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
</asp:AutoCompleteExtender>
                                    </td>
                                    <th></th>
                                    <td>
         <%--                             <asp:Button ID="btncheckno" runat="server" CssClass="btn btn-primary" Text="ตรวจสอบข้อมูล" />--%>
                                    </td>
                                </tr>
                            </table>

                       <hr />
                                  <table class="table-condensed">
   <asp:GridView ID="GVVIEWW" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-bordered table-hover table-responsive " 
        CellPadding="3"  AutoGenerateColumns="False">
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
                                        <Columns>
                                     <asp:BoundField DataField="SF_NO" HeaderText="เลขที่" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>                                    
                                           <asp:BoundField DataField="STAMP_Supervisor" HeaderText="ผู้ควบคุม"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="STAMP_Supervisor_Status" HeaderText="สถานะผู้ควบคุม"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            
                                           <asp:BoundField DataField="STAMP_Recipient_Know" HeaderText="ผู้รับทราบ(จบ.วิชาชีพ)"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="STAMP_Recipient_Know_Status" HeaderText="สถานะผู้รับทราบ"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>

                                            
                                           <asp:BoundField DataField="STAMP_Approvers" HeaderText="เจ้าของพื้นที่"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="STAMP_Approvers_Status" HeaderText="สถานะเจ้าของพื้นที่"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            
                                            
 
                                        </Columns>  
                                    </asp:GridView>
                             
                             <hr />
                             
      <table class="table-condensed">
            <tr>
                <th class="text-left">
                <Header><h4 align="left"></h4></Header>
                    <asp:Label ID="Label1" runat="server" Text="เช็คสถานะการต่อเวลา" Visible="false"></asp:Label>
                </th>  
            </tr>
      </table>
   <asp:GridView ID="GridView1" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-bordered table-hover table-responsive " 
        CellPadding="3"  AutoGenerateColumns="False">
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
                                        <Columns>
                                     <asp:BoundField DataField="SF_NO" HeaderText="เลขที่" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>                                    
                                            <asp:BoundField DataField="PERMIT_Supervisor" HeaderText="ผู้ควบคุม" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                           <asp:BoundField DataField="PERMIT_Supervisor_Status" HeaderText="สถานะผู้ควบคุม"  
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>

                                         <asp:BoundField DataField="PERMIT_Recipient_Know" HeaderText="ผู้รับทราบ(จบ.วิชาชีพ)"  
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="PERMIT_Recipient_Know_Status" HeaderText="สถานะผู้รับทราบ"  
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                            
                                        <asp:BoundField DataField="PERMIT_Approvers" HeaderText="เจ้าของพื้นที่"  
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="PERMIT_Approvers_Status" HeaderText="สถานะเจ้าของพื้นที่"  
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                        </Columns>  
                                    </asp:GridView>
                             
                             
                                   </table> 
                        </div>
                    </Content>
                </asp:AccordionPane>
             
                  
                        
                
           </Panes> 
           
         </asp:Accordion> 
</div> 
</div> 
</asp:Content> 
