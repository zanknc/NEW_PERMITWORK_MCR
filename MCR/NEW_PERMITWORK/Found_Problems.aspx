<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Found_Problems.aspx.vb" Inherits="Found_Problems" title="Found_Problems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class=" container-fluid ">
  <div class="row">
<div class="col-md-6 col-md-offset-3">
                    <h5>Welecome : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> | <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h5>
                        <hr />
  <h4 style="border-bottom: 1px solid #c5c5c5; margin-top: 60px;">
    <i>ปัญหาที่พบเจอและข้อมูลเพิ่มเติมอื่นๆ
    </i>
         
  </h4>
  <div style="padding: 20px;" id="form-olvidado">
    <h4 class="  text-center">
 
    </h4>
      <fieldset>
        <div class="form-group input-group">
          <span class="input-group-addon">
            <i >&nbsp;NAME  &nbsp;
            </i>
          </span>
<%--          <input class="form-control" placeholder="Username" name="Username" type="Username" required="" autofocus="">--%>
            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="NAME" autofocus=""></asp:TextBox>
        </div>
        <div class="form-group input-group">
          <span class="input-group-addon">
            <i>&nbsp;DETAIL&nbsp;
            </i>
          </span>
            <asp:TextBox ID="txtdetail" runat="server" class="form-control" placeholder="Detail"  value="" required=""></asp:TextBox>
<%--            <textarea class="form-control" rows="3"></textarea>--%>
        </div>
        
       <div class="form-group input-group">
          <span class="input-group-addon">
            <i>&nbsp;OTHER    &nbsp;
            </i>
          </span>
            <asp:TextBox ID="txtOther" runat="server" class="form-control" placeholder="Other"  value="" ></asp:TextBox>
<%--            <textarea class="form-control" rows="3"></textarea>--%>
        </div>
        <div class="form-group">
<%--          <button type="submit" class="btn btn-primary btn-block">
            LOGIN
          </button>--%>
            <asp:Button ID="btnsave" runat="server" Text="SUBMIT" class="btn btn-primary btn-block" />
          <p class="help-block">


          </p>
        </div>
      </fieldset>
  </div>

</div>
</div>

</div>
</asp:Content>

