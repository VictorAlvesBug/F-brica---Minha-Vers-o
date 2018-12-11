using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFiap.Web.MVC.Models
{
    public class AdministradorModel
    {
        public int Adm { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Sexo { get; set; }
        public int Rg { get; set; }
        public int Cpf { get; set; }
        public int Endereco { get; set; }

    }
}