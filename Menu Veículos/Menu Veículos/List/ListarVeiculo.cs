using System;
using Microsoft.Data.SqlClient;

namespace Menu_VeiculoListVehicle
{
    public class ListarVeiculos
    {
        public static void ExibirVeiculos()
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Placa, Modelo, Ano, Preco FROM Veiculos";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("ID\tNome\tPlaca\tModelo\tAno\tPreço");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                string placa = reader.GetString(2);
                                string modelo = reader.GetString(3);
                                int ano = reader.GetInt32(4);
                                decimal preco = reader.GetDecimal(5);

                                Console.WriteLine($"{id}\t{nome}\t{placa}\t{modelo}\t{ano}\t{preco:C}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }
    }
}
