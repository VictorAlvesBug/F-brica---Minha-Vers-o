using Fiap03.MOD;
using Fiap03.MOD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.Models
{
    public class CarroModel
    {
        public int Id { get; set; }

        //FK
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int MarcaId { get; set; }

        [Display(Name = "Nome")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ModeloId { get; set; }
        
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        //? --> PERMITE QUE O COMBUSTIVEL SEJA NULL
        [Display(Name = "Combustível")]
        public Combustivel? Combustivel { get; set; }
        
        [Range(minimum:1950, maximum:3000)]
        public int Ano { get; set; }

        public bool Esportivo { get; set; }

        [Display(Name = "Placa")]
        [StringLength(8, MinimumLength = 8)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Placa { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //FK
        public DocumentoModel Documento { get; set; }

        public long Renavam { get; set; }

        public CarroModel() { }

        public CarroModel(CarroMOD mod)
        {
            Id = mod.Id;
            MarcaId = mod.MarcaId;
            Marca = mod.Marca;
            ModeloId = mod.ModeloId;
            Modelo = mod.Modelo;
            Combustivel = mod.Combustivel;
            Ano = mod.Ano;
            Esportivo = mod.Esportivo;
            Placa = mod.Placa;
            Descricao = mod.Descricao;
            if (mod.Documento != null)
            {
                Documento = new DocumentoModel(mod.Documento);
            }
        }
    }
}