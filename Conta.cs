using System;

namespace DIO.BANK
{
    public class Conta
    {

        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, TipoConta tipoConta, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;

        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Depósito não realizado");
                return;
            }

            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {

            if ((this.Saldo - valor) < (this.Credito * -1))
            {
                Console.WriteLine("Saldo indisponível");
                return false;
            }

            this.Saldo -= valor;
            Console.WriteLine("O saldo atual da conta do {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if (this.Sacar(valor))
            {
              contaDestino.Depositar(valor);
              Console.WriteLine("Saldo: {0}", this.Saldo);
            }
            else{
              Console.WriteLine("Operação não realizada");
            }


        }

        public override string ToString()
        {
            string retorno = "";
            retorno = "Tipo de Conta " + this.TipoConta + " | ";
            retorno += "Titular " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}