using Fiap03.MOD;
using Fiap03.MOD.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap03.Web.MVC.Models
{
    public class DocumentoModel
    {
        [Display(Name = "Renavam")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public long Renavam { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Categoria? Categoria { get; set; }

        [Display(Name = "Data de Fabricação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataFabricacao { get; set; }

        public DocumentoModel() { }

        public DocumentoModel(DocumentoMOD mod)
        {
            if (mod != null)
            {
                Renavam = mod.Renavam;
                Categoria = mod.Categoria;
                DataFabricacao = mod.DataFabricacao;
            }
        }
    }
}