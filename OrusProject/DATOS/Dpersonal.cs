using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OrusProject.LOGICA;
using System.Windows.Forms;

namespace OrusProject.DATOS
{
    public class Dpersonal
    {
        public bool InsertarPersonal(Lpersonal parametros)
        {
			try
			{
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("InsertarPersonal", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Identificación", parametros.Identificación);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo);
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

        public bool editarPersonal(Lpersonal parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("editarPersonal", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Identificación", parametros.Identificación);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo);
                cmd.Parameters.AddWithValue("@Sueldo_Por_Hora", parametros.SueldoPorHora);
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

        public bool eliminarPersonal(Lpersonal parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("eliminarPersonal", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idpersonal", parametros.Id_personal);                
                cmd.ExecuteNonQuery(); //Ejecutar los datos 
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

        public void mostrarPersonal(ref DataTable dataTable, int desde, int hasta)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPersonal", ConexionMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", desde);
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

        public void BuscarPersonal(ref DataTable dataTable, int desde, int hasta, string buscador)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("BuscarPersonal", ConexionMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", desde);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
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
