using Fiap02.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap02.Web.MVC.Controllers
{
    public class AlunoController : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            //VEM DO URL
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            //VEM DO URL
            return View(new Aluno());
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            //VEM DO BOTÃO CADASTRAR

            //FAZ A PERSISTENCIA DE DADOS
            ViewBag.nome = aluno.Nome;  // É APAGADO APOS REDIRECT
            TempData["nome"] = aluno.Nome;  // NÃO É APAGADO APOS REDIRECT

            return View(aluno);
            //return RedirectToAction("Cadastrar");
        }

        /*
        
        >AULA 2 (01/11/2018)
        ROTAS
        CAPTURAR DADOS - PARAMETROS (OBJETO, SEPARADAMENTE OU REQUEST)
        FORMULARIO HTML
        HTTP GET/POST
        FORWARD/REDIRECT
        ENVIAR OS DADOS DA CONTROLLER PARA A VIEW
          - TempData
          - ViewBag
          - (MODEL) STRONGLY TYPED VIEW


         */
    }
}