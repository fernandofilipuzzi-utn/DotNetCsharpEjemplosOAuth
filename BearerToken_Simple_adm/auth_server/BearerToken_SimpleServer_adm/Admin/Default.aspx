﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BearerToken_SimpleServer_adm.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
               

        <div class="row">

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/inicio.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>APIs</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Ver Documentación - swagger</p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" target="_blank" href="swagger">Ir</a>
                </div>
            </div>

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/postman.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Postman</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Ver Documentación - Postman</p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" target="_blank" href="https://www.postman.com/fernandofilipuzziutn/workspace/dotnetcsharpejemplosbdsensillos/overview">Ir</a>
                </div>
            </div>

        
            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/token_acceso_code.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Credenciales</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Administrar credenciales</p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="/admin/credenciales.aspx">Alta de credenciales</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

