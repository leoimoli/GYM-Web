using Gym.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Dao
{
    public class ClienteDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool ValidarClienteExistente(string dni, string sexo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Cliente> lista = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", dni),
             new MySqlParameter("Sexo_in", sexo)};
            string proceso = "ValidarClienteExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "cliente");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static bool InsertCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
            cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _cliente.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("idPlan_in", _cliente.idPlan);
            cmd.Parameters.AddWithValue("Estado_in", _cliente.Estado);
            cmd.Parameters.AddWithValue("Contraseña_in", _cliente.Contraseña);
            cmd.Parameters.AddWithValue("Imagen_in", _cliente.Imagen);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _cliente.FechaDeAlta);
            cmd.Parameters.AddWithValue("FechaUltimaConexion_in", _cliente.FechaUltimaConexion);
            cmd.Parameters.AddWithValue("idPerfil_in", _cliente.idPerfil);
            cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool EditarCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _cliente.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("idPlan_in", _cliente.idPlan);
            cmd.Parameters.AddWithValue("Contraseña_in", _cliente.Contraseña);
            cmd.Parameters.AddWithValue("Imagen_in", _cliente.Imagen);
            cmd.Parameters.AddWithValue("idPerfil_in", _cliente.idPerfil);
            cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool BajaCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "BajaCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Estado_in", _cliente.Estado);
            cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ReactivarCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "ReactivarCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            string Estado = "Activo";
            cmd.Parameters.AddWithValue("Estado_in", Estado);
            cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Cliente> ConsultarClientes(Cliente _cliente)
        {
            connection.Close();
            connection.Open();
            List<Cliente> _listaClientes = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Estado_in", _cliente.Estado) };
            string proceso = "ConsultarClientes";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Cliente listaClientes = new Entidades.Cliente();
                    listaClientes.idCliente = Convert.ToInt32(item["idCliente"].ToString());
                    listaClientes.Dni = item["Dni"].ToString();
                    listaClientes.Sexo = item["Sexo"].ToString();
                    listaClientes.Apellido = item["Apellido"].ToString();
                    listaClientes.Nombre = item["Nombre"].ToString();
                    listaClientes.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaClientes.Telefono = item["Telefono"].ToString();
                    listaClientes.Email = item["Email"].ToString();
                    listaClientes.idPlan = Convert.ToInt32(item["idPlan"].ToString());
                    listaClientes.Contraseña = item["Contrasenia"].ToString();
                    if (item[11].ToString() != string.Empty)
                    {
                        listaClientes.Imagen = (byte[])item["Imagen"];
                    }
                    listaClientes.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                    listaClientes.FechaUltimaConexion = Convert.ToDateTime(item["FechaUltimaConexion"].ToString());
                    listaClientes.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                    listaClientes.PlanNombre = item["planNombre"].ToString();
                    listaClientes.PerfilNombre = item["perfilNombre"].ToString();
                    _listaClientes.Add(listaClientes);
                }
            }
            connection.Close();
            return _listaClientes;
        }
    }
}
