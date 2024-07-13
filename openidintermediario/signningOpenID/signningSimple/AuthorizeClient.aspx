<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizeClient.aspx.cs" Inherits="signningSimple.AuthorizeClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link rel="stylesheet" href="/Content/navarlateral.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" />
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
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

        <div class="container">
            <div class="col justify-content-center align-items-center min-vh-100">

                <div class="col-4 col-md-8 col-sm-12">

                    <asp:LinkButton ID="btnGoogle" OnClick="btnGoogle_Click" runat="server">Google</asp:LinkButton>
           
                </div>

                
            </div>
        </div>
    </form>
</body>
</html>

