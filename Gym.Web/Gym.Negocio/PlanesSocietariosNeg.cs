using Gym.Dao;
using Gym.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.Negocio
{
    public class PlanesSocietariosNeg
    {
        public static bool GurdarPlan(PlanesSociales _planes)
        {
            bool exito = false;
            try
            {
                ValidarDatosPlanes(_planes);
                bool PlanExistente = ValidarPlanExistente(_planes);
                if (PlanExistente == true)
                {
                    const string message = "Ya existe un plan registrado con el nokbre ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = PlanesDao.InsertPlan(_planes);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool GuardarNuevoValor(PlanesSociales _planes)
        {
            bool exito = false;
            try
            {
                exito = PlanesDao.InsertNuevoValor(_planes);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        public static bool EliminarPlan(PlanesSociales _planes)
        {
            bool exito = false;
            try
            {
                exito = PlanesDao.BajaPlan(_planes);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
        private static void ValidarDatosPlanes(PlanesSociales _planes)
        {
            if (String.IsNullOrEmpty(_planes.Nombre))
            {
                const string message = "El campo dni es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
        private static bool ValidarPlanExistente(PlanesSociales _planes)
        {
            bool existe = PlanesDao.ValidarPlanExistente(_planes.Nombre);
            return existe;
        }
        public static List<PlanesSociales> ConsultarPlan(PlanesSociales _planes)
        {
            List<PlanesSociales> _listaPlanes = new List<PlanesSociales>();
            try
            {
                _listaPlanes = PlanesDao.ConsultarPlan(_planes);
            }
            catch (Exception ex)
            {

            }
            return _listaPlanes;
        }
    }
}
