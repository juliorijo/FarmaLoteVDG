using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FarmaLoteVDG
{
    public class ConexionTest
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["FarmaLoteVDG"].ConnectionString;

        public bool ProbarConexion()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    return conexion.State == ConnectionState.Open;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión: " + ex.Message);
                    return false;
                }
            }
        }

        public static List<MedicineLot> ListarLotes(string filtro = null)
        {
            List<MedicineLot> lista = new List<MedicineLot>();

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string query = "SELECT ID_Lote, Nombre_Medicamento, Numero_Lote, Cantidad_Disponible, Fecha_Vencimiento FROM LOTE WHERE Activo = 1";

                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idLote = Convert.ToInt32(reader["ID_Lote"]); 
                        string nombreMedicamento = reader["Nombre_Medicamento"].ToString();
                        string numeroLote = reader["Numero_Lote"].ToString();
                        int cantidad = Convert.ToInt32(reader["Cantidad_Disponible"]);
                        DateTime vencimiento = Convert.ToDateTime(reader["Fecha_Vencimiento"]);

                        MedicineLot lote = new MedicineLot(nombreMedicamento, numeroLote, cantidad, vencimiento);
                        lote.Id = idLote; 

                        lista.Add(lote);
                    }
                }
            }

            return lista;
        }

        public static void CrearLote(string nombreProducto, string categoria, bool gravado, string numeroLote, DateTime fechaVencimiento, int cantidad)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearLote", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Gravado", gravado);
                cmd.Parameters.AddWithValue("@NumeroLote", numeroLote);
                cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                SqlParameter paramId = new SqlParameter("@IdLoteNuevo", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramId);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarLote(MedicineLot lote)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarLote", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Lote", lote.Id);
                cmd.Parameters.AddWithValue("@NumeroLote", lote.LotNumber);
                cmd.Parameters.AddWithValue("@FechaVencimiento", lote.Expiry);
                cmd.Parameters.AddWithValue("@Cantidad", lote.Quantity);
                cmd.Parameters.AddWithValue("@Nombre_Medicamento", lote.Medicine); 

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void RetirarLote(int idLote)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_RetirarLote", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLote", idLote);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}