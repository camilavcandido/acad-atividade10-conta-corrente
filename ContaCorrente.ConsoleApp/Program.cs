using System;

namespace ContaCorrente.ConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(1000, false);
            ContaCorrente conta2 = new ContaCorrente(2000, true);

            conta1.Depositar(100);
            conta1.Transferir(conta2, 50);
            conta1.EmitirExtrato();
            conta2.EmitirExtrato();
        }

    }
}