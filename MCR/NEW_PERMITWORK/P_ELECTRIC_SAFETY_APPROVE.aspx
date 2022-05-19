<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="P_ELECTRIC_SAFETY_APPROVE.aspx.vb" Inherits="P_ELECTRIC_SAFETY_APPROVE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <div class="well">  
            <h2 class="text-danger">Electrical Work Safety Approve</h2>  
            <span class="text-info">This Step for Safety Approve </span>  
            <hr/>
            <div class="table-responsive">
                <asp:GridView ID="gvsafetyapp" runat="server" Width="100%" CssClass="table table-bordered success " AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="SCNO" HeaderText="ELECTRICAL NO" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCNAME" HeaderText="REQUEST" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCWORKDETAIL" HeaderText="WORK DETAIL" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCWORKDATE" HeaderText="WORK DATE" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCWORKDATEFROM" HeaderText="TIME FROM" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCWORKDATETO" HeaderText="TIME TO" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCNAMECONTROL" HeaderText="CONTROL WORK NAME" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCEMAILCONTROL" HeaderText="CONTROL WORK EMAIL" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCWORKAREA" HeaderText="WORK AREA" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCFLOOR" HeaderText="FLOOR" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCSTAMPCONTROL" HeaderText="CONTROL APPROVE" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCAPPNAME" HeaderText="HOST APPROVE" HeaderStyle-CssClass="text-center text-nowrap" />
                        <asp:BoundField DataField="SCSAFETYNAME" HeaderText="SAFETY APPROVE" HeaderStyle-CssClass="text-center text-nowrap" />
                    </Columns>
                </asp:GridView>
            </div>
           
            <asp:LinkButton ID="lnksafetyapprove" runat="server" CssClass="btn btn-success fa fa-check">Approve</asp:LinkButton>
          
        </div>
    </div>
</asp:Content>

