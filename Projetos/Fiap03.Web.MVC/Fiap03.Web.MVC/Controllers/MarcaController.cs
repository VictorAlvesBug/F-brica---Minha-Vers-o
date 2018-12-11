using Fiap03.DAL.Repositories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using Fiap03.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    [Authorize]
    public class MarcaController : Controller
    {
        private IMarcaRepository _marcaRepository = new MarcaRepository();

        private MarcaMOD MarcaModel_To_MarcaMOD(MarcaModel model)
        {
            var listaCarroMOD = new List<CarroMOD>();
            model.Carros.ToList().ForEach(c => 
            listaCarroMOD.Add(CarroModel_To_CarroMOD(c)));

            var mod = new MarcaMOD()
            {
                Id = model.Id,
                Nome = model.Nome,
                DataCriacao = model.DataCriacao,
                Cnpj = model.Cnpj,
                Carros = listaCarroMOD
            };

            return mod;
        }

        private CarroMOD CarroModel_To_CarroMOD(CarroModel model)
        {
            model.Renavam = model.Documento.Renavam;

            var documentoMOD = new DocumentoMOD()
            {
                Renavam = model.Renavam,
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

        [HttpGet] //VEM DO URL
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost] //VEM DO FORM
        public ActionResult Cadastrar(MarcaModel marca)
        {
            /*if (!_marcaRepository.ValidarCnpj(marca.Cnpj))
            {
                ModelState.AddModelError("Cnpj", new Exception("CNPJ já existente"));
            }*/

            if (!ModelState.IsValid)
            {
                return Cadastrar();
            }
            //VALIDAR CAMPOS DO FORM
            if (!ModelState.IsValid)
            {
                //ERRO DE VALIDAÇÃO, RETORNA PARA A PAGINA OS ERROS DE VALIDAÇÃO
                return View(marca);
            }

            //CONVERTER DE MOD PARA MODEL
            var mod = new MarcaMOD()
            {
                Cnpj = marca.Cnpj,
                DataCriacao = marca.DataCriacao,
                Nome = marca.Nome
            };
            try
            {
                //CHAMAR O REPOSITORY (CADASTRAR) PARA GRAVAR NO BANCO
                _marcaRepository.Cadastrar(mod);
                TempData["msg"] = "Marca cadastrada com sucesso";
                return RedirectToAction("Listar");
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao cadastrar marca";
                return null;
            }
            
        }

        [HttpGet] //VEM DO URL
        public ActionResult Listar()
        {
            //INSTANCIA A LISTA DE MARCA MODEL
            var listaModel = new List<MarcaModel>();
            //BUSCA A LISTA DE MARCAMOD DO BANCO DE DADOS
            var listaMOD = _marcaRepository.Listar();
            //CONVERTE O MOD PARA MODEL
            listaMOD.ToList().ForEach(m => listaModel.Add(new MarcaModel(m)));
            //RETORNA A VIEW COM A LISTA DE MARCAMODEL
            return View(listaModel);
        }

        /*[HttpGet]
        public ActionResult Pesquisar(int nome)
        {
            //ANO RETORNARA 0 CASO O SELECIONE ESTEJA MARCADO
            using (IDbConnection db = new SqlConnection(
            ConfigurationManager.
            ConnectionStrings["DBCarros"].
            ConnectionString))
            {
                var comando = "SELECT * FROM Marca WHERE Nome LIKE @Nome";
                IList<MarcaModel> lista = db.Query<MarcaModel>(comando, new { nome }).ToList();
                return View("Listar", lista);
            }
        }*/

        //ABRE A TELA DE LISTAGEM DOS CARROS DESSA MARCA
        [HttpGet]
        public ActionResult Detalhes(int idDaMarca)
        {
            //PESQUISA A MARCA COM OS CARROS NO BD
            var marcaMOD = _marcaRepository.BuscarComCarros(idDaMarca);
            //TRANSFORMAR O MOD EM MODEL
            var marcaModel = new MarcaModel(marcaMOD);
            return View(marcaModel);
        }

        //ABRE A TELA DE EDIÇÃO COM O FORM PREENCHIDO
        [HttpGet]
        public ActionResult Editar(int id)
        {
            //BUSCAR A MARCAMOD DO BANCO DE DADOS PELO ID
            var marcaMOD = _marcaRepository.Buscar(id);
            //CONVERTER A MARCAMOD PARA MARCAMODEL
            var marcaModel = new MarcaModel(marcaMOD);
            //RETORNAR A VIEW COM O MODEL
            return View(marcaModel);
        }

        //EFETUA EDIÇÃO E VOLTA PRA LISTAGEM
        [HttpPost]
        public ActionResult Editar(MarcaModel marca)
        {
            if (!_marcaRepository.ValidarCnpj(marca.Cnpj))
            {
                ModelState.AddModelError("Cnpj", new Exception("CNPJ já existente"));
            }

            if (!ModelState.IsValid)
            {
                return Editar(marca.Id);
            }

            //CONVERTE O MODEL PARA MOD
            var mod = new MarcaMOD()
            {
                Id = marca.Id,
                Cnpj = marca.Cnpj,
                DataCriacao = marca.DataCriacao,
                Nome = marca.Nome
            };
            //CHAMA O METODO DO REPOSITORU PARA EDITAR
            _marcaRepository.Editar(mod);
            TempData["msg"] = "Marca atualizada com sucesso";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            _marcaRepository.Excluir(codigo);
            TempData["msg"] = "Marca excluída com sucesso";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult ValidarCnpj(string cnpj)
        {
            var ok = _marcaRepository.ValidarCnpj(cnpj);
            return Json(new { valido = ok }, JsonRequestBehavior.AllowGet);
        }
    }
}