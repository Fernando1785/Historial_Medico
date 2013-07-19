using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CapaDatos.pojos;
namespace CapaDatos
{
   public class Datos
    {
       Conexion con2 = new Conexion();
       SqlConnection con;
        public DataTable ObtenerPaciente()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        {
            string cadena = con2.Cadena;
            con = new SqlConnection(cadena);
            string query = "select * from PACIENTE";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TraerSexo()
        {
            string cadena = con2.Cadena;
            con = new SqlConnection(cadena);
            string query = "select s.id_sexo, s.nombre_sexo from sexo s";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable ObtenerPacienteSPr()
        {
            con.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "obtener_paciente";
            
            
            //comando.ExecuteNonQuery();


            con.Close();
            DataTable dt = new DataTable();
            return dt;
        }

       

        public DataTable ObtenerTurnoSp()
        {
            string cadena = con2.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);

            SqlCommand miComm = new SqlCommand();
            miComm.Connection = miConn;
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            miComm.CommandText = "obtener_turno_depurado";
            SqlDataAdapter miDA = new SqlDataAdapter(miComm);
            DataSet ds = new DataSet();
            miDA.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;

        }

        public DataTable ObtenerMedicoSp()
        {
            string cadena = con2.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);

            SqlCommand miComm = new SqlCommand();
            miComm.Connection = miConn;
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            miComm.CommandText = "obtener_medico";
            SqlDataAdapter miDA = new SqlDataAdapter(miComm);
            DataSet ds = new DataSet();
            miDA.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;

        }

     

    }
}
