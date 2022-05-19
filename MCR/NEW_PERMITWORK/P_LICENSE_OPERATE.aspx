<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_LICENSE_OPERATE.aspx.vb" Inherits="P_License_Operate" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    <script type="text/javascript">

         $(document).ready(function () {
             $("#<% = txtPermit_Start.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpStartSelect,
//                   maxTime: {
//                      hour: 08, minute: 00
//                  }
               });
               $("#<% = txtPermit_End.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpEndSelect,
//                  minTime: {
//                      hour: 17, minute: 00
//                   }
               });
           });

           // when start time change, update minimum for end timepicker
           function tpStartSelect(time, endTimePickerInst) {
               $("#<% = txtPermit_End.ClientID%>").timepicker('option', {
               minTime: {
                   hour: endTimePickerInst.hours,
                   minute: endTimePickerInst.minutes
               }
           });
       }
           
       // when end time change, update maximum for start timepicker
       function tpEndSelect(time, startTimePickerInst) {
           $("#<% = txtPermit_Start.ClientID%>").timepicker('option', {
                maxTime: {
                    hour: startTimePickerInst.hours,
                    minute: startTimePickerInst.minutes
                }
            });
        }
       
    </script>
    
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
                <Header><h3 align="center">การต่อใบอนุญาตให้ทำงาน</h3></Header>
                </th>  
            </tr>
        </table>
        

<hr />         
<div style="width: 1300px;"  >
<asp:Accordion   
    ID="MyAccordion"
    runat="Server"
    SelectedIndex="0"
    HeaderCssClass="accordionHeader"
    HeaderSelectedCssClass="accordionHeaderSelected"
    ContentCssClass="contentclass"
    AutoSize="None"
    FadeTransitions="true"
    TransitionDuration="500"
    FramesPerSecond="60"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">

            <Panes>
            <asp:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">กรุณาใส่เลขที่</h4></Header>
                    <Content>
                    <h5>Welecome : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> | <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h5>
                        <hr />
                        <div align="center">
                            <table class="table-condensed">
                                <tr>
                                    <th></th>
                                    <td>
                                    </td>
                                    <th>เลขที่</th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtcheckno" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <th></th>
                <%--                    <td>
                               <asp:Button ID="btncheckno" runat="server" CssClass="btn btn-primary" Text="ตรวจสอบข้อมูล" />
                                    </td>--%>
                                </tr>
                            </table>
 <asp:AutoCompleteExtender ServiceMethod="SearchSFNO"
    MinimumPrefixLength="1"
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="txtcheckno"
    ID="AutoCompleteExtender3" runat="server" FirstRowSelected = "false">
</asp:AutoCompleteExtender>

                        </div>
                    </Content>
                </asp:AccordionPane>
             
              <asp:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">การต่อใบอนุญาตให้ทำงาน</h4></Header>
                    <Content>
                        <hr />
                        <table class="table-condensed">
                            <tr>
                                <th>ตั้วแต่เวลา</th>
                                <th>
                                <asp:TextBox ID="txtPermit_Start" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>
                                <th>ถึงเวลา</th>
                                <th>
                                <asp:TextBox ID="txtPermit_End" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>
                                <th></th>
                                <th></th>
                            </tr>
                            <tr>
                                <th>เหตุผลการต่อเวลา</th>
                                <th colspan="4">
                                <asp:TextBox ID="txtPermitRemark" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>
                            </tr>
<%--                            <tr>
                            <br />
                            <br />
                             <th></th>
                          <th colspan = "3" class="text-center "><asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="เพิ่มข้อมูล" />
                         <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="ปริ้นข้อมูล" /></th>
                          <th></th>
                            </tr>--%>
                        </table>
                    </Content> 
                </asp:AccordionPane>           
           </Panes> 
           
         </asp:Accordion> 
            <div>
            <table class="table-condensed">
                <tr>
                    <th><asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="บันทึกข้อมูล" />
                    </th>&nbsp;&nbsp;<th><asp:Button ID="Btnprint" runat="server" CssClass="btn  btn-primary" Text="ปริ้นข้อมูล"  /></th>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-bordered table-hover table-responsive " 
        CellPadding="3"  AutoGenerateColumns="False">
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
        <Columns>

                                     <asp:BoundField DataField="SF_NO" HeaderText="NO" 
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center "  />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " />
                                            </asp:BoundField>                                    
                                     <asp:BoundField DataField="SF_WorkDate" HeaderText="WORK DATE" 
                                                      HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SF_Time_str1" HeaderText="WORK TIME FROM"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SF_Time_end1" HeaderText="WORK TIME TO"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                     <asp:BoundField DataField="SF_WORK_Details" HeaderText="WORK DETAIL"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            
                                            
                                         <asp:BoundField DataField="STAMP_Applicant" HeaderText="APPLICANT BY"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="STAMP_Applicant_Date" HeaderText="APPLICANT DATE"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STAMP_Supervisor" HeaderText="CONTROL BY"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                           <asp:BoundField DataField="SP_EMP_CONTRACTOR_NAME" HeaderText="CONREACTOR BY"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                                                                                                                   <asp:BoundField DataField="PERMIT_DATEFROM" HeaderText="OVERTIME FROM"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                           <asp:BoundField DataField="PERMIT_DATETO" HeaderText="OVERTIME TO"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="PERMIT_REMARK" HeaderText="OVERTIME DETAIL"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                      
                                        </Columns>
    </asp:GridView>
</div> 
</div> 
</asp:Content>     