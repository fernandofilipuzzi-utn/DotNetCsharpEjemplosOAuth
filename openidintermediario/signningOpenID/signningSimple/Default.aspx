<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="signningSimple._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
           
        </section>

        <div>
            <a href="login?provider=Google">Login with Google</a>
            <a href="logout.aspx">Logout</a>

        </div>
    </main>

</asp:Content>
