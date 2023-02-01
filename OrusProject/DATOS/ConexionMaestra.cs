using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OrusProject.DATOS
{
    public class ConexionMaestra
    {
        public static string conexion = @"Data Source=Jaouad-Oukassi\SQLEXPRESS; Initial Catalog=OurusJaouad; Integrated Security=true";
        public static SqlConnection conectar = new SqlConnection(conexion); // CREAR LA CONEXION

        public static void abrir()
        {
            if(conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void cerrar()
        {
            if(conectar.State != ConnectionState.Closed)
            {
                conectar.Close();
            }
        }
    }
}
