using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public Pessoa(double peso, double altura)
        {
            Peso = peso;
            Altura = altura;
        }

        public double CalcularIMC()
        {
            return Peso / (Altura * Altura);
        }
    }
}
