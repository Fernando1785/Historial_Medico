using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaDatos.pojos;
using System.Data.SqlClient;
using System.Data;



namespace CapaLogicaNegocios
{
  public class LogicaPaciente
    {
        Paciente mypaciente;


        public DataTable ObtenerPaciente()
        {
            mypaciente = new Paciente();
            DataTable dt = mypaciente.ObtenerPacienteSP();

            return dt;
        }

        public DataTable BuscarPaciente(string cedula)
        {
            mypaciente = new Paciente();
            DataTable dt = mypaciente.buscarPacienteSP(cedula);
            return dt;
        }

        public DataTable BuscarPacienteApellido(string apellido)
        {
            mypaciente = new Paciente();
            DataTable dt = mypaciente.buscarPacienteApellidoSp(apellido);
            return dt;
        }

        public Boolean IngresarPaciente(Paciente paciente)
        {
            Boolean inserto = false;
            mypaciente = new Paciente();
            inserto = mypaciente.IngresarPacienteSP(paciente);
            return inserto;
        }
        public Boolean ModificarPaciente(Paciente paciente)
        {
            Boolean inserto = false;
            mypaciente = new Paciente();
            inserto = mypaciente.modificarPacienteSp(paciente);
            return inserto;
        }

        public Boolean eliminarPaciente(String idpaciente)
        {
            Boolean inserto = false;
            mypaciente = new Paciente();
            inserto = mypaciente.eliminarPaciente(Convert.ToInt32(idpaciente));
            return inserto;
        }

    }


}
