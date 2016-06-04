<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
 
     <div id="login_div" runat="server">
      <table>
          <tr>
              <td>Email</td>
              <td><input id="email_box" type="text" runat="server"/></td>
          </tr>
          <tr>
              <td>Password</td>
              <td><input id="pass_box" type="password" runat="server"/></td>
          </tr>
          <tr>
             <!-- <td><input type ="submit" runat="server" value="Login" onclick="Register_Click"/></td>-->
              <td><asp:Button Text="Login" OnClick="Login_Click" runat="server"/></td>
              <td><asp:Button OnClick="Register_Click" runat="server" Text="Register"/></td>
          </tr>
          </table>

         <a href="views/admin/doctor/admin_doctor_add.aspx">views/admin/doctor/admin_doctor_add.aspx</a>
    </div>

    <p id="blah" runat="server"></p>
</asp:Content>

