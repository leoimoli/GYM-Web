using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using Gym.Dao;

namespace Gym.Negocio
{
    public class RutinaNeg
    {
        public static bool GurdarRutina(List<Rutina> listaRutina, int idCliente)
        {
            bool exito = false;
            try
            {
                exito = RutinaDao.InsertRutina(listaRutina, idCliente);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
    }
}
