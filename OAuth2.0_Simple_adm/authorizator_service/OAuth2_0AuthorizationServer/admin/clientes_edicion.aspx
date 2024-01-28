<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="clientes_edicion.aspx.cs" Inherits="OAuth2_0AuthorizationServer.admin.clientes_edicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de clientes</h3>
        <p class="lead">Alta de cliente.</p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container" style="background-color: #dcdced;">

                <div class="form-column">
                    <h4>Cliente ID</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbClienteID">GUID Cliente(client id):</label>
                        <asp:TextBox ID="tbClienteID" CssClass="form-control col-5" Text="" runat="server" placeholder="GUID Generado"/>
                    </div>
                </div>

                <div class="form-column">
                    <h4>Clave Secreta</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCuitVendedor">Clave secreta:</label>
                        <div class="col">
                            <asp:TextBox ID="tbClaveSecreta" CssClass="form-control col-5" Text="" runat="server" placeholder="Cuit del Cliente Vendedor"/>
                            <small id="smClaveSecreta" class="form-text text-muted">clave secreta</small>
                        </div>
                    </div>

                </div>

                <div class="form-group text-center">
                    <asp:Button ID="btnAgregarCliente" runat="server" OnClick="btnAgregarCliente_Click" CssClass="btn btn-sm btn-primary"  Text="Agregar Cliente"/>                            
                </div>
            </div>

            <script>

                function highlightSyntax() {
                    document.querySelectorAll('pre code').forEach((block) => {
                        hljs.highlightBlock(block);
                    });
                }

                function handleKeyPress(event) {
                    var charCode = event.charCode;
                                      
                    if ((charCode < 48 || charCode > 57) && charCode !== 44) {
                        return false;
                    }
                }

                function copiarAlPortapapelesEnviado() {
                    var contenidoDiv = document.querySelector('#dvContenidoEnviado')
                    var rango = document.createRange();
                    rango.selectNodeContents(contenidoDiv);
                    var seleccion = window.getSelection();
                    seleccion.removeAllRanges();
                    seleccion.addRange(rango);

                    document.execCommand('copy');

                    seleccion.removeAllRanges();

                    alert('Contenido copiado al portapapeles');
                }
               
            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
