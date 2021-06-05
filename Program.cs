using System;
using System.Collections.Generic;

namespace DIO.BANK
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X" )
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine();
                        NovaConta();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        ListarContas();
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        Sacar();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        Depositar();
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        Transferir();
                        Console.WriteLine();
                        break;
                    default:
                         throw new ArgumentOutOfRangeException("Opção Inválida");
                        
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Bem vindo ao DIO BANK");
            Console.WriteLine("Selecione uma das seguintes opções abaixo!");
            Console.WriteLine("1 - Cadastrar uma conta");
            Console.WriteLine("2 - Listar contas");
            Console.WriteLine("3 - Realizar um saque");
            Console.WriteLine("4 - Realizar um depósito");
            Console.WriteLine("5 - Realizar uma transferência");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            return opcao;

        }

        private static void NovaConta()
        {
            Console.WriteLine("Informe o tipo da conta (1) Pessoa Fisica - (2)  Pessoa Juridica");
            int tipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do titular da conta");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o saldo da conta");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o crédito da conta");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome, (TipoConta)tipoConta, saldo, credito);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {

                Conta conta = listContas[i];

                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);

            }


        }

        private static void Depositar()

        
        {
             if (listContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas. Realize o cadastro da conta para realizar o depósito");
                return;
            }

            Console.WriteLine("Informe o número da conta");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor do depósito");
            double valor = double.Parse(Console.ReadLine());


            listContas[numero].Depositar(valor);
        }

        private static void Sacar(){
             if (listContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas. Opção não disponível");
                return;
            }
            Console.WriteLine("Informe o número da conta");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor do saque");
            double valor = double.Parse(Console.ReadLine());

            listContas[numero].Sacar(valor);

        }

        private static void Transferir(){
             if (listContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas. Opção não disponível");
                return;
            }
            Console.WriteLine("Informe o número da conta de ORIGEM");
            int origem = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor da tranferencia");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o número da conta de DESTINO");
            int destino = int.Parse(Console.ReadLine());

            listContas[origem].Transferir(valor, listContas[destino]);

        }
    }
}
