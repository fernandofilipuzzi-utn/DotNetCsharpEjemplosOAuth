<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ResourceAPIServer._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Ejemplo de recursos tokenizados"</h3>
        <p class="lead">APIs y web tokenizadas</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/inicio.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>API Web tokenizada</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Ver Documentación - swagger</p>
                </div>

            </div>
            <div class="text-center">
                <a class="btn btn-primary" Target="_blank" href="swagger">Ir</a>
            </div>
        </div>

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/inicio.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Web tokenizada</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Ver página tokenizada</p>
                </div>

            </div>
            <div class="text-center">
                <a class="btn btn-primary" Target="_blank" href="/web_tokenizada/PaginaTokenizada.aspx?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyGCsvt-RW72c0-w50u0RR2BWsm2fj4w">Ir</a>
        </div>
    </div>

    </div>

</asp:Content>