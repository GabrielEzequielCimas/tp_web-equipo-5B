using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_5B
{
    public partial class Promo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void validarVoucher (string voucher) {
            VoucherNegocio negocio = new VoucherNegocio();
            List<Vouchers> listaVouchers = negocio.Listar();
            bool encontrado =false;
            bool invalido = false;
            foreach (Vouchers buscarVoucher in listaVouchers)
            {
                if (buscarVoucher.codigoVoucher == voucher)
                {
                    encontrado = true;
                    
                    if (buscarVoucher.FechaCanje != null)
                    {
                        invalido = true;
                    }
                }
            }
            if (encontrado == true && invalido == false)
            {
                lblMensaje.Text = "Voucher válido.";
            }
            else if (encontrado == true)
            {
                lblMensaje.Text = "El voucher ya fue usado.";
            }
            else
            {
                lblMensaje.Text = "Voucher inválido.";
            }

        }

        protected void btnIngresoVoucher_Click(object sender, EventArgs e)
        {
            validarVoucher(txtVoucher.Text);
        }
    }
}