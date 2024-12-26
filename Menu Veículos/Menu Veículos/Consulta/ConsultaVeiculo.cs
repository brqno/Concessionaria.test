using System;
using Microsoft.Data.SqlClient;

namespace ConsultaVeiculos
{
    public class VeiculoConsulta
    {
        public static void Consulta()
        {
            Console.WriteLine("Digite 1 para buscar por ID ou 2 para buscar por Nome:");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.Write("Digite o ID do veículo: ");
                int id = int.Parse(Console.ReadLine());
                ConsultarVeiculoPorId(id);
            }
            else if (escolha == "2")
            {
                Console.Write("Digite o Nome do veículo: ");
                string nome = Console.ReadLine();
                ConsultarVeiculoPorNome(nome);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        public static void ConsultarVeiculoPorId(int id)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Placa, Modelo, Ano, Preco FROM Veiculos WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("ID: " + reader["Id"]);
                                    Console.WriteLine("Nome: " + reader["Nome"]);
                                    Console.WriteLine("Placa: " + reader["Placa"]);
                                    Console.WriteLine("Modelo: " + reader["Modelo"]);
                                    Console.WriteLine("Ano: " + reader["Ano"]);
                                    Console.WriteLine("Preço: R$ " + reader["Preco"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum veículo encontrado com o ID fornecido.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        public static void ConsultarVeiculoPorNome(string nome)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Placa, Modelo, Ano, Preco FROM Veiculos WHERE Nome LIKE @Nome";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", "%" + nome + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("ID: " + reader["Id"]);
                                    Console.WriteLine("Nome: " + reader["Nome"]);
                                    Console.WriteLine("Placa: " + reader["Placa"]);
                                    Console.WriteLine("Modelo: " + reader["Modelo"]);
                                    Console.WriteLine("Ano: " + reader["Ano"]);
                                    Console.WriteLine("Preço: R$ " + reader["Preco"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum veículo encontrado com o Nome fornecido.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }
    }
}
