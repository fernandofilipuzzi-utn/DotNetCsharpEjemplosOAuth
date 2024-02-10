<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppWebDemoCliente._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background: url(../img/gente.jpg) no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
        <h3 class="display-4">Escenerarios como cliente</h3>
        <p class="lead">Escenearios posibles accesos a otros recursos externos (web,apis)</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="../img/token_acceso.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Web del cliente</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Método de acceso mediante el paso del token en la url</p>
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnModo1" class="btn btn-primary" OnClick="btnModo1_Click"  Text="Ir" runat="server"/>
            </div>
        </div>

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="../img/token_acceso.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Acceso a Página Web</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Por el webconfig</p>
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnModo2" class="btn btn-primary" OnClick="btnModo2_Click" Text="Ir" runat="server"/>
            </div>
        </div>
    </div>

</asp:Content>