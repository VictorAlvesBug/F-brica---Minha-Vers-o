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
    public class AlunoController : Controller
    {
        [HttpGet]
        public ActionResult PortalDoAluno()
        {
            using (IDbConnection db = new SqlConnection(
                    ConfigurationManager.
                    ConnectionStrings["DB_FIAP"].
                    ConnectionString))
            {
                db.Open();
                string comando = @"SELECT * FROM Aluno
                                    WHERE Rm = @Rm";

                AlunoModel aluno = db.Query<AlunoModel>(comando, 
                    new
                    {
                        Rm = Convert.ToInt32(TempData["codigo"])
                    }).SingleOrDefault();
            }

            return View(new AlunoModel());
            //return View(aluno);
        }
    }
}