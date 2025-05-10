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
    public partial class SeleccionPremio : System.Web.UI.Page
    {
        public List<Articulo> listaPremios;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void cargarPremios()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaPremios = negocio.Listar();
        }
    }
}