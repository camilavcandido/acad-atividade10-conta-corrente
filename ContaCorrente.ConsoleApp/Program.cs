using System;

namespace ContaCorrente.ConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            ContaCorrente conta1 = new ContaCorrente();
            conta1.numero = 111;
            conta1.saldo = 0;
            conta1.limite = 1000;
            conta1.ehEspecial = true;
            conta1.movimentacoes = new Movimentacao[10];

            ContaCorrente conta2 = new ContaCorrente();
            conta2.numero = 222;
            conta2.saldo = 200;
            conta2.limite = 1000;
            conta2.ehEspecial = false;
            conta2.movimentacoes = new Movimentacao[10];

            conta1.ExibirDadosConta();
            conta1.Depositar(400);
            conta1.Sacar(50);
            conta1.Transferir(conta2, 100);
            conta1.EmitirExtrato();

            conta2.ExibirDadosConta();
            conta2.Depositar(100000);
            conta2.Sacar(5000);
            conta2.EmitirExtrato();

        }

    }
}