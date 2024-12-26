using System;
using Microsoft.Data.SqlClient;

namespace ConsultaVendedores
{
    public class VendedorConsulta
    {
        public static void Consulta()
        {
            Console.WriteLine("Digite 1 para buscar por ID ou 2 para buscar por Nome:");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.Write("Digite o ID do vendedor: ");
                int id = int.Parse(Console.ReadLine());
                ConsultarVendedorPorId(id);
            }
            else if (escolha == "2")
            {
                Console.Write("Digite o Nome do vendedor: ");
                string nome = Console.ReadLine();
                ConsultarVendedorPorNome(nome);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        public static void ConsultarVendedorPorId(int id)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Usuario FROM Vendedores WHERE Id = @Id";
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
                                    Console.WriteLine("Idade: " + reader["Idade"]);
                                    Console.WriteLine("CPF/CNPJ: " + reader["CPF_CNPJ"]);
                                    Console.WriteLine("Usuário: " + reader["Usuario"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum vendedor encontrado com o ID fornecido.");
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

        public static void ConsultarVendedorPorNome(string nome)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Usuario FROM Vendedores WHERE Nome LIKE @Nome";
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
                                    Console.WriteLine("Idade: " + reader["Idade"]);
                                    Console.WriteLine("CPF/CNPJ: " + reader["CPF_CNPJ"]);
                                    Console.WriteLine("Usuário: " + reader["Usuario"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum vendedor encontrado com o Nome fornecido.");
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
