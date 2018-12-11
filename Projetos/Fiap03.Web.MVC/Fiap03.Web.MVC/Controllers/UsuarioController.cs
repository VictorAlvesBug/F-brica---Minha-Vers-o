using Fiap03.Web.MVC.App_Start;
using Fiap03.Web.MVC.Models;
using Fiap03.Web.MVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //GERENCIADOR DE USUARIO
        private readonly UserManager<UsuarioModel> _userManager;
        
        //ABRE A PAGINA DE LOGIN
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            //CAPTURAR A URL QUE O USUARIO DESEJA
            var model = new UsuarioViewModel()
            {
                Url = ReturnUrl
            };

            //ENVIA O MODEL COM A URL PARA A VIEW
            return View(model);
        }

        //EFETUA LOGIN
        [HttpPost]
        public async Task<ActionResult> Login(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var usuario = await _userManager.FindAsync(model.Login, model.Senha);

            if (usuario != null)
            {
                var identity = await _userManager.CreateIdentityAsync(
                    usuario, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.Url));
            }

            ModelState.AddModelError("", "Usuario e/ou Senha inválidos");
            return View();
        }

        public ActionResult Logout()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index","Home");
        }

        //ABRIR TELA DE CADASTRO DE USUARIO
        [HttpGet]
        public ActionResult Cadastrar(string ReturnUrl)
        {
            //CAPTURAR A URL QUE O USUARIO DESEJA
            var model = new UsuarioViewModel()
            {
                Url = ReturnUrl
            };

            //ENVIA O MODEL COM A URL PARA A VIEW
            return View(model);
        }

        //CADASTRAR USUARIO
        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioViewModel model)
        {
            //VALIDA SE O MODEL ESTA OK
            if (!ModelState.IsValid)
            {
                return View();
            }

            //CRIA UM OBJET PARA PERSISTIR NO BANCO DE DADOS
            var usuarioModel = new UsuarioModel()
            {
                UserName = model.Login
            };

            //PERSISTIR NO BANCO DE DADOS
            var result = await _userManager.CreateAsync(usuarioModel, model.Senha);

            //VERIFICAR SE CADASTROU COM SUCESSO
            if (result.Succeeded)
            {
                var identity = await _userManager.CreateIdentityAsync(usuarioModel, 
                    DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);
                return RedirectToAction("index", "home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return View();
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }

        //CONTRUTOR PARA INICIALIZAR O GERENCIADOR DE USUARIO
        public UsuarioController()
        {
            _userManager = IdentityConfig.UserManagerFactory.Invoke();
        }

        //LIBERAR OS RECURSOS QUANDO O OBJETO CONTROLLER FOR DESTRUIDO
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}