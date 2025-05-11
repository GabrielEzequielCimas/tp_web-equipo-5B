﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionPremio.aspx.cs" Inherits="TPWeb_equipo_5B.SeleccionPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center my-4">Elegí tu premio</h2>
    <div class="row justify-content-center">
        <asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound" OnItemCommand="rptArticulos_ItemCommand">
            <ItemTemplate>
                <div class="col-md-4 d-flex justify-content-center mb-4">
                    <div class="card" style="width: 18rem;">
                        <!-- Carrusel para mostrar los premios -->
                        <div id="carousel_<%# Eval("IdArticulo") %>" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src="<%# Eval("Url") %>" class="d-block w-100" alt="Imagen" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel_<%# Eval("IdArticulo") %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon"></span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carousel_<%# Eval("IdArticulo") %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon"></span>
                            </button>
                        </div>

                        <!-- Cuerpo de la tarjeta -->
                        <div class="card-body text-center">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <!--- Boton Seleccionar -->
                            <asp:Button ID="btnSeleccionar" runat="server" Text="¡Quiero este!" CommandName="Seleccionar" CommandArgument='<%# Eval("IdArticulo") %>' CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
