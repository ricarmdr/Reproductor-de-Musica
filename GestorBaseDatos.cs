using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReproductorMusica
{
    public class GestorBaseDatos
    {
        private string cadenaConexion;

        //metodo constructor
        public GestorBaseDatos(string conexion)
        {
            cadenaConexion = conexion;
        }

        //metodo para guardar una cancion
        public void GuardarCancion(string nombre, string artista, string ruta)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();

                string query = "INSERT INTO Cancion (nombre, artista, rutaArchivo) VALUES (@nombre, @artista, @ruta)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@artista", artista);
                cmd.Parameters.AddWithValue("@ruta", ruta);

                cmd.ExecuteNonQuery();
            }
        }

        //metodo para crear playlist
        public void CrearPlaylist(string nombrePlaylist)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();

                string query = "INSERT INTO Playlist (nombrePlaylist) VALUES(@nombre)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", nombrePlaylist);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
