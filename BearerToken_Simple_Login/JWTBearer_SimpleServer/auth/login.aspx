<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JWTBearer_SimpleServer.auth.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
