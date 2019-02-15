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
        public void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario _usuario = new Usuario();
            _usuario.Dni = txtDni.Text;
            _usuario.Contraseña = txtClave.Text;
            List<Usuario> lista = new List<Usuario>();
            lista = UsuarioNeg.LoginUsuario(_usuario);
            if (lista.Count > 0)
            {
                _usuario.IdUsuario = lista[0].IdUsuario;
                _usuario.FechaUltimaConexion = DateTime.Now;
                bool Exito = UsuarioNeg.ActualizarUltimaConexion(_usuario);
                if (Exito == true)
                {
                    HttpContext.Current.Session["loginUsuario"] = lista.First();
                    Response.Redirect("DefaultWF.aspx");
                }
                else
                {

                }
            }
            else
            {
                throw new Exception("El usuario ingresado/contraseña incorrecta.");
            }
        }
    }
}