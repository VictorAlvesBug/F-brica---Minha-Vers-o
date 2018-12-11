using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model
{
    class Disciplina
    {
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }

        public Disciplina()
        {
            Nota1 = 0;
            Nota2 = 0;
            Nota3 = 0;
        }

        public double ObterMedia()
        {
            return (Nota1+Nota2+Nota3) / 3;
        }
    }
}
