using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFiap.Web.MVC.Models
{
    public class AlunoModel
    {
        public int Rm { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Sexo Sexo { get; set; }
        public int Rg { get; set; }
        public int Cpf { get; set; }
        public string Endereco { get; set; }
    }
}