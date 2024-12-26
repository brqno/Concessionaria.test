using System;
using Microsoft.Data.SqlClient;

namespace Menu_Veículos.Veiculos
{
    public class Veiculo
    {
        public static int ProximoId = 1; // Inicializa o contador de IDs
        public int Id { get; private set; } // ID do veículo
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Preço { get; set; }

        public Veiculo(string nome, string placa, string modelo, int ano, double preço)
        {
            this.Id = ProximoId++; // Atribui o ID e incrementa o próximo ID
            Nome = nome;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Preço = preço;
        }
    }

    public static class VeiculoService
    {
        private static string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";

        public static void AddVeiculo()
        {
            // Nome
            Console.WriteLine("Digite o nome do veículo: ");
            string nome = Console.ReadLine();

            // Placa
            Console.WriteLine("Nos informe a placa, por gentileza: ");
            string placa = Console.ReadLine();
            if (placa.Length != 7 || !long.TryParse(placa, out _))
            {
                Console.WriteLine("Placa inválida! Deve conter exatamente 7 dígitos alfanuméricos.");
                return;
            }

            // Modelo
            Console.WriteLine("Nos informe o modelo do carro: ");
            string modelo = Console.ReadLine();
            if (modelo.EndsWith("SUV") || modelo.EndsWith("HATCH") || modelo.EndsWith("SEDAN"))
            {
                Console.WriteLine("Modelo aprovado!");
            }
            else
            {
                Console.WriteLine("Por favor, selecione um modelo válido.");
                return;
            }

            // Ano
            Console.WriteLine("Informe o ano do veículo: ");
            int ano = int.Parse(Console.ReadLine());

            // Preço
            Console.WriteLine("Nos informe o preço do seu carro: ");
            string input = Console.ReadLine();
            double preco;

            if (double.TryParse(input, out preco))
            {
                // Inserir no banco de dados
                InsertVeiculoIntoDatabase(nome, placa, modelo, ano, preco);
            }
            else
            {
                Console.WriteLine("O valor informado não é um preço válido.");
            }
        }

        private static void InsertVeiculoIntoDatabase(string nome, string placa, string modelo, int ano, double preco)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Veiculos (Nome, Placa, Modelo, Ano, Preco) VALUES (@Nome, @Placa, @Modelo, @Ano, @Preco)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Adiciona parâmetros à query para evitar SQL Injection
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Placa", placa);
                    command.Parameters.AddWithValue("@Modelo", modelo);
                    command.Parameters.AddWithValue("@Ano", ano);
                    command.Parameters.AddWithValue("@Preco", preco);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("Veículo cadastrado com sucesso no banco de dados!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao tentar cadastrar o veículo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
        }
    }
}
