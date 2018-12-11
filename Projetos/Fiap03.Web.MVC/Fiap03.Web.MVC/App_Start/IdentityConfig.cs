using Fiap03.Web.MVC.Context;
using Fiap03.Web.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.App_Start
{
    public class IdentityConfig
    {
        //GERENCIA O USUARIO PARA LOGAR E DESLOGAR
        public static Func<UserManager<UsuarioModel>> UserManagerFactory { get; set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/usuario/login")
            });
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<UsuarioModel>(
                new UserStore<UsuarioModel>(new UsuarioContext()));
                // permite caracteres alfa numéricos no username
                usermanager.UserValidator = new UserValidator<UsuarioModel>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                return usermanager;
            };
        }
    }
}