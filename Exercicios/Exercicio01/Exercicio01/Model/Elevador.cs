using Exercicio01.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model
{
    class Elevador
    {
        public int AndarAtual { get; set; }
        public readonly int TotalAndares;
        public readonly int MaxPessoas;
        public int NumPessoas { get; set; }

        public Elevador(int totalAndares, int maxPessoas)
        {
            // SETA UMA VEZ O VALOR, DEPOIS NÃO É MAIS MUTÁVEL
            TotalAndares = totalAndares;
            MaxPessoas = maxPessoas;
        }

        public void Inicializa()
        {
            AndarAtual = 0; //TÉRREO
            NumPessoas = 0; //VAZIO
        }

        public void Entra()
        {
            if (NumPessoas < MaxPessoas)
            {
                NumPessoas++;
            }
            else
            {
                throw new MaxPessoasException(" Não é possível entrar pois o elevador está lotado");
            }
        }

        public void Sai()
        {
            if (NumPessoas > 0)
            {
                NumPessoas--;
            }
            else
            {
                throw new MinPessoasException(" Não é possível sair pois o elevador está vazio");
            }
        }

        public void Sobe()
        {
            if (AndarAtual < TotalAndares)
            {
                AndarAtual++;
            }
            else
            {
                throw new MaxAndaresException(" Não é possível subir pois você já está no último andar");
            }
        }

        public void Desce()
        {
            if (AndarAtual > 0)
            {
                AndarAtual--;
            }
            else
            {
                throw new MinAndaresException(" Não é possível descer pois você já está no térreo");
            }
        }
    }
}
