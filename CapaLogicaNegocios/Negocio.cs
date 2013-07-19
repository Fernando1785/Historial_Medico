using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaDatos.pojos;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CapaLogicaNegocios
{
   public class Negocio
    {
        public List<Paciente> ObtenerPaciente()
        {
            Datos datos = new Datos();
            List<Paciente> lista = new List<Paciente>();
            Paciente paci = new Paciente();

            DataTable dt = datos.ObtenerPaciente();
            foreach (DataRow r in dt.Rows)
            {
                  paci.Id = Convert.ToInt32(r["ID_PACIENTE"].ToString());
                  paci.Nombre = r["NOMBRE_PACIENTE"].ToString();
                  paci.Apellido = r["APELLIDO_PACIENTE"].ToString();
                  paci.Direc = r["DIRECCION_PACIENTE"].ToString();
                    
                  lista.Add(paci);
            }
            return lista;
        }


        

        public DataTable ObtenerturnoSP()
        {
            Datos datos = new Datos();
            DataTable dt = datos.ObtenerTurnoSp();

            return dt;
        }
        public DataTable ObtenerMedicoSp()
        {
            Datos datos = new Datos();
            //List<Paciente> lista = new List<Paciente>();
            DataTable dt = datos.ObtenerMedicoSp();

            return dt;
        }

        public Boolean validar_email(String email)
       {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}