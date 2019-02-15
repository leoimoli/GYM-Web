using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gym;
using Gym.Entidades;
using Gym.Negocio;

namespace Gym.Web
{
    public partial class LoginWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario _usuario = new Usuario();
            _usuario.Dni = "33222111";
            _usuario.Contraseña = "AAAA";
            List<Usuario> lista = new List<Usuario>();
            lista = UsuarioNeg.LoginUsuario(_usuario);
            if (lista.Count > 0)
            {
                _usuario.IdUsuario = lista[0].IdUsuario;
                _usuario.FechaUltimaConexion = DateTime.Now;
                bool Exito = UsuarioNeg.ActualizarUltimaConexion(_usuario);
                if (Exito == true)
                {
                    const string message2 = "Login Exitoso.";
                    const string caption2 = "Éxito";
                    //var result2 = MessageBox.Show(message2, caption2,
                    //                             MessageBoxButtons.OK,
                    //                             MessageBoxIcon.Asterisk);
                }
                else
                {
                    const string message2 = "No se pudo actualizar la ultima conexión.";
                    const string caption2 = "Éxito";
                    //var result2 = MessageBox.Show(message2, caption2,
                    //                             MessageBoxButtons.OK,
                    //                             MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                const string message2 = "Usuario o clave incorrectas.";
                const string caption2 = "Éxito";
                //var result2 = MessageBox.Show(message2, caption2,
                //                             MessageBoxButtons.OK,
                //                             MessageBoxIcon.Asterisk);
            }
        }
    }
}