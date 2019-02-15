using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using System.Windows.Forms;
using Gym.Dao;
using Gym.Entidades;
using Gym.Dao;

namespace Gym.Negocio
{
    public class UsuarioNeg
    {
        public static List<Usuario> BuscarUsuarioPorDni(string dni)
        {
            List<Usuario> _listaUsuarios = new List<Usuario>();
            try
            {
                _listaUsuarios = UsuarioDao.BuscarUsuarioPorDNI(dni);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaUsuarios;
        }
        public static List<Usuario> LoginUsuario(Usuario _usuario)
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            lista = UsuarioDao.LoginUsuario(_usuario.Dni, _usuario.Contraseña);
            if (lista.Count > 0)
            {
                int idUsuario = Convert.ToInt32(lista[0].IdUsuario.ToString());
            }
            return lista;
        }
        public static bool EliminarUsuario(Usuario _usuario)
        {
            bool exito = false;
            try
            {
                exito = UsuarioDao.BajaUsuario(_usuario);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool GurdarUsuario(Usuario _usuario)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_usuario);
                bool UsuarioExistente = ValidarUsuarioExistente(_usuario.Dni, _usuario.Sexo);
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
                    exito = UsuarioDao.InsertUsuario(_usuario);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool ActualizarUltimaConexion(Usuario _usuario)
        {
            bool exito = false;
            try
            {
                exito = UsuarioDao.ActualizarUltimaConexion(_usuario);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool ReactivarUsuario(Usuario _usuario)
        {
            bool exito = false;
            try
            {
                exito = UsuarioDao.ReactivarUsuario(_usuario);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static List<Usuario> BuscarUsuarioPorApellido(string apellido)
        {
            List<Usuario> _listaUsuarios = new List<Usuario>();
            try
            {
                _listaUsuarios = UsuarioDao.BuscarUsuarioPorApellido(apellido);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaUsuarios;
        }
        public static bool EditarUsuario(Usuario _usuario)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_usuario);
                exito = UsuarioDao.EditarUsuario(_usuario);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        private static void ValidarDatos(Usuario _usuario)
        {
            if (String.IsNullOrEmpty(_usuario.Dni))
            {
                const string message = "El campo dni es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_usuario.Sexo))
            {
                const string message = "El campo Sexo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_usuario.Apellido))
            {
                const string message = "El campo apellido es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_usuario.Nombre))
            {
                const string message = "El campo nombre es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_usuario.Contraseña))
            {
                const string message = "El campo contraseña es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_usuario.Contraseña != _usuario.Contraseña2)
            {
                const string message = "Las contraseñas ingresadas no coinciden.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_usuario.Perfil <= 0)
            {
                const string message = "El perfil es un campo obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
        public static List<Usuario> ConsultarUsuarios(Usuario _usuario)
        {
            List<Usuario> _listaUsuarios = new List<Usuario>();
            try
            {
                _listaUsuarios = UsuarioDao.ConsultarUsuarios(_usuario);
            }
            catch (Exception ex)
            {
              
            }
            return _listaUsuarios;
        }
        private static bool ValidarUsuarioExistente(string dni, string sexo)
        {
            bool existe = UsuarioDao.ValidarUsuarioExistente(dni, sexo);
            return existe;
        }

    }
}
