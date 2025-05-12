using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_5B
{

    public partial class SeleccionPremio : System.Web.UI.Page
    {
        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                string codigoVoucher = Request.QueryString["codigo"];
                string idArticulo = e.CommandArgument.ToString();
                Response.Redirect($"CargaDatos.aspx?codigo={codigoVoucher}&idArticulo={idArticulo}");
            }
        }
        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Articulo articulo = (Articulo)e.Item.DataItem;
            var rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");// No puedo acceder directo al repeater pq esta dentro del repeater principal
            if (articulo.imagenes != null && articulo.imagenes.Count > 0)
            {
                // acá cargo las imagenes en el repeater
                rptImagenes.DataSource = articulo.imagenes;
                rptImagenes.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Selecciona tu premio - Promo Ganá";

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                var articulos = negocio.Listar();
                rptArticulos.DataSource = articulos;
                rptArticulos.DataBind();
            }
        }
    }
}