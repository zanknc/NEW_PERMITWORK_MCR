<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_ELECTRICAL.aspx.vb" Inherits="P_ELECTRICAL" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    <script type="text/javascript">
        $(function () {
            $("#<% = tb_date.ClientID%>").datepicker({
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

        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
        }
    </script>
    <style type="text/css">
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

         .auto-style1 {
             white-space: nowrap;
             width: 15px;
         }


        


      

       

        


        .style1
        {
            height: 30px;
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
                            var url = 'P_ELECTRICAL.aspx';
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
                    ใบอนุญาตให้ปฎิบัติงานอันตรายเกี่ยวกับไฟฟ้า</th>
                 
            </tr>
            <tr>
                <th class="text-center">
                   Electrical Work Permit
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
                                        <asp:Label ID="lblno" runat="server" Text=""  Visible="false" ></asp:Label>

                                    </th>   
                                    </tr> 
                                    </table>
</div>
<%--     <p class="text-center "><th>เลขที่
        <asp:Label ID="lblno" runat="server"  Text=""></asp:Label>&nbsp;&nbsp;&nbsp;</th></p>--%>
    <div class="container">

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
                <asp:AccordionPane ID="AccordionPane6" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 class="text-left">กรุณาตรวจสอบเลขที่</h4></Header>
                    <Content>
                        <div class="col-md-12 text-center">
                            <h5>Welecome : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> | <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h5>

                        </div>
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
                                    <td>
                                      <%--<asp:Button ID="btncheckno" runat="server" CssClass="btn btn-primary" Text="ตรวจสอบข้อมูล" />--%>
                                      <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary" Text="ปริ้นข้อมูล" />
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
                <asp:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                         <Header><h4 align="left">ใบอนุญาตให้ปฎิบัติงานอันตรายเกี่ยวกับไฟฟ้า</h4></Header>
                    <Content>
                        <div align="center">
                            
                            <table class="table-condensed">
                                <tr>
                                    <th class=" text-right">เลขที่</th>
                                    <th class=" text-left">
                                        <asp:Label ID="lblcheckno" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th class=" text-left" >
                                        พ.ศ. &nbsp;<asp:Label ID="lblyear" runat="server" Text=""></asp:Label></th>
                                    <th class="text-left"></th>
                                    <td class="">&nbsp;</td>
                                </tr>
                                <tr>
                                    <th class=" text-right">ตามที่</th>
                                    <th class=" text-left">
                                        <asp:DropDownList ID="ddlnametitle" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Value="นาย"></asp:ListItem>
                                            <asp:ListItem Value="นาง"></asp:ListItem>
                                            <asp:ListItem Value="นางสาว"></asp:ListItem>
                                            <asp:ListItem Value="MR"></asp:ListItem>
                                            <asp:ListItem Value="MISS"></asp:ListItem>
                                            <asp:ListItem Value="MRS"></asp:ListItem>
                                        </asp:DropDownList>

                                    </th>
                                    <th class=" text-right" colspan="2">
                                      <asp:TextBox ID="txtname" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </th>
                                    <th class="text-right"></th>
                                    <td class=""></td>
                                </tr>
                                <tr>
                                    <th class=" text-right">เบอร์โทรศัพท์มือถือ</th>
                                    <td class="text-left">
                                        <asp:TextBox ID="tbtelmobile" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                    <th class=" text-right">เบอร์ภายในหน่วยงาน</th>
                                    <td class="text-left">
                                        <asp:TextBox ID="tbtelcompany" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                    <td></td>

                                </tr>
                                <tr>
                                    <th colspan="1">ขออนุญาตเข้าปฏิบัติงาน จำนวน</th>
                                    <th  class="text-left"><asp:TextBox ID="txtnamesum" runat="server" CssClass="form-control input-sm"  AutoPostBack="true" ></asp:TextBox></th>
                                    <th>คน ดังมีรายชื่อต่อไปนี้</th>
                                    <th class="text-left">&nbsp;</th>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (1)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername1" runat="server" CssClass="form-control input-sm"  Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                    <td colspan="2" class=" text-right"></td>
                                </tr>
                                <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (2)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername2" runat="server" CssClass="form-control input-sm"   Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                    <td colspan="2" class=" text-right"></td>
                                </tr>
                               <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (3)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername3" runat="server" CssClass="form-control input-sm"   Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                 <td colspan="2" class=" text-right"></td>
                                </tr>
                                                               <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (4)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername4" runat="server" CssClass="form-control input-sm"   Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                    <td colspan="2" class=" text-right"></td>
                                </tr>
                               <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (5)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername5" runat="server" CssClass="form-control input-sm"   Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                <td colspan="2" class=" text-right"></td>
                                </tr>
                                                               <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (6)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername6" runat="server" CssClass="form-control input-sm"   Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                            <td colspan="2" class=" text-right"></td>
                                </tr>
<%--                                                               <tr>
                                    <td colspan="1" class=" text-right">รายชื่อ (7)</td>
                                    <th colspan="3" class="">

                                        <asp:DropDownList ID="ddlcername7" runat="server" CssClass="form-control input-sm"  Enabled = "false"  >
                                        </asp:DropDownList>
                                    </th>
                                <td colspan="2" class=" text-right"></td>
                                </tr> --%>                   
</table>
</div>
</Content>

                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 class="text-left">รายละเอียดการขออนุญาต</h4></Header><Content>
                        <div class="row">
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>วันเวลาที่ปฏิบัติงาน</label>
                                    <input id="tb_date" type="text" name="tb_maker" class="form-control input-sm" placeholder="กรุณาเลือกวันที่" runat="server"/>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>ตั้งแต่เวลา</label>
                                    <input id="tb_time_start" type="text" name="tb_maker" class="form-control input-sm" placeholder="เวลาเริ่มต้น" runat="server"/>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>ถึงเวลา</label>
                                    <input id="tb_time_end" type="text" name="tb_maker" class="form-control input-sm" placeholder="เวลาสิ้นสุด" runat="server"/>
                                </div>
                            </div>
                            
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>บริเวณที่ปฏิบัติงาน</label>
                                    <asp:DropDownList ID="ddlworkarea" runat="server" CssClass="form-control input-sm">
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
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>Floor ชั้น</label>
                                    <asp:DropDownList ID="ddlworkfloor" runat="server" CssClass=" form-control input-sm ">
                                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>อื่นๆ</label>
                                    <input id="tb_areaother" type="text" name="tb_maker" class="form-control input-sm" placeholder="อื่นๆ" runat="server"/>
                                </div>
                            </div>
                            
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>ฝ่าย</label>
                                    <asp:DropDownList ID="ddlareadiv" runat="server" CssClass=" form-control input-sm"  AutoPostBack="true" OnSelectedIndexChanged="ddlareadiv_SelectedIndexChanged"  >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>แผนก</label>
                                    <asp:DropDownList ID="ddlareadep" runat="server" CssClass=" form-control input-sm"  >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class='col-md-4'>    
      
                            </div>
                            
                            <div class='col-md-8'>    
                                <div class='form-group'>
                                    <label>รายละเอียดของงาน</label>
                                    <input id="tb_workdetail" type="text" name="tb_maker" class="form-control input-sm" placeholder="กรุณากรอกรายละเอียดด้วยครับ" runat="server"/>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>กำลังไฟฟ้าสูงสุด / Volte</label>
                                    <input id="tb_height_volte" type="text" name="tb_maker" class="form-control input-sm" placeholder="กำลังไฟฟ้าสูงสุด / Volte" runat="server"/>
                                </div>
                            </div>
                            
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>ผู้ควบคุม</label>
                                    <input id="tb_name_control" type="text" name="tb_maker" class="form-control input-sm" placeholder="กรุณาใส่เฉพาะชื่อ" runat="server"/>
                                </div>
                            </div>
                            <div class='col-md-4'>    
                                <div class='form-group'>
                                    <label>อีเมล์ภายในบริษัท</label>
                                    <input id="tb_emailcontrol_company" type="text" name="tb_maker" class="form-control input-sm" placeholder="กรุณาใส่อีเมล์ภายในบริษัท" runat="server"/>
                                </div>
                            </div>
                        </div>
                  <%--<div align="center">
                  
                                <table class="table-condensed">
                                
                                <tr>
                                    <th class="text-nowrap" colspan="2">ซึ่งทำงานในแผนก/หน่วยงาน</th><th class="text-nowrap"><asp:TextBox ID="txtdivdep" runat="server" CssClass="form-control input-sm"></asp:TextBox></th><th class="text-nowrap text-right" colspan="3">เข้าไปปฏิบัติงานเกี่ยวกับ</th><th class="text-nowrap" colspan="5"><asp:TextBox ID="txtworkdetail" runat="server" CssClass="form-control input-sm"></asp:TextBox></th></tr><tr>
                                    <th class="text-nowrap" colspan="2">สถานที่ที่ปฏิบัติงาน</th><th class="text-nowrap"><asp:TextBox ID="txtlocation" runat="server" CssClass="form-control input-sm"></asp:TextBox></th><th class="text-nowrap text-right">ในวันที่</th><th class="auto-style1"><asp:TextBox ID="TB_DATE" runat="server" CssClass="form-control input-sm" Width="100px"></asp:TextBox></th><th class="text-nowrap">ระหว่างเวลา</th><th class="text-nowrap text-center"><asp:TextBox ID="tb_time_startx" runat="server" CssClass="form-control input-sm" Width="100px"></asp:TextBox></th><th colspan="2" class="text-center">ถึง</th><td colspan="2" class="text-center"><asp:TextBox ID="tb_time_endx" runat="server" CssClass="form-control input-sm" Width="100px"></asp:TextBox></td></tr><tr>
                                    <th class="text-nowrap" colspan="2">บริษัท</th><th class="text-nowrap" colspan="4"><asp:TextBox ID="txtcompany" runat="server" CssClass=" form-control input-sm"></asp:TextBox></th><th class="text-nowrap text-right">&nbsp;</th><td colspan="4">&nbsp;</td></tr><tr>
                                    <th class="text-nowrap">อนุญาตให้</th><th class="text-nowrap">
                                        <asp:DropDownList ID="ddlnametitlepermit" runat="server" CssClass="form-control input-sm" Width="80px">
                                            <asp:ListItem Value="นาย"></asp:ListItem>
                                            <asp:ListItem Value="นาง"></asp:ListItem>
                                            <asp:ListItem Value="นางสาว"></asp:ListItem>
                                            <asp:ListItem Value="MR"></asp:ListItem>
                                            <asp:ListItem Value="MISS"></asp:ListItem>
                                            <asp:ListItem Value="MRS"></asp:ListItem>
                                        </asp:DropDownList></th>
                                        <th class="text-nowrap" colspan="4">
                                        <asp:TextBox ID="txtnamepermit" runat="server" CssClass="form-control input-sm"></asp:TextBox></th><th class="text-nowrap text-center">จำนวน</th><td colspan="2"><asp:TextBox ID="txtsumpermit" runat="server" CssClass="form-control input-sm" Width="60px"></asp:TextBox></td><th colspan="2" class="text-center">คน</th></tr>

                                </table>
                  </div>--%>
                  </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">เครื่องมือและอุปกรณ์ที่นำเข้าไป</h4></Header><Content>
                  <div align="center">
                  
                                                        <table class="table-condensed">
                            <tr>
                                <th class="text-nowrap">เครื่องมือ - อุปกรณ์ :  1.</th>
                                <th><asp:TextBox ID="txtEquipment_E1" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal"  AutoPostBack="true">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E1_Detail" runat="server"  CssClass=" form-control   " Enabled="false" ></asp:TextBox></th>
                                
                            </tr>
                            <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  2.</th>
                                <th><asp:TextBox ID="txtEquipment_E2" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal"  AutoPostBack="true">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E2_Detail" runat="server"  CssClass=" form-control   " Enabled="false"></asp:TextBox></th>
                                
                            </tr>
                            <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  3.</th>
                                <th><asp:TextBox ID="txtEquipment_E3" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <td></td>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                
                                <th><asp:TextBox ID="txtEquipment_E3_Detail" runat="server"  CssClass=" form-control" Enabled="false"></asp:TextBox></th>
                            </tr>
                          <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  4.</th>
                                <th><asp:TextBox ID="txtEquipment_E4" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG" ></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E4_Detail" runat="server"  CssClass=" form-control   " Enabled="false"></asp:TextBox></th>
                                
                            </tr>
                                                        <tr>
                                <th>เครื่องมือ - อุปกรณ์ :  5.</th>
                                <th><asp:TextBox ID="txtEquipment_E5" runat="server"  CssClass=" form-control "></asp:TextBox></th>
                                <th></th>
                                <th class="text-nowrap">ตรวจสอบเครื่องมือ :</th>
                                    <th>
                                        <asp:CheckBoxList ID="CHK_Equipment_E5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="OK"></asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="NG"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </th>
                               
                                <th><asp:TextBox ID="txtEquipment_E5_Detail" runat="server"  CssClass=" form-control " Enabled="false"></asp:TextBox></th>
                                
                            </tr>

                        </table>

                  </div></Content></asp:AccordionPane>
                <%--<asp:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">1.ตรวจสอบสิ่งที่จะก่อให้เกิดอันตรายในการปฏิบัติงานนี้</h4></Header><Content>
                  <div align="center">
                  
                                <table class="table-condensed">

                                   <tr>
                                       <th class="text-nowrap">1.สารไวไฟ/ลุกใหม้/ระเบิด</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap">5.เครื่องจักร/เครื่องมือ/อุปกรณ์</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">2.สารกัดกร่อน</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap">6.ประกายไฟ/ความร้อน</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S6" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี" >&nbsp; </asp:ListItem>
                                        <asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">3.สารมีพิษ/ฝุ่น/ฟูมแก๊ส</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap">7.อื่นๆ</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S7" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">4.กระแสไฟฟ้า</th><td colspan="2">
                                           <asp:CheckBoxList ID="CHK_Items_S4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="มี"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไม่มี"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap"></th>
                                       <td colspan="2">
                                       </td>
                                       
                                   </tr>
                                
                                </table>
                  </div>
                 
                        
                    </Content>
                </asp:AccordionPane>--%>
                <%--<asp:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">2.ตรวจสอบความปลอดภัยก่อนการปฏิบัติงาน และกำลังปฏิบัติงาน</h4></Header><Content>
                  <div align="center">
                  
                                <table class="table-condensed table-bordered">

                                   <tr>
                                       <th class="text-nowrap">1.ตรวจสอบฟ้าให้ปลอดภัย</th><td colspan="2">
                                           <asp:CheckBoxList ID="Chk_Safety1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap">10.ผลการตรวจสารเคมี</th><td colspan="2">
                                           <asp:CheckBoxList ID="Chk_Safety10" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">2.ตรวจสอบเครื่องจักรให้ปลอดภัย</th><td colspan="2">
                                           <asp:CheckBoxList ID="Chk_Safety2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th>ผลการตรวจ</th><td colspan="2">
                                       </td>
                                       
                                   </tr>
                                    <tr>
                                       <th class="text-nowrap">3.ตรวจสอบเครื่องมือให้ปลอดภัย</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-right">- ออกซิเจนมากกว่า 18%</th><td colspan="2">
                                           <asp:TextBox ID="txtchemicals1" runat="server" CssClass="form-control input-sm"></asp:TextBox></td></tr><tr>
                                       <th class="text-nowrap">4.มีการระบายของเสียทิ้ง</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-right">- สารไวไฟ 10%</th><td colspan="2">
                                           <asp:TextBox ID="txtchemicals2" runat="server" CssClass="form-control input-sm"></asp:TextBox></td></tr><tr>
                                       <th class="text-nowrap">5.มีการระบายอากาศ</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th>- สารเคมีอื่นๆ ระบุ</th><td colspan="2">
                                       </td>
                                    </tr>
                                    <tr>
                                       <th class="text-nowrap">6.มีการทำความสะอาด</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety6" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><td><asp:TextBox ID="txtchemicals31" runat="server" CssClass="form-control input-sm"></asp:TextBox></td><th class="text-center">ppm หรือ</th><td><asp:TextBox ID="txtchemicals32" runat="server" CssClass="form-control input-sm" Width="50"></asp:TextBox></td><th class="text-left">mg/m</th></tr><tr>
                                       <th class="text-nowrap">7.ปิด/ลดระบบความดัน/ความร้อน</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety7" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><td><asp:TextBox ID="txtchemicals33" runat="server" CssClass="form-control input-sm"></asp:TextBox></td><th class="text-center">ppm หรือ</th><td><asp:TextBox ID="txtchemicals34" runat="server" CssClass="form-control input-sm" Width="50"></asp:TextBox></td><th class="text-left">mg/m</th></tr><tr>
                                       <th class="text-nowrap">8.ปิดแยกระบบวาล์ว</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety8" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><td><asp:TextBox ID="txtchemicals35" runat="server" CssClass="form-control input-sm"></asp:TextBox></td><th class="text-center">ppm หรือ</th><td><asp:TextBox ID="txtchemicals36" runat="server" CssClass="form-control input-sm" Width="50"></asp:TextBox></td><th class="text-left">mg/m</th></tr><tr>
                                       <th class="text-nowrap">9.อื่นๆ</th><td colspan="2">
                                        <asp:CheckBoxList ID="Chk_Safety9" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><td><asp:TextBox ID="txtnamechek" runat="server" CssClass="form-control input-sm" placeholder="ชื่อผู้ตรวจ"></asp:TextBox></td><td><asp:TextBox ID="txtdatechek" runat="server" CssClass="form-control input-sm" placeholder="วันที่ตรวจ" Enabled="false"></asp:TextBox></td></tr></table></div></Content></asp:AccordionPane>--%>
                <%--<asp:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="contentclass" HeaderCssClass="accordionHeader">
                    <Header><h4 align="left">3.จัดมาตรการด้านความปลอดภัยขณะปฏิบัติงาน</h4></Header><Content>
                  
                 <div align="center">
                  
                                <table class="table-condensed  table-bordered">

                                   <tr>
                                       <th class="text-nowrap">1.หมวกนิรภัย</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures1" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">11.ผู้ช่วยเหลือ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures11" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">2.แว่นนิรภัย</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures2" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">12.ผู้ควบคุมงาน</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures12" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">3.ถุงมือ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures3" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">13.แผนการช่วยเหลือฉุกเฉิน</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures13" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">4.รองเท้า</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures4" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">14.ติดตั้งป้ายเตือนต่างๆ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures14" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">5.แว่นตาลดแสง</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures5" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">15.เครื่องตรวจวัดสารเคมี</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures15" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">6.กระบังหน้า</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures6" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">16.อุปกรณ์ในการดับเพลิง</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures16" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">7.หน้ากากป้องกันฝุ่น/ฟูม/แก๊ส</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures7" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">17.เสื้อทนไฟ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures17" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr>
                                    <tr>
                                       <th class="text-nowrap">8.เครื่องช่วยหายใจแบบมีถังอากาศ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures8" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap" colspan="2">18.แสงสว่าง</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures18" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">9.เข็มขัดนิรภัยและสายชูชีพ</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures9" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td><th class="text-nowrap">19.อื่นๆ</th><th class="text-nowrap">
                                           <asp:TextBox ID="txtMeasures19" runat="server" CssClass="form-control input-sm"></asp:TextBox></th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures19" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td></tr><tr>
                                       <th class="text-nowrap">10.อุปกรณ์สื่อสาร</th><td>
                                           <asp:CheckBoxList ID="CHKSCMeasures10" runat="server" CssClass="mycheckbox" RepeatDirection="Horizontal" CellSpacing="3">
                                        <asp:ListItem onclick="MutExChkList(this);" Value="1" Text="ต้องการ"></asp:ListItem><asp:ListItem onclick="MutExChkList(this);" Value="0" Text="ไมต้องการ"></asp:ListItem></asp:CheckBoxList></td>
                                       <td>

                                       </td>
                                       
                                   </tr>
                                   
                                   
                                
                                </table>
                  </div>
                        
                    </Content>
                </asp:AccordionPane>--%>
            </Panes>
    </asp:Accordion>            
        <hr/>
    <div class="container">
        <div class='col-md-6 text-center'>    
            <div class='form-group'>
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="บันทึกข้อมูล" /> 

            </div>
        </div>
        <div class='col-md-6 text-center'>    
            <div class='form-group'>
               <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-primary" Text="แก้ไขข้อมูล" Visible="false" />
            </div>
        </div>
            
        </div>
    </div>
    
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

            <asp:BoundField DataField="SCNO" HeaderText="ELECTRICAL NO" 
                        HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                        <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center "  />
                        <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                    </asp:BoundField>                                    
            <asp:BoundField DataField="SCNAME" HeaderText="NAME"
                        HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                        <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center  " />
                    </asp:BoundField>
            <%--<asp:BoundField DataField="SCWORKDIV" HeaderText="DIVISION"  
                                    HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                        <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                        <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                    </asp:BoundField>--%>
            <asp:BoundField DataField="SCWORKDETAIL" HeaderText="WORK DETAIL"  
                                    HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" >
                        <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                        <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                    </asp:BoundField>
            <asp:BoundField DataField="SCWORKDATE" HeaderText="WORK DATE"  
                                    HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                        <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                    </asp:BoundField>
            <asp:BoundField DataField="SCWORKDATEFROM" HeaderText="TIME FROM"  
                            HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
            </asp:BoundField>

            <asp:BoundField DataField="SCWORKDATETO" HeaderText="TIME TO"  
                            HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
            </asp:BoundField>
            <asp:BoundField DataField="SCNAMECONTROL" HeaderText="CONTROL NAME"  
                            HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
            </asp:BoundField>

            <asp:BoundField DataField="SCWORKAREA" HeaderText="AREA"  
                            HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
            </asp:BoundField>
            <asp:BoundField DataField="SCFLOOR" HeaderText="FLOOR"  
                            HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
            </asp:BoundField>
                                            
                                      
        </Columns>
    </asp:GridView>
</div>
</asp:Content>

