using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Entidades
{
    public class Rutina
    {
        public int idRutina { get; set; }
        public int idCliente { get; set; }
        public int idDetalleRutina { get; set; }
        public int idEjercicio { get; set; }
        public int CantidadSeries { get; set; }
        public string Peso { get; set; }
        public string Tiempo { get; set; }
    }
}
