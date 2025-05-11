using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_5B
{
    public partial class CargaDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                lblDireccionError.Visible = true;
            }
            else
            {
                lblDireccionError.Visible = false;
            }

            if (!cbTerminos.Checked)
            {
                lblTerminosError.Visible = true;
                return;
            }
            else
            {
                lblTerminosError.Visible = false;
            }

            // Resto de logica
        }
    }
}