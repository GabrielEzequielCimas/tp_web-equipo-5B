<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionPremio.aspx.cs" Inherits="TPWeb_equipo_5B.SeleccionPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Seleccioná tu premio</h2>
<asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound" OnItemCommand="rptArticulos_ItemCommand">
    <ItemTemplate>
        <div class="card mb-4" style="width: 18rem;">

            <!-- el carousel para mostrare todas las imagenes delk articulo -->

            <div  class="carousel slide" data-bs-ride="carousel">
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

            <!-- Cuerpo de la card -->

            <div class="card-body">
                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                <p class="card-text"><%# Eval("Descripcion") %></p>
                <p class="card-text"><strong>$<%# Eval("Precio") %></strong></p>

            <!-- boton poara seleccionar -->

                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Eval("IdArticulo") %>' CssClass="btn btn-primary mt-2" />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>