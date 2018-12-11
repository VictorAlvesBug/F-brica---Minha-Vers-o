using System;
using System.Data.SqlClient;
using Fiap03.DAL.Repositories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiap03.DAL.Test
{
    [TestClass]
    public class MarcaRepositoryTest
    {
        private IMarcaRepository rep;

        //METODO QUE EXECUTA ANTES DOS TESTES
        [TestInitialize]
        public void init()
        {
            rep = new MarcaRepository();
        }

        [TestMethod]
        public void Cadastrar_Marca_Test()
        {
            //CRIAR OS OBJETOS
            var marca = new MarcaMOD()
            {
                Nome = "Test Nome",
                DataCriacao = DateTime.Now,
                Cnpj = "Test Cnpj"
            };
            //CHAMAR O METODOS A SEREM TESTADOS
            rep.Cadastrar(marca);
            //VALIDA SE ESTA OK - FOI GERADO UM ID PELO BANCO DE DADOS
            Assert.IsNotNull(marca.Id);
            Assert.AreNotEqual(0, marca.Id);
        }

        [TestMethod]
        public void Lista_Marca_Test()
        {
            //CRIAR OS OBJETOS
            //CHAMAR O METODOS A SEREM TESTADOS
            var lista = rep.Listar();
            //VALIDA SE ESTA OK
            Assert.IsNotNull(lista);
            Assert.AreNotEqual(0, lista.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Cadastrar_Sem_Nome_Test()
        {
            //CRIAR OS OBJETOS
            var marca = new MarcaMOD()
            {
                DataCriacao = DateTime.Now,
                Cnpj = "Test Cnpj"
            };
            //CHAMAR O METODOS A SEREM TESTADOS
            rep.Cadastrar(marca);
            //VALIDA SE ESTA OK - FOI GERADO UM ID PELO BANCO DE DADOS
        }
    }
}
