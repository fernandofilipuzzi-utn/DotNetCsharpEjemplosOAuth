<%@ Page Title="" Language="C#" MasterPageFile="~/web_cliente_consume_token/Site_cliente_consume_token.Master" AutoEventWireup="true" CodeBehind="VistaPaginaEmbebida.aspx.cs" Inherits="ResourceAPIServer.web_cliente_consume_token.VistaPaginaEmbebida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background: url(../img/gente.jpg) no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
        <h3 class="display-4">Escenerarios como cliente</h3>
        <p class="lead">Escenearios posibles de acceso por parte del cliente a recursos tokenizados</p>
    </div>

    <div class="container">    
        <div class="row">
            <iframe id="iframeControl" class="col-12" scrolling="no" seamless="seamless" runat="server" frameborder="0" allowFullScreen="true"></iframe>
        </div>
    </div>

    <style>
        iframe {
          display: block;
          border: none;         /* Reset default border */
          height: 100vh;        /* Viewport-relative units */
          width: calc(100% + 17px);
        }
        div {
          overflow-x: hidden;  /* oculta la barra de desplazamiento horizontal con overflow-x:hidden */
        }
    </style>
</asp:Content>
