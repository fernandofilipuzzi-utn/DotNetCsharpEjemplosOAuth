<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="credenciales_edicion.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales_edicion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de credenciales</h3>
        <p class="lead">Alta de credenciales.</p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container" style="background-color: #dcdced;">

                <div class="form-group row m-2">
                    <label class="col-form-label col-3 text-right" for="tbtbGuid">GUID Cliente(client id):</label>
                    <asp:TextBox ID="tbGuid" CssClass="form-control col-5" Text="" runat="server" placeholder="GUID Generado"/>
                </div>
                
                <div class="form-group row m-2">
                    <label class="col-form-label col-3 text-right" for="tbCuitVendedor">Clave secreta:</label>
                    <div class="col">
                        <asp:TextBox ID="tbClave" CssClass="form-control col-5" Text="" runat="server" placeholder="Clave"/>
                        <small id="smClave" class="form-text text-muted">url</small>
                    </div>
                </div>
                
                <div class="form-group text-center">
                    <asp:Button ID="btnConfirmarAgregar" runat="server" OnClick="btnConfirmarAgregar_Click" CssClass="btn btn-sm btn-primary"  Text="Agregar Modulo"/>                            
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
