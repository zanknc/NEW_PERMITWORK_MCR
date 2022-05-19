<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_HOTWORK_PERMIT.aspx.vb" Inherits="P_HOTWORK_PERMIT" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
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
                 dateFormat: 'yy-mm-dd'
              
           
             });
         });

         $(document).ready(function () {
             $("#<% = tb_time_start.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpStartSelect,
                   minTime: {
                       hour: 08, minute: 00
                   }
               });
               $("#<% = tb_time_end.ClientID%>").timepicker({
                   showLeadingZero: false,
                   onSelect: tpEndSelect,
                  maxTime: {
                       hour: 17, minute: 00
                   }
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


<script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "WORK PERMIT ONLINE",
                    buttons: {
                        Close: function () {

                            $(this).dialog('close');
                            var url = 'P_HOTWORK_PERMIT.aspx';
                            $(location).attr('href', url);
                        }
                    },
                    width: 400,
                    height: 250,
                    modal: true
                });
            });
        };
    </script>
 <script type="text/javascript">
        function VPPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "WORK PERMIT ONLINE",
                    buttons: {
                        Close: function () {

                            $(this).dialog('close');
//                            var url = 'P_PermitWork.aspx';
//                            $(location).attr('href', url);
                        }
                    },
                    width: 420,
                    height: 300,
                    modal: true
                });
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                     <div id="dialog" style="display: none;">
                        
                     </div>
    <br />
    <br />
    <br />

    <div align="center">
        <table class="table-condensed">
            <tr>
                <th class="text-center">
                    ใบอนุญาตให้ทำงานที่ต้องใช้ความร้อน (เชื่อม,ตัด,ทำให้เกิดประกายไฟ,ขุดเจาะ,เจียรและรังสี)
                </th>
                 
            </tr>
            <tr>
                <th class="text-center">
                    Hot Work Permit
                </th>
            </tr>
        </table>
    </div>
    <hr />

<div align="center">
    
                                     <table class="table-condensed">
                                <tr>
                         <%--           <th>เลขที่</th>--%>
                                    <th>
                                        <asp:Label ID="lblno" runat="server" Text="" Visible="false"  ></asp:Label>

                                    </th>   
                                    </tr> 
                                    </table>
</div>
    <div align="center">
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
    TransitionDuration="300"
    FramesPerSecond="60"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">
            <Panes>
            <asp:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">กรุณาตรวจสอบเลขที่</h4></Header>
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
                                    <td>
                                        <asp:TextBox ID="txtcheckno" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th></th>
                                    <td>
                                      <asp:Button ID="btncheckno" runat="server" CssClass="btn btn-primary" Text="ตรวจสอบข้อมูล" />
                                      <asp:Button ID="btnprint" runat="server" CssClass="btn  btn-primary" Text="ปริ้นข้อมูล" />
                                    </td>
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
                <asp:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">1.ใบอนุญาตใช้เฉพาะวันที่</h4></Header>
                    <Content>
                        <hr />
                        <div align="center">
                            <table class="table-condensed">
                                <tr>
                                    <th>1.ใบอนุญาตใช้เพาะวันที่</th>
                                    <td>
                                        <asp:TextBox ID="tb_date_wk" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th>ตั้งแต่เวลา</th>
                                    <td>
                                        <asp:TextBox ID="tb_time_start" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th>ถึงเวลา</th>
                                    <td>
                                        <asp:TextBox ID="tb_time_end" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>ชื่อแผนก/ผู้รับเหมา</th>
                                    <td>
                                        <asp:TextBox ID="txtdepname" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th class="text-nowrap">ประเภทการทำงาน</th>
                                    <td>
                                        <asp:TextBox ID="txtworktype" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th>
                                        
                                    </th>
                                    <td>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-nowrap">ชื่อสถานที่/บริเวรปฏิบัติงาน</th>
                                    <td>
                                        <asp:TextBox ID="txtareaname" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th>ใบแจ้งเลขที่</th>
                                    <td>
                                        <asp:TextBox ID="txtinvoive" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                    </td>
                                    <th>
                                        
                                    </th>
                                    <td>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <th>ผู้ควบคุมงานชื่อ</th>
                                    <td>
                                        <asp:TextBox ID="txtworknamecontrol" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <th></th>
                                    <td>
                                        
                                    </td>
                                    <th>
                                        
                                    </th>
                                    <td>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <th>ประเภทพื้นที่</th>
                                    <td>
                                        <asp:CheckBox ID="ChkNormal" runat="server" CssClass="mycheckbox" Text="ปกติ" />
                                    </td>
                                    <th>
                                        <asp:CheckBox ID="ChkInhigh" runat="server" CssClass="mycheckbox" text="อยู่ที่สูง"/>
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="ChkDusty" runat="server" CssClass="mycheckbox" Text="ฝุ่นมาก" />
                                    </td>
                                    <th class="text-nowrap">
                                        <asp:CheckBox ID="ChkChemicals" runat="server" CssClass="mycheckbox" Text="สารเคมี"/>
                                    </th>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        
                                    </th>
                                    <th>
                                        <asp:CheckBox ID="ChkType" runat="server" CssClass="mycheckbox" Text="อื่นๆ ระบุ"  AutoPostBack="true"/>
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTypedetail" runat="server" Width="300" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                    </td>
                                   
                                </tr>

                            </table>

                        </div>
                        
           
    
    
  
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">2.รายชื่ออุปกรณ์ที่นำเข้ามาทำงานมีดังนี้</h4></Header>
                    <Content>
                         <hr />
                        <div align="center">
                            <table class="table-condensed">
                                <tr>
                                    <th><asp:CheckBox ID="ChkWelding_machine" runat="server" CssClass="mycheckbox" Text="เครื่องเชื่อมไฟฟ้าและก๊าซต่างๆ" /></th>
                                    <th><asp:CheckBox ID="ChkElectric_Drill" runat="server" CssClass="mycheckbox" Text="สว่านไฟฟ้า" /></th>
                                    <th><asp:CheckBox ID="ChkGrinder" runat="server" CssClass="mycheckbox" Text="เครื่องเจียร" /></th>
                                  
                                </tr>
                                <tr>
                                    <th><asp:CheckBox ID="ChkGas_Cylinders" runat="server" CssClass="mycheckbox" Text="ถังก๊าซสำหรับงานเชื่อม" /></th>
                                    <th><asp:CheckBox ID="ChkDrills" runat="server" CssClass="mycheckbox" Text="เครื่องเจาะ" /></th>
                                    <th><asp:CheckBox ID="ChkCutter" runat="server" CssClass="mycheckbox" Text="เครื่องตัด" /></th>
                                    <th><asp:CheckBox ID="ChkOther" runat="server" CssClass="mycheckbox" Text="อื่นๆ" AutoPostBack="true" /></th>
                                    <td><asp:TextBox ID="txtOtherDetail" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox></td>
                                </tr>
                            </table>

                        </div>

         
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">3. รายการความปลอดภัยที่ต้องดำเนินการพิจารณาก่อนเข้าปฏิบัติงาน</h4></Header>
                    <Content>
               
                        <div align="center">
                            <table class=" table table-condensed">
                                <tr>
                                    <th class="text-center">ลำดับ</th>
                                    <th class="text-center">รายการตรวจสอบ</th>
                                    <th>ใช่</th>
                                    <th>ไม่ใช่</th>
                                    <th class="text-center">หมายเหตุ</th>
                                </tr>
                                <tr>
                                    <th class="text-center">1</th>
                                    <th>มีการเคลื่อนย้ายวัตถุไวไฟออกจากพื้นที่</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" >  </asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S1" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">2</th>
                                    <th>มีการปิดกั้นวัตถุที่สามารถติดไฟได้ออกจากหน้างาน</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                        <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S2" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">3</th>
                                    <th>มีการระบายอากาศที่เหมาะสม</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                        <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S3" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">4</th>
                                    <th>มีการติดป่าย / สัญญาณเตือน/ หรือกั้นเขต ให้ระวัง</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                          <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S4" runat="server"  CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">5</th>
                                    <th>อันตรายจากการปฏิบัติงาน</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                                 <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S5" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">6</th>
                                    <th>มีทีมเฝ้าระวังไฟ (Firewash Team)</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S6" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                 <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S6" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">7</th>
                                    <th>มีการเตีรยมถังดับเพลิง</th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S7" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                         <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                                    <th><asp:TextBox ID="txtItems_S7" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th class="text-center">8</th>
                                    <th colspan="1">อื่นๆ <asp:TextBox ID="txtItems_S8_Detail" runat="server"></asp:TextBox></th>
                                    <th colspan="2">
                                        <asp:CheckBoxList ID="CHK_Items_S8" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal">
                                  <asp:ListItem onclick="MutExChkList(this);"  Value="1" Text="ใช่" ></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่ใช่" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               <th><asp:TextBox ID="txtItems_S8" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                            </table>

                        </div>
<%--<asp:TextBox ID="txtItems_S8_Detail" runat="server" CssClass="form-control" width="150px"></asp:TextBox>--%>
                        
          
    
    
  
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">4.ได้เตรียมอุปกรณ์ป้องกันภัยส่วนบุคลไว้ใช้งานดังนี้</h4></Header>
                    <Content>
                         <hr />
                        <div align="center">
                            <table class="table-condensed">
                                <tr>
                                    <th><asp:CheckBox ID="ChkEyewear" runat="server" CssClass="mycheckbox" Text="แว่นตานิรภัย" /></th>
                                    <th><asp:CheckBox ID="ChkShoes" runat="server" CssClass="mycheckbox" Text="รองเท้านิรภัย" /></th>
                                    <th><asp:CheckBox ID="ChkWelding_Helmets" runat="server" CssClass="mycheckbox" Text="หน้ากากเชื่อม" /></th>
                                  
                                </tr>
                                <tr>
                                    <th><asp:CheckBox ID="ChkGlove" runat="server" CssClass="mycheckbox" Text="ถุงมือ" /></th>
                                    <th><asp:CheckBox ID="ChkExtinguisher" runat="server" CssClass="mycheckbox" Text="เครื่องดับเพลิง" /></th>
                                    <th><asp:CheckBox ID="ChkEar_Plugs" runat="server" CssClass="mycheckbox" Text="ปลั๊กอุดหู" /></th>
                                   
                                </tr>
                                <tr>
                                    <th><asp:CheckBox ID="ChkPro_Other" runat="server" CssClass="mycheckbox" Text="อื่นๆ..." AutoPostBack="true" /></th>
                                    <th colspan="2"><asp:TextBox ID="txtPro_OtherDetail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox></th>
                                </tr>
                            </table>

                        </div>

                        
          
    
    
  
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">การตรวจสอบก่อนเริ่มปฏิบัติงาน (เลือกเฉพาะบุคลที่เกี่ยวข้อง)</h4></Header>
                    <Content>
                         <h4>ข้าพเจ้าได้ร่วมกันตรวจสอบความเรียบร้อยพื้นที่ปฏิบัติงานด้วยตนเองเรียบร้อยแล้วรายการต่อไปนี้</h4>
                        <div align="center">
                            <table class="table-condensed">
                                <tr >
                                    <th>ฝ่ายปฏิบัติงาน</th>
                                    <th><asp:TextBox ID="txtbeforework" runat="server" CssClass="form-control"></asp:TextBox></th>
                                    <td><%--<asp:CheckBox ID="chkbeforerepair" runat="server" CssClass="mycheckbox" Text="พน.ซ่อม" />--%></td>
                                
                                    <th>ผู้ควบคุมงาน</th>
                                    <th><asp:TextBox ID="txtbeforecontrol" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th>หน่วยงานเจ้าของพื้นที่</th>
                                    <th><asp:TextBox ID="txtbeforearea" runat="server" CssClass="form-control"></asp:TextBox></th>
                                    <td><%--<asp:CheckBox ID="chkbeforehead" runat="server" CssClass="mycheckbox" Text="หน.แผนก" />--%></td>

                                    <th>แผนกความปลอดภัย</th>
                                    <th><asp:TextBox ID="txtbeforesafety" runat="server" CssClass="form-control"></asp:TextBox></th>
                                   
                                </tr>
                                
                            </table>

                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane6" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">การตรวจสอบหลังปฏิบัติงานเสร็จ</h4></Header>
                    <Content>
                         <h4>ข้าพเจ้าได้ร่วมกันตรวจสอบความเรียบร้อยของพื้นที่ปฏิบัติงานด้วยตนเองเรียบร้อยแล้วตามรายการต่อไปนี้</h4>
                                                 <div align="center">
                                                                             <table class="table-condensed">
                                <tr>
                                    <th class="text-right ">ฝ่ายปฏิบัติงาน</th>
                                    <td><asp:CheckBox ID="CHECK_Area" runat="server" CssClass="mycheckbox" Text="จัดเก็บพื้นที่ปกิบัติงานเรียบร้อย" /></td>
                                    <td><asp:CheckBox ID="CHECK_Release" runat="server" CssClass="mycheckbox" Text="ปลดป้าย'ห้ามแตะ'" /></td>
                                    <td><asp:CheckBox ID="CHECK_No_fuel_left" runat="server" CssClass="mycheckbox" Text="ไม่มีแหล่งเชื่อเพลิงหลงเหลือ" /></td>
                                    
                                </tr>
                                <tr>
                                    <td><asp:CheckBox ID="CHECK_Equipmen" runat="server" CssClass="mycheckbox" Text="จัดเก็บเครื่องมือในการทำงานเรียบร้อย" /></td>
                                    <td colspan="1"><asp:CheckBox ID="CHECK_Other" runat="server" CssClass="mycheckbox" Text="อื่นๆ" /><asp:TextBox ID="txtCHECK_OtherDetail" runat="server" ></asp:TextBox></td> 
                         
                                </tr>
                                
                            </table>
                             <h4>พร้อมทั้งแจ้งให้ทางหน่วยงานเจ้าของพื้นที่ทราบการสิ้นสุดงาน</h4>
                            <table class="table-condensed">
                            
                                <tr >
                                    <th>ฝ่ายปฏิบัติงาน</th>
                                    <th><asp:TextBox ID="txtafterwork" runat="server" CssClass="form-control"></asp:TextBox></th>
                                    <td><%--<asp:CheckBox ID="chkafterrepair" runat="server" CssClass="mycheckbox" Text="พน.ซ่อม" />--%></td>
                                
                                    <th>ผู้ควบคุมงาน</th>
                                    <th><asp:TextBox ID="txtafercontrol" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                                <tr>
                                    <th>หน่วยงานเจ้าของพื้นที่</th>
                                    <th><asp:TextBox ID="txtafterarea" runat="server" CssClass="form-control"></asp:TextBox></th>
                                    <td><%--<asp:CheckBox ID="chkafterwork" runat="server" CssClass="mycheckbox" Text="หน.งาน" />--%></td>

                                    <th>แผนกความปลอดภัย</th>
                                    <th><asp:TextBox ID="txtaftersafety" runat="server" CssClass="form-control"></asp:TextBox></th>
                                   
                                </tr>
                                <tr>
                                    <%--<td><asp:CheckBox ID="chkafterhead" runat="server" CssClass="mycheckbox" Text="หน.แผนก" /></td>--%>
                                    <th>ผู้ประสานงานความปลอดภัยเวลา</th>
 <%--                                    <td><asp:CheckBox ID="chkaftertime" runat="server" CssClass="mycheckbox" Text="ผู้ประสานงานความปลอดภัยเวลา" /></td>--%>
                                     <th class="text-left "><asp:TextBox ID="txtafertime" runat="server" CssClass="form-control"></asp:TextBox></th>
                                </tr>
                            </table>

                        </div>
                        
                    </Content>
                </asp:AccordionPane>
            </Panes>
    </asp:Accordion>
        <div>
            <table class="table-condensed">
                <tr>
                    <th><asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="บันทึกข้อมูล" />
                    </th>&nbsp;&nbsp;<th><asp:Button ID="BtnUpdate" runat="server" CssClass="btn  btn-primary" Text="แก้ไขข้อมูล" Visible="false" /></th>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>

