using System;
namespace ContaCorrente.ConsoleApp
{
    public partial class ContaCorrente
    {
        static int geraNumero = 0;
        private int _numero;
        private double _saldo;
        private double _limite;
        private bool _ehEspecial;
        private Movimentacao[] _movimentacoes;
        private Notificador notificador = new Notificador();

        //construtor - ok
        public ContaCorrente(double limite, bool ehEspecial)
        {
            geraNumero++;
            this._numero = geraNumero;
            this._limite = limite;
            this._ehEspecial = ehEspecial;
            this._movimentacoes = new Movimentacao[100];
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
            Movimentacao movimentacaoRealizada = new Movimentacao();
            movimentacaoRealizada.tipo = "Crédito";
            movimentacaoRealizada.valor = valor;
            AddMovimentacao(movimentacaoRealizada);
            notificador.ApresentaMensagem("Depósito realizado com sucesso",
                ConsoleColor.Green);

        }

        public void Sacar(double valor)
        {

            if (valor > (this._saldo + this._limite))
                notificador.ApresentaMensagem("Saldo insuficiente!", ConsoleColor.Red);
            else
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.tipo = "Débito";
                movimentacao.valor = valor;
                AddMovimentacao(movimentacao);
                this._saldo -= valor;
                notificador.ApresentaMensagem("Saque realizado com sucesso!", ConsoleColor.Green);
            }

        }

        public void Transferir(ContaCorrente contaDestino, double valor)
        {
            if (valor > _saldo)
            {
                notificador.ApresentaMensagem("Saldo insuficiente!", ConsoleColor.Red);
            }
            else
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.tipo = "Transferência";
                movimentacao.valor = valor;
                AddMovimentacao(movimentacao);
                _saldo -= valor;
                contaDestino._saldo += valor;
                notificador.ApresentaMensagem("Trânsferencia realizada com sucesso", ConsoleColor.Green);
            }

        }

        public void EmitirExtrato()
        {
            Console.WriteLine("===========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Conta Número {0}: ", this._numero);
            Console.ResetColor();
            Console.WriteLine("Saldo: {0} ", this._saldo);
            Console.WriteLine("Limite: {0}", this._limite);
            if (this._ehEspecial == true)
                Console.WriteLine("Conta Especial: Sim");
            else
            {
                Console.WriteLine("Conta Especial: Não");
            }

            notificador.ApresentaMensagem("Extrato", ConsoleColor.Blue);
            if (_movimentacoes[0] == null)
                notificador.ApresentaMensagem("Conta não possuí movimentações", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < _movimentacoes.Length; i++)
                {
                    if (_movimentacoes[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        switch (_movimentacoes[i].tipo)
                        {
                            case "Crédito":
                                Console.WriteLine("Deposito realizado no " +
                                    "valor de R$ {0}", _movimentacoes[i].valor);
                                break;
                            case "Débito":
                                Console.WriteLine("Saque realizado no " +
                                   "valor de R$ {0}", _movimentacoes[i].valor);
                                break;
                            case "Transferência":
                                Console.WriteLine("Trânsferencia realizada no " +
                                   "valor de R$ {0}", _movimentacoes[i].valor);
                                break;
                        }
                    }
                }
            }
        }

        private void AddMovimentacao(Movimentacao movimentacao)
        {
            for (int i = 0; i < _movimentacoes.Length; i++)
            {
                if (_movimentacoes[i] == null)
                {
                    _movimentacoes[i] = movimentacao;
                    break;
                }
            }
        }

    }

}

