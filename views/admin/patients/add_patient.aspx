<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="add_patient.aspx.cs" Inherits="views_Admin_Patients_admin_patient_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <div id="add_patient_div">
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
               <td><label for="weight">Weight (pounds)</label></td>
               <td><input id="weight" type="text"  runat="server" placeholder="weight in pounds"/></td>
           </tr>
           <tr>
               <td><label for="height">height</label></td>
                <td><input id="height"  runat="server" type="text" placeholder="height in feet"/></td>
           </tr>
       </table>

        <asp:Button ID="add" runat="server" OnClick="add_click" Text="ADD PATIENT" />
    <div id="err" runat="server">
        <p id="error" runat ="server">

        </p>
    </div>
   </div>
</asp:Content>

