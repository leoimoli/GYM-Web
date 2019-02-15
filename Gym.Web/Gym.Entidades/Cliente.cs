using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Entidades
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime FechaUltimaConexion { get; set; }
        public string Contraseña { get; set; }
        public string Contraseña2 { get; set; }
        public int idPlan { get; set; }
        public int idPerfil { get; set; }
        public int idUsuario { get; set; }
        public string Estado { get; set; }
        public byte[] Imagen { get; set; }
        public string PlanNombre { get; set; }
        public string PerfilNombre { get; set; }
    }
}
