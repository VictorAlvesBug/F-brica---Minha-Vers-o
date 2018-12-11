using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }

        public Produto(string nome, int quantidade, decimal preco, decimal desconto)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
            Desconto = desconto;
        }
    }
}
