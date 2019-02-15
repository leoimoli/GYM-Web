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
    public class FichaMedicaDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool InsertFichaMedica(FichaMedica _ficha)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaFichaMedica";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Peso_in", _ficha.Peso);
            cmd.Parameters.AddWithValue("Altura_in", _ficha.Altura);
            cmd.Parameters.AddWithValue("Medicamentos_in", _ficha.Medicamentos);
            cmd.Parameters.AddWithValue("Cirugias_in", _ficha.Cirugias);
            cmd.Parameters.AddWithValue("Afecciones_in", _ficha.Afecciones);
            cmd.Parameters.AddWithValue("idCliente_in", _ficha.idCliente);
            cmd.Parameters.AddWithValue("FechaAlta_in", _ficha.FechaAlta);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
