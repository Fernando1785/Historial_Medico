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
    public partial class frmPaciente : System.Web.UI.Page
    {
        Paciente paci;
        LogicaPaciente logPaci;
        //LogicaEspecialidad logEspe;
        Datos datos;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //llenarEspecialidad();
                llenarSexo();
                cargarPaciente();

                //como al inicio no hago la busqueda el boton limpiar busqueda debe estar desactivado
                btnLimpiaBusqueda.Enabled = false;

                btnModificar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            }
         }

          private void cargarPaciente()
        {
            logPaci = new LogicaPaciente();
            dt = logPaci.ObtenerPaciente();
            gridPaciente.DataSource = dt;
            gridPaciente.DataBind();
        }


        

          private void llenarSexo()
          {
              datos = new Datos();
              dt = new DataTable();
              dt = datos.TraerSexo();
              cbxSexop.DataSource = dt;
              cbxSexop.DataValueField = "ID_SEXO";
              cbxSexop.DataTextField = "NOMBRE_SEXO";
              cbxSexop.DataBind();
          }



          #region metodos para el gridview

          protected void gridPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gridPaciente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                this.tblDatos.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
               // int codigo = Convert.ToInt32(gridPaciente.DataKeys[index].Value);
               // txtmedicom.Text = gridPaciente.DataKeys[index].Value.ToString();

               // txtmedicom.Text = gridPaciente.DataKeys[gridPaciente.SelectedIndex].Values[1].ToString();

                //idespec.Text = gridPaciente.DataKeys[gridPaciente.SelectedIndex].Values[2].ToString();


                txtpaciente.Text = Convert.ToString(gridPaciente.DataKeys[index].Values["ID_PACIENTE"]);
                String idsexo = Convert.ToString(gridPaciente.DataKeys[index].Values["ID_SEXO"]);

             
                txtCedulap.Text = gridPaciente.Rows[index].Cells[2].Text;
                txtNombrep.Text = gridPaciente.Rows[index].Cells[3].Text;
                txtApellidop.Text = gridPaciente.Rows[index].Cells[4].Text;
                txtFechaPaciente.Text = gridPaciente.Rows[index].Cells[5].Text;
                txtEdadp.Text = gridPaciente.Rows[index].Cells[6].Text;

                cbxSexop.SelectedValue = idsexo;
                
                txtDireccionp.Text = gridPaciente.Rows[index].Cells[9].Text;
                txtTelefonop.Text = gridPaciente.Rows[index].Cells[10].Text;
                txtCelularp.Text = gridPaciente.Rows[index].Cells[11].Text;

                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = false;
                txtCedulap.ReadOnly = true;
            }
        }

        protected void gridPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            // Set the new page index of GridView
            gridPaciente.PageIndex = newPageIndex;
            cargarPaciente();
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            this.txtpaciente.Text = "";
            limpiarDatos();

            this.tblDatos.Visible = true;
            this.btnNuevo.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.txtCedulap.Focus();
        }


        private void limpiarDatos()
        {
            txtCedulap.Text = "";
            txtNombrep.Text = "";
            txtApellidop.Text = "";
            txtFechaPaciente.Text = "";
            txtEdadp.Text = "";
            txtDireccionp.Text="";
            txtTelefonop.Text="";
            txtCelularp.Text = "";
          
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            paci = new Paciente();
            paci.Id = Convert.ToInt32(txtpaciente.Text.Trim());
            paci.Cedula = txtCedulap.Text.Trim();
            paci.Nombre = txtNombrep.Text.Trim();
            paci.Apellido = txtApellidop.Text.Trim();
            paci.Fecha = Convert.ToDateTime(txtFechaPaciente.Text);
            paci.Edad = Convert.ToInt32(txtEdadp.Text.Trim());
            paci.Sexo = cbxSexop.SelectedValue;
            paci.Direc = txtDireccionp.Text.Trim();
            paci.Telef = txtTelefonop.Text.Trim();
            paci.Celular = txtCelularp.Text.Trim();
            logPaci = new LogicaPaciente();
            Boolean modificar = logPaci.ModificarPaciente(paci);
            if (modificar)
            {
                cargarPaciente();
            }
        }

        protected void btnActivaBusquedad_Click(object sender, EventArgs e)
        {
            //Server.Transfer("frmPaciente.aspx");
            //Response.Redirect("frmPaciente.aspx");
            tblDatos.Visible = false;
            tblBusqueda.Visible = true;
            //lo activo cuadno hago la busqueda
            btnLimpiaBusqueda.Enabled = true;
        //    if(this.IsValid)
           //       Response.Redirect("frmPaciente.aspx");

    
        }

      

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            logPaci = new LogicaPaciente();
             paci = new Paciente();
             dt = new DataTable();
             dt = logPaci.BuscarPaciente(txtCedulap.Text.Trim());
             if (dt.Rows.Count >=1 )
             {
                 tblError.Visible = true;
                 lblError.Text = "Cédula ya Existe!!!!";
             }
             else
             { 
             
             paci.Cedula = txtCedulap.Text.Trim();
             paci.Nombre = txtNombrep.Text.Trim();
             paci.Apellido = txtApellidop.Text.Trim();
             paci.Fecha = Convert.ToDateTime(txtFechaPaciente.Text);
             paci.Edad = Convert.ToInt32(txtEdadp.Text.Trim());
             paci.Sexo = cbxSexop.SelectedValue;
             paci.Direc = txtDireccionp.Text.Trim();
             paci.Telef = txtTelefonop.Text.Trim();
             paci.Celular = txtCelularp.Text.Trim();
         
             logPaci.IngresarPaciente(paci);
            cargarPaciente();

            tblError.Visible = false;

             }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            logPaci = new LogicaPaciente();
            Boolean eliminar = logPaci.eliminarPaciente(txtpaciente.Text.Trim());
            if (eliminar)
            {
                cargarPaciente();

            }

        }


        protected void btnBuscaCedula_Click(object sender, EventArgs e)
        {
            paci = new Paciente();
            logPaci = new LogicaPaciente();
            dt = new DataTable();
            dt = logPaci.BuscarPaciente(txtBusquedaCedula.Text.Trim());
            gridPaciente.DataSource = dt;
            gridPaciente.DataBind();
        }

        protected void btnBuscaApellido_Click(object sender, EventArgs e)
        {
            paci = new Paciente();
            logPaci = new LogicaPaciente();
            dt = new DataTable();
            dt = logPaci.BuscarPacienteApellido(txtBusquedaApellido.Text.Trim());
            gridPaciente.DataSource = dt;
            gridPaciente.DataBind();

        }

        protected void btnLimpiaBusqueda_Click(object sender, EventArgs e)
        {
            //leugo te explico eso ahorita hago este boton
            //este boton va ha ser para resetear la grilla para que veas todos los registros

            //limpias datos
            limpiarDatos();
            //cargas la grilla con todos los datos
            cargarPaciente();
            //ocultas la tabla de busqueda con false
            tblBusqueda.Visible = false;
          


        }
    }
}
    

