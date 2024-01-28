<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OAuth2_0AuthorizationServer.admin.login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="/Content/css" />
    <link href="/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <style>
        @media (max-width: 767px) {
            .container.row {
                min-width: 361px; /* Ajusta este valor según tus necesidades */
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <script type="text/javascript">

            //window.history.replaceState({}, '', './Default');

            window.addEventListener('pageshow', function (event) {
                if (event.persisted) {
                    var cookie = document.cookie.match(/(^|;) ?UsuarioSettings=([^;]*)(;|$)/);
                    if (!cookie) {
                        alert('no existe');
                    }
                    else {
                        //  alert('existe');
                        window.location.href = 'Default.aspx';
                    }
                }
            });

        </script>

        <asp:UpdatePanel ID="uppLoginVecino" runat="server">
            <ContentTemplate>


                <div class="container body-content">
                    <div class="col-md-5">
                        <div css="form-group">
                            <asp:Label Text="Usuario:" for="tbUsuario"  runat="server" />
                            <asp:TextBox ID="tbUsuario" CssClass="form-control"
                                         placeholder="Ingrese su el nombre de Usuario"  runat="server" />
                        </div>

                        <div css="form-group">
                            <asp:Label Text="Clave:" for="tbClave" runat="server" />
                            <asp:TextBox ID="tbClave" TextMode="Password" CssClass="form-control"
                                        placeholder="Ingrese su clave" runat="server" />
                        </div>

                        <asp:Button ID="btnAceptar" Text="Ingresar" CssClass="btn btn-primary" 
                                    OnClick="btnAceptar_Click" runat="server" />
                    </div>

                    <div><asp:Label ID="lbError" runat="server" Visible="false" /> </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
