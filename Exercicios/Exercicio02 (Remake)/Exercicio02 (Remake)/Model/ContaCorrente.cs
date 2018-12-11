using Fiap.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Banco.Model
{
    public sealed class ContaCorrente : Conta
    {
        public TipoConta Tipo { get; set; }

        public override void Retirar(decimal valor)
        {
            if (valor > 0)
            {
                if (Tipo == TipoConta.Comum && (Saldo - valor) < 0)
                {
                    throw new SaldoInsuficienteException("Saldo insuficiente para efetuar saque");
                }

                Saldo -= valor;
            }
        }
    }
}
