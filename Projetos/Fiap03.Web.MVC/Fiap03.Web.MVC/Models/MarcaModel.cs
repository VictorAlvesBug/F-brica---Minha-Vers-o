using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.Models
{
    public class MarcaModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Data de Criação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(18, MinimumLength = 18)]
        public string Cnpj { get; set; }

        public IList<CarroModel> Carros { get; set; }

        public MarcaModel() { }

        public MarcaModel(MarcaMOD mod)
        {
            Nome = mod.Nome;
            Id = mod.Id;
            DataCriacao = mod.DataCriacao;
            Cnpj = mod.Cnpj;
            if (mod.Carros != null)
            {
                //INSTANCIA A LISTA DE CARROS
                var lista = new List<CarroModel>();
                mod.Carros.ToList().ForEach(c => lista.Add(new CarroModel(c)));
                Carros = lista;
            }
        }
    }
}