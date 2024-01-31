<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="credenciales_edicion.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales_edicion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de credenciales</h3>
        <p class="lead">Alta de credenciales.</p>
    </div>

    <div class="container">
        <div class="col-12" style="background-color: #dcdced;">

            <div class="form-group row p-2">
                <label class="col-form-label col-3 text-right" for="tbIdCredencial">Id:</label>
                <div class="col-8">
                    <div class="row">
                        <asp:TextBox ID="tbIdCredencial" CssClass="form-control text-muted" Text="" runat="server" Enabled="false" placeholder="Id credencial" />
                    </div>
                </div>
            </div>

            <div class="form-group row p-2">
                <label class="col-form-label col-3 text-right" for="tbtbGuid">GUID Cliente(client id):</label>
                <div class="col-8">
                    <div class="row">
                        <asp:TextBox ID="tbGuidCredencial" CssClass="form-control copy-paste" Text="" runat="server" placeholder="GUID Generado" />
                    </div>
                </div>
            </div>

            <div class="form-group row p-2">
                <label class="col-form-label col-3 text-right" for="tbClave">Clave secreta:</label>
                <div class="col-8">
                    <div class="row">
                        <asp:TextBox ID="tbClaveCredencial" CssClass="form-control col-9 copy-paste" Text="" runat="server" placeholder="Clave" />                    
                    </div>
                    <div class="row">
                        <small id="smClave" class="form-text text-muted">clave alfanumérica</small>
                    </div>
                </div>
            </div>

            <div class="form-group row p-2">
                <label class="col-form-label col-3 text-right" for="tbScopes">Scopes:</label>
                <div class="col-8">                    
                    <div class="row">
                        <asp:TextBox ID="tbScopesCredencial" CssClass="form-control copy-paste" Text="" runat="server" placeholder="Scopes" />
                    </div>
                    <div class="row">
                        <small id="smScope" class="form-text text-muted">scopes separados por espacios (ejemplo 1: api1), (ejemplo 2: api1 api2)</small>
                    </div>
                </div>
            </div>

            <div class="form-group text-center p-2">
                <asp:Button ID="btnConfirmarOPCredencial" runat="server" OnClick="btnConfirmarOPCredencial_Click" CssClass="btn btn-sm btn-primary" Text="Agregar Credencial" />
            </div>
        </div>


        <div class="col-12 p-2" style="background-color: #dcdced;">

            <asp:ListView ID="lvModulos" InsertItemPosition="LastItem" OnItemDataBound="lvModulos_ItemDataBound" runat="server">
                <LayoutTemplate>
                    <table class="table">
                        <thead>
                            <th>Id</th>
                            <th>descripcion</th>
                            <th>Url</th>
                            <th>Op</th>
                        </thead>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><asp:TextBox ID="tbEdIdModulo" Enabled="false" CssClass="form-control text-muted" Text='<%#Eval("id")%>' runat ="server" placeholder="descripción" /></td>
                        <td><asp:TextBox ID="tbEdDescripcionModulo" Enabled="false" CssClass="form-control text-muted" Text='<%#Eval("descripcion")%>' runat ="server" placeholder="descripción" />                        </td>
                        <td><asp:TextBox ID="tbEdUrlModulo" CssClass="form-control" Text='<%#Eval("url")%>' runat ="server" placeholder="url" /></td>
                        <td>
                            <asp:LinkButton ID="lbtnEdModificarModulo" OnClick="lbtnEdModificarModulo_Click" runat="server"><i class="fas fa-pencil-alt"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbtnEdEliminarModulo" OnClick="lbtnEdEliminarModulo_Click" runat="server"><i class="fas fa-trash"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

                <InsertItemTemplate>
                    <tr>
                        <td><asp:TextBox ID="tbInsertIdModulo" Enabled="false" CssClass="form-control text-muted" Text="" runat="server" placeholder="Id" /></td>
                        <td><asp:TextBox ID="tbInsertDescripcionModulo" CssClass="form-control" Text="" runat="server" placeholder="Descripcion" /></td>
                        <td><asp:TextBox ID="tbInsertUrlModulo" CssClass="form-control" Text="" runat="server" placeholder="URL" /></td>
                        <td><asp:LinkButton ID="lBtnAgregarNuevoModulo" OnClick="lbtnInsertNuevoModulo_Click" runat="server"><i class="fas fa-plus"></i></asp:LinkButton></td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </div>


    </div>

</asp:Content>
