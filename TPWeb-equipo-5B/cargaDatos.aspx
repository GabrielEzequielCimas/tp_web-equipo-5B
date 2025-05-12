<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaDatos.aspx.cs" Inherits="TPWeb_equipo_5B.CargaDatos" %><asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title" class="container mt-4">
        <h1 class="mb-4">Ingresá tus datos</h1>

        <!-- DNI -->
        <div class="mb-3">
            <h6>DNI</h6>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control mb-2" placeholder="99888777" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged"></asp:TextBox>
        </div>

        <!-- Informacion Personal -->
        <div class="mb-3">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-2" placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control mb-2" placeholder="Apellido"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-2" placeholder="email@email.com" TextMode="Email"></asp:TextBox>
        </div>

        <!-- Direccion -->
        <div class="mb-3">
            <h6>Dirección</h6>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control mb-2" placeholder="Calle 123"></asp:TextBox>
            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control mb-2" placeholder="Mi ciudad"></asp:TextBox>
            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control mb-2" placeholder="XXXX"></asp:TextBox>
            <asp:Label ID="lblDireccionError" runat="server" CssClass="text-danger small" Text="Falta dirección." Visible="false"></asp:Label>
        </div>

        <!-- Checkboxes -->
        <div class="mb-4">
            <div class="form-check mb-2">
                <asp:CheckBox ID="cbTerminos" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="<%= cbTerminos.ClientID %>">Acepto los términos y condiciones.</label>
            </div>
            <asp:Label ID="lblTerminosError" runat="server" CssClass="text-danger small" Text="Por favor acepte los términos y condiciones." Visible="false"></asp:Label>
        </div>

        <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert alert-danger">
            <asp:Label ID="lblError" runat="server" />
        </asp:Panel>

        <asp:Panel ID="pnlExito" runat="server" Visible="false" CssClass="alert alert-success">
            <asp:Label ID="lblExito" runat="server" />
        </asp:Panel>

        <!-- Boton Submit -->
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Participar!" CssClass="btn btn-primary px-4" OnClick="btnSubmit_Click" />
        </div>
    </main>

</asp:Content>