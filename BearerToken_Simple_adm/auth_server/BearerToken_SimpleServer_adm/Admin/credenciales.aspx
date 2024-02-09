<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="credenciales.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container m-3">

        <div class="jumbotron m-3 p-3" style="background-color: #dcdced;">
            <h3 class="display-4">Credenciales</h3>
            <p class="lead">Administración de credenciales.</p>
        </div>

        <div class="col-12 m-3" style="background-color: #dcdced;">

            <div class="row text-center p-4">
                <div class="col-12">
                    <h4>Credenciales de acceso</h4>
                </div>
            </div>

            <asp:ListView ID="lvCredenciales" InsertItemPosition="LastItem" OnItemCreated="lvCredenciales_ItemCreated" OnItemDataBound="lvCredenciales_ItemDataBound" runat="server">

                <LayoutTemplate>
                    <table class="table table-condensed table-borderless table-hover text-center">
                        <thead class="table-dark">
                            <th>Id</th>
                            <th>GUID</th>
                            <th>Clave</th>
                            <th>Descripción</th>
                            <th>HABILITADO</th>
                            <th>Scopes</th>
                            <th></th>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>

                <InsertItemTemplate>
                    <tr>
                        <td colspan="6"></td>
                        <td>
                            <asp:HyperLink ID="hlModificar" runat="server" NavigateUrl='<%# $"credenciales_edicion.aspx" %>'><i class="fas fa-plus"></i></asp:HyperLink></td>
                        <tr />
                </InsertItemTemplate>

                <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lbIdCredencial" runat="server" Text='<%#Eval("id")%>'/></td>
                        <td><code class="copy-paste"><%#Eval("guid")%></code></td>
                        <td><code class="copy-paste"><%#Eval("clave")%></code></td>
                        <td>
                            <%#(Eval("descripcion") as string)?.Length>10 ? (Eval("descripcion") as string)?.Substring(0,7)+"...":Eval("descripcion") as string%>
                        </td>
                        <td><%#Eval("habilitado")%></td>
                        <td><%#Eval("scopes")%></td>
                        <td>
                            <asp:HyperLink ID="hlModificar" runat="server" NavigateUrl='<%# $"credenciales_edicion.aspx?Id={Eval("Id")}" %>'><i class="fas fa-pencil-alt"></i></asp:HyperLink>
                            <asp:LinkButton ID="lbtnEliminar" OnClick="lbtnEliminarCredencial_Click" CommandArgument='<%#Eval("Id")%>' runat="server"><i class="fas fa-trash" CommandArgument="<%#$"{Eval("id")}"%>"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>
        </div>  
    </div>


    <script>
        var elementosACopiar = document.querySelectorAll('.copy-paste');

        elementosACopiar.forEach(function (elemento) {
            var boton = document.createElement('button');
            boton.className = 'btn fas fa-copy ml-2';
            boton.addEventListener('click', function () {
                copiarAlPortapapeles(elemento);
            });
            elemento.parentNode.insertBefore(boton, elemento.nextSibling);
        });

        function copiarAlPortapapeles(elemento) {
            var texto = elemento.getAttribute('data-copiar-texto') || elemento.textContent;
            var inputTemporal = document.createElement('input');
            inputTemporal.style.position = 'absolute';
            inputTemporal.style.left = '-9999px';
            document.body.appendChild(inputTemporal);
            inputTemporal.value = texto;
            inputTemporal.select();
            document.execCommand('copy');
            document.body.removeChild(inputTemporal);
            alert('¡Texto copiado al portapapeles!');
        }
    </script>
</asp:Content>
