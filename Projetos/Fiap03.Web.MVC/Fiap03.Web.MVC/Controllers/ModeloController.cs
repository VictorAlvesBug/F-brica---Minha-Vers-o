using Fiap03.DAL.Repositories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using Fiap03.Web.MVC.Models;
using Fiap03.Web.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class ModeloController : Controller
    {
        private IModeloRepository _modeloRepository = new ModeloRepository();
        private IMarcaRepository _marcaRepository = new MarcaRepository();

        private ModeloMOD ModeloModel_To_ModeloMOD(ModeloModel model)
        {
            var mod = new ModeloMOD()
            {
                Id = model.Id,
                Nome = model.Nome,
                MarcaId = model.MarcaId
            };

            return mod;
        }

        [HttpGet]
        public ActionResult Index(int marcaId)
        {
            var marca = _marcaRepository.Buscar(marcaId);

            var listaModeloModel = new List<ModeloModel>();
            var listaModeloMOD = _modeloRepository.Listar(marcaId);
            listaModeloMOD.ToList().ForEach(m => listaModeloModel.Add(new ModeloModel(m)));

            var modeloViewModel = new ModeloViewModel()
            {
                NomeMarca = marca.Nome,
                Lista = listaModeloModel,
                Modelo = new ModeloModel()
                {
                    MarcaId = marca.Id
                }
            };

            return View(modeloViewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(ModeloViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Index(model.Modelo.Id);
            }

            var mod = ModeloModel_To_ModeloMOD(model.Modelo);
            _modeloRepository.Cadastrar(mod);
            TempData["msg"] = "Modelo cadastrado com sucesso";
            return RedirectToAction("Index", new { marcaId = model.Modelo.MarcaId });
        }
    }
}