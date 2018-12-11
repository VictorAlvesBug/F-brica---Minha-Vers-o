using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Treinando01.MOD;

namespace Treinando01.Web.MVC.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "RM")]
        public int Rm { get; set; }

        public AlunoModel() { }

        public AlunoModel(AlunoMOD alunoMOD)
        {
            Id = alunoMOD.Id;
            Nome = alunoMOD.Nome;
            Rm = alunoMOD.Rm;
        }
    }
}