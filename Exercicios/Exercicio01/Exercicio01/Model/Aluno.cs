using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model
{
    class Aluno
    {
        public Disciplina disciplina { get; set; }
        public string Nome { get; set; }

        public Aluno(string nome)
        {
            disciplina = new Disciplina();
            Nome = nome;
        }

        public void AtribuirNotas(double nota1, double nota2, double nota3)
        {
            disciplina.Nota1 = nota1;
            disciplina.Nota2 = nota2;
            disciplina.Nota3 = nota3;
        }

        public double ObterMedia()
        {
            return disciplina.ObterMedia();
        }
    }
}
