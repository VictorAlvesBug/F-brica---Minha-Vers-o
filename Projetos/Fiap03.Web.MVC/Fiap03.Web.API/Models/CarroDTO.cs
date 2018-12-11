using Fiap03.MOD;
using Fiap03.MOD.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.API.Models
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

        public CarroDTO() { }

        public CarroDTO(CarroMOD carroMOD)
        {
            Id = carroMOD.Id;
            MarcaId = carroMOD.MarcaId;
            Marca = carroMOD.Marca;
            ModeloId = carroMOD.ModeloId;
            Modelo = carroMOD.Modelo;
            Placa = carroMOD.Placa;
            Ano = carroMOD.Ano;
            Esportivo = carroMOD.Esportivo;
            Combustivel = carroMOD.Combustivel;
            Descricao = carroMOD.Descricao;
            Renavam = carroMOD.Renavam;
            Documento = new DocumentoDTO(carroMOD.Documento);
        }
    }
}