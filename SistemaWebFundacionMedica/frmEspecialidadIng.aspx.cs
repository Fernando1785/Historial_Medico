using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CapaLogicaNegocios;
using CapaDatos;
using CapaDatos.pojos;

namespace SistemaWebFundacionMedica
{
    public partial class frmEspecialidadIng : System.Web.UI.Page
    {
        Int32 id_espe = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarGrilla();

                btnModificar.Enabled = false;
                btnIngreso.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }


        protected void cargarGrilla()
        {
            Especiadidad espe = new Especiadidad();
            Datos dato = new Datos();
            DataTable dt = new DataTable();
            dt = espe.traerEspecialidadcbx();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {

            Especiadidad esp;
            LogicaEspecialidad logEspe;
            Datos datos;
            DataTable dt;

            logEspe = new LogicaEspecialidad();
            esp = new Especiadidad();
            dt = new DataTable();
            dt = logEspe.BuscarEspecialidad(txtEspe.Text.Trim());
            if (dt.Rows.Count >= 1)
            {
                tblErrorm.Visible = true;
                lblErrorm.Text = "Especialidad ya Existe!!!!";
            }
            else
            {
                LogicaEspecialidad espe = new LogicaEspecialidad();
                Boolean ingreso = espe.IngresarEspecialidad(txtEspe.Text.Trim());
                if (ingreso)
                {
                    cargarGrilla();
                    this.txtEspe.Text = "";
                }

                tblErrorm.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                this.tblDatos.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(GridView1.DataKeys[index].Value);
                txtid.Text = GridView1.DataKeys[index].Value.ToString();
                string espe = GridView1.Rows[index].Cells[2].Text;
                txtEspe.Text = espe;
                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnIngreso.Enabled = false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            // Set the new page index of GridView
            GridView1.PageIndex = newPageIndex;
            cargarGrilla();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            id_espe = Convert.ToInt32(txtid.Text.Trim());
            LogicaEspecialidad espe = new LogicaEspecialidad();
            Boolean ingreso = espe.ModificarPaciente(txtEspe.Text.Trim(),id_espe);
            if (ingreso)
            {
                cargarGrilla();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LogicaEspecialidad espe = new LogicaEspecialidad();
            Boolean eliminar = espe.eliminarEspecialidad(txtid.Text.Trim());
            if (eliminar)
            {
                cargarGrilla();

            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtEspe.Text = "";
            this.txtid.Text = "";
            this.tblDatos.Visible = true;
            this.btnNuevo.Enabled = false;
            this.btnIngreso.Enabled = true;
            this.txtEspe.Focus();
        }
    }
}
