using System;
using Microsoft.Data.SqlClient;

namespace Menu_Veículos.Vendedor
{
    public class Vendedor
    {
        public static int ProximoId = 1; // Inicializa o contador de IDs
        public int Id { get; private set; } // ID do vendedor
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Vendedor(string nome, int idade, string cpf_cnpj, string usuario, string senha)
        {
            Id = ProximoId++;
            Nome = nome;
            Idade = idade;
            CPF_CNPJ = cpf_cnpj;
            Usuario = usuario;
            Senha = senha;
        }
    }

    public static class VendedorService
    {
        // Defina a string de conexão com o banco de dados
        private static readonly string connectionString = "SuaConnectionStringAqui";

        public static void AddVendedor()
        {
            // Nome
            Console.WriteLine("Digite o nome do Vendedor: ");
            string nome = Console.ReadLine();

            // Idade
            Console.WriteLine("Agora, nos informe a idade do vendedor: ");
            if (!int.TryParse(Console.ReadLine(), out int idade) || idade < 18)
            {
                Console.WriteLine("Idade inválida. O vendedor deve ter 18 anos ou mais.");
                return;
            }

            // CPF/CNPJ
            Console.WriteLine("Nos informe seu CPF ou CNPJ. Digite 0 para CPF, ou 1 para CNPJ");
            int tipoDocumento;
            if (!int.TryParse(Console.ReadLine(), out tipoDocumento) || (tipoDocumento != 0 && tipoDocumento != 1))
            {
                Console.WriteLine("Opção inválida! Digite 0 para CPF ou 1 para CNPJ.");
                return;
            }

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
                Console.WriteLine("CPF válido.");
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
                Console.WriteLine("CNPJ válido.");
            }

            // Usuário
            Console.WriteLine("Por gentileza, nos informe um nome de usuário (utilize apenas 5 dígitos): ");
            string usuario = Console.ReadLine();
            if (usuario.Length != 5)
            {
                Console.WriteLine("Seu usuário deve conter exatamente 5 dígitos!");
                return;
            }

            // Senha
            Console.WriteLine("Digite agora sua senha (entre 5 e 15 caracteres): ");
            string senha = Console.ReadLine();
            if (senha.Length < 5 || senha.Length > 15)
            {
                Console.WriteLine("Sua senha deve ter no mínimo 5 caracteres e no máximo 15 caracteres.");
                return;
            }

            Vendedor vendedor = new Vendedor(nome, idade, documento, usuario, senha);

            // Inserir vendedor no banco de dados
            InsertVendedor(vendedor);
        }

        public static void InsertVendedor(Vendedor vendedor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abre a conexão com o banco de dados
                    connection.Open();

                    // Comando SQL para inserir o novo vendedor
                    string query = @"INSERT INTO Vendedores (Nome, Idade, CPF_CNPJ, Usuario, Senha) 
                                     VALUES (@Nome, @Idade, @CPF_CNPJ, @Usuario, @Senha)";

                    // Criação do comando SQL com parâmetros
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", vendedor.Nome);
                        command.Parameters.AddWithValue("@Idade", vendedor.Idade);
                        command.Parameters.AddWithValue("@CPF_CNPJ", vendedor.CPF_CNPJ);
                        command.Parameters.AddWithValue("@Usuario", vendedor.Usuario);
                        command.Parameters.AddWithValue("@Senha", vendedor.Senha);

                        // Executa o comando no banco de dados
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Vendedor {vendedor.Nome} cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falha ao cadastrar o vendedor.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar cadastrar o vendedor: " + ex.Message);
            }
        }
    }
}
