using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Banco.Model
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        private readonly decimal _rendimento;
        public decimal Taxa { get; set; }

        public ContaPoupanca(decimal valor)
        {
            _rendimento = valor;
        }

        public decimal CalculaRetornoInvestimento()
        {
            return Saldo * _rendimento;
        }

        public override void Retirar(decimal valor)
        {
            if (valor > 0)
            {
                if (Saldo - (valor + Taxa) < 0)
                {
                    throw new SaldoInsuficienteException();
                    //SAI DO METODO
                }

                //FUNCIONA IGUAL
                Saldo -= (valor + Taxa);
                //Saldo -= valor + Taxa;
            }
        }
    }
}
