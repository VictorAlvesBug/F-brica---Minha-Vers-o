using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.API.Models
{
    public class ModeloDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }

        public ModeloDTO() { }

        public ModeloDTO(ModeloMOD modeloMOD)
        {
            Id = modeloMOD.Id;
            Nome = modeloMOD.Nome;
            MarcaId = modeloMOD.MarcaId;
        }
    }
}