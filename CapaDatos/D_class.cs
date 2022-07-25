using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using CapaEntidad;

namespace CapaDatos
{
    public class D_class
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
    
        public List<E_class> ListarDatos(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("sp_buscardatos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);

            leerFilas = cmd.ExecuteReader();
            
            List<E_class> Listar = new List<E_class>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_class
                {
                    Id = leerFilas.GetInt32(0),
                    Nombre = leerFilas.GetString(1),
                    Apellidos = leerFilas.GetString(2),
                    Telefono = leerFilas.GetString(3),
                    Ocupacion = leerFilas.GetString(4)
                });
            }
            conexion.Close();
            leerFilas.Close();
            return Listar;
        }

        public void InsertarDatos(E_class dato)//categoria
        {
            SqlCommand cmd = new SqlCommand("sp_insertardatos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", dato.Nombre);
            cmd.Parameters.AddWithValue("@apellidos", dato.Apellidos);
            cmd.Parameters.AddWithValue("@telefono", dato.Telefono);
            cmd.Parameters.AddWithValue("@ocupacion", dato.Ocupacion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarDatos(E_class dato)//categoria
        {
            SqlCommand cmd = new SqlCommand("sp_editardatos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", dato.Id);
            cmd.Parameters.AddWithValue("@nombre", dato.Nombre);
            cmd.Parameters.AddWithValue("@apellidos", dato.Apellidos);
            cmd.Parameters.AddWithValue("@telefono", dato.Telefono);
            cmd.Parameters.AddWithValue("@ocupacion", dato.Ocupacion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarDatos(E_class dato)//categoria
        {
            SqlCommand cmd = new SqlCommand("sp_eliminardatos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", dato.Id);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}


     
