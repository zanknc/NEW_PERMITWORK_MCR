<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_CHECKDATATODAY.aspx.vb" Inherits="P_CHECKDATATODAY" title="CHECK WORKPERMIT"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



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
         
//                  $("[id*=txtDateFrom]").datepicker({
//                    changeYear: true,
//                    yearRange: "-15:+20",
//                    dateFormat: 'yy-mm-dd',
//                    changeMonth: true,
//                    numberOfMonths: 2,
//                    onClose: function (selectedDate) {
//                    $("[id*=txtDateTo]").datepicker("option", "minDate", selectedDate);

//                    }
//                });
//                $("[id*=txtDateTo]").datepicker({
//                    changeYear: true,
//                    yearRange: "-15:+20",
//                    dateFormat: 'yy-mm-dd',
//                    changeMonth: true,
//                    numberOfMonths: 2,
//                    onClose: function (selectedDate) {
//                     $("[id*=txtDateFrom]").datepicker("option", "maxDate", selectedDate);
//                    }
//                });

         
                  $(function () {
             $("#<% = txtDateFrom.ClientID%>").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 //minDate: -30,
                 //maxDate: 29,
                 dateFormat: 'yy-mm-dd',
                         onClose: function (selectedDate) {
                    $("[id*=txtDateTo]").datepicker("option", "minDate", selectedDate);
                    }
           
             });
         });
                           $(function () {
             $("#<% = txtDateTo.ClientID%>").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 //minDate: -29,
                 //maxDate: 30,
                 dateFormat: 'yy-mm-dd' , 
                                     onClose: function (selectedDate) {
                     $("[id*=txtDateFrom]").datepicker("option", "maxDate", selectedDate);
                    }
              
           
             });
         });
         

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <br />
                    <br />
                    <br />
<div align="center">
<table class="table-condensed">

            <tr>
                <th class="text-center">
                <Header><h3 align="center">CHECK DATA WORK TODAY</h3></Header>
                </th>  
            </tr>
        </table>
        <hr /> 
                            <h5>Welecome : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> | <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h5> 
                            <br />
        <table><tr>                    
                                <th>&nbsp; DATE FROM :&nbsp;&nbsp;</th>
                                <th>
                                    <asp:TextBox ID="txtDateFrom" runat="server" CssClass=" form-control "></asp:TextBox>
                                </th>
                                <th>&nbsp; DATE TO :&nbsp;&nbsp;</th>
                                <th>
                                    <asp:TextBox ID="txtDateTo" runat="server" CssClass=" form-control "></asp:TextBox>
                                </th>
                                                                <th></th>
                                <th> 
                                    &nbsp;&nbsp;<asp:Button ID="btnsearch" runat="server" CssClass=" btn btn-info" 
                                Text="ค้นหาข้อมูล" Width="100px" /> </th>
            <td>
                <asp:Button ID="btn_export_excel" runat="server" CssClass="btn btn-success" Text="Excel" Width="100px" Visible="false" />
            </td>
                            </tr>
                            </table>
         <br />
         <br />
         
         <div class="row text-center ">  
                        <asp:GridView ID="GVVIEW" runat="server" BackColor="White"  ShowHeaderWhenEmpty="false" AllowSorting="True" OnSorting="GVVIEW_Sorting"
                          AutoGenerateSelectButton="true"  CssClass="table table-bordered table-hover table-responsive " 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="SF_NO" 
        CellPadding="3"  AutoGenerateColumns="False" 
               onselectedindexchanged="GVVIEW_SelectedIndexChanged">

        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" Width="100px"/>
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  />
        <Columns>
<%--                <asp:ButtonField Text="Print" CommandName="Print" ItemStyle-Width="100" />--%>
                                     <asp:BoundField DataField="SF_NO" HeaderText="NO" 
                                          SortExpression="SF_NO"
                                                HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" >
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center "  />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " />
                                            </asp:BoundField>                                    
                                     <asp:BoundField DataField="SF_WorkDate" HeaderText="WORK DATE" 
                                         
                                                      HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center  " DataFormatString="{0:dd-MM-yyyy}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center " />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center text-nowrap " />
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
                                                SortExpression="PERMIT_DATEFROM"
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center " ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                           <asp:BoundField DataField="PERMIT_DATETO" HeaderText="OVERTIME TO"  
                                               SortExpression="PERMIT_DATETO"
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs  text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" DataFormatString="{0:HH:mm}">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs  text-center" />
                                            </asp:BoundField>
                                          <asp:BoundField DataField="PERMIT_REMARK" HeaderText="OVERTIME DETAIL"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SF_THE_WORK_AREA" HeaderText="AREA"
                                                 SortExpression="SF_THE_WORK_AREA"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SF_THE_WORK_FLOOR" HeaderText="FLOOR"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SF_THE_WORK_OTHER" HeaderText="OTHER"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SP_EMP_CONTRACTOR" HeaderText="CONTRACTOR"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SF_Tel_Internal" HeaderText="Tel"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SF_Tel_External" HeaderText="Mobile"  
                                                         HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs text-center">
                                                <HeaderStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center"/>
                                                <ItemStyle CssClass="visible-lg visible-md visible-sm visible-xs text-center" />
                                            </asp:BoundField>
                                            
                                      
                                        </Columns>
    </asp:GridView>
                        </div>
 </div> 
</asp:Content>

