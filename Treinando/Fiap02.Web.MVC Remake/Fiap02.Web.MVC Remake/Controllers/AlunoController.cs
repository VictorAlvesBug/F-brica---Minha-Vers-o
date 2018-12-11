using Fiap02.Web.MVC_Remake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap02.Web.MVC_Remake.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        //ALVO DO URL ~/aluno/index
        public ActionResult Index()
        {
            return View(new Aluno());
        }

        //ALVO DO URL ~/aluno/adicionar
        public ActionResult Adicionar()
        {
            return View(new Aluno());
        }

        //ALVO DO URL ~/aluno/listar
        public ActionResult Listar(Aluno aluno)
        {
            /*string nome = aluno.Nome;
            string ano = aluno.Ano;
            double nota = aluno.Nota;*/
            return View(aluno);
        }
    }
}