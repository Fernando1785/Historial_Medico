using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.pojos
{
   public class Paciente
    {
      private  int id;
      private string cedula;
      private string nombre;
      private string apellido;
      private DateTime fecha;
      private int edad;
      private string sexo;
      private string direc;
      private string telef;
      private string celular;

      

        Conexion con = new Conexion();
        SqlConnection miConn;

      #region get and set
        public int Id
        {
            get { return id; }
            set { id = value; }
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


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
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


        #endregion



        public DataTable ObtenerPacienteSP()
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);

            SqlCommand miComm = new SqlCommand();
            miComm.Connection = miConn;
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            miComm.CommandText = "obtener_paciente";
            miConn.Open();
            SqlDataAdapter miDA = new SqlDataAdapter(miComm);
            DataSet ds = new DataSet();
            miConn.Close();
            miDA.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;

        }


        public DataTable buscarPacienteApellidoSp(string apellido)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm;
            try
            {
                miConn.Open();
                miComm = new SqlCommand("buscaPacienteAp", miConn);
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


        public DataTable buscarPacienteSP(string cedula)
        {
            string cadena = con.Cadena;
            SqlConnection miConn = new SqlConnection(cadena);
            SqlCommand miComm;
            try
            {
                miConn.Open();
                miComm = new SqlCommand("buscaPaciente",miConn);
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

        // metodo para ingresar pacicente
        public Boolean IngresarPacienteSP(Paciente paciente)
        {
            string cadena = con.Cadena;
            miConn = new SqlConnection(cadena);
            try
            {
                miConn.Open();
                SqlCommand miComm = new SqlCommand();
                miComm.Connection = miConn;
                miComm.CommandType = System.Data.CommandType.StoredProcedure;
                miComm.CommandText = "ingresar_paciente";
                // miComm.CommandTimeout = 10;
                miComm.Parameters.AddWithValue("@CEDULA_PACIENTE", paciente.Cedula);
                miComm.Parameters.AddWithValue("@NOMBRE_PACIENTE", paciente.Nombre);
                miComm.Parameters.AddWithValue("@APELLIDO_PACIENTE", paciente.Apellido);
                miComm.Parameters.AddWithValue("@FECHA_NACIMIENTO_PACIENTE", paciente.Fecha);
                miComm.Parameters.AddWithValue("@EDAD_PACIENTE", paciente.Edad);
                miComm.Parameters.AddWithValue("@SEXO_PACIENTE", paciente.Sexo);
                miComm.Parameters.AddWithValue("@DIRECCION_PACIENTE", paciente.Direc);
                miComm.Parameters.AddWithValue("@TELEFONO_PACIENTE", paciente.Telef);
                miComm.Parameters.AddWithValue("@CELULAR_PACIENTE", paciente.Celular);
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

       //metodo para modificar paciente
        public Boolean modificarPacienteSp(Paciente paciente)
        {
            string cadena = con.Cadena;
            miConn = new SqlConnection(cadena);
            try
            {
                miConn.Open();
                SqlCommand miComm = new SqlCommand();
                miComm.Connection = miConn;
                miComm.CommandType = System.Data.CommandType.StoredProcedure;
                miComm.CommandText = "actualizar_paciente";
                // miComm.CommandTimeout = 10;
                miComm.Parameters.AddWithValue("@CEDULA_PACIENTE", paciente.Cedula);
                miComm.Parameters.AddWithValue("@NOMBRE_PACIENTE", paciente.Nombre);
                miComm.Parameters.AddWithValue("@APELLIDO_PACIENTE", paciente.Apellido);
                miComm.Parameters.AddWithValue("@FECHA_NACIMIENTO_PACIENTE", paciente.Fecha);
                miComm.Parameters.AddWithValue("@EDAD_PACIENTE", paciente.Edad);
                miComm.Parameters.AddWithValue("@SEXO_PACIENTE", paciente.Sexo);
                miComm.Parameters.AddWithValue("@DIRECCION_PACIENTE", paciente.Direc);
                miComm.Parameters.AddWithValue("@TELEFONO_PACIENTE", paciente.Telef);
                miComm.Parameters.AddWithValue("@CELULAR_PACIENTE", paciente.Celular);
                miComm.Parameters.AddWithValue("@id", paciente.Id);
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

       //metodo para modificar paciente
        public Boolean eliminarPaciente(Int32 idpaciente)
        {
            string cadena = con.Cadena;
            SqlConnection miConn2 = new SqlConnection(cadena);
            string query = "delete from PACIENTE where ID_PACIENTE  =  '" + idpaciente + "' ";
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
