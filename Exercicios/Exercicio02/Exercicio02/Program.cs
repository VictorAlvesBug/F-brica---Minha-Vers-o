using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Banco.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente corrente = new ContaCorrente()
            {
                Tipo = TipoConta.Comum,
                Agencia = 123,
                DataAbertura = DateTime.Now,
                Numero = 12345,
                Saldo = 100
            };
            //                                         CONVERTER PARA DECIMAL
            ContaPoupanca poupanca = new ContaPoupanca(0.05m)
            {
                Taxa = 0.2m,
                Agencia = 2,
                DataAbertura = new DateTime(1999, 01, 10),
                Numero = 54321,
                Saldo = 200
            };

            ConsoleKey key;
            String feedback = "";

            do
            {
                Console.Clear();

                Console.WriteLine("----------------- Corrente -----------------");
                Console.WriteLine(" Tipo: " + corrente.Tipo);
                Console.WriteLine(" Agencia: " + corrente.Agencia);
                Console.WriteLine(" DataAbertura: " + corrente.DataAbertura);
                Console.WriteLine(" Numero: " + corrente.Numero);
                Console.WriteLine(" Saldo: " + corrente.Saldo);

                Console.WriteLine("\n----------------- Poupanca -----------------");
                Console.WriteLine(" Tipo: " + poupanca.Taxa);
                Console.WriteLine(" Agencia: " + poupanca.Agencia);
                Console.WriteLine(" DataAbertura: " + poupanca.DataAbertura);
                Console.WriteLine(" Numero: " + poupanca.Numero);
                Console.WriteLine(" Saldo: " + poupanca.Saldo);

                if (feedback.Length > 0)
                {
                    Console.WriteLine(feedback);
                }

                Console.WriteLine("\n-------------- Teclas de ação --------------");
                Console.WriteLine(" A --> Deposita 10 reais na conta corrente");
                Console.WriteLine(" S --> Retira 10 reais da conta corrente");
                Console.WriteLine(" D --> Deposita 10 reais na conta poupanca");
                Console.WriteLine(" F --> Retira 10 reais da conta poupanca");
                Console.WriteLine(" G --> Calcula retorno de investimento");
                Console.WriteLine(" ESC --> Sair");

                feedback = "";

                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        corrente.Depositar(10);
                        feedback += "\n Depositou 10 reais na conta corrente";
                        break;
                    case ConsoleKey.S:
                        try
                        {
                            corrente.Retirar(10);
                            feedback += "\n Retirou 10 reais da conta corrente";
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            feedback += "\n" + e.Message;
                        }
                        break;
                    case ConsoleKey.D:
                        poupanca.Depositar(10);
                        feedback += "\n Depositou 10 reais na conta poupanca";
                        break;
                    case ConsoleKey.F:
                        try
                        {
                            poupanca.Retirar(10);
                            feedback += "\n Retirou 10 reais da conta poupanca";
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            feedback += "\n" + e.Message;
                        }
                        break;
                    case ConsoleKey.G:
                        decimal retorno = poupanca.CalculaRetornoInvestimento();
                        feedback += "\nRetorno de investimento: " + retorno;
                        break;
                    default:
                        break;
                }

            }
            while (key != ConsoleKey.Escape);
            
        }
    }
}
