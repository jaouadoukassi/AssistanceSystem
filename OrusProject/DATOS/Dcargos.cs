using OrusProject.LOGICA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrusProject.DATOS
{
    public class Dcargos
    {
        public bool insertar_Cargo(Lcargo parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Cargo", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //RAISERROR obligatorio trabajemos con .Message
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public bool editar_Cargo(Lcargo parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("editar_Cargo", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", parametros.Id_Cargo);
                cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                cmd.Parameters.AddWithValue("@Sueldo", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //RAISERROR obligatorio trabajemos con .Message
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public void buscarCargos(ref DataTable dataTable, string buscador)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("buscarCargos", ConexionMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
                da.Fill(dataTable);//Pasar los datos y no se ejecutan
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.StackTrace);
            }
            finally
            {
                ConexionMaestra.cerrar();               
            }
        }
    }
}
