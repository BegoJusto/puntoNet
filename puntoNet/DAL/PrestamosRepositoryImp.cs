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
    public class PrestamosRepositoryImp : PrestamosRepository
    {

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Prestamos create(Prestamos prestamos)
        {
            const string SQL = "crearPrestamo";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                conexion.Open();
                cmd.Parameters.AddWithValue("@fDevolucion", prestamos.FDevolucion);
                cmd.Parameters.AddWithValue("@fRecogida", prestamos.FRecogida);
                cmd.Parameters.AddWithValue("@idEjemplar", prestamos.Ejemplar.CodEjemplar);
                cmd.Parameters.AddWithValue("@idUsuario", prestamos.Usuario.CodUsuario);
                cmd.Parameters.Add("@idPrestamo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                prestamos.CodPrestamo = int.Parse(cmd.Parameters["idPrestamo"].Value.ToString());
                
            }
            return prestamos;
        }

        public IList<Prestamos> getAll()
        {
            const string SQL = "mostrarPrestamos";
            IList<Prestamos> prestamos = null;
            Prestamos prestamo = null;
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                prestamos = new List<Prestamos>();
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            prestamo = parsePrestamo(reader);
                            prestamos.Add(prestamo);
                        }
                    }
                }

            }
            return prestamos;
        }

        private Prestamos parsePrestamo(SqlDataReader reader)
        {
            Prestamos prestamo = new Prestamos();
            prestamo.CodPrestamo = Convert.ToInt32(reader["idPrestamo"]);
            prestamo.FDevolucion = Convert.ToDateTime(reader["fDevolucion"].ToString());
            prestamo.FRecogida = Convert.ToDateTime(reader["fRecogida"].ToString());
            prestamo.Ejemplar.Titulo = reader["titulo"].ToString();
           // prestamo.Usuario.Nombre = reader["Nombre"].ToString();
            prestamo.Ejemplar.Autor.Nombre = reader["nombreAutor"].ToString();
            return prestamo;

        }

        public Prestamos getById(int id)
        {
            const string SQL = "mostrarUnPrestamo";
            Prestamos prestamo = null;
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                conexion.Open();
                cmd.Parameters.AddWithValue("idPrestamo", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            prestamo = parsePrestamo(reader);
                        }
                    }
                }
            }
            return prestamo;
        }

        public Prestamos update(Prestamos prestamos)
        {
            const string SQL = "actualizarPrestamo";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.Parameters.AddWithValue("@fDevolucion", prestamos.FDevolucion);
                cmd.Parameters.AddWithValue("@fRecogida", prestamos.FRecogida);
                cmd.Parameters.AddWithValue("@idEjemplar", prestamos.Ejemplar.CodEjemplar);
                cmd.Parameters.AddWithValue("@idUsuario", prestamos.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@idPrestamo", prestamos.CodPrestamo);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            return prestamos;
        }
    }
}