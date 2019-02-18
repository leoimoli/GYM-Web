<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarioWF.aspx.cs" Inherits="Gym.Web.ConsultarUsuarioWF" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <%-- <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>--%>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Consulta Usuario</h1>
                            </div>
                            <form class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtDni" class="form-control form-control-user" placeholder="Dni" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="cmbSexo" class="form-control form-control-user" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtApellido" class="form-control form-control-user" placeholder="Apellido" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtNombre" class="form-control form-control-user" placeholder="Nombre" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:Calendar ID="FechaDesde" runat="server"></asp:Calendar>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Calendar ID="FechaHasta" runat="server"></asp:Calendar>
                                    </div>
                                </div>
                                <a href="login.html" class="btn btn-primary btn-user btn-block">Consultar
                </a>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
