<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="credenciales.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Credenciales</h3>
        <p class="lead">Administración de credenciales.</p>
    </div>

    <div class="container" style="background-color: #dcdced;">

        <asp:ListView ID="lvCredenciales" InsertItemPosition="LastItem" OnItemCreated="lvCredenciales_ItemCreated" OnItemDataBound="lvCredenciales_ItemDataBound" runat="server">

            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <th>Id</th>
                        <th>GUID</th>
                        <th>Frase</th>
                        <th>HABILITADO</th>
                        <th>Scopes</th>
                        <th>Op</th>
                    </thead>

                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />

                </table>
            </LayoutTemplate>

            <InsertItemTemplate>
                <tr>
                    <td colspan="5"></td>
                    <td>
                        <asp:HyperLink ID="hlModificar" runat="server" NavigateUrl='<%# $"credenciales_edicion.aspx" %>'><i class="fas fa-plus"></i></asp:HyperLink></td>
                    <tr />
            </InsertItemTemplate>

            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="lbIdCredencial" runat="server" Text='<%#Eval("id")%>'/></td>
                    <td><%#Eval("guid")%></td>
                    <td><%#Eval("clave")%></td>
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

</asp:Content>
