<%@ Page Title="" Language="C#" MasterPageFile="~/modo_autorizacion_1/Site.Master" AutoEventWireup="true" CodeBehind="FormularioPrueba.aspx.cs" Inherits="ResourceAPIServer.modo_autorizacion_1.FormularioPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row m-3">
            <div class="col-8 m-3 text-center">
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
