<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="check_in.aspx.cs" Inherits="views_Admin_Patients_admin_patient_remove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
     <div id="add_room_div">
       <table>
           <tr> 
               <td><label for="id">Patient ID</label></td>
               <td><input id="id" type="text"  runat="server" placeholder="ID of Patient"/></td>
           </tr>
           <tr> 
               <td><label for="DoctorAssigned">Assign Doctor</label></td>
               <td><input id="DoctorAssigned" type="text"  runat="server" placeholder="ID of Doctor Assigned"/></td>
           </tr>
           <tr> 
               <td><label for="DateAdmitted">Date Admitted</label></td>
               <td><input id="DateAdmitted" type="text"  runat="server" placeholder="YYYY-MM-DD"/></td>
           </tr>
           <tr>
               <td><label for="RoomAssigned">Assign Room</label></td>
               <td><input id="RoomAssigned" type="text"  runat="server" placeholder="Enter room number"/></td>
          </tr>
           <tr>
               <td><label for="nurse">Nurse Visited</label></td>
               <td><input id="nurse" type="text"  runat="server" placeholder="ID of Nurse Visited"/></td>
          </tr>
       </table>

        <asp:Button ID="add" runat="server" OnClick="add_click" Text="Sign In" />
    <div id="err" runat="server">
        <p id="error" runat ="server"></p>
    </div>
   </div>
</asp:Content>

