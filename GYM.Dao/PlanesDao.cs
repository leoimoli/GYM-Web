using Gym.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Dao
{
    public class PlanesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool InsertPlan(PlanesSociales _planes)
        {
            int idUltimoPlanInsertado = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaPlan";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Nombre_in", _planes.Nombre);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _planes.FechaDeAlta);
            cmd.Parameters.AddWithValue("idUsuario_in", _planes.idUsuario);
            cmd.Parameters.AddWithValue("Estado_in", _planes.Estado);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idUltimoPlanInsertado = Convert.ToInt32(r["ID"].ToString());
            }
            if (idUltimoPlanInsertado > 0)
            {
                exito = InsertHistorialValorPlan(_planes, idUltimoPlanInsertado);
            }
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool InsertHistorialValorPlan(PlanesSociales _planes, int idUltimoPlanInsertado)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaHistorialValorPlan";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Valor_in", _planes.Valor);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _planes.FechaDeAlta);
            cmd.Parameters.AddWithValue("idUsuario_in", _planes.idUsuario);
            cmd.Parameters.AddWithValue("idPlan_in", idUltimoPlanInsertado);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool BajaPlan(PlanesSociales _planes)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "BajaPlan";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Estado_in", _planes.Estado);
            cmd.Parameters.AddWithValue("idPlan_in", _planes.idPlan);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<PlanesSociales> ConsultarPlan(PlanesSociales _listaPlanes)
        {
            connection.Close();
            connection.Open();
            List<PlanesSociales> listaPlanes = new List<PlanesSociales>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Estado_in", _listaPlanes.Estado) };
            string proceso = "ConsultarPlanes";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.PlanesSociales listaPlanes2 = new Entidades.PlanesSociales();
                    listaPlanes2.idPlan = Convert.ToInt32(item["idPlan"].ToString());
                    listaPlanes2.Nombre = item["Nombre"].ToString();
                    listaPlanes2.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                    listaPlanes2.Valor = Convert.ToDecimal(item["Valor"].ToString());
                    listaPlanes.Add(listaPlanes2);
                }
            }
            connection.Close();
            return listaPlanes;
        }
        public static bool InsertNuevoValor(PlanesSociales _planes)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaHistorialValorPlan";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Valor_in", _planes.Valor);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _planes.FechaDeAlta);
            cmd.Parameters.AddWithValue("idUsuario_in", _planes.idUsuario);
            cmd.Parameters.AddWithValue("idPlan_in", _planes.idPlan);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ValidarPlanExistente(string nombre)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<PlanesSociales> lista = new List<PlanesSociales>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                       new MySqlParameter("Nombre_in", nombre)};
            string proceso = "ValidarPlanExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "planessocietarios");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
    }
}
