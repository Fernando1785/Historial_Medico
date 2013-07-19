using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaDatos.pojos;
using System.Data.SqlClient;
using System.Data;

namespace CapaLogicaNegocios
{
    public class LogicaEspecialidad
    {
        public Boolean IngresarEspecialidad(string espec)
        {
            Boolean inserto = false;
            Especiadidad espe = new Especiadidad();
            inserto = espe.ingresarEspecialidad(espec);
            return inserto;
        }

        public Boolean ModificarPaciente(string espec, Int32 id)
        {
            Boolean inserto = false;
            Especiadidad espe = new Especiadidad();
            inserto = espe.modificarEspecialidad(espec, id);
            return inserto;
        }


        public DataTable ObtenerEspecialidad()
        {
            Especiadidad espe = new Especiadidad();
            DataTable dt = new DataTable();
            dt = espe.traerEspecialidadcbx();
            return dt;
          
            
        }


        public Boolean eliminarEspecialidad(String idespecialidad)
        {
            Boolean inserto = false;
            Especiadidad espe = new Especiadidad();
            inserto = espe.eliminarEspecialidad(Convert.ToInt32(idespecialidad));
            return inserto;
        }


        public DataTable BuscarEspecialidad(string especialidad)
        {
            Especiadidad espe = new Especiadidad();
            DataTable dt = espe.buscarEspecialidadSP(especialidad);
            return dt;
        }

    }
}
