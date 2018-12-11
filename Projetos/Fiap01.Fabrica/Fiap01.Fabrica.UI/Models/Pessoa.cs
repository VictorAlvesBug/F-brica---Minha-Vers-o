using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Models
{
    //CLASSE ABSTRRATA NÃO DA PRA INSTANCIAR ()
    //QUANDO NÃO DECLARA A HERANÇA ELE HERDA DE object
    public abstract class Pessoa
    {
        //PROPRIEDADE private INICIA COM UNDERLINE _
        private string _nome;

        //FUNCIONAM DA MESMA FORMA
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        //////

        public int Idade { get; set; }

        public Genero Sexo { get; set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public abstract void VerBoletim();

        //virtual --> PERMITE A SOBREESCRITA DO METODO (override)
        public virtual void Cadastrar()
        {
            Console.WriteLine();
        }
    }
}
