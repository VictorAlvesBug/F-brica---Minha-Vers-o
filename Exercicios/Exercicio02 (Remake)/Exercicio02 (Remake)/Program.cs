using Fiap.Banco.Model;
using Fiap.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02__Remake_
{
    class Program
    {
        public static ConsoleColor ConsoleColor { get; private set; }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            ContaCorrente cc = new ContaCorrente()
            {
                Tipo = TipoConta.Comum,
                Agencia = 123,
                Numero = 123456,
                DataAbertura = DateTime.Now,
                Saldo = 100
            };

            ContaPoupanca cp = new ContaPoupanca(0.05m)
            {
                Agencia = 321,
                Numero = 654321,
                DataAbertura = new DateTime(1999, 01, 10),
                Saldo = 100
            };

            ConsoleKey key;
            string feedback = "";

            do
            {
                Console.Clear();
                Console.WriteLine(" Contas Bancarias");

                Console.WriteLine("\n ----- Conta Corrente -----");
                Console.WriteLine("   Tipo: " + cc.Tipo);
                Console.WriteLine("   Agencia: " + cc.Agencia);
                Console.WriteLine("   Numero: " + cc.Numero);
                Console.WriteLine("   Data: " + cc.DataAbertura);
                Console.WriteLine("   Saldo: " + cc.Saldo);

                Console.WriteLine("\n ----- Conta Poupança -----");
                Console.WriteLine("   Taxa: " + cp.Taxa);
                Console.WriteLine("   Agencia: " + cp.Agencia);
                Console.WriteLine("   Numero: " + cp.Numero);
                Console.WriteLine("   Data: " + cp.DataAbertura);
                Console.WriteLine("   Saldo: " + cp.Saldo);

                if (feedback.Length > 0)
                {
                    Console.WriteLine("\n" + feedback);
                }

                Console.Write("\n A --> Depositar 10 reais na conta corrente");
                Console.Write("\n S --> Retirar 10 reais na conta corrente");
                Console.Write("\n D --> Depositar 10 reais na conta poupança");
                Console.Write("\n F --> Retirar 10 reais na conta poupança");
                Console.Write("\n G --> Calcular retorno de investimento da conta poupança");

                Console.WriteLine("\n");

                key = Console.ReadKey().Key;
                feedback = "";

                switch (key)
                {
                    case ConsoleKey.A:
                        cc.Depositar(10);
                        feedback += "Depositou 10 reais na conta corrente";
                        break;

                    case ConsoleKey.S:
                        try
                        {
                            cc.Retirar(10);
                            feedback += "Retirou 10 reais da conta corrente";
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            feedback += e.Message;
                        }
                        break;

                    case ConsoleKey.D:
                        cp.Depositar(10);
                        feedback += "Depositou 10 reais na conta poupança";
                        break;

                    case ConsoleKey.F:
                        try
                        {
                            cp.Retirar(10);
                            feedback += "Retirou 10 reais da conta poupança";
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            feedback += e.Message;
                        }
                        break;

                    case ConsoleKey.G:
                        feedback += "Retorno de investimento da conta poupanca: " + cp.CalculaRetornoInvestimento();
                        break;
                }
            }
            while (key != ConsoleKey.Escape);
        }
    }
}
