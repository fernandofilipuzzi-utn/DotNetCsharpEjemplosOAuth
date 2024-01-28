<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="OAuth2_0AuthorizationServer.admin.nuevo_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Alta/Modificación de una Deuda en Interbanking</h3>
        <p class="lead">Este mensaje puede ser utilizado por Recaudadoras que tengan Habilitado el parámetro de <span class="text-danger">Publicación de Deuda</span>. 
            Con este mensaje se <span class="text-danger">genera una PreConfección si no existe</span>, 
            o <span class="text-danger">modifica si existe en un estado</span> que indique que aún no fue procesado
        </p>
        <p>Se dará de alta una deuda si cumple alguna de las siguientes condiciones:</p>
        <ul>
            <li>No existe una PreConfección BtoB con el identificador de la deuda para la Recaudadora en estado Habilitado</li>
            <li>Existe una PreConfección BtoB con el identificador de la deuda para la Recaudadora en estado Baja y la marca de Eliminado en SI, que indica que fue eliminada por la Recaudadora </li>
         </ul>
        <p>Se modificará la deuda si existe una PreConfección BtoB con el identificador de la deuda en estado Habilitado.</p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container" style="background-color: #dcdced;">

                <div class="form-column">
                    <h4>Agregue el identificador de la deuda</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbIdentificadorDeuda">Identificador de deuda:</label>
                        <asp:TextBox ID="tbIdentificadorDeuda" CssClass="form-control col-5" Text="" runat="server" 
                                placeholder="Agregue la id del pago" onkeypress="return handleKeyPress(event)" />
                    </div>
                </div>

                <div class="form-column">
                    <h4>Creando/Modificando la Preconfección</h4>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCuitVendedor">CUIT Vendedor:</label>
                        <div class="col">
                            <asp:TextBox ID="tbCuitVendedor" CssClass="form-control col-5" Text="" runat="server" placeholder="Cuit del Cliente Vendedor" onkeypress="return handleKeyPress(event)" />
                            <small id="tbCuitVendedorHelp" class="form-text text-muted">Cuit del Cliente Vendedor, 11 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbIdCuentaRecaudacion">Id Cuenta Pagador:</label>
                        <div class="col">
                            <asp:TextBox ID="tbIdCuentaRecaudacion" CssClass="form-control col-5" Text="" runat="server" placeholder="identificador de la cuenta de Recaudación" onkeypress="return handleKeyPress(event)" />
                            <small id="tbIdCuentaRecaudacionHelp" class="form-text text-muted">identificador de la cuenta de Recaudación del Vendedor de 25 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCuitPagador">CUIT Pagador:</label>
                        <div class="col">
                            <asp:TextBox ID="tbCuitPagador" CssClass="form-control col-5" Text="" runat="server" placeholder="Cuit del Cliente Pagador" onkeypress="return handleKeyPress(event)" />
                            <small id="tbCuitPagadorHelp" class="form-text text-muted">Cuit del Cliente Pagador, 11 caracters</small>
                         </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbNroComprobante">Número de Comprobante:</label>
                        <div class="col">
                            <asp:TextBox ID="tbNroComprobante" CssClass="form-control col-5" Text="" runat="server" placeholder="Número de Comprobante/Factura" onkeypress="return handleKeyPress(event)" />
                            <small id="tbNroComprobanteHelp" class="form-text text-muted">Número de Comprobante/Factura, hasta 40 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3  text-right" for="bMoneda">Moneda</label>
                        <div class="col">
                            <asp:TextBox ID="tbMoneda" CssClass="form-control col-5" Text="" runat="server" placeholder="ARS=Pesos/USD=Dólares Según ISO4217">ARS</asp:TextBox>
                            <small id="tbMonedaHelp" class="form-text text-muted">ARS=Pesos/USD=Dólares Según ISO4217</small>
                        </div>
                    </div>

                    <!--primer vencimiento -->

                    <div class="form-group row m-2" >
                        <label class="col-form-label col-3 text-right" for="tbFecha1erVencimiento">Fecha primer vencimiento(yyyy-MM-dd):</label>
                        <div class="col">
                            <asp:TextBox ID="tbFecha1erVencimiento" CssClass="form-control col-5" runat="server" placeholder="yyyy-MM-ddd" />
                            <small id="tbFecha1erVencimientoHelp" class="form-text text-muted align-content-start">Fecha de Vencimiento, formato fecha yyyy-MM-dd</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbImporte1erVencimiento">Importe Primer Vencimiento</label>
                        <div class="col">
                            <asp:TextBox ID="tbImporte1erVencimiento" CssClass="form-control col-5" Text="" runat="server" placeholder="Importe a pagar del 1er Vencimiento" />
                            <small id="tbImporte1erVencimientoHelp" class="form-text text-muted">Importe a pagar del 1er Vencimiento, formato:14 enteros 2 decimales</small>
                        </div>
                    </div>

                    <!--segundo vencimiento -->

                    <div class="form-group row m-2" >
                        <label class="col-form-label col-3 text-right" for="tbFecha1erVencimiento">Fecha Segundo vencimiento(yyyy-MM-dd):</label>
                        <div class="col">
                            <asp:TextBox ID="tbFecha2doVencimiento" CssClass="form-control col-5" Text="" runat="server" placeholder="Fecha de Vencimiento" />
                            <small id="tbFecha2doVencimientoHelp" class="form-text text-muted">Fecha de Vencimiento, formato fecha yyyy-MM-dd</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbImporte1erVencimiento">Importe Segundo Vencimiento</label>
                        <div class="col">
                            <asp:TextBox ID="tbImporte2doVencimiento"  CssClass="form-control col-5" Text="" runat="server" placeholder="Importe a pagar del 2do Vencimiento," />
                            <small id="tbImporte2doVencimientHelp" class="form-text text-muted">Importe a pagar del 2do Vencimiento, formato:14 enteros 2 decimales</small>
                        </div>
                    </div>

                    <!--tercer vencimiento -->

                    <div class="form-group row m-2" >
                        <label class="col-form-label col-3 text-right" for="tbFecha3erVencimiento">Fecha Tercer vencimiento(yyyy-MM-dd):</label>
                        <div class="col">
                            <asp:TextBox ID="tbFecha3erVencimiento"  CssClass="form-control col-5" Text="" runat="server" placeholder="Fecha de Vencimiento" />
                            <small id="tbFecha3erVencimientoHelp" class="form-text text-muted">Fecha de Vencimiento, formato fecha yyyy-MM-dd</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbImporte3erVencimiento">Importe Tercer Vencimiento</label>
                        <div class="col">
                            <asp:TextBox ID="tbImporte3erVencimiento" CssClass="form-control col-5" Text="" runat="server"  placeholder="Importe a pagar del 3er Vencimiento" />
                            <small id="tbImporte3erVencimientoHelp" class="form-text text-muted">Importe a pagar del 3er Vencimiento, formato:14 enteros 2 decimales</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCodigoVinculacion">Código Vinculación</label>
                        <div class="col">
                            <asp:TextBox ID="tbCodigoVinculacion" CssClass="form-control col-5" Text="" runat="server" placeholder="Código con el Cliente" onkeypress="return handleKeyPress(event)" />
                            <small id="tbCodigoVinculacionHelp" class="form-text text-muted">Código con el Cliente se vincula cuando necesita una vinculación distinta a CUIT, 50 Caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbObservacion1">Observación 1</label>
                        <div class="col">
                            <asp:TextBox ID="tbObservacion1" CssClass="form-control col-5" Text="" runat="server" placeholder="Observación 1"/>
                            <small id="tbObservacion1Help" class="form-text text-muted">Se pueden Ingresar hasta 60 caracteres, van a aparecer en la transferencia (por eso el límite)</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbObservacion2">Observación 2</label>
                        <div class="col">
                            <asp:TextBox ID="tbObservacion2" CssClass="form-control col-5" Text="" runat="server" placeholder="Observación 2"/>
                            <small id="tbObservacion2Help" class="form-text text-muted">Se puede ingresar hasta 250 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbObservacion3">Observación 3</label>
                        <div class="col">
                            <asp:TextBox ID="tbObservacion3" CssClass="form-control col-5" Text="" runat="server" placeholder="Observación 2"/>
                            <small id="tbObservacion3Help" class="form-text text-muted">Se puede ingresar hasta 250 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbLocalidad">Localidad</label>
                        <div class="col">
                            <asp:TextBox ID="tbLocalidad" CssClass="form-control col-5" Text="" runat="server" placeholder="Localidad"/>
                            <small id="tbLocalidadHelp" class="form-text text-muted">Se pueden ingresar hasta 60 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbProvincia">Provincia</label>
                        <div class="col">
                            <asp:TextBox ID="tbProvincia" CssClass="form-control col-5" Text="" runat="server" placeholder="Provincia"/>
                            <small id="tbProvinciaHelp" class="form-text text-muted">Se pueden ingresar hasta 60 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCodigoPostal">Código Postal</label>
                        <div class="col">
                            <asp:TextBox ID="tbCodigoPostal"
                                            style="font-size: 14px; font-family: sans-serif;" 
                                            CssClass="form-control col-5" Text="" runat="server" placeholder="Código Postal"/>
                            <small id="tbCodigoPostalHelp" class="form-text text-muted">Se pueden ingresar hasta 60 caracteres</small>
                        </div>
                    </div>

                    <div class="form-group row m-2">
                        <label class="col-form-label col-3 text-right" for="tbCodigoBarra">CodigoBarra</label>
                        <div class="col">
                            <asp:TextBox ID="tbCodigoBarra"
                                            style="font-size: 14px; font-family: sans-serif;" 
                                            CssClass="form-control col-5" Text="" runat="server" placeholder="Código de Barra"/>
                            <small id="tbCodigoBarraHelp" class="form-text text-muted">Se pueden ingresar hasta 60 caracteres</small>
                        </div>
                    </div>
                </div>

                <div class="form-group text-center">
                    <asp:Button ID="btnEnviarDeuda" runat="server" OnClick="btnEnviarDeuda_Click" CssClass="btn btn-sm btn-primary"  Text="Enviar Deuda"/>                            
                </div>
            </div>

            <div class="form-group text-center">
                <label>Objecto enviado:</label>
                <div style="position:relative; width: 100%; background: #fffef4; text-align: left; border: 1px solid black;">
                    <button onclick="copiarAlPortapapelesEnviado()" class="btn fa"  style="position: absolute; top: 5px; right: 5px; background-color: #007bff;"><i class="fa fa-solid fa-copy"></i></button>
                    <div id="dvContenidoEnviado"><asp:Literal ID="tbEnviado" runat="server" Mode="PassThrough"/></div>
                </div>
            </div>
                        
            <div class="form-group text-center">
                <label>Mensajes recibidos:</label>
                <div style="position:relative; width: 100%; background: #fffef4; text-align: left; border: 1px solid black;">
                    <button onclick="copiarAlPortapapeles()" class="btn fa" style="position: absolute; top: 5px; right: 5px; background-color: #007bff;"><i class="fa fa-solid fa-copy"></i></button>
                    <div id="dvContenido" class="code"><asp:Literal ID="tbRespuesta" runat="server" Mode="PassThrough"/></div>
                </div>
            </div>

            <div class="text-center">
                <asp:HyperLink Id="btnConsultaDeuda" Visible="false" CssClass="btn btn-primary" NavigateUrl="consultaDeuda" Text="Consulta de deuda creada" runat="server"/>
            </div>

            <script>

                function highlightSyntax() {
                    document.querySelectorAll('pre code').forEach((block) => {
                        hljs.highlightBlock(block);
                    });
                }

                function handleKeyPress(event) {
                    var charCode = event.charCode;

                    // Permitir solo números (del 0 al 9) y la coma (código ASCII 44)
                    if ((charCode < 48 || charCode > 57) && charCode !== 44) {
                        return false;
                    }
                }

                function copiarAlPortapapelesEnviado() {
                    // Selecciona el contenido del div
                    var contenidoDiv = document.querySelector('#dvContenidoEnviado')
                    var rango = document.createRange();
                    rango.selectNodeContents(contenidoDiv);
                    var seleccion = window.getSelection();
                    seleccion.removeAllRanges();
                    seleccion.addRange(rango);

                    // Copia el contenido al portapapeles
                    document.execCommand('copy');

                    // Deselecciona el contenido
                    seleccion.removeAllRanges();

                    // Puedes agregar una alerta o algún otro tipo de retroalimentación
                    alert('Contenido copiado al portapapeles');
                }

                function copiarAlPortapapeles() {
                    var contenidoDiv = document.querySelector('#dvContenido').innerText;

                    // Crear un área de texto temporal
                    var areaTextoTemporal = document.createElement('textarea');
                    areaTextoTemporal.value = contenidoDiv;

                    // Asegurarse de que el área de texto sea visible para poder seleccionar su contenido
                    areaTextoTemporal.style.position = 'fixed';
                    areaTextoTemporal.style.opacity = 0;

                    // Agregar el área de texto al cuerpo del documento
                    document.body.appendChild(areaTextoTemporal);

                    // Seleccionar el contenido del área de texto
                    areaTextoTemporal.select();
                    document.execCommand('copy');

                    // Eliminar el área de texto temporal
                    document.body.removeChild(areaTextoTemporal);

                    // Puedes agregar una alerta o algún otro tipo de retroalimentación
                    alert('Contenido copiado al portapapeles');
                }
            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
