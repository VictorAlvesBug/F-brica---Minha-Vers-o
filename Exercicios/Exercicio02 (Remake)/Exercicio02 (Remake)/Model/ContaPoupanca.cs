using Fiap.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Banco.Model
{
    public class ContaPoupanca : Conta, IContaInvestimento
    {
        private readonly decimal _rendimento;
        public decimal Taxa { get; set; }

        public ContaPoupanca(decimal rendimento)
        {
            _rendimento = rendimento;
        }

        public override void Retirar(decimal valor)
        {
            if (valor > 0)
            {
                if ((Saldo - (valor+Taxa)) < 0)
                {
                    throw new SaldoInsuficienteException("Saldo insuficiente para efetuar saque");
                }

                Saldo -= valor + Taxa;
            }
        }

        public decimal CalculaRetornoInvestimento()
        {
            return Saldo * _rendimento;
        }
    }
}
