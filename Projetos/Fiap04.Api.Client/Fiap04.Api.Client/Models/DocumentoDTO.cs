using Fiap04.Api.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap04.Api.Client.Models
{
    public class DocumentoDTO
    {
        public long Renavam { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }
    }
}