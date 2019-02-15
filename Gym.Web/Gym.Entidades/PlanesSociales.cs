using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Entidades
{
    public class PlanesSociales
    {
        public int idPlan { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
        public decimal Valor { get; set; }
        public string Estado { get; set; }
    }
}
