using Fiap03.MOD;
using Fiap03.MOD.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.API.Models
{
    public class DocumentoDTO
    {
        public long Renavam { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }

        public DocumentoDTO() { }

        public DocumentoDTO(DocumentoMOD documentoMOD)
        {
            Renavam = documentoMOD.Renavam;
            Categoria = documentoMOD.Categoria;
            DataFabricacao = documentoMOD.DataFabricacao;
        }
    }
}