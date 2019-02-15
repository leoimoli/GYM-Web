using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Entidades
{
    public class FichaMedica
    {
        public int idFichaTecnica { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string Medicamentos { get; set; }
        public string Cirugias { get; set; }
        public string Afecciones { get; set; }
        public int idCliente { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
