using System;
using Microsoft.Data.SqlClient;

namespace Menu_VeiculoListSeller
{
    public class ListarVendedor
    {
        public static void ExibirVendedores()
        {
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Nome, Idade, CPF_CNPJ, Usuario FROM Vendedores";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Vendedores cadastrados:");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                int idade = reader.GetInt32(2);
                                string cpfCnpj = reader.GetString(3);
                                string usuario = reader.GetString(4);

                                Console.WriteLine($"ID: {id}");
                                Console.WriteLine($"Nome: {nome}");
                                Console.WriteLine($"Idade: {idade}");
                                Console.WriteLine($"CPF/CNPJ: {cpfCnpj}");
                                Console.WriteLine($"Usuário: {usuario}");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao listar os vendedores.");
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
