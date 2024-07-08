<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="signning.client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
        </section>

        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Login with OpenID Connect" OnClick="btnLogin_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
<%--        <asp:Label ID="lb1" runat="server" />
        <asp:Label ID="lb2" runat="server" />
        <asp:Label ID="lb3" runat="server" />--%>
    </main>

</asp:Content>
