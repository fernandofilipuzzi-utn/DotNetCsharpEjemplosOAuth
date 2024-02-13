<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="/Content/css" />

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">


    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

   
</head>
<body  style="background-color: #f1f5f8; min-width: 536px;">
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <%--Framework Scripts--%>
                <asp:ScriptReference Path="https://code.jquery.com/jquery-3.5.1.slim.min.js" />
                <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" />
                <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" />
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <script type="text/javascript">

            window.addEventListener('pageshow', function (event) {
                if (event.persisted) {
                    var cookie = document.cookie.match(/(^|;) ?UsuarioSettings=([^;]*)(;|$)/);
                    if (!cookie) {
                        alert('no existe');
                    }
                    else {
                        window.location.href = 'Default.aspx';
                    }
                }
            });

        </script>

        <div class="container text-center">

            <div class="jumbotron">
                <h3 class="display-4">Administración de credenciales</h3>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="row">

                        <div class="col-12 text-center">

                            <div class="row p-3">
                                <asp:Label ID="lbError" CssClass="alert alert-dark" role="alert" runat="server" Visible="false" />
                            </div>

                            <div class="row justify-content-center">
                                <div class="col-sm-12 col-md-6 p-3" style="background-color: #dcdced;">

                                    <div class="row text-center p-4">
                                        <div class="col-12">
                                            <h4>Ingrese su usuario y contraseña</h4>
                                        </div>
                                    </div>

                                    <div class="row text-center m-3">

                                        <div class="col-12">

                                            <div class="form-group row m-3">
                                                <div class="col-4 text-right">
                                                    <label class="col-form-label" for="tbUsuario">Usuario</label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:TextBox ID="tbUsuario" CssClass="form-control col-12" placeholder="Ingrese su el nombre de Usuario" runat="server" />
                                                    <small id="usuarioHelp" class="form-text col-12 text-muted">Usuario registrado</small>
                                                </div>
                                            </div>

                                            <div class="form-group row m-3">
                                                <div class="col-4 text-right">
                                                    <label class="col-form-label" for="tbClave">Clave</label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:TextBox ID="tbClave" TextMode="Password" CssClass="form-control form-control-lg" placeholder="Ingrese su clave" runat="server" />
                                                </div>
                                            </div>

                                            <asp:Button ID="btnAceptar" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />

                                        </div>
                                    </div>
                                </div>

                            </div> 
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
