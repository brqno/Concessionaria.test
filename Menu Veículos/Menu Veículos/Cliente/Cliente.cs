using System;
using Microsoft.Data.SqlClient; // Biblioteca necessária para conexão com o SQL Server

namespace Menu_Veículos.Cliente
{
    public class Cliente
    {
        public static int ProximoId = 1; // Inicializa o contador de IDs
        public int Id { get; private set; } // ID do cliente
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Pagamento { get; set; }

        public Cliente(string nome, int idade, string cpf_cnpj, string email, string endereco, string pagamento)
        {
            this.Id = ProximoId++; // Atribui o ID e incrementa o próximo ID
            Nome = nome;
            Idade = idade;
            CPF_CNPJ = cpf_cnpj;
            Email = email;
            Endereco = endereco;
            Pagamento = pagamento;
        }
    }

    public static class ClienteService
    {
        public static void AddCliente()
        {
            try
            {
                // Nome
                Console.WriteLine("Digite o nome do Cliente: ");
                string nome = Console.ReadLine();

                // Idade
                Console.WriteLine("Agora, nos informe a idade do cliente: ");
                int idade = int.Parse(Console.ReadLine());
                if (idade < 18)
                {
                    Console.WriteLine("O cliente deve possuir mais de 18 anos.");
                    return;
                }

                // CPF/CNPJ
                Console.WriteLine("Nos informe seu CPF ou CNPJ. Digite 0 para CPF, ou 1 para CNPJ");
                int tipoDocumento = int.Parse(Console.ReadLine());

                string documento = "";

                if (tipoDocumento == 0) // CPF
                {
                    Console.WriteLine("Digite seu CPF: ");
                    documento = Console.ReadLine();

                    if (documento.Length != 11 || !long.TryParse(documento, out _))
                    {
                        Console.WriteLine("CPF inválido! Deve conter exatamente 11 dígitos numéricos.");
                        return;
                    }
                }
                else if (tipoDocumento == 1) // CNPJ
                {
                    Console.WriteLine("Digite seu CNPJ: ");
                    documento = Console.ReadLine();

                    if (documento.Length != 14 || !long.TryParse(documento, out _))
                    {
                        Console.WriteLine("CNPJ inválido! Deve conter exatamente 14 dígitos numéricos.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite 0 para CPF ou 1 para CNPJ.");
                    return;
                }

                // Email
                Console.WriteLine("Por gentileza, nos informe o E-mail do cliente: ");
                string email = Console.ReadLine();
                if (!(email.EndsWith("gmail.com") || email.EndsWith("outlook.com") || email.EndsWith("hotmail.com")))
                {
                    Console.WriteLine("Aceitamos apenas emails dos domínios: Hotmail, Outlook e Gmail.");
                    return;
                }

                // Endereço
                Console.WriteLine("Informe a Rua: ");
                string rua = Console.ReadLine();
                Console.WriteLine("Informe o Número: ");
                string numero = Console.ReadLine();
                Console.WriteLine("Informe o Bairro: ");
                string bairro = Console.ReadLine();
                Console.WriteLine("Informe a Cidade: ");
                string cidade = Console.ReadLine();
                Console.WriteLine("Informe o Estado: ");
                string estado = Console.ReadLine();
                Console.WriteLine("Informe o CEP: ");
                string cep = Console.ReadLine();
                if (cep.Length != 8 || !long.TryParse(cep, out _))
                {
                    Console.WriteLine("CEP inválido! Deve conter exatamente 8 dígitos numéricos.");
                    return;
                }

                // Criação do endereço
                string endereco = $"{rua}, {numero}, {bairro}, {cidade}, {estado}, {cep}";

                // Pagamento
                Console.WriteLine("Nos informe sua forma de pagamento: ");
                string pagamento = Console.ReadLine();
                if (!(pagamento.EndsWith("PIX") || pagamento.EndsWith("Crédito") || pagamento.EndsWith("Débito")))
                {
                    Console.WriteLine("Forma de pagamento inválida. Aceitamos apenas PIX, Crédito ou Débito.");
                    return;
                }

                // Criação do cliente
                Cliente cliente = new Cliente(nome, idade, documento, email, endereco, pagamento);

                // Salvar cliente no banco de dados
                SaveToDatabase(cliente);

                Console.WriteLine($"Cliente {cliente.Nome} cadastrado com sucesso! ID: {cliente.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private static void SaveToDatabase(Cliente cliente)
        {
            // Substitua pela sua string de conexão
            string connectionString = "Server=DESKTOP-9LK813Q;Database=Concessionaria;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Clientes (Nome, Idade, CPF_CNPJ, Email, Endereco, Pagamento)
                    VALUES (@Nome, @Idade, @CPF_CNPJ, @Email, @Endereco, @Pagamento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Idade", cliente.Idade);
                    command.Parameters.AddWithValue("@CPF_CNPJ", cliente.CPF_CNPJ);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    command.Parameters.AddWithValue("@Pagamento", cliente.Pagamento);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
