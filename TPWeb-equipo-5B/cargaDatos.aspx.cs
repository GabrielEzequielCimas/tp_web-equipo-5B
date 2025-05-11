using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace TPWeb_equipo_5B
{
    public partial class CargaDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar parametros al cargar la pagina
                string codigoVoucher = Request.QueryString["codigo"];
                string idArticuloStr = Request.QueryString["idArticulo"];

                if (string.IsNullOrEmpty(codigoVoucher))
                {
                    MostrarError("Falta el codigo de voucher. Por favor, regrese e ingrese un codigo valido.");
                    btnSubmit.Enabled = false;
                    return;
                }

                if (string.IsNullOrEmpty(idArticuloStr))
                {
                    MostrarError("No se ha seleccionado un articulo. Por favor, regrese y seleccione un premio.");
                    btnSubmit.Enabled = false;
                    return;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validar campos del formulario
            bool validacionExitosa = true;

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                lblDireccionError.Visible = true;
                validacionExitosa = false;
            }
            else
            {
                lblDireccionError.Visible = false;
            }

            if (!cbTerminos.Checked)
            {
                lblTerminosError.Visible = true;
                validacionExitosa = false;
            }
            else
            {
                lblTerminosError.Visible = false;
            }

            if (!validacionExitosa) return;

            // Procesar voucher
            try
            {
                string codigoVoucher = Request.QueryString["codigo"];
                string idArticuloStr = Request.QueryString["idArticulo"];

                // Verificar si llego el codigo de voucher
                if (string.IsNullOrEmpty(codigoVoucher))
                {
                    MostrarError("Error: Código de voucher no encontrado.");
                    return;
                }

                if (string.IsNullOrEmpty(idArticuloStr) || !int.TryParse(idArticuloStr, out int idArticulo))
                {
                    MostrarError("Error: Artículo no válido.");
                    return;
                }

                VoucherNegocio voucherNegocio = new VoucherNegocio();

                // Verificar si el voucher existe
                if (!voucherNegocio.BuscarVoucher(codigoVoucher))
                {
                    MostrarError("El código de voucher no es válido.");
                    return;
                }

                if (voucherNegocio.VoucherYaCanjeado(codigoVoucher))
                {
                    MostrarError("Este voucher ya ha sido canjeado anteriormente.");
                    return;
                }

                int idCliente = voucherNegocio.InsertarCliente(
                    txtDNI.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    txtEmail.Text,
                    txtDireccion.Text,
                    txtCiudad.Text,
                    txtCP.Text
                );

                bool canjeExitoso = voucherNegocio.CanjearVoucher(codigoVoucher, idCliente, idArticulo);

                if (canjeExitoso)
                {
                    Response.Redirect("ExitoCanje.aspx?codigo=" + codigoVoucher);
                }
                else
                {
                    MostrarError("No se pudo completar el canje. Por favor, intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        private void MostrarError(string mensaje)
        {
            pnlError.Visible = true;
            lblError.Text = mensaje;
        }
    }
}