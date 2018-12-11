using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Banco.Model
{
    //sealed NÃO PERMITE A HERANCA DA CLASSE ATUAL
    public sealed class ContaCorrente : Conta
    {
        public TipoConta Tipo;

        public ContaCorrente()
        {
            Saldo = 0;
        }

        public override void Retirar(decimal valor)
        {
            if (valor > 0)
            {
                if (Tipo == TipoConta.Comum && Saldo-valor < 0)
                {
                    throw new SaldoInsuficienteException("Você não possui saldo suficiente para efetuar o saque");
                    //QUANDO CHEGA NO throw ELE NAO EXECUTA O RESTO DO CODIGO
                    //SE COMPORTA COMO SE FOSSE UM return
                }

                Saldo -= valor;
            }
        }
    }
}
