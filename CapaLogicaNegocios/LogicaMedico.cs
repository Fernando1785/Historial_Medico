using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaDatos.pojos;
using System.Data.SqlClient;
using System.Data;

namespace CapaLogicaNegocios
{
     public class  LogicaMedico
    { 
        Medico mymedico;

        public DataTable ObtenerMedico()
        {
            mymedico = new Medico();
            DataTable dt = mymedico.ObtenerMedicoSp();
            return dt;
        }

        public DataTable BuscarMedico(string cedula)
        {
            mymedico = new Medico();
            DataTable dt = mymedico.buscarMedicoSP(cedula);
            return dt;
        }

        public DataTable BuscarMedicoApellido(string apellido)
        {
            mymedico = new Medico();
            DataTable dt = mymedico.buscarPacienteApellidoSp(apellido);
            return dt;
        }
        public Boolean IngresarMedico(Medico medico)
        {
            Boolean inserto = false;
            mymedico = new Medico();
            inserto = mymedico.IngresarMedicoSP(medico);
            return inserto;
        }

        public Boolean ModificarMedico(Medico medico)
        {
            Boolean inserto = false;
            mymedico = new Medico();
            inserto = mymedico.modificarMedicoSp(medico);
            return inserto;
        }

        public Boolean eliminarMedico(String idmedico)
        {
            Boolean inserto = false;
            mymedico = new Medico();
            inserto = mymedico.eliminarMedico(Convert.ToInt32(idmedico));
            return inserto;
        }
    }
}
