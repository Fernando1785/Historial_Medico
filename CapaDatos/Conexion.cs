using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
   public class Conexion
    {
        //private string cadena =  @"Data Source=fernando\SQL2008; Initial Catalog=FUNDACION01; User id=sa; Password=sa";
        private string cadena = "Data Source=localhost; Initial Catalog=FUNDACION01; User id=sa; Password=sa";

        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
    }
}
