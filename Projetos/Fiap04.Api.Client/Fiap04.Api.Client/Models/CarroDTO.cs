using Fiap04.Api.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap04.Api.Client.Models
{
    public class CarroDTO
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public bool Esportivo { get; set; }
        public Combustivel? Combustivel { get; set; }
        public string Descricao { get; set; }
        //FK
        public long Renavam { get; set; }
        public DocumentoDTO Documento { get; set; }
    }
}