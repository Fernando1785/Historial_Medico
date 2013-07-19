using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocios;
using CapaDatos;
using CapaDatos.pojos;

namespace SistemaWebFundacionMedica
{
    public partial class DefaultLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Negocio log = new Negocio();
            if (log.validar_email(TextEmail.Text.Trim()))
            {
                panelMensaje.Visible = false;
                //existe despues del select

                panelMensaje.Visible = false;
                Session["SESION_INICIADA"] = "SI";
                //Session["CEDULA"] = ds.Tables(0).Rows(0)("ci").ToString();
                //Session["CONTRASENA"] = ds.Tables(0).Rows(0)("contrasena").ToString();
                Response.Redirect("frmWebInicio.aspx");

            }
            else
            {
                lblMensaje.Text = "Dirección de email no válida ";
                panelMensaje.Visible = true;
            }

        }
    }
}
