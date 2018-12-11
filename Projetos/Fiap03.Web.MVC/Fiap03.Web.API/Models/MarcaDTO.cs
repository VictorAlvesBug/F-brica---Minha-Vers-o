using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.API.Models
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Cnpj { get; set; }

        public MarcaDTO() { }

        public MarcaDTO(MarcaMOD marcaMOD)
        {
            Id = marcaMOD.Id;
            Nome = marcaMOD.Nome;
            DataCriacao = marcaMOD.DataCriacao;
            Cnpj = marcaMOD.Cnpj;
        }
    }
}