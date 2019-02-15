using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using System.Windows.Forms;
using Gym.Dao;

namespace Gym.Negocio
{
    public class FichaMedicaNeg
    {
        public static bool GurdarFichaMedica(FichaMedica _ficha)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_ficha);
                exito = FichaMedicaDao.InsertFichaMedica(_ficha);

            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        private static void ValidarDatos(FichaMedica _ficha)
        {
            if (String.IsNullOrEmpty(_ficha.Peso))
            {
                const string message = "El campo Peso es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_ficha.Altura))
            {
                const string message = "El campo Altura es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
