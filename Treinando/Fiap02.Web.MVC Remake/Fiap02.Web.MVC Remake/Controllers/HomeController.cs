using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap02.Web.MVC_Remake.Controllers
{
    public class HomeController : Controller
    {
        //ALVO DO URL ~/home/index
        public ActionResult Index()
        {
            return View();
        }
    }
}