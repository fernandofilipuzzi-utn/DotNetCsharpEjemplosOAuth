<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="credenciales_edicion.aspx.cs" Inherits="JWTBearer_SimpleServer.Admin.credenciales_edicion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div class="container" style="min-width: 786px;">
                 

        <div class="row m-0 p-0">

            <div class="col-12 m-0 p-0">

                <div class="row justify-content-end p-t-3" >
			        <div class="form-group col-4">
                        <asp:CheckBox ID="chkHabilitadoCredencial" CssClass="switch" runat="server"/>                    
                        <label for="<%=chkHabilitadoCredencial.ClientID%>" class="form-label" >Habilitar</label>
                    </div>
                </div>

                <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">

                    <div class="row text-center p-4">
                        <div class="col-12"><h4>Credencial de acceso del módulo</h4></div>
                    </div>

                    <div class="form-group row p-2">
                        <label class="col-form-label col-3 text-right" for="<%=tbIdCredencial%>"">Id:</label>
                        <div class="col-9">
                            <div class="row">
                                <asp:TextBox ID="tbIdCredencial" CssClass="form-control text-muted form-control-lg col-12" 
                                        Text="" runat="server" Enabled="false" placeholder="Id credencial" />
                            </div>
                        </div>
                    </div>

                    <div class="form-group row p-2">
                        <label class="col-form-label col-3 text-right" for="tbGuidCredencial">GUID Cliente(client id):</label>
                        <div class="col-9">
                            <div class="row">
                                <asp:TextBox ID="tbGuidCredencial" MaxLength="50" CssClass="form-control form-control-lg col-12" 
                                                Text="" runat="server" placeholder="GUID Generado" />
                            </div>
                            <div class="row p-0 m-0">
                                <div class="col">
                                    <small class="form-text text-muted col-12">Máximo 50 caracteres</small>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row p-2">
                        <label class="col-form-label col-3 text-right" for="tbClaveCredencial">Clave secreta:</label>
                        <div class="col-9">
                            <div class="row">
                                <asp:TextBox ID="tbClaveCredencial" MaxLength="50" CssClass="form-control form-control-lg col-12" Text="" runat="server" placeholder="Clave" />
                            </div>
                            <div class="row p-0 m-0">
                                <div class="col">
                                    <small class="form-text text-muted col-12">Máximo 50 caracteres</small>
                                    <small class="form-text text-muted col-12">clave alfanumérica</small>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row p-2">
                        <label class="col-form-label col-3 text-right" for="tbDescripcionCredencial">Breve descripción:</label>
                        <div class="col-9">
                            <div class="row">
                                <asp:TextBox ID="tbDescripcionCredencial" MaxLength="50" CssClass="form-control form-control-lg col-12" Text="" runat="server" placeholder="Breve descripción" />
                            </div>
                            <div class="row p-0 m-0">
                                <div class="col">
                                    <asp:RequiredFieldValidator ID="rfvDescripcionCredencial" runat="server" ControlToValidate="tbDescripcionCredencial" InitialValue="" ErrorMessage="Campo requerido." ForeColor="Red" Display="Dynamic" />
                                    <small class="form-text text-muted col-12">Máximo 50 caracteres</small>
                                    <small id="smDescripcionCredencial" class="form-text text-muted col-12">Etiqueta para identificar la credencial - (nombre municipalidad)</small>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row p-2">
                        <label class="col-form-label col-3 text-right" for="tbScopesCredencial">Scopes:</label>
                        <div class="col-9">
                            <div class="row">
                                <asp:TextBox ID="tbScopesCredencial" MaxLength="50" CssClass="form-control form-control-lg col-12" Text="" runat="server" placeholder="Scopes" />
                            </div>
                            <div class="row">
                                <small id="smScope" class="form-text text-muted col-12">Scopes separados por espacios (ejemplo 1: api1), (ejemplo 2: api1 api2)</small>
                            </div>
                        </div>
                    </div>

                    <div class="form-group text-center p-2">
                        <asp:Button ID="btnConfirmarOPCredencial" runat="server" OnClick="btnConfirmarOPCredencial_Click" CssClass="btn btn-sm btn-primary" Text="Agregar Credencial" />
                    </div>
                
                </div>

                <div class="col-12 mb-3 mt-3 justify-content-center" style="background-color: #dcdced;">

                    <div class="row text-center p-2 m-3 ">
                        <div class="col-12">
                            <h4>Modulos</h4>
                        </div>
                    </div>

                    <asp:ListView ID="lvModulos" InsertItemPosition="LastItem" OnItemDataBound="lvModulos_ItemDataBound" runat="server">

                        <LayoutTemplate>
                            <table class="table table-condensed table-borderless table-hover text-center">
                                <thead class="table-dark">
                                    <th class="col-2">Id</th>
                                    <th class="col-2">Descripción</th>
                                    <th class="col-7">URL</th>
                                    <th class="col-1"></th>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </tbody>
                            </table>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <tr>
                                <td class="col-2">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:TextBox ID="tbEdIdModulo" Enabled="false" CssClass="form-control form-control-lg text-muted col-12" Text='<%#Eval("id")%>' runat="server" placeholder="descripción" />
                                        </div>
                                    </div>
                                </td>
                                <td class="col-2">
                                    <asp:TextBox ID="tbEdDescripcionModulo" MaxLength="50" Enabled="false" CssClass="form-control form-control-lg text-muted col-12" Text='<%#Eval("descripcion")%>' runat="server" placeholder="descripción" />
                                </td>
                                <td class="col-7">
                                    <asp:TextBox ID="tbEdUrlModulo" MaxLength="200" CssClass="form-control form-control-lg col-12" Text='<%#Eval("url")%>' runat="server" placeholder="url" /></td>
                                <td class="col-1">
                                    <asp:LinkButton ID="lbtnEdModificarModulo" OnClick="lbtnEdModificarModulo_Click" runat="server"><i class="fas fa-pencil-alt"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnEdEliminarModulo" OnClick="lbtnEdEliminarModulo_Click" runat="server"><i class="fas fa-trash"></i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <InsertItemTemplate>

                            <asp:UpdatePanel ID="UpdatePanelInsert" runat="server">
                                <ContentTemplate>

                                    <tr>
                                        <td class="col-2">
                                            <div class="row">
                                                <div class="col-12">
                                                    <asp:TextBox ID="tbInsertIdModulo" Enabled="false" CssClass="form-control text-muted col-12" Text="" runat="server" placeholder="Id" />
                                                </div>
                                            </div>
                                        </td>
                                        <td class="col-2">
                                            <div class="row">
                                                <div class="col-12">
                                                    <asp:TextBox ID="tbInsertDescripcionModulo" MaxLength="50" CssClass="form-control col-12" Text="" runat="server" placeholder="Descripcion" />
                                                    <small class="form-text text-muted">Máximo 50 caracteres</small>
                                                </div>

                                            </div>
                                        </td>
                                        <td class="col-7">
                                            <div class="row">
                                                <div class="col-12">
                                                    <asp:TextBox ID="tbInsertUrlModulo" MaxLength="50" CssClass="form-control col-12" Text="" runat="server" placeholder="URL" />
                                                </div>
                                                <small class="form-text text-muted">Máximo 50 caracteres</small>
                                            </div>
                                        </td>
                                        <td class="col-1">
                                            <div class="col-12">
                                                <asp:LinkButton ID="lBtnAgregarNuevoModulo" OnClick="lbtnInsertNuevoModulo_Click" runat="server"><i class="fas fa-plus"></i></asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </InsertItemTemplate>

                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
