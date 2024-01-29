<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modulos_edicion.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.modulos_edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de modulos</h3>
        <p class="lead">Alta de cliente.</p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container" style="background-color: #dcdced;">

                <div class="form-column">
                    <h4>Cliente ID</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbClienteID">GUID Cliente(client id):</label>
                        <asp:TextBox ID="tbDescripcion" CssClass="form-control col-5" Text="" runat="server" placeholder="GUID Generado"/>
                    </div>
                </div>

                <div class="form-column">
                    <h4>Clave Secreta</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCuitVendedor">Clave secreta:</label>
                        <div class="col">
                            <asp:TextBox ID="tbURL" CssClass="form-control col-5" Text="" runat="server" placeholder="URL"/>
                            <small id="smURL" class="form-text text-muted">url</small>
                        </div>
                    </div>

                </div>

                <div class="form-group text-center">
                    <asp:Button ID="btnConfirmarAgregar" runat="server" OnClick="btnConfirmarAgregar_Click" CssClass="btn btn-sm btn-primary"  Text="Agregar Modulo"/>                            
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
