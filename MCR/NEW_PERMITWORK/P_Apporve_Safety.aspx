<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_Apporve_Safety.aspx.vb" Inherits="P_Apporve_Safety" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <script type="text/javascript">
         function MutExChkList(chk) {
             var chkList = chk.parentNode.parentNode.parentNode;
             var chks = chkList.getElementsByTagName("input");
             for (var i = 0; i < chks.length; i++) {
                 if (chks[i] != chk && chk.checked) {
                     chks[i].checked = false;
                 }
             }
         }
         
         $(function () {
             $("#<% = tb_date_wk.ClientID%>").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 minDate: -0,
                 maxDate: 4,
                 dateFormat: 'yy-mm-dd'
              
           
             });
         });

         $(document).ready(function () {
             $("#<% = tb_time_start.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpStartSelect,
                   //maxTime: {
                   //    hour: 16, minute: 30
                   //}
               });
               $("#<% = tb_time_end.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpEndSelect,
                   //minTime: {
                   //    hour: 9, minute: 15
                   //}
               });
           });

           // when start time change, update minimum for end timepicker
           function tpStartSelect(time, endTimePickerInst) {
               $("#<% = tb_time_end.ClientID%>").timepicker('option', {
               minTime: {
                   hour: endTimePickerInst.hours,
                   minute: endTimePickerInst.minutes
               }
           });
       }

       // when end time change, update maximum for start timepicker
       function tpEndSelect(time, startTimePickerInst) {
           $("#<% = tb_time_start.ClientID%>").timepicker('option', {
                maxTime: {
                    hour: startTimePickerInst.hours,
                    minute: startTimePickerInst.minutes
                }
            });
        }
       
       
                $(document).ready(function () {
             $("#<% = txtPermit_Start.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpStartSelect,
                                      minTime: {
                   hour: 17, minute: 00
                   }
                   //maxTime: {
                   //    hour: 16, minute: 30
                   //}
               });
               $("#<% = txtPermit_End.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpEndSelect,
                   //minTime: {
                   //    hour: 9, minute: 15
                   //}
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
                <Header><h3 align="center">SAFETY APPORVE</h3></Header>
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
                                           <asp:BoundField DataField="STAMP_Supervisor" HeaderText="CONTROLLER BY"  
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
                 <br />
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
                
                <asp:AccordionPane ID="AccordionPane8" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                <Header><h4 align="left">ผู้ขออนุญาตและผู้ควบคุม</h4></Header>
                     <Content>
                        <hr />
                       <table class="table-condensed">
                            <tr>
                                <th>ผู้ขออนุญาต</th>
                                <th>
                                <asp:TextBox ID="txtAApplicant" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>
                                <th></th>
                                <th></th>
                            </tr>
                            
                          <tr>
                                <th>ผู้ควบคุม</th>
                                <th>
                                <asp:TextBox ID="txtControl" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>
                                <th>อีเมล์ภายในบริษัท</th>
                                <th>
                                <asp:TextBox ID="txtControlEmail" runat="server"  CssClass=" form-control"></asp:TextBox>

                                </th>
                                <th> <asp:RegularExpressionValidator
        id="regEmail"
        ControlToValidate="txtControlEmail"
        Text="(Invalid email)"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Runat="server" /> </th>
                                <th></th>
                            </tr>
                        </table> 
                     </Content> 
               </asp:AccordionPane> 
                <asp:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">ประเภทและลักษณะงานที่ทำ</h4></Header>
                    <Content>
                        <hr />
                        <table class="table-condensed">
                            <tr>
                                <th><asp:CheckBox ID="CHK_Contruction" runat="server" Text="งานก่อสร้าง" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Work_Glass" runat="server" Text="งานที่เกี่ยวกับระบบแก๊ส" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Work_Chemical" runat="server" Text="งานที่เกี่ยวข้องกับสารเคมี" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Lifting_More" runat="server" Text="งานขนย้ายหรือยกของหนัก" class="checkbox-inline"  /></th>
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Work_High" runat="server" Text="งานที่เกี่ยวข้องกับที่สูง" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Related_System" runat="server" Text="งานที่เกี่ยวข้องกับระบบไฟฟ้า" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Install" runat="server" Text="งานติดตั้ง ตรวจสอบและซ่อมบำรุง" class="checkbox-inline"  /></th>
                                <th></th>
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Work_others" runat="server" Text="งานอื่นๆ ระบุ" class="checkbox-inline "  /></th>
                                <th colspan="3"><asp:TextBox ID="txtWorkother" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th ></th>
                          


                            </tr>
                        </table>

                        <table class="table-condensed">
                            <tr>
                                <th>บริเวณที่ปฎิบัติงาน</th>
                                <th>
                                 <asp:DropDownList ID="ddlworkarea" runat="server" CssClass=" form-control ">
                                    <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>H</asp:ListItem>
                                    <asp:ListItem>I</asp:ListItem>
                                 </asp:DropDownList>
                                </th>
                                <th>Floor(ชั้น):</th>
                                <th>
                                 <asp:DropDownList ID="ddlworkfloor" runat="server" CssClass=" form-control ">
                                    <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                                                <th>อื่นๆ :</th>
                                <th><asp:TextBox ID="txtOtherDetails" runat="server"  CssClass="form-control "></asp:TextBox> </th>

                            </tr>

                              <tr>                    
                                <th>ฝ่าย:</th>
                                <th>
                                <asp:TextBox ID="ddlareadiv" runat="server"  CssClass="form-control"  ></asp:TextBox> 
                                </th>
                                <th>แผนก:</th>
                                <th>
                                <asp:TextBox ID="ddlareadep" runat="server"  CssClass="form-control"  ></asp:TextBox> 
                                </th>
                                                                <th></th>
                                <th></th>

                            </tr>

                            <tr>
                                <th class="text-nowrap">วันเวลาที่ปฎิบัติงาน วันที่ :</th>
                                <th><asp:TextBox ID="tb_date_wk" runat="server"  CssClass=" form-control"></asp:TextBox></th>
                                <th class="text-nowrap">ตั้งแต่เวลา :</th>
                                <th><asp:TextBox ID="tb_time_start" runat="server"  CssClass="form-control "></asp:TextBox> </th>
                                <th class="text-nowrap">ถึงเวลา :</th>
                                <th><asp:TextBox ID="tb_time_end" runat="server"  CssClass="form-control "></asp:TextBox> </th>
                            </tr>
                            <tr>
                                <th class="text-nowrap">รายละเอียดของงาน :</th>
                                <th colspan="5"><asp:TextBox ID="txtDetailWork" runat="server"  CssClass=" form-control" AutoCompleteType="Search"></asp:TextBox></th>
                          
                            </tr>

                            
                        </table>                    
   
                        <table class="table-condensed">
                            <tr>
                                <th class="text-nowrap">เครื่องมือ - อุปกรณ์ :  1.</th>
                                <th><asp:TextBox ID="txtEquipment_E1" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E1_Detail" runat="server"  CssClass=" form-control   " ></asp:TextBox></th>
                                
                            </tr>
                            <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  2.</th>
                                <th><asp:TextBox ID="txtEquipment_E2" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E2_Detail" runat="server"  CssClass=" form-control   " ></asp:TextBox></th>
                                
                            </tr>
                            <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  3.</th>
                                <th><asp:TextBox ID="txtEquipment_E3" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <td></td>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                
                                <th><asp:TextBox ID="txtEquipment_E3_Detail" runat="server"  CssClass=" form-control   " ></asp:TextBox></th>
                            </tr>
                          <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  4.</th>
                                <th><asp:TextBox ID="txtEquipment_E4" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E4_Detail" runat="server"  CssClass=" form-control   " ></asp:TextBox></th>
                                
                            </tr>
                                                        <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  5.</th>
                                <th><asp:TextBox ID="txtEquipment_E5" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E5_Detail" runat="server"  CssClass=" form-control   "></asp:TextBox></th>
                                
                            </tr>

                        </table>
                        <table class="table-condensed">
                            <tr>
                                
                                <th>ผู้ปฎิบัติงาน:</th>
                                <th><asp:CheckBox ID="ChkOperator1"  runat="server"  Text="พนักงาน บ.โรม อินทิเกรเต็ด ซิสเต็มส์ "  class="checkbox-inline"  AutoPostBack="true"  /></th>
                                <th>ฝ่าย:</th>
                                <th>
                                    <asp:TextBox ID="txtddldivion" runat="server"  CssClass=" form-control   "></asp:TextBox>
                                </th>
                                <th>แผนก:</th>
                                <th>
                                   <asp:TextBox ID="txtddldepartment" runat="server"  CssClass=" form-control   "></asp:TextBox>
                                </th>
                                
                            </tr>
                            <tr>
                                <th></th>
                                <th><asp:CheckBox ID="ChkOperator2" runat="server" Text="ผู้รับเหมา (บริษัท)" class="checkbox-inline"   AutoPostBack="true" /></th>
                                <th>บริษัท :</th>
                                <th colspan="3"> <asp:TextBox ID="txtSearch" runat="server"  CssClass="form-control" ></asp:TextBox></th>
                            </tr>
                            
                            <tr>
                                <th></th>
                                <th></th>
                                <th>ชื่อ :</th>
                                <th><asp:TextBox ID="txtname" runat="server" CssClass="form-control" ></asp:TextBox></th>
                                <th>ลูกทีม</th>
                                <th><asp:TextBox ID="txtsumname" runat="server" CssClass="form-control" ></asp:TextBox></th>
                            </tr>
                        </table>
 </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">ระบบความปลอดภัยที่นำมาใช้</h4></Header>
                    <Content>
                        <hr />
                        <table class="table-condensed">
                            <tr>
                                <th><asp:CheckBox ID="ChkFire_safety" runat="server" Text="ถังดับเพลิง" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Warning_Sign" runat="server" Text="ป้ายเตือน" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_The_Barrier" runat="server" Text="การกั้นพื้นที่" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Certified_By_Engineer" runat="server" Text="การรับรองโดยวิศวกรรม/งานสูง/นั่งร้าน" class="checkbox-inline"  /></th>
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Fire_Wash" runat="server" Text="Firewach Team" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Signal_man" runat="server" Text="Signal man" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="ChkStandand_alone" runat="server" Text="Standand Alone" class="checkbox-inline"  /></th>
                                <th></th>
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Other" runat="server" Text="งานอื่นๆ ระบุ" class="checkbox-inline "  /></th>
                                <th  colspan="3"><asp:TextBox ID="txtCHK_Detail" runat="server"  CssClass=" form-control   "></asp:TextBox></th>
    
                            </tr>
                        </table>
                         </Content>
                        
                    </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">อุปกรณ์ป้องกันอันตรายส่วนบุคคลที่นำมาใช้</h4></Header>
                    <Content>
                        <hr />
                        <table class="table-condensed">
                            <tr>
                                <th><asp:CheckBox ID="CHK_Safety_Shoes" runat="server" Text="รองเท้านิรภัย" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Earplugs" runat="server" Text="ปลั๊กลดเสียง" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Chemical_Clothing" runat="server" Text="ชุดป้องกันสารเคมี" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Respirator" runat="server" Text="หน้ากากป้องกันสารเคมี" class="checkbox-inline"  /></th>
                                
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Chemical_Gloves" runat="server" Text="ถุงมือกันสารเคมี" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Safety_glasses_dimming" runat="server" Text="แว่นตานิรภัย,ลดเสียง" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Helmet" runat="server" Text="หมวกนิรภัย" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_Shieldother" runat="server" Text="กระบังหน้าลดแสง,กันกระเด็น" class="checkbox-inline"  /></th>
                           
                            </tr>
                            <tr>
                                <th><asp:CheckBox ID="CHK_Safety_belt" runat="server" Text="เข็มขัด/เชือกนิรภัย" class="checkbox-inline"  /></th>
                                <th><asp:CheckBox ID="CHK_OtherEquipment" runat="server" Text="อื่นๆ ระบุ" class="checkbox-inline "  /></th>
                                <th  colspan="2"><asp:TextBox ID="txtequipment_Details" runat="server"  CssClass=" form-control   "></asp:TextBox></th>
    
                            </tr>
                        </table>
                         </Content>
                        
                    </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">ตรวจสอบความเรียบร้อยของสถานที่และอุปกรณ์เครื่องมือ</h4></Header>
                    
                    <Content>
                        <hr />
                    <table class="table-condensed">
                          
                      <tr>
                                <th>ตรวจสอบความความเรียบร้อย</th>
                                    <th>
                                        <asp:CheckBoxList ID="chkchekarea" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" >
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ใช่        "></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="        ไม่ใช่"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                <th></th>
                                <th>
                             
                                </th>
                                <th></th>
                                <th></th>
                            </tr>
                            
                          <tr>
                                <th>ข้อแนะนำเพิ่มเติม</th>
                                <th colspan="4">
                                <asp:TextBox ID="txtfinishdetail" runat="server"  CssClass=" form-control"></asp:TextBox>
                                </th>

                                <th>                                           </th>
                                <th></th>
                            </tr>
                      </table> 
                        <hr />
  
                    </Content>
                    

               </asp:AccordionPane>     
               <asp:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">การต่อเวลา ในกรณีที่ทราบว่าจะทำงานหลัง 17.00 น.</h4></Header>
                    
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
                        </table>
                    </Content> 
                    

               </asp:AccordionPane>
            </Panes>
    </asp:Accordion>
<div>
            <table class="table-condensed">
                <tr>
                    <th>&nbsp;</th>&nbsp;&nbsp;<th>&nbsp;</th>
                </tr>
            </table>
        </div>

    </div>
                 
</div> 

</asp:Content>