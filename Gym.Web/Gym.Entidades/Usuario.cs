using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime FechaUltimaConexion { get; set; }
        public string Contraseña { get; set; }
        public string Contraseña2 { get; set; }
        public int Perfil { get; set; }
        public string Estado { get; set; }

        public string NombrePerfil { get; set; }
    }
}
