using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CapaDatos.pojos;

namespace CapaDatos.pojos
{

   public class Especiadidad
    {
        
      
       Conexion con = new Conexion();
  
        int id;
        string nombre;


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }




        public DataTable traerEspecialidadcbx()
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm = new SqlCommand();
            miComm.Connection = miConn;
            string query = "select es.ID_ESPECIALIDAD, es.NOMBRE_ESPECIALIDAD from ESPECIALIDAD es";
            SqlDataAdapter da = new SqlDataAdapter(query, miConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            miConn.Close();
            return dt;
        }

        public Boolean ingresarEspecialidad(string nombre)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            string query = "insert into ESPECIALIDAD(NOMBRE_ESPECIALIDAD) values('" + nombre + "')";
            SqlCommand miComm = new SqlCommand(query, miConn);
          //  miComm.ExecuteNonQuery();
           // SqlDataAdapter da = new SqlDataAdapter(query, miConn);
            try
            {
                miConn.Open();
                miComm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                miConn.Close();
                return false;
                throw new Exception(ex.Message);
            }
            finally
            {
                miConn.Close();
                miComm.Dispose();
            }
        }


        public Boolean modificarEspecialidad(string nombre, Int32 id)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            string query =  "update ESPECIALIDAD set ";
            query = query + " NOMBRE_ESPECIALIDAD = ('" + nombre + "')";
            query = query + " where ID_ESPECIALIDAD  = ('" + id + "')";


            SqlCommand miComm = new SqlCommand(query, miConn);
            //  miComm.ExecuteNonQuery();
            // SqlDataAdapter da = new SqlDataAdapter(query, miConn);
            try
            {
                miConn.Open();
                miComm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                miConn.Close();
                return false;
                throw new Exception(ex.Message);
            }
            finally
            {
                miConn.Close();
                miComm.Dispose();
            }
        }





        public Boolean eliminarEspecialidad(Int32 idespecialidad)
        {
            string cadena = con.Cadena;
            SqlConnection miConn2 = new SqlConnection(cadena);
            string query = "delete from ESPECIALIDAD where ID_ESPECIALIDAD  =  '" + idespecialidad + "' ";
            SqlCommand sql = new SqlCommand(query, miConn2);

            try
            {
                miConn2.Open();
                sql.ExecuteNonQuery();
                return true;
            }

            catch (SqlException ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
            finally
            {
                miConn2.Close();
            }

        }

        public DataTable buscarEspecialidadSP(string especialidad)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm;
            try
            {
                miConn.Open();
                miComm = new SqlCommand("buscaEspecialidad", miConn);
                miComm.CommandType = CommandType.StoredProcedure;
                miComm.Parameters.AddWithValue("@especialidad", especialidad);
                SqlDataReader reader = miComm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (miConn != null && miConn.State != ConnectionState.Closed)
                {
                    miConn.Close();
                }
            }
        }
        
    }
}
