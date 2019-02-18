using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gym.Entidades;

namespace Gym.Web
{
    public partial class DefaultWF : Page
    {
        //public Usuario usuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //int idUsuario = Convert.ToInt32(((Usuario)HttpContext.Current.Session["loginUsuario"]).IdUsuario);
            //usuarioActual = (Usuario)HttpContext.Current.Session["loginUsuario"];
            //lblUsuarioRegistrado.Text = usuarioActual.Nombre +" "+ usuarioActual.Apellido;
        }
    }
}