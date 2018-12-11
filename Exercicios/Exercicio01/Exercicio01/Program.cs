using Exercicio01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Exercicio01.Exceptions;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();
            Cabecalho();

            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                Console.Clear();
                Cabecalho();

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Exercicio_1();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Exercicio_2();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Exercicio_3();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Exercicio_4();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Exercicio_5();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Exercicio_6();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Exercicio_7();
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        Exercicio_8();
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        Exercicio_9();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Exercicio_10();
                        break;
                }

                Console.Clear();
                Cabecalho();
            }
            while (key != ConsoleKey.Escape);
        }

        public static void Cabecalho()
        {
            Console.WriteLine("\n Digite o número do exercicio de 0 a 9 (0 --> Ex10)\n");
        }

        public static void Pausa()
        {
            Console.Write("\n Pressione qualquer tecla...");
            Console.ReadKey();
        }

        public static string AddString(int qtde, String texto)
        {
            string str = "";

            for (int i = 0; i < qtde; i++)
            {
                str += texto;
            }

            return str;
        }

        public static void Exercicio_1()
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex1) Numeros entre 10 e 500: ");

            for (int i = 10; i <= 500; i++)
            {
                Console.Write(i);
                if (i < 500)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(";");
                }
            }

            Pausa();
        }

        public static void Exercicio_2()
        {
            Console.Clear();
            Cabecalho();
            int soma = 0;

            for (int i = 1; i <= 100; i++)
            {
                soma += i;
            }

            Console.WriteLine(" Ex2) Soma de 1 a 100: " + soma);

            Pausa();
        }

        public static void Exercicio_3()
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex3) Multiplos de 3 entre 1 e 100: ");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write(i);
                    if (i + 3 < 100)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(";");
                    }
                }
            }

            Pausa();
        }

        public static void Exercicio_4()
        {
            bool variasLeituras = true;

            string linha;
            int x;

            if (variasLeituras)
            {
                do
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine(" 1 --> Sair do exercicio");
                    Console.Write("\n Ex4) Informe um valor inteiro para x: ");

                    linha = Console.ReadLine();

                    if (linha == "1")
                    {
                        return;
                    }

                    if (int.TryParse(linha, out x))
                    {
                        if (x % 2 == 0) // Par
                        {
                            x = x / 2;
                            Console.WriteLine(" x é par --> x = x/2");
                        }
                        else // Impar
                        {
                            x = 7 * x + 1;
                            Console.WriteLine(" x é impar --> x = 7*x + 1");
                        }

                        Console.WriteLine(" x = " + x);
                    }
                    else
                    {
                        Console.WriteLine(" Valor inválido");
                    }

                    Pausa();
                }
                while (true);
            }
            else
            {
                Console.Clear();
                Cabecalho();
                Console.Write(" Ex4) Informe um valor inteiro para x: ");

                linha = Console.ReadLine();

                if (int.TryParse(linha, out x))
                {
                    do
                    {
                        if (x % 2 == 0) // Par
                        {
                            x = x / 2;
                            Console.WriteLine(" x é par --> x = x/2");
                        }
                        else // Impar
                        {
                            x = 7 * x + 1;
                            Console.WriteLine(" x é impar --> x = 7*x + 1");
                        }

                        Console.WriteLine(" x = " + x);
                    }
                    while (x != 1);
                }
                else
                {
                    Console.WriteLine(" Valor inválido");
                }

                Pausa();
            }
        }

        public static void Exercicio_5()
        {
            string linha;
            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex5) Cálculo de Salário em função das horas trabalhadas.");
            Console.Write("\n Informe o valor da hora trabalhada: R$");

            decimal valor;
            do
            {
                linha = Console.ReadLine();

                if (decimal.TryParse(linha, out valor))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine(" Ex5) Cálculo de Salário em função das horas trabalhadas.");
                    Console.Write("\n Informe o valor da hora trabalhada: R$");
                }
            }
            while (true);

            Console.Write(" Informe o número de horas trabalhadas: ");

            int numHoras;
            do
            {
                linha = Console.ReadLine();

                if (int.TryParse(linha, out numHoras))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine(" Ex5) Cálculo de Salário em função das horas trabalhadas.");
                    Console.WriteLine("\n Informe o valor da hora trabalhada: R$" + valor);
                    Console.Write(" Informe o número de horas trabalhadas: ");
                }
            }
            while (true);

            Console.WriteLine("\n Seu salário será: R$" + (numHoras * valor).ToString("0.00"));

            Pausa();
        }

        public static void Exercicio_6()
        {
            Produto[] produto = new Produto[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex6) Cadastro de 3 produtos.");

                string linha;

                Console.WriteLine("\n ---------- Informações do produto " + (i + 1) + " ----------");

                Console.Write("\n Nome: ");
                string nome = Console.ReadLine();

                Console.Write(" Quantidade: ");
                int quantidade;
                do
                {
                    linha = Console.ReadLine();

                    if (int.TryParse(linha, out quantidade))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Cabecalho();
                        Console.WriteLine(" Ex6) Cadastro de 3 produtos.");
                        Console.WriteLine("\n ---------- Informações do produto " + (i + 1) + " ----------");

                        Console.Write("\n Nome: " + nome);
                        Console.Write("\n Quantidade: ");
                    }
                }
                while (true);

                Console.Write(" Preço: R$");
                decimal preco;
                do
                {
                    linha = Console.ReadLine();

                    if (decimal.TryParse(linha, out preco))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Cabecalho();
                        Console.WriteLine(" Ex6) Cadastro de 3 produtos.");
                        Console.WriteLine("\n ---------- Informações do produto " + (i + 1) + " ----------");

                        Console.Write("\n Nome: " + nome);
                        Console.Write("\n Quantidade: " + quantidade);
                        Console.Write("\n Preço: R$");
                    }
                }
                while (true);

                Console.Write(" Desconto (caso não tenha --> 0) em %: ");
                decimal desconto;
                do
                {
                    linha = Console.ReadLine();

                    if (decimal.TryParse(linha, out desconto))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Cabecalho();
                        Console.WriteLine(" Ex6) Cadastro de 3 produtos.");
                        Console.WriteLine("\n ---------- Informações do produto " + (i + 1) + " ----------");

                        Console.Write("\n Nome: " + nome);
                        Console.Write("\n Quantidade: " + quantidade);
                        Console.Write("\n Preço: R$" + preco);
                        Console.Write("\n Desconto (caso não tenha --> 0) em %: ");
                    }
                }
                while (true);

                produto[i] = new Produto(nome, quantidade, preco, desconto);
            }

            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex6) Cadastro de 3 produtos.\n");

            Console.WriteLine(" |      Produto       | Qtde. | P. Unidade (c/ desconto) |");
            // ("|20|7|26|")

            string info;
            decimal precoTotal = 0;

            for (int i = 0; i < 3; i++)
            {
                info = "";
                info += " | ";
                info += produto[i].Nome;
                info += AddString(19 - produto[i].Nome.Length, " ");
                info += "|";
                info += AddString(3, " ");
                info += produto[i].Quantidade;
                info += AddString(4 - produto[i].Quantidade.ToString().Length, " ");
                info += "|";
                info += AddString(10, " ");

                decimal precoUnidade = produto[i].Preco - (produto[i].Preco * (produto[i].Desconto / 100));

                info += precoUnidade.ToString("0.00");
                info += AddString(16 - precoUnidade.ToString("0.00").Length, " ");
                info += AddString(1, "|");

                Console.WriteLine(info);

                precoTotal += produto[i].Quantidade * precoUnidade;
            }

            info = "";
            info += " | Preço total";
            info += AddString(27, " ");
            info += precoTotal.ToString("0.00");
            info += AddString(16-precoTotal.ToString("0.00").Length, " ");
            info += "|";

            Console.WriteLine(info);

            Pausa();

            /*/// Nao funciona
            string linha;
            decimal salario;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex6) Cálculo de crédito especial.");
                Console.Write("\n Informe o seu salário: ");
                linha = Console.ReadLine();
            }
            while (decimal.TryParse(linha, out salario));

            decimal creditoEspecial;

            if (salario < 200)
            {
                creditoEspecial = 0;
            }
            else if (salario < 400)
            {
                creditoEspecial = salario * 0.2m;
            }
            else if (salario < 600)
            {
                creditoEspecial = salario * 0.3m;
            }
            else
            {
                creditoEspecial = salario * 0.4m;
            }

            Console.WriteLine("\n Crédito especial: R$" + creditoEspecial);

            Pausa();*/
        }

        public static void Exercicio_7()
        {
            string linha;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex7) Cálculo de IMC.");
                Console.Write("\n ----- Informações da pessoa -----");
                Console.Write("\n Nome: ");
                linha = Console.ReadLine();
            }
            while (linha.Trim() == "");
            string nome = linha;

            int idade;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex7) Cálculo de IMC.");
                Console.Write("\n ----- Informações da pessoa -----");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Idade: ");
                linha = Console.ReadLine();

                if (int.TryParse(linha, out idade))
                {
                    break;
                }
            }
            while (true);

            double peso;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex7) Cálculo de IMC.");
                Console.Write("\n ----- Informações da pessoa -----");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Idade: " + idade);
                Console.Write("\n Peso: ");
                linha = Console.ReadLine();

                if (double.TryParse(linha, out peso))
                {
                    break;
                }
            }
            while (true);

            double altura;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex7) Cálculo de IMC.");
                Console.Write("\n ----- Informações da pessoa -----");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Idade: " + idade);
                Console.Write("\n Peso: " + peso);
                Console.Write("\n Altura: ");
                linha = Console.ReadLine();

                if (double.TryParse(linha, out altura))
                {
                    break;
                }
            }
            while (true);

            Pessoa pessoa = new Pessoa(peso, altura)
            {
                Nome = nome,
                Idade = idade
            };

            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex7) Cálculo de IMC.");
            Console.Write("\n ----- Informações da pessoa -----");
            Console.Write("\n Nome: " + pessoa.Nome);
            Console.Write("\n Idade: " + pessoa.Idade);
            Console.Write("\n Peso: " + pessoa.Peso.ToString("0.0"));
            Console.Write("\n Altura: " + pessoa.Altura.ToString("0.00"));
            Console.Write("\n\n IMC: " + pessoa.CalcularIMC().ToString("0.00"));

            Pausa();

            /*Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex7) Cálculo de preço devido por um cliente.");
            Console.Write("\n Informe o código do produto: ");
            string codigo = Console.ReadLine();
            Console.Write("\n Informe a quantidade comprada: ");

            string linha;
            int qtde;
            do
            {
                linha = Console.ReadLine();

                if (int.TryParse(linha, out qtde))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine(" Ex7) Cálculo de preço devido por um cliente.");
                    Console.WriteLine("\n Informe o código do produto: " + codigo);
                    Console.Write("\n Informe a quantidade comprada: ");
                }
            }
            while (true);

            switch (codigo)
            {
                case "1001":
                    Console.WriteLine("\n Preço devido pelo cliente: " + (qtde * 51.32));
                    break;
                case "1324":
                    Console.WriteLine("\n Preço devido pelo cliente: " + (qtde * 16.45));
                    break;
                case "6548":
                    Console.WriteLine("\n Preço devido pelo cliente: " + (qtde * 12.37));
                    break;
                case "987":
                    Console.WriteLine("\n Preço devido pelo cliente: " + (qtde * 15.32));
                    break;
                case "7623":
                    Console.WriteLine("\n Preço devido pelo cliente: " + (qtde * 6.45));
                    break;
                default:
                    Console.WriteLine("\n Código inválido");
                    break;
            }

            Pausa();*/
        }

        public static void Exercicio_8()
        {
            Elevador elevador = new Elevador(10, 8);
            elevador.Inicializa();

            ConsoleKey key;
            string feedback = "";

            do
            {
                Console.Clear();
                Cabecalho();
                Console.Write(" Ex8) Controle de um elevador\n");
                Console.Write("\n ---------- Elevador ----------");
                Console.Write("\n  Andar atual: " + elevador.AndarAtual);
                if (elevador.AndarAtual == 0) { Console.Write(" (Térreo)"); }
                else if (elevador.AndarAtual == elevador.TotalAndares) { Console.Write(" (Último andar)"); }
                Console.Write("\n  Num. andares: " + elevador.TotalAndares);
                Console.Write("\n  Num. pessoas: " + elevador.NumPessoas);
                if (elevador.NumPessoas == 0) { Console.Write(" (Vazio)"); }
                else if (elevador.NumPessoas == elevador.MaxPessoas) { Console.Write(" (Lotado)"); }
                Console.Write("\n  Lotação: " + elevador.MaxPessoas);
                Console.Write("\n\n");

                if (feedback.Length > 0)
                {
                    Console.WriteLine(feedback + "\n");
                }
                
                Console.WriteLine(" W --> Sobe");
                Console.WriteLine(" S --> Desce");
                Console.WriteLine(" A --> Sai");
                Console.WriteLine(" D --> Entra");
                Console.WriteLine(" ESC --> Sair do Exercicio");

                feedback = "";

                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        try
                        {
                            elevador.Sobe();
                            feedback += " Subiu um andar";
                        }
                        catch (MaxAndaresException e)
                        {
                            feedback += e.Message;
                        }
                        break;

                    case ConsoleKey.S:
                        try
                        {
                            elevador.Desce();
                            feedback += " Desceu um andar";
                        }
                        catch (MinAndaresException e)
                        {
                            feedback += e.Message;
                        }
                        break;

                    case ConsoleKey.A:
                        try
                        {
                            elevador.Sai();
                            feedback += " Saiu uma pessoa";
                        }
                        catch (MinPessoasException e)
                        {
                            feedback += e.Message;
                        }
                        break;

                    case ConsoleKey.D:
                        try
                        {
                            elevador.Entra();
                            feedback += " Entrou uma pessoa";
                        }
                        catch (MaxPessoasException e)
                        {
                            feedback += e.Message;
                        }
                        break;
                }
            }
            while (key != ConsoleKey.Escape);

            /*int totalVotos = 0;
            int voto;
            int[] votos = new int[7];
            for (int i = 0; i < 7; i++)
            {
                votos[i] = 0;
            }
            bool empate = false;
            int vencedor = 0;
            int maxVotos = 0;

            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex8) Votos de uma eleição.");
                Console.WriteLine("\n 1-5 --> Candidatos");
                Console.WriteLine(" 6 --> Voto nulo");
                Console.WriteLine(" 7 --> Voto branco");
                Console.WriteLine(" 0 --> Finalizar votação");
                Console.WriteLine("\n Votos computados: " + totalVotos);
                Console.Write("\n Vote: ");

                string linha;
                do
                {
                    linha = Console.ReadLine();

                    if (int.TryParse(linha, out voto))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Cabecalho();
                        Console.WriteLine(" Ex8) Votos de uma eleição.");
                        Console.WriteLine("\n 1-5 --> Candidatos");
                        Console.WriteLine(" 6 --> Voto nulo");
                        Console.WriteLine(" 7 --> Voto branco");
                        Console.WriteLine(" 0 --> Finalizar votação");
                        Console.WriteLine("\n Votos computados: " + totalVotos);
                        Console.Write("\n Vote: ");
                    }
                }
                while (true);

                if (voto >= 1 && voto <= 7)
                {
                    votos[voto - 1]++;
                    totalVotos++;
                }
                int cont = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (votos[i] > maxVotos)
                    {
                        maxVotos = votos[i];
                        vencedor = i + 1;
                    }
                    else if (votos[i] == maxVotos)
                    {
                        cont++;
                    }
                }

                if (cont > 1)
                {
                    empate = true;
                }
                else
                {
                    empate = false;
                }

            }
            while (voto != 0);

            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex8) Votos de uma eleição.");
            Console.WriteLine("\n Resultado");
            Console.WriteLine("\n Candidato 1: " + votos[0] + " votos");
            Console.WriteLine(" Candidato 2: " + votos[1] + " votos");
            Console.WriteLine(" Candidato 3: " + votos[2] + " votos");
            Console.WriteLine(" Candidato 4: " + votos[3] + " votos");
            Console.WriteLine(" Candidato 5: " + votos[4] + " votos");
            Console.WriteLine("\n Nulo (6): " + votos[5] + " votos");
            Console.WriteLine(" Branco (7): " + votos[6] + " votos");

            if (empate)
            {
                Console.WriteLine("\n Empate");
            }
            else
            {
                Console.WriteLine("\n Vencedor: Candidato" + vencedor);
            }

            Pausa();*/
        }

        public static void Exercicio_9()
        {
            string linha;

            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex9) Cadastro de aluno.");
                Console.WriteLine("\n ---------- Informações do aluno ----------");
                Console.Write("\n Nome: ");
                linha = Console.ReadLine();
            }
            while (linha.Trim() == "");
            string nome = linha;

            double nota1;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex9) Cadastro de aluno.");
                Console.WriteLine("\n ---------- Informações do aluno ----------");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Nota 1: ");
                linha = Console.ReadLine();
                if (double.TryParse(linha, out nota1))
                {
                    break;
                }
            }
            while (true);

            double nota2;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex9) Cadastro de aluno.");
                Console.WriteLine("\n ---------- Informações do aluno ----------");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Nota 1: " + nota1);
                Console.Write("\n Nota 2: ");
                linha = Console.ReadLine();
                if (double.TryParse(linha, out nota2))
                {
                    break;
                }
            }
            while (true);

            double nota3;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine(" Ex9) Cadastro de aluno.");
                Console.WriteLine("\n ---------- Informações do aluno ----------");
                Console.Write("\n Nome: " + nome);
                Console.Write("\n Nota 1: " + nota1);
                Console.Write("\n Nota 2: " + nota2);
                Console.Write("\n Nota 3: ");
                linha = Console.ReadLine();
                if (double.TryParse(linha, out nota3))
                {
                    break;
                }
            }
            while (true);

            Aluno aluno = new Aluno(nome);

            aluno.AtribuirNotas(nota1, nota2, nota3);

            Console.WriteLine("\n Média: " + aluno.ObterMedia().ToString("0.00"));

            Pausa();
        }

        public static void Exercicio_10()
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine(" Ex10) Padrões triangulares:");

            Console.WriteLine("\n    A)");
            for (int j = 0; j < 10; j++)
            {
                Console.Write("    ");

                for (int i = 0; i < 10; i++)
                {
                    if (i <= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n    B)");
            for (int j = 9; j >= 0; j--)
            {
                Console.Write("    ");

                for (int i = 0; i < 10; i++)
                {
                    if (i <= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n    C)");
            for (int j = 0; j < 10; j++)
            {
                Console.Write("    ");

                for (int i = 0; i < 10; i++)
                {
                    if (i >= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n    D)");
            for (int j = 9; j >= 0; j--)
            {
                Console.Write("    ");

                for (int i = 0; i < 10; i++)
                {
                    if (i >= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write("\n");
            }

            Pausa();
        }
    }
}
