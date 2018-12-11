using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Models
{
    class Aluno : Pessoa
    {
        public string Rm { get; set; }

        //O CONSTRUTOR DO FILHO PRECISA CHAMAR UM CONSTRUTOR DO PAI
        //base --> CLASSE PAI (Pessoa) (COMO SE FOSSE O super DO JAVA)
        public Aluno(string rm, string nome) : base(nome)
        {
            Rm = rm;
        }

        public override void VerBoletim()
        {
            Console.WriteLine("Aluno visualizando o boletim");
        }

        public override void Cadastrar()
        {
            Console.WriteLine("sendo cadastrado");
        }
    }
}
