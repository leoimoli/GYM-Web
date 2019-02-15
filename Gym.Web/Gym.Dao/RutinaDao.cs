using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Gym.Dao
{
    public class RutinaDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool InsertRutina(List<Rutina> listaRutina, int idCliente)
        {
            int ultimaRutinaCreada = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaRutina";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idCliente_in", idCliente);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                ultimaRutinaCreada = Convert.ToInt32(r["ID"].ToString());
            }
            if (ultimaRutinaCreada > 0)
            {
                connection.Close();
                exito = InsertDetalleRutina(listaRutina);
            }

            connection.Close();
            return exito;
        }

        private static bool InsertDetalleRutina(List<Rutina> listaRutina)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            foreach (var item in listaRutina)
            {
                string proceso = "AltaDetalleRutina";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEjercicio_in", item.idEjercicio);
                cmd.Parameters.AddWithValue("CantidadSeries_in", item.CantidadSeries);
                cmd.Parameters.AddWithValue("idRutina_in", item.idRutina);
                cmd.Parameters.AddWithValue("Peso_in", item.Peso);
                cmd.Parameters.AddWithValue("Tiempo_in", item.Tiempo);
                cmd.ExecuteNonQuery();
            }
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
