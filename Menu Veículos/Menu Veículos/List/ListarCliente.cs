using System;
using Microsoft.Data.SqlClient;

namespace Menu_VeiculosListClient
{
    public class ListarClientes
    {
        public static void ExibirClientes()
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para selecionar os campos desejados
                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Email, Pagamento FROM Clientes";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Exibe o cabeçalho
                            Console.WriteLine("{0,-5} {1,-25} {2,-6} {3,-15} {4,-25} {5,-10}", "ID", "Nome", "Idade", "CPF/CNPJ", "Email", "Pagamento");
                            Console.WriteLine(new string('-', 90));

                            // Loop para exibir os dados
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                int idade = reader.GetInt32(2);
                                string cpfCnpj = reader.GetString(3);
                                string email = reader.GetString(4);
                                string pagamento = reader.GetString(5);

                                // Exibe os dados alinhados corretamente
                                Console.WriteLine("{0,-5} {1,-25} {2,-6} {3,-15} {4,-25} {5,-10}", id, nome, idade, cpfCnpj, email, pagamento);
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
