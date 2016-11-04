using System;
using System.Collections.Generic;
using puntoNet.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace puntoNet.DAL {
    public class UsuarioRepositoryImp : UsuarioRepository
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Usuario create(Usuario usuario)
        {
            const string SQL = "crearUsuario";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@password", usuario.Pass);
                cmd.Parameters.AddWithValue("@usuario", usuario.Alias);
                cmd.Parameters.AddWithValue("@fNacimiento", usuario.FNacimiento);
                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                usuario.CodUsuario = Convert.ToInt32(cmd.Parameters["@idUsuario"].Value);
            }

            return usuario;
        }

        public void delete(int id)
        {

            const string SQL = "borrarUsuario";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo",id);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Usuario> getAll()
        {
            IList<Usuario> usuarios = null;
            const string SQL = "mostrarUsuarios";
            Usuario usuario;

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    usuarios = new List<Usuario>();
                    if (reader.HasRows)
                    {                       
                        while (reader.Read())
                        {
                            usuario = parseUsuario(reader);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        
        public Usuario getById(int id)
        {
            Usuario usuario = null;
            const string SQL = "mostrarUnUsuario";

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("idUsuario", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) {
                            usuario = parseUsuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        public Usuario Login(Login model) {
            const string SQL = "login";
            Usuario usuario = new Usuario();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@secreto", model.Pass);
                cmd.Parameters.AddWithValue("@nick", model.Alias);
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                usuario.CodUsuario = Convert.ToInt32(cmd.Parameters["@idUsuario"].Value);

            }

            return usuario;
        }

        public Usuario update(Usuario usuario)
        {
            const string SQL = "actualizarUsuario";

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@secreto", usuario.Pass);
                cmd.Parameters.AddWithValue("@nick", usuario.Alias);
                cmd.Parameters.AddWithValue("@fNacimiento", usuario.FNacimiento);
                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.ExecuteNonQuery();
            }

            return usuario;
        }

        private Usuario parseUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.CodUsuario = Convert.ToInt32(reader["idUsuario"]);
            usuario.Nombre = reader["nombre"].ToString();
            usuario.Apellidos = reader["apellidos"].ToString();
            usuario.Pass = reader["secreto"].ToString();
            usuario.Alias = reader["nick"].ToString();
            try {
                usuario.FNacimiento = Convert.ToDateTime(reader["fNacimiento"]);
            } catch {
                usuario.FNacimiento = new DateTime();
            }
            usuario.Dni = reader["dni"].ToString();
            usuario.Email = reader["email"].ToString();
            return usuario;
        }

    }
}