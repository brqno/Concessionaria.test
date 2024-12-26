using System;
using Microsoft.Data.SqlClient;

namespace ConsultaClientes
{
    public class ClienteConsulta
    {
        public static void Consulta()
        {
            Console.WriteLine("Digite 1 para buscar por ID ou 2 para buscar por Nome:");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.Write("Digite o ID do cliente: ");
                int id = int.Parse(Console.ReadLine());
                ConsultarClientePorId(id);
            }
            else if (escolha == "2")
            {
                Console.Write("Digite o Nome do cliente: ");
                string nome = Console.ReadLine();
                ConsultarClientePorNome(nome);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        public static void ConsultarClientePorId(int id)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Email, Pagamento FROM Clientes WHERE Id = @Id";
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
                                    Console.WriteLine("Email: " + reader["Email"]);
                                    Console.WriteLine("Pagamento: " + reader["Pagamento"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum cliente encontrado com o ID fornecido.");
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

        public static void ConsultarClientePorNome(string nome)
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Email, Pagamento FROM Clientes WHERE Nome LIKE @Nome";
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
                                    Console.WriteLine("Email: " + reader["Email"]);
                                    Console.WriteLine("Pagamento: " + reader["Pagamento"]);
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum cliente encontrado com o Nome fornecido.");
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
