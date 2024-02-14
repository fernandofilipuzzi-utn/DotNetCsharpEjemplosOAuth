<%@ Page Title="" Language="C#" MasterPageFile="~/web_tokenizada/Site_tokenizado.Master" AutoEventWireup="true" CodeBehind="PaginaTokenizada.aspx.cs" Inherits="ResourceAPIServer.web_tokenizada.PaginaTokenizada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="background-color: #dcdced;">

        <div class="row m-3">
            <div class="col-8 m-3 text-center">

                <h3>Formulario embebido</h3>

                <div class="form-group row m-3">
                    <div class="col-4">
                        <label class="form-label" for="btnNombre" >Nombre y apellido</label>
                    </div>
                    <div class="col-6">
                        <div class="row">
                            <input id="btnNombre" class="form-control" />
                        </div>
                     </div>
                </div>

                <button class="btn btn-primary">Aceptar</button>
             </div>
        </div>
    </div>

</asp:Content>
