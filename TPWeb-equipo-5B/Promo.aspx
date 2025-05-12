<%@ Page Title="%: Page.Title %" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Promo.aspx.cs" Inherits="TPWeb_equipo_5B.Promo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title" class="container mt-4">
        <h4 class="mb-4">¡Ingresá el código de tu voucher!</h4>

        <div class="mb-3">
            <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control" placeholder="Código del voucher"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnIngresoVoucher" runat="server" OnClick="btnIngresoVoucher_Click" Text="Siguiente" CssClass="btn btn-primary" />
        </div>

        <div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
        </div>
    </main>
    
</asp:Content>