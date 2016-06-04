<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="views_admin_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p id="result" runat="server"></p>
    </div>

        <p id="error" runat="server"></p>
        <asp:Button runat="server" Text="Back Too DashBoard" OnClick="GoBack"/>
    </form>
</body>
</html>
