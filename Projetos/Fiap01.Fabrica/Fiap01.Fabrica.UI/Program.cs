using Fiap01.Fabrica.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI
{
    class Program
    {
        //EXECUTAVEL NO WINDOWNS (DESKTOP) --> .EXE
        //EXECUTAVEL NO NAVEGADOR (WEB) --> .DLL 

        //METODOS INICIAM COM LETRA MAIÚSCULA

        //CONSTRUTOR NAO TEM RETORNO(NEM VOID) E TEM O NOME DA CLASSE

        // CASO NÃO SEJA DETERMINADO O 

        static void Main(string[] args)
        {
            //CRIANDO UM OBJETO ALUNO

            //PARAMETRO É OBRIGATORIO
            Aluno aluno = new Aluno("123", "Victor")
            {
                //ORDEM NÃO IMPORTA
                //VALORES OPCIONAIS
                //Nome = "Victor",
                Idade = 10
            };

            aluno.Sexo = Genero.Masculino;

            //CRIANDO UMA LISTA DE ALUNOS
            IList<Aluno> turma = new List<Aluno>();
            turma.Add(aluno);
            turma.Add(new Aluno("321", "Arnaldo"));

            foreach (var item in turma)
            {
                Console.WriteLine(item.Nome);
            }

            //SO DA PRA CRIAR COM var QUANDO DEFINIMOS SEU VALOR
        }
    }
}
