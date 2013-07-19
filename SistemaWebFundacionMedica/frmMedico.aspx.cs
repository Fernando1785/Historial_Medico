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
    public partial class frmMedico : System.Web.UI.Page
    {
        Medico med;
        LogicaEspecialidad logEspe;
        LogicaMedico logMedi;
        Datos datos;
        DataTable dt;

         protected void Page_Load(object sender, EventArgs e)
        {

               if (!IsPostBack)
            {
                llenarEspecialidad();
                llenarSexo();
                cargarMedico();

                btnModificar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            }

          
        }


        private void cargarMedico()
        {
            logMedi = new LogicaMedico();
            dt = logMedi.ObtenerMedico();
            gridMedico.DataSource = dt;
            gridMedico.DataBind();
        }

        private void llenarEspecialidad()
        {
            logEspe = new LogicaEspecialidad();
            dt = new DataTable();
            dt = logEspe.ObtenerEspecialidad();
            cbxespecialidadm.DataSource = dt;
            cbxespecialidadm.DataValueField = "ID_ESPECIALIDAD";
            cbxespecialidadm.DataTextField = "NOMBRE_ESPECIALIDAD";
            cbxespecialidadm.DataBind();
        }


        private void llenarSexo()
        {
            datos = new Datos();
            dt = new DataTable();
            dt = datos.TraerSexo();
            cbxSexom.DataSource = dt;
            cbxSexom.DataValueField = "ID_SEXO";
            cbxSexom.DataTextField = "NOMBRE_SEXO";
            cbxSexom.DataBind();
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
             logMedi = new LogicaMedico();
             med = new Medico();
             dt = new DataTable();
             dt =  logMedi.BuscarMedico(txtCedulam.Text.Trim());
             if (dt.Rows.Count >= 1)
             {
                 tblErrorm.Visible = true;
                 lblErrorm.Text = "Cédula ya Existe!!!!";
             }
             else
             {
                 med.Ides = Convert.ToInt32(cbxespecialidadm.SelectedValue);
                 med.Cedula = txtCedulam.Text.Trim();
                 med.Nombre = txtNombrem.Text.Trim();
                 med.Apellido = txtApellidom.Text.Trim();
                 med.Fecha = Convert.ToDateTime(txtFechaMedico.Text);
                 med.Edad = Convert.ToInt32(txtEdadm.Text.Trim());
                 med.Sexo = cbxSexom.SelectedValue;
                 med.Direc = txtDireccionm.Text.Trim();
                 med.Telef = txtTelefonom.Text.Trim();
                 med.Celular = txtCelularm.Text.Trim();

                 logMedi.IngresarMedico(med);
                 cargarMedico();
                 tblErrorm.Visible = false;
             }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtmedicom.Text = "";

            //ya esta pues solo le llamas

            limpiarDatos();
           
            this.tblDatos.Visible = true;
            this.btnNuevo.Enabled = false;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.cbxespecialidadm.Focus();
        }

        private void limpiarDatos()
        {
            txtCedulam.Text = "";
            txtNombrem.Text = "";
            txtApellidom.Text = "";
            txtFechaMedico.Text = "";
            txtEdadm.Text="";
            txtDireccionm.Text = "";
            txtTelefonom.Text = "";
            txtCelularm.Text = "";
        }
        
        #region metodos para el gridview
        protected void gridMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gridMedico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                this.tblDatos.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
               // int codigo = Convert.ToInt32(gridMedico.DataKeys[index].Value);
               // txtmedicom.Text = gridMedico.DataKeys[index].Value.ToString();

               // txtmedicom.Text = gridMedico.DataKeys[gridMedico.SelectedIndex].Values[1].ToString();

                //idespec.Text = gridMedico.DataKeys[gridMedico.SelectedIndex].Values[2].ToString();


                txtmedicom.Text = Convert.ToString(gridMedico.DataKeys[index].Values["ID_MEDICO"]);
                String idespecc = Convert.ToString(gridMedico.DataKeys[index].Values["ID_ESPECIALIDAD"]);
                String idsexo = Convert.ToString(gridMedico.DataKeys[index].Values["ID_SEXO"]);

                cbxespecialidadm.SelectedValue = idespecc;
                txtCedulam.Text = gridMedico.Rows[index].Cells[4].Text;
                txtNombrem.Text = gridMedico.Rows[index].Cells[5].Text;
                txtApellidom.Text = gridMedico.Rows[index].Cells[6].Text;
                txtFechaMedico.Text = gridMedico.Rows[index].Cells[7].Text;
                txtEdadm.Text = gridMedico.Rows[index].Cells[8].Text;

                cbxSexom.SelectedValue = idsexo;
                
                txtDireccionm.Text = gridMedico.Rows[index].Cells[11].Text;
                txtTelefonom.Text = gridMedico.Rows[index].Cells[12].Text;
                txtCelularm.Text = gridMedico.Rows[index].Cells[13].Text;

                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = false;
            }
        }

        protected void gridMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            // Set the new page index of GridView
            gridMedico.PageIndex = newPageIndex;
            cargarMedico();
        }

        #endregion

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //id_espe = Convert.ToInt32(txtid.Text.Trim());
            med = new Medico();
            med.Id = Convert.ToInt32(txtmedicom.Text.Trim());
            med.Ides = Convert.ToInt32(cbxespecialidadm.SelectedValue);
            med.Cedula = txtCedulam.Text.Trim();
            med.Nombre = txtNombrem.Text.Trim();
            med.Apellido = txtApellidom.Text.Trim();
            med.Fecha = Convert.ToDateTime(txtFechaMedico.Text);
            med.Edad = Convert.ToInt32(txtEdadm.Text.Trim());
            med.Sexo = cbxSexom.SelectedValue;
            med.Direc = txtDireccionm.Text.Trim();
            med.Telef = txtTelefonom.Text.Trim();
            med.Celular = txtCelularm.Text.Trim();
            logMedi = new LogicaMedico();
            //logMedi.IngresarMedicoSp(med);
            Boolean modificar = logMedi.ModificarMedico(med);
            if (modificar)
            {
                cargarMedico();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            logMedi = new LogicaMedico();
           Boolean eliminar =  logMedi.eliminarMedico(txtmedicom.Text.Trim());
           if (eliminar)
           {
               cargarMedico();
           
           }

        }

        protected void btnActivaBusquedadm_Click(object sender, EventArgs e)
        {
            //Server.Transfer("frmPaciente.aspx");
            //Response.Redirect("frmPaciente.aspx");
            tblDatos.Visible = false;
            tblBusquedam.Visible = true;
            //lo activo cuadno hago la busqueda
            btnLimpiaBusquedam.Enabled = true;
            //    if(this.IsValid)
            //       Response.Redirect("frmPaciente.aspx");

    

        }

        protected void btnLimpiaBusquedam_Click(object sender, EventArgs e)
        {
            //leugo te explico eso ahorita hago este boton
            //este boton va ha ser para resetear la grilla para que veas todos los registros

            //limpias datos
            limpiarDatos();
            //cargas la grilla con todos los datos
            cargarMedico();
            //ocultas la tabla de busqueda con false
            tblBusquedam.Visible = false;
            


        }

        protected void btnBuscaCedulam_Click(object sender, EventArgs e)
        {

            med = new Medico();
            logMedi = new LogicaMedico();
            dt = new DataTable();
            dt = logMedi.BuscarMedico(txtBusquedaCedulam.Text.Trim());
            gridMedico.DataSource = dt;
            gridMedico.DataBind();
        }

        protected void btnBuscaApellidom_Click(object sender, EventArgs e)
        {
            med = new Medico();
            logMedi = new LogicaMedico();
            dt = new DataTable();
            dt = logMedi.BuscarMedicoApellido(txtBusquedaApellidom.Text.Trim());
            gridMedico.DataSource = dt;
            gridMedico.DataBind();

        }

    }
}
