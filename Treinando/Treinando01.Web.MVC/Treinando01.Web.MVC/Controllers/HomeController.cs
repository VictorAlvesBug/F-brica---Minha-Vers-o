using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinando01.DAL.Repositories;
using Treinando01.DAL.Repositories.Interfaces;
using Treinando01.MOD;
using Treinando01.Web.MVC.Models;

namespace Treinando01.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IAlunoRepository _alunoRepository = new AlunoRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new AlunoModel());
        }

        [HttpPost]
        public ActionResult Cadastrar(AlunoModel alunoModel)
        {
            var alunoMOD = new AlunoMOD()
            {
                Id = alunoModel.Id,
                Nome = alunoModel.Nome,
                Rm = alunoModel.Rm
            };

            _alunoRepository.Cadastrar(alunoMOD);

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var listaAlunoMOD = _alunoRepository.Listar();
            var listaAlunoModel = new List<AlunoModel>();
            listaAlunoMOD.ToList().ForEach(
                a => listaAlunoModel.Add(new AlunoModel(a))
                );
            return View(listaAlunoModel);
        }
    }
}