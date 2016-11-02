using puntoNet.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using puntoNet.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace puntoNet.DAL {
    public class FotoRepositoryImp : FotoRepository {

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Foto create(Foto foto) {
            const string SQL = "crearFoto";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image);
                cmd.ExecuteNonQuery();
                foto.idFoto = Convert.ToInt32(cmd.Parameters["@idFoto"].Value);
            }
            return foto;
        }

        public void delete(int id) {
            throw new NotImplementedException();
        }

        public IList<Foto> getAll() {
            throw new NotImplementedException();
        }

        public Foto getById(int id) {
            Foto foto = null;
            const string SQL = "mostrarUnaFoto";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", id);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            foto = parseFoto(reader);
                        }
                    }
                }
            }
            return foto;
        }

        private Foto parseFoto(SqlDataReader reader) {
            Foto foto = new Foto();
            foto.idFoto = Convert.ToInt32(reader["idFoto"]);
            foto.nombre = Convert.ToString(reader["nombre"]);
            //foto.imagen = Convert.reader["imagen"];
            return foto;
        }

        public Foto update(Foto foto) {
            const string SQL = "actualizarFoto";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {

                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idFoto", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar);
              //  cmd.Parameters.A("@imagen", System.Data.SqlDbType.Image);
                cmd.ExecuteNonQuery();
            }
            return foto;
        }
    }
}