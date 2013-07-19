using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.pojos
{
    public class Medico
    {
       //private int especialidad;
       private int id;
       private int ides;
       private string cedula;
       string nombre;
       private string apellido;
       private DateTime fecha;

         
       Int32 edad;
       string sexo;
       string direc;
       string telef;
       string celular;

       Conexion con = new Conexion();
       SqlConnection miConn;


       #region GetSet

       public DateTime Fecha
       {
           get { return fecha; }
           set { fecha = value; }
       }


       public string Celular
       {
           get { return celular; }
           set { celular = value; }
       }

       public string Telef
       {
           get { return telef; }
           set { telef = value; }
       }
     

       public string Direc
       {
           get { return direc; }
           set { direc = value; }
       }

    

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
      

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
      

        public int Ides
        {
            get { return ides; }
            set { ides = value; }
        }
      


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

       #endregion

         //obtener medico
        public DataTable ObtenerMedicoSp()
        {
            string cadena = con.Cadena;
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

        //Metodo buscar Medico mediante el apellido del medico
        public DataTable buscarPacienteApellidoSp(string apellido)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm;
            try
            {
                miConn.Open();
                miComm = new SqlCommand("buscaMedicoAp", miConn);
                miComm.CommandType = CommandType.StoredProcedure;
                miComm.Parameters.AddWithValue("@apellido", apellido);
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

        //Metodo para buscar Medico mediante la cedula del medico
        public DataTable buscarMedicoSP(string cedula)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm;
            try
            {
                miConn.Open();
                miComm = new SqlCommand("buscaMedico", miConn);
                miComm.CommandType = CommandType.StoredProcedure;
                miComm.Parameters.AddWithValue("@cedula", cedula);
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

        // metodo para ingresar medico
        public Boolean IngresarMedicoSP(Medico medico)
        {
            string cadena = con.Cadena;
            miConn = new SqlConnection(cadena);
            try
            {
                miConn.Open();
                SqlCommand miComm = new SqlCommand();
                miComm.Connection = miConn;
                miComm.CommandType = System.Data.CommandType.StoredProcedure;
                miComm.CommandText = "ingresar_medico";
               // miComm.CommandTimeout = 10;
                miComm.Parameters.AddWithValue("@ID_ESPECIALIDADfk ", medico.Ides);
                miComm.Parameters.AddWithValue("@CEDULA_MEDICO", medico.Cedula);
                miComm.Parameters.AddWithValue("@NOMBRE_MEDICO", medico.Nombre);
                miComm.Parameters.AddWithValue("@APELLIDO_MEDICO", medico.Apellido);
               // DateTime fechaNa = Convert.ToDateTime(medico.fecha);
                miComm.Parameters.AddWithValue("@FECHA_NACIMIENTO_MEDICO", medico.fecha);
                miComm.Parameters.AddWithValue("@EDAD_MEDICO", medico.Edad);
                miComm.Parameters.AddWithValue("@SEXO_MEDICO", medico.Sexo);
                miComm.Parameters.AddWithValue("@DIRECCION_MEDICO",medico.Direc);
                miComm.Parameters.AddWithValue("@TELEFONO_MEDICO", medico.Telef);
                miComm.Parameters.AddWithValue("@CELULAR_MEDICO", medico.Celular);
                miComm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;

            }
            finally
            {
                miConn.Close();
            }
        }

        // metodo para modificar medico
        public Boolean modificarMedicoSp(Medico medico)
        {
            string cadena = con.Cadena;
            miConn = new SqlConnection(cadena);
            try
            {
                miConn.Open();
                SqlCommand miComm = new SqlCommand();
                miComm.Connection = miConn;
                miComm.CommandType = System.Data.CommandType.StoredProcedure;
                miComm.CommandText = "actualizar_medico";
                // miComm.CommandTimeout = 10;
                miComm.Parameters.AddWithValue("@ID_ESPECIALIDADfk ", medico.Ides);
                miComm.Parameters.AddWithValue("@CEDULA_MEDICO", medico.Cedula);
                miComm.Parameters.AddWithValue("@NOMBRE_MEDICO", medico.Nombre);
                miComm.Parameters.AddWithValue("@APELLIDO_MEDICO", medico.Apellido);
                miComm.Parameters.AddWithValue("@FECHA_NACIMIENTO_MEDICO", medico.Fecha);
                miComm.Parameters.AddWithValue("@EDAD_MEDICO", medico.Edad);
                miComm.Parameters.AddWithValue("@SEXO_MEDICO", medico.Sexo);
                miComm.Parameters.AddWithValue("@DIRECCION_MEDICO", medico.Direc);
                miComm.Parameters.AddWithValue("@TELEFONO_MEDICO", medico.Telef);
                miComm.Parameters.AddWithValue("@CELULAR_MEDICO", medico.Celular);
                miComm.Parameters.AddWithValue("@id", medico.Id);
                miComm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                miConn.Close();
            }
        }

        //Metodo paar eliminar medico
        public Boolean eliminarMedico(Int32 idmedico)
        {
            string cadena = con.Cadena;
            SqlConnection miConn2 = new SqlConnection(cadena);
            string query = "delete from MEDICO where ID_MEDICO  =  '" + idmedico + "' ";
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
    }
}
