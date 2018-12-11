using Fiap03.MOD.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.MOD
{
    public class DocumentoMOD
    {
        public long Renavam { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }
    }
}
