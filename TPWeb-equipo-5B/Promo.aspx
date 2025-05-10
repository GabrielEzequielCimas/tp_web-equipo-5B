<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Promo.aspx.cs" Inherits="TPWeb_equipo_5B.Promo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Ingresá el código de tu voucher!</h3>
        <asp:TextBox ID="txtVoucher" runat="server"></asp:TextBox>
        <asp:Button ID="btnIngresoVoucher" runat="server" OnClick="btnIngresoVoucher_Click" Text="Siguiente" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </main>


</asp:Content>


