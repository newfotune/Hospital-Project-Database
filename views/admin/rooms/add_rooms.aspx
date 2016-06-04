<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="add_rooms.aspx.cs" Inherits="views_admin_rooms_add_rooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
     <div id="add_room_div">
       <table>
           <tr> 
               <td><label for="description">Describe Facilities</label></td>
               <td><asp:TextBox runat="server" ID="description" type="text" placeholder="Describe in less than 100 characters " Height="39px"></asp:TextBox></td> 
           </tr>
           <tr>
               <td><label for="numBeds">Number of Beds</label></td>
               <td><input id="numBeds" type="text"  runat="server" placeholder="Number of Beds"/></td>
          </tr>
       </table>

        <asp:Button ID="add" runat="server" OnClick="add_click" Text="ADD ROOM" />
    <div id="err" runat="server">
        <p id="error" runat ="server"></p>
    </div>
   </div>
</asp:Content>

