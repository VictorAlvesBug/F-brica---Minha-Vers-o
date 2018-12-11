using Dapper;
using SistemaFiap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFiap.Web.MVC.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(int codigo, string senha)
        {
            TempData["codigo"] = codigo;

            /*using (IDbConnection db = new SqlConnection(
                ConfigurationManager.
                ConnectionStrings["DB_FIAP"].
                ConnectionString))
            {
                string comando = "";

                switch (codigo.ToString().Length)
                {
                    case 3:
                        //BUSCA NA TABELA DE ADMINISTRADOR
                        comando = @"SELECT * FROM Administrador WHERE
                                       Adm = @Adm AND Senha = @Senha";
                        AdministradorModel administrador = db.Query<AdministradorModel>(comando,
                            new
                            {
                                Adm = codigo,
                                Senha = senha
                            }).SingleOrDefault();

                        if (administrador != null)
                        {
                            return RedirectToAction("PortalDoAdministrador", "Administrador");
                        }
                        break;
                    case 4:
                        //BUSCA NA TABELA DE PROFESSOR
                        comando = @"SELECT * FROM Professor WHERE
                                       Pf = @Pf AND Senha = @Senha";
                        ProfessorModel professor = db.Query<ProfessorModel>(comando,
                            new
                            {
                                Pf = codigo,
                                Senha = senha
                            }).SingleOrDefault();

                        if (professor != null)
                        {
                            return RedirectToAction("PortalDoProfessor", "Professor");
                        }
                        break;
                    case 5:
                        //BUSCA NA TABELA DE ALUNO
                        comando = @"SELECT * FROM Aluno WHERE
                                       Rm = @Rm AND Senha = @Senha";
                        AlunoModel aluno = db.Query<AlunoModel>(comando,
                            new
                            {
                                Rm = codigo,
                                Senha = senha
                            }).SingleOrDefault();

                        if (aluno != null)
                        {*/
                            return RedirectToAction("PortalDoAluno", "Aluno");
                        /*}
                        break;
                }

                return View();
            }*/
        }
    }
}