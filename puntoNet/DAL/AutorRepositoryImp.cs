using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using puntoNet.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace puntoNet.DAL
{
    public class AutorRepositoryImp : AutorRepository
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Autor create(Autor autor)
        {
            const string SQL = "crearAutor";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@nombreautor", autor.Nombre);
                cmd.Parameters.Add("@idAutor", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                autor.CodAutor = Convert.ToInt32(cmd.Parameters["@idAutor"].Value);
            }
            return autor;
        }

        public void delete(int id)
        {
            const string SQL = "borrarAutor";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.ExecuteNonQuery();

            }
        }

        public IList<Autor> getAll()
        {
            IList<Autor> autores = null;
            const string SQL = "mostrarAutores";
            Autor autor;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    autores = new List<Autor>();
                    if (reader.HasRows)
                    {
      
                        while (reader.Read())
                        {
                            autor = parseAutor(reader);
                            autores.Add(autor);
                        }
                    }
                }
            }
            return autores;

        }


        public Autor getById(int id)
        {
            Autor autor = null;
            const string SQL = "mostrarUnAutor";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read()) {
                            autor = parseAutor(reader);
                        }
                    }
                }
            }
                return autor;
        }

        public Autor update(Autor autor)
        {
            const string SQL = "actualizarAutor";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                
                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAutor", autor.CodAutor);
                cmd.Parameters.AddWithValue("@nombreAutor", autor.Nombre);
                cmd.ExecuteNonQuery();
            }
            return autor;

        }

        private Autor parseAutor(SqlDataReader reader)
        {
            Autor autor = new Autor();
            autor.CodAutor = Convert.ToInt32(reader["idAutor"]);
            autor.Nombre = reader["nombreAutor"].ToString();
            return autor;
        }
    }
}