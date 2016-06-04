<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="view_rooms.aspx.cs" Inherits="views_admin_rooms_ViewRooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
     <div id="display" runat="server"></div>

   <asp:Button ID="delete_btn" runat="server" Text="Delete" OnClick="DeleteID"/>
    <input id ="delete_box" placeholder="enter ID" runat="server"/>

    <br /><br />
    <p id="error" runat="server"></p>
</asp:Content>

