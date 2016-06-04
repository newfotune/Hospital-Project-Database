<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="add_nurse.aspx.cs" Inherits="views_Admin_Nurses_admin_nurses_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
     <div id="add_nurse_div">
       <table>
           <tr>
               <td><label for="f_name">First Name</label></td>
               <td><input id="f_name" type="text"  runat="server" placeholder="Enter first Name"/></td>
           </tr>
           <tr>
               <td><label for="l_name">Last Name</label></td>
               <td><input id="l_name" type="text"  runat="server" placeholder="Enter Last Name"/></td>
          </tr>
           <tr>
               <td><label for="gender">Gender</label></td>
               <td><asp:DropDownList runat="server" ID="gender"></asp:DropDownList></td>
           </tr>
           <tr>
              <td><label for="email">Email</label></td>
               <td> 
                   <asp:TextBox ID="email" Columns="20" AutoCompleteType="Email" Width="300" placeholder="enter email" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
                <td><label for="DOB">Date of Birth</label></td>
               <td>
                   <asp:TextBox runat="server" ID="DOB" placeholder="YYYY-MM-DD"></asp:TextBox>  
               </td>
           </tr>
           <tr>
               <td><label for="phone">Primary Phone</label></td>
               <td><input id="phone" runat="server" type="text" placeholder="xxx-xxx-xxxx"/></td>
           </tr>
           <tr>
               <td><label for="hiredate">Hire Date</label></td>
               <td><input id="hiredate" type="text"  runat="server" placeholder="YYYY-MM-DD"/></td>
           </tr>
           <tr> 
               <td><label for="address">Address Line</label></td>
               <td><asp:TextBox runat="server" ID="address" type="text" placeholder="address_line" Height="39px"></asp:TextBox></td> 
           </tr>
           <tr>
               <td><label for="city">City</label></td>
               <td><input id="city"  runat="server" type="text" placeholder="city"/></td>
               <td><label for="state">State</label></td>
               <td><asp:DropDownList runat="server" ID="states"></asp:DropDownList></td>
           </tr>
           <tr>
               <td><label for="salary">Salary</label></td>
                <td><input id="salary"  runat="server" type="text" placeholder="salary"/></td>
           </tr>
          <tr>
               <td><label for="qualifications">Qualification</label></td>
                <td><input id="qualifications"  runat="server" type="text" placeholder="Qualification"/></td>
           </tr>
       </table>
   </div>
    <asp:Button ID="add" runat="server" OnClick="add_click" Text="ADD Nurse" />
    <div id="err" runat="server">
        <p id="error" runat ="server">

        </p>
    </div>
</asp:Content>

