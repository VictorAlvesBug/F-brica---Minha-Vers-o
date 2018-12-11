using System;
using System.Web.Mvc;
using Fiap03.MOD;
using Fiap03.Web.MVC.Controllers;
using Fiap03.Web.MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiap03.Web.MVC.Test
{
    [TestClass]
    public class MarcaControllerTest
    {
        [TestMethod]
        public void Cadastro_Post_Test()
        {
            //CRIAR O OBJETO CONTROLLER
            MarcaController controller = new MarcaController();

            //CRIAR UM OBJETO MARCA
            MarcaModel marca = new MarcaModel()
            {
                Nome = "Test Nome",
                DataCriacao = DateTime.Now,
                Cnpj = "Test Cnpj"
            };

            //CHAMAR O METODO CADASTRAR POST
            controller.Cadastrar(marca);

            //VALIDAR SE O RESULTADO TEM A MENSAGEM DE SUCESSO
            Assert.AreEqual(controller.TempData["msg"], "Marca cadastrada com sucesso");
        }
    }
}
