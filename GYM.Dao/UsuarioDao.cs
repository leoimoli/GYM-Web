using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using MySql.Data.MySqlClient;
using System.Data;


namespace Gym.Dao
{
    public class UsuarioDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool InsertUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaUsuario";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _usuario.Sexo);
            cmd.Parameters.AddWithValue("Apellido_in", _usuario.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _usuario.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _usuario.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Perfil_in", _usuario.Perfil);
            cmd.Parameters.AddWithValue("Contraseña_in", _usuario.Contraseña);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _usuario.FechaDeAlta);
            cmd.Parameters.AddWithValue("FechaUltimaConexion_in", _usuario.FechaUltimaConexion);
            cmd.Parameters.AddWithValue("Estado_in", _usuario.Estado);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Usuario> LoginUsuario(string usuario, string contraseña)
        {
            connection.Close();
            string estado = "Activo";
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", usuario),
                                       new MySqlParameter("Contraseña_in", contraseña),
             new MySqlParameter("Estado_in", estado)};
            string proceso = "LoginUsuario";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Usuario listaUsuario = new Entidades.Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool BajaUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "BajaUsuario";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            string Estado = "Inactivo";
            cmd.Parameters.AddWithValue("Estado_in", Estado);
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _usuario.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Usuario> BuscarUsuarioPorDNI(string dni)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("DNI_in", dni)};
            string proceso = "BuscarUsuarioPorDNI";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Usuario listaUsuario = new Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = Convert.ToInt32(item["Perfil"].ToString());
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool ReactivarUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "ReactivarUsuario";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            string Estado = "Activo";
            cmd.Parameters.AddWithValue("Estado_in", Estado);
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _usuario.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ActualizarUltimaConexion(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "ActualizarUltimaConexion";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FechaUltimaConexion_in", _usuario.FechaUltimaConexion);
            cmd.Parameters.AddWithValue("IdUsuario_in", _usuario.IdUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ValidarUsuarioExistente(string dni, string sexo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Usuario> lista = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", dni),
             new MySqlParameter("Sexo_in", sexo)};
            string proceso = "ValidarUsuarioExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "usuario");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<Usuario> ConsultarUsuarios(Usuario _usuario)
        {
            connection.Close();
            connection.Open();
            List<Usuario> _listaUsuarios = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Estado_in", _usuario.Estado) };
            string proceso = "ConsultarUsuarios";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Usuario listaUsuario = new Entidades.Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.Dni = item["Sexo"].ToString();
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.Perfil = Convert.ToInt32(item["idPerfil"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["FechaUltimaConexion"].ToString());
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.NombrePerfil = item["prueba"].ToString();
                    _listaUsuarios.Add(listaUsuario);
                }
            }
            connection.Close();
            return _listaUsuarios;
        }
        public static List<Usuario> BuscarUsuarioPorApellido(string apellido)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Apellido_in", apellido)};
            string proceso = "BuscarUsuarioPorApellido";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Usuario listaUsuario = new Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = Convert.ToInt32(item["Perfil"].ToString());
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool EditarUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarUsuario";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Apellido_in", _usuario.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _usuario.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _usuario.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Contraseña_in", _usuario.Contraseña);
            cmd.Parameters.AddWithValue("Perfil_in", _usuario.Perfil);
            cmd.Parameters.AddWithValue("Estado_in", _usuario.Estado);
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _usuario.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
