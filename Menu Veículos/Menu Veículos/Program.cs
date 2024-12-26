// Program.cs
using System;
using Menu_Veículos.Cliente;
using Menu_Veículos.Veiculos;
using Menu_Veículos.Vendedor;
using Menu_VeiculosListClient;
using Menu_VeiculoListVehicle;
using Menu_VeiculoListSeller;
using ConsultaClientes;
using ConsultaVeiculos;
using ConsultaVendedores;
class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("-- Menu Concessionária --");
            Console.WriteLine("-------------------------");
            Console.WriteLine("[1] Cadastrar Veículo");
            Console.WriteLine("[2] Cadastrar Cliente");
            Console.WriteLine("[3] Cadastrar Vendedor");
            Console.WriteLine("[4] Listar Veículos");
            Console.WriteLine("[5] Listar Vendedores");
            Console.WriteLine("[6] Listar Clientes");
            Console.WriteLine("[7] Pesquisar Veículo");
            Console.WriteLine("[8] Pesquisar Clientes");
            Console.WriteLine("[9] Pesquisar Vendedor");
            Console.WriteLine("[10] Sair");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>");

            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    Console.WriteLine("Opção 1 selecionada: Cadastrar Veículo");
                    VeiculoService.AddVeiculo();
                    break;

                case "2":
                    Console.WriteLine("Opção 2 selecionada: Cadastrar Cliente.");
                    ClienteService.AddCliente();
                    break;

                case "3":
                    Console.WriteLine("Opção 3 selecionada: Cadastrar Vendedor.");
                    VendedorService.AddVendedor();
                    break;

                case "4":
                    Console.WriteLine("Opção 4 selecionada: Listar Veículos");
                    ListarVeiculos.ExibirVeiculos();
                    break;

                case "5":
                    Console.WriteLine("Opção 5 selecionada: Listar Vendedores");
                    ListarVendedor.ExibirVendedores();
                    break;

                case "6":
                    Console.WriteLine("Opção 6 selecionada: Listar Clientes");
                    ListarClientes.ExibirClientes();
                    break;

                case "7":
                    Console.WriteLine("Opção 7 selecionada: Consultar Veículo");
                    VeiculoConsulta.Consulta();
                    break;

                case "8":
                    Console.WriteLine("Opção 8 selecionada: Consultar Clientes");
                    ClienteConsulta.Consulta();
                    break;

                case "9":
                    Console.WriteLine("Opção 9 selecionada: Consultar Clientes");
                    VendedorConsulta.Consulta();
                    break;

                case "10":
                    Console.WriteLine("Saindo...");
                    running = false; // Encerra o programa
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente!");
                    break;
            }
        }
    }
}
