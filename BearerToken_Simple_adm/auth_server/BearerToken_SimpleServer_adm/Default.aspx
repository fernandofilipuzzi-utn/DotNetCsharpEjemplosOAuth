﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BearerToken_SimpleServer_adm._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Servicio autenticador</h3>
        <p class="lead">Este servicio administra las credenciales y provee las autenticaciones y autorizaciones correspondientes.</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/inicio.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
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
            <img src="./img/postman.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
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

    </div>

</asp:Content>
