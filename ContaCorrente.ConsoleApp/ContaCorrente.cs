using System;
namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int numero;
        public double saldo;
        public double limite;
        public bool ehEspecial;
        public Movimentacao[] movimentacoes;

        public void Depositar(double valor)
        {
            saldo += valor;
            Movimentacao movimentacaoRealizada = new Movimentacao();
            movimentacaoRealizada.tipo = "Crédito";
            movimentacaoRealizada.valor = valor;
            AddMovimentacao(movimentacaoRealizada);
            apresentaMensagem("Depósito realizado com sucesso", ConsoleColor.Green);

        }

        public void Sacar(double valor)
        {

            if (valor > (saldo + limite))
                apresentaMensagem("Saldo insuficiente!", ConsoleColor.Red);
            else
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.tipo = "Débito";
                movimentacao.valor = valor;
                AddMovimentacao(movimentacao);
                saldo -= valor;
                apresentaMensagem("Saque realizado com sucesso!", ConsoleColor.Green);
            }

        }

        public void AddMovimentacao(Movimentacao movimentacao)
        {
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] == null)
                {
                    movimentacoes[i] = movimentacao;
                    break;
                }
            }
        }

        public double EmitirSaldo()
        {
            return saldo;

        }

        public void Transferir(ContaCorrente contaDestino, double valor)
        {
            if (valor > saldo)
            {
                apresentaMensagem("Saldo insuficiente!", ConsoleColor.Red);
            }
            else
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.tipo = "Débito";
                movimentacao.valor = valor;
                AddMovimentacao(movimentacao);
                saldo -= valor;
                contaDestino.saldo += valor;
                apresentaMensagem("Trânsferencia realizada com suceeso", ConsoleColor.Green);
            }

        }

        public void EmitirExtrato()
        {


            apresentaMensagem("Extrato", ConsoleColor.Blue);
            if (movimentacoes[0] == null)
                apresentaMensagem("Conta não possuí movimentações", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < movimentacoes.Length; i++)
                {
                    if (movimentacoes[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        switch (movimentacoes[i].tipo)
                        {
                            case "Crédito":
                                Console.WriteLine("Deposito realizado no " +
                                    "valor de R$ {0}", movimentacoes[i].valor);
                                break;
                            case "Débito":
                                Console.WriteLine("Saque realizado no " +
                                   "valor de R$ {0}", movimentacoes[i].valor);
                                break;
                        }
                    }
                }
            }
        }

        public void apresentaMensagem(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void ExibirDadosConta()
        {
            Console.WriteLine("===========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Conta Número {0}: ", this.numero);
            Console.ResetColor();
            Console.WriteLine("Saldo: {0} ", this.saldo);
            Console.WriteLine("Limite: {0}", this.limite);
            if (this.ehEspecial == true)
                Console.WriteLine("Conta Especial: Sim");
            else
                Console.WriteLine("Conta Especial: Não");
        }
    }

}

