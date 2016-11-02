using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using puntoNet.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace puntoNet.DAL
{
    public class LibroRepositoryImp : LibroRespository
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Libro create(Libro libro)
        {
            const string SQL = "crearLibro";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                conexion.Open();
                cmd.Parameters.AddWithValue("@idAutor", libro.Autor.CodAutor);                
                AutorRepositoryImp autor = new AutorRepositoryImp();
                if (autor.getById(libro.Autor.CodAutor) != null) {
                    cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    libro.CodLibro = int.Parse(cmd.Parameters["@idLibro"].Value.ToString());
                } // el crear autor falta
            }
            return libro;

        }

        public void delete(int codigo)
        {
            const string SQL = "borrarLibro";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.Parameters.AddWithValue("@codigo", int.Parse(codigo.ToString()));
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Libro> getAll()
        {
            IList<Libro> libros = null;
            const string SQL = "mostrarLibros";
            Libro libro;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //libros = new List<Libro>();
                    if (reader.HasRows)
                    {
                        libros = new List<Libro>();
                        while (reader.Read())
                        {
                            libro = parseLibro(reader);
                            libros.Add(libro);
                        }
                    }
                }
            }
            return libros;
        }
        public Libro getById(int codigo)
        {
            Libro libro = null;
            const string SQL = "mostrarUnLibro";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", codigo); 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) {
                            libro = parseLibro(reader);
                        }
                    }
                }

            }
            return libro;
        }

        public Libro update(Libro libro)
        {
            const string SQL = "actualizarLibro";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.Parameters.AddWithValue("@idLibro", libro.CodLibro);
                cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@idAutor", libro.Autor.CodAutor);        
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            return libro;
        }

        private Libro parseLibro(SqlDataReader reader)
        {
            Libro libro = new Libro();
            libro.CodLibro = Convert.ToInt32(reader["idLibro"]);
            libro.Titulo = reader["titulo"].ToString();
            libro.Autor.Nombre = reader["nombreAutor"].ToString();
            return libro;

        }
    }
}