<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="credenciales_edicion.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales_edicion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de credenciales</h3>
        <p class="lead">Alta de credenciales.</p>
    </div>


    <div class="container">
        <div class="col-12" style="background-color: #dcdced;">

            <div class="form-group row m-2">
                <label class="col-form-label col-3 text-right" for="tbIdCredencial">Id:</label>
                <div class="col">
                    <asp:TextBox ID="tbIdCredencial" CssClass="form-control col-5" Text="" runat="server" placeholder="Id credencial" />
                </div>
            </div>

            <div class="form-group row m-2">
                <label class="col-form-label col-3 text-right" for="tbtbGuid">GUID Cliente(client id):</label>
                <div class="col">
                    <asp:TextBox ID="tbGuid" CssClass="form-control col-5" Text="" runat="server" placeholder="GUID Generado" />
                </div>
            </div>

            <div class="form-group row m-2">
                <label class="col-form-label col-3 text-right" for="tbClave">Clave secreta:</label>
                <div class="col">
                    <asp:TextBox ID="tbClave" CssClass="form-control col-5" Text="" runat="server" placeholder="Clave" />
                    <small id="smClave" class="form-text text-muted">url</small>
                </div>
            </div>

            <div class="form-group row m-2">
                <label class="col-form-label col-3 text-right" for="tbScopes">Scopes:</label>
                <div class="col">
                    <asp:TextBox ID="tbScopes" CssClass="form-control col-5" Text="" runat="server" placeholder="Scopes" />
                    <small id="smScope" class="form-text text-muted">url</small>
                </div>
            </div>

            <div class="form-group text-center">
                <asp:Button ID="btnConfirmarEdicionCredencial" runat="server" OnClick="btnConfirmarEdicionCredencial_Click" CssClass="btn btn-sm btn-primary" Text="Agregar Credencial" />
            </div>
        </div>
        

        <div class="col-12" style="background-color: #dcdced;">

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
                
                <InsertItemTemplate>
                    <tr>
                        <td><asp:TextBox ID="tbIdModulo" CssClass="form-control" Text="" runat="server" placeholder="Id" /></td>
                        <td><asp:TextBox ID="tbDescripcion" CssClass="form-control" Text="" runat="server" placeholder="Descripcion" /></td>
                        <td><asp:TextBox ID="tbURL" CssClass="form-control" Text="" runat="server" placeholder="URL" /></td>
                        <td><asp:LinkButton ID="lBtnAgregarNuevoModulo" OnClick="lBtnAgregarNuevoModulo_Click" runat="server"><i class="fas fa-plus"></i></asp:LinkButton></td>                        
                    </tr>
                </InsertItemTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#Eval("id")%></td>
                        <td><%#Eval("descripcion")%></td>
                        <td><%#Eval("url")%></td>
                        <td>
                            <asp:HyperLink ID="hlModificarModulo" runat="server" NavigateUrl='<%# $"credenciales_edicion.aspx?Id={Eval("Id")}" %>'><i class="fas fa-pencil-alt"></i> </asp:HyperLink>
                            <asp:LinkButton ID="lbtnEliminarModulo" OnClick="lbtnEliminarModulo_Click" runat="server"><i class="fas fa-trash" CommandArgument="<%#$"{Eval("id")}"%>"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>


            </asp:ListView>
        </div>

        
    </div>

</asp:Content>
