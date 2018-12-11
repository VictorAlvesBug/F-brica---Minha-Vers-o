using Fiap03.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using Fiap03.DAL.ConnectionFactories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.DAL.Repositories;
using Fiap03.MOD;

namespace Fiap03.Web.MVC.Controllers
{
    public class CarroController : Controller
    {
        private ICarroRepository _carroRepository = new CarroRepository();
        private IMarcaRepository _marcaRepository = new MarcaRepository();
        private IModeloRepository _modeloRepository = new ModeloRepository();

        //SIMULA O BANCO DE DADOS
        //STATIC --> A LISTA É DA CLASSE E NÃO DO OBJETO
        //SE TIVEREM VARIOS OBJETOS A LISTA SERÁ A MESMA PARA TODOS ELES

        private void CarregarMarcas()
        {
            //INSTANCIA UMA LISTA DE MARCAMODEL
            var listaMarcaModel = new List<MarcaModel>();
            //BUSCA A LISTA DE MARCAMOD
            var listaMarcaMOD = _marcaRepository.Listar();
            //CONVERTE A LISTA DE MOD PARA MODEL
            listaMarcaMOD.ToList().ForEach(m =>
            listaMarcaModel.Add(new MarcaModel(m)));

            ViewBag.marcas = new SelectList(listaMarcaModel, "Id", "Nome");
        }

        private CarroMOD CarroModel_To_CarroMOD(CarroModel model)
        {
            model.Renavam = model.Documento.Renavam;

            var documentoMOD = new DocumentoMOD()
            {
                Renavam = model.Documento.Renavam,
                Categoria = model.Documento.Categoria,
                DataFabricacao = model.Documento.DataFabricacao
            };
            
            var mod = new CarroMOD()
            {
                Id = model.Id,
                Marca = model.Marca,
                MarcaId = model.MarcaId,
                Modelo = model.Modelo,
                ModeloId = model.ModeloId,
                Placa = model.Placa,
                Ano = model.Ano,
                Esportivo = model.Esportivo,
                Combustivel = model.Combustivel,
                Descricao = model.Descricao,
                Renavam = model.Renavam,
                Documento = documentoMOD
            };

            return mod;
        }

        [HttpGet]
        public ActionResult ValidarPlaca(string placa)
        {
            var ok = _carroRepository.ValidarPlaca(placa);
            return Json(new { valida = ok }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ValidarRenavam(long renavam)
        {
            var ok = _carroRepository.ValidarRenavam(renavam);
            return Json(new { valido = ok }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuscarModelos(int marcaId)
        {
            var listaModeloMOD = _modeloRepository.BuscarModelos(marcaId);
            var lista = listaModeloMOD.Select(
                    c => new {
                        id = c.Id,
                        nome = c.Nome
                    });

            return Json(listaModeloMOD, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            //LISTAR AS MARCAS NO BANCO DE DADOS
            CarregarMarcas();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CarroModel model)
        {
            if (!_carroRepository.ValidarPlaca(model.Placa))
            {
                ModelState.AddModelError("Placa", new Exception("Placa já existente"));
            }

            if (!_carroRepository.ValidarRenavam(model.Renavam))
            {
                ModelState.AddModelError("Renavam", new Exception("Renavam já existente"));
            }

            if (!ModelState.IsValid)
            {
                return Cadastrar();
            }

            //CONVERTE CARROMODEL PARA CARROMOD
            var mod = CarroModel_To_CarroMOD(model);

            //CADASTRA O CARROMOD NO BANCO DE DADOS
            _carroRepository.Cadastrar(mod);

            //REDIRECIONA PARA UMA URL
            //CRIA UMA REQUEST PARA A PAGINA DE RESPOSTA
            //F5 NA VERDADE REFAZ A ULTIMA REQUEST
            //É COMO SE TIVESSE CLICADO NO URL E APERTADO ENTER
            TempData["msg"] = "Carro cadastrado com sucesso";
            return RedirectToAction("Listar");
            //DEVE-SE SEMPRE FAZER UM REDIRECT APOS UM POST
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var listaModel = new List<CarroModel>();
            var listaMOD = _carroRepository.Listar();
            listaMOD.ToList().ForEach(c => listaModel.Add(new CarroModel(c)));
            return View(listaModel);
        }

        [HttpGet]
        public ActionResult Pesquisar(int ano)
        {
            //ANO RETORNARA 0 CASO O SELECIONE ESTEJA MARCADO
            var listaModel = new List<CarroModel>();
            var listaMOD = _carroRepository.BuscarPorAno(ano);
            listaMOD.ToList().ForEach(c => listaModel.Add(new CarroModel(c)));
            return PartialView("_Dados", listaModel);
        }

        [HttpGet]
        public ActionResult Detalhes(CarroModel carro)
        {
            //ENVIA A LISTA DE DADOS PARA A VIEW
            return View(carro);
        }

        //ABRE A TELA DE EDIÇÃO COM O FORM PREENCHIDO
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var carroMOD = _carroRepository.Buscar(id);
            var carroModel = new CarroModel(carroMOD);
            CarregarMarcas();
            //MANDAR O CARRO PARA A VIEW
            return View(carroModel);
        }

        //EFETUA EDIÇÃO E VAI PARA LISTAGEM
        [HttpPost]
        public ActionResult Editar(CarroModel model)
        {
            if (!_carroRepository.ValidarPlaca(model.Placa))
            {
                ModelState.AddModelError("Placa", new Exception("Placa já existente"));
            }

            if (!_carroRepository.ValidarRenavam(model.Renavam))
            {
                ModelState.AddModelError("Renavam", new Exception("Renavam já existente"));
            }

            if (!ModelState.IsValid)
            {
                return Editar(model.Id);
            }

            var mod = CarroModel_To_CarroMOD(model);
            _carroRepository.Editar(mod);
            TempData["msg"] = "Carro atualizado com sucesso";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            _carroRepository.Excluir(codigo);
            TempData["msg"] = "Carro excluído com sucesso";
            return RedirectToAction("Listar");
        }

        /*
        
         HELPERS
         - (LABELFOR, DROPDOWN, LISTFOR)
         - (TEXTBOXFOR, TEXTAREAFOR)
         - (ACTIONLINK)
         - (BEGINFORM, ENDFORM, USING)
         RAZOR
         CRIAR OS HELPERS 

        VIEW
        -RAZOR
        -HELPERS
        -HTML/CSS/JS
        -BOOTSTRAP
        -LAYOUT
        -SECTION/PARTIAL

        CONTROLLER
        -ACTIONS
        -[GET][POST]
        -ACTIONRESULT
        
        VIEW --> CONTROLLER
        -PARAMETROS ("NAME")

        CONTROLLER --> VIEW
        -VIEWBAG.NAME
        -TEMPDATA["NAME"]
        -MODEL

        MODEL
        -BD

        BOOTSTRAP/LAYOUT

        DAPPER
        -ORM (MAPEAMENTO, OBJETO, RELACIONAL)

        QUERY

        - MODAL/EXCLUIR
        -EDITAR
        -PESQUISA POR UMA PROPRIEDADE

        HOMEWORK
        -AJUSTAR O PESQUISAR E O EDITAR
        -COMPLETAR A LISTA DE CARROS (NA LISTAGEM DE MARCA)
        
        - DAL --> DATA ACCESS LAYER

        VALIDAÇÕES
        - ANOTAÇÕES NA MODEL
        - CONTROLLER - if(modelState.isValid) ...
        - CSHTML - MENSAGENS

        INSTALAR
        - JQUERYUI
        - INPUTMASK

        1. AJUSTAR O FORM DE PESQUISA
        2. CRIAR UMA PARTIAL VIEW PARA O CORPO DA TABELA
        3. AJUSTAR O RETORNO DA ACTION(CONTROLLER)

        AJAX
        JQUERY / MASCARA / UI-DATEPICKER
         */
    }
}