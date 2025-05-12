using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using dominio;
using negocio;

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
        protected bool validacion()
        {
            bool validacionExitosa = true;

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                lblDireccionError.Visible = true;
                validacionExitosa = false;
            }
            if (!int.TryParse(txtDNI.Text, out int dni))
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

            return validacionExitosa;
        }

        bool validarParametros()
        {
            string codigoVoucher = Request.QueryString["codigo"];
            string idArticuloStr = Request.QueryString["idArticulo"];


            // Verificar si llego el codigo de voucher
            if (string.IsNullOrEmpty(codigoVoucher))
            {
                MostrarError("Error: Código de voucher no encontrado.");
                return false;
            }

            if (string.IsNullOrEmpty(idArticuloStr) || !int.TryParse(idArticuloStr, out int idArticulo))
            {
                MostrarError("Error: Artículo no válido.");
                return false;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            // Verificar si el voucher existe
            if (!voucherNegocio.BuscarVoucher(codigoVoucher))
            {
                MostrarError("El código de voucher no es válido.");
                return false;
            }

            if (voucherNegocio.VoucherYaCanjeado(codigoVoucher))
            {
                MostrarError("Este voucher ya ha sido canjeado anteriormente.");
                return false;
            }
            return true;
        }

        Cliente cargarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Dni = txtDNI.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.CP = txtCP.Text;
            return cliente;
        }

        int insertarCliente(Cliente cliente)
        {
            try
            {
                int idCliente = 0;
                ClienteNegocio negocio = new ClienteNegocio();
                List<Cliente> listaClientes = negocio.Listar();
                foreach (Cliente buscarCliente in listaClientes)
                {
                    if (buscarCliente.Dni.ToString() == txtDNI.Text)
                    {
                        idCliente = buscarCliente.Id;
                    }
                }
                if (idCliente != 0)
                {
                    cliente.Id = idCliente;
                    negocio.modificar(cliente);
                }
                else
                {
                    negocio.agregar(cliente);
                }
                return idCliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string codigoVoucher = Request.QueryString["codigo"];
            string idArticuloStr = Request.QueryString["idArticulo"];
            // Validar campos del formulario
            bool validacionExitosa = validacion();
            bool validarParametro = validarParametros();

            if (!validacionExitosa || !validarParametro) return;

            int idArticulo = int.Parse(idArticuloStr);

            // Procesar voucher
            try
            {
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                Cliente cliente = new Cliente();
                cliente = cargarCliente();
                int idCliente = insertarCliente(cliente);
                if (idCliente == 0) idCliente = negocio.BuscarIdCliente();

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

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "Evento ejecutado"; // Solo para probar
            lblError.Visible = true;
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listaClientes = negocio.Listar();
            foreach (Cliente buscarCliente in listaClientes)
            {
                if (buscarCliente.Dni.ToString() == txtDNI.Text)
                {
                    txtNombre.Text = buscarCliente.Nombre;
                    txtApellido.Text = buscarCliente.Apellido;
                    txtEmail.Text = buscarCliente.Email;
                    txtDireccion.Text = buscarCliente.Direccion;
                    txtCiudad.Text = buscarCliente.Ciudad;
                    txtCP.Text = buscarCliente.CP;
                }
            }
        }
    }
}