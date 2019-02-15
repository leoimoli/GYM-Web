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
    public class EjerciciosDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool InsertTipoEjercicio(Ejercicios _ejercicio)
        {
            int idUltimoTipoCreado = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaTipoEjercicio";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NombreTipoEjercicio_in", _ejercicio.NombreTipoEjercicio);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idUltimoTipoCreado = Convert.ToInt32(r["ID"].ToString());
            }


            exito = true;
            connection.Close();
            return exito;
        }
        public static bool InsertEjercicio(Ejercicios _ejercicio)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaEjercicio";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Nombre_in", _ejercicio.Nombre);
            cmd.Parameters.AddWithValue("Imagen_in", _ejercicio.Imagen);
            cmd.Parameters.AddWithValue("idTipoEjercicio_in", _ejercicio.idTipoEjercicio);
            cmd.Parameters.AddWithValue("idUsuario_in", _ejercicio.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close(); 
            return exito;
        }
    }
}
