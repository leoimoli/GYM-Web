using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using System.Windows.Forms;
using Gym.Dao;

namespace Gym.Negocio
{
    public class ClienteNeg
    {
        public static bool GurdarCliente(Cliente _cliente)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_cliente);
                bool UsuarioExistente = ValidarClienteExistente(_cliente.Dni, _cliente.Sexo);
                if (UsuarioExistente == true)
                {
                    const string message = "Ya existe un usuario registrado con el dni ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = ClienteDao.InsertCliente(_cliente);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        private static bool ValidarClienteExistente(string dni, string sexo)
        {
            bool existe = ClienteDao.ValidarClienteExistente(dni, sexo);
            return existe;
        }
        private static void ValidarDatos(Cliente _cliente)
        {
            if (String.IsNullOrEmpty(_cliente.Dni))
            {
                const string message = "El campo dni es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_cliente.Sexo))
            {
                const string message = "El campo Sexo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_cliente.Apellido))
            {
                const string message = "El campo apellido es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_cliente.Nombre))
            {
                const string message = "El campo nombre es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_cliente.Contraseña))
            {
                const string message = "El campo contraseña es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_cliente.Contraseña != _cliente.Contraseña2)
            {
                const string message = "Las contraseñas ingresadas no coinciden.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_cliente.idPerfil <= 0)
            {
                const string message = "El perfil es un campo obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
        public static bool EditarCliente(Cliente _cliente)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_cliente);
                exito = ClienteDao.EditarCliente(_cliente);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool EliminarCliente(Cliente _cliente)
        {
            bool exito = false;
            try
            {
                exito = ClienteDao.BajaCliente(_cliente);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool ReactivarCliente(Cliente _cliente)
        {
            bool exito = false;
            try
            {
                exito = ClienteDao.ReactivarCliente(_cliente);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static List<Cliente> ConsultarClientes(Cliente _cliente)
        {
            List<Cliente> _listaClientes = new List<Cliente>();
            try
            {
                _listaClientes = ClienteDao.ConsultarClientes(_cliente);
            }
            catch (Exception ex)
            {

            }
            return _listaClientes;
        }
    }
}
