namespace Menu_Veículos.Cliente
{
    public class Endereco
    {
        public static int ProximoId = 1; // Inicializa o contador de IDs
        public int Id { get; private set; } // ID do endereço
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            // Atribuindo o próximo ID disponível e incrementando o contador
            Id = ProximoId++;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
    }
}
