using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{

    public class CriptomonedaDAO
    {
        public void DarAlta(Criptomoneda cripto)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);
                using (connection)
                {
                    connection.Open();
                    string query = "INSERT INTO Criptomoneda (siglas, descripcion, precio) VALUES(@siglas, @descripcion, @precio)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@siglas", cripto.Siglas);
                        command.Parameters.AddWithValue("@descripcion", cripto.Descripcion);
                        command.Parameters.AddWithValue("@precio", cripto.Precio);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarPrecio(int ID, double precio)
        { 
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);
                using (connection)
                {
                    connection.Open();
                    string query = "UPDATE Criptomoneda SET precio = @precio WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", ID);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Criptomoneda> GetCriptos()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);

                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM Criptomoneda";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        List<Criptomoneda> Criptos = new List<Criptomoneda>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Criptomoneda cripto = new Criptomoneda();
                                cripto.ID = Convert.ToInt32(reader["id"]);
                                cripto.Descripcion = reader["descripcion"].ToString();
                                cripto.Precio = Convert.ToDouble(reader["precio"]);
                                Criptos.Add(cripto);
                            }
                        }
                        return Criptos;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int id)
        {
            
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);
                using (connection)
                {
                    connection.Open();
                    string query = "DELETE FROM Criptomoneda WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
