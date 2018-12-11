using Fiap04.Api.Client.DAL;
using Fiap04.Api.Client.DAL.Interfaces;
using Fiap04.Api.Client.Models;
using Fiap04.Api.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client
{
    class Program
    {
        private static ICarroRepository _carroRepository = new CarroRepository();
        private static IMarcaRepository _marcaRepository = new MarcaRepository();
        private static IModeloRepository _modeloRepository = new ModeloRepository();

        static void Main(string[] args)
        {
            Console.SetWindowSize(122, 30);
            Console.ForegroundColor = ConsoleColor.Green;

            Limpar();
            DesenharMenu(Menu.Inicio);
            Console.ReadKey();
        }

        private static void Limpar()
        {
            Console.Clear();
            DesenharMenu(Menu.Cabecalho);
        }

        private static void InformacoesCarro(CarroDTO carroDTO)
        {
            Console.WriteLine(" Id: " + carroDTO.Id);
            try
            {
                Console.WriteLine(" Marca: " + _marcaRepository.Buscar(carroDTO.MarcaId).Nome);
            }
            catch (Exception e)
            {
                Console.WriteLine(" " + e.Message + " Marca");
            }
            try
            {
                Console.WriteLine(" Modelo: " + _modeloRepository.Buscar(carroDTO.ModeloId).Nome);
            }
            catch (Exception e)
            {
                Console.WriteLine(" " + e.Message + " Modelo");
            }

            Console.WriteLine(" Placa: " + carroDTO.Placa);
            Console.WriteLine(" Ano: " + carroDTO.Ano);
            Console.WriteLine(" Combustível: " + carroDTO.Combustivel);
            Console.WriteLine(" Esportivo: " + carroDTO.Esportivo);
            Console.WriteLine(" Descrição: " + carroDTO.Descricao);
            Console.WriteLine(" Documento ");
            Console.WriteLine(" - Renavam: " + carroDTO.Documento.Renavam);
            Console.WriteLine(" - Categoria: " + carroDTO.Documento.Categoria);
            Console.WriteLine(" - Data de Fabricação: " + carroDTO.Documento.DataFabricacao.ToShortDateString());
        }

        private static void InformacoesMarca(MarcaDTO marcaDTO)
        {
            Console.WriteLine(" Id: " + marcaDTO.Id);
            Console.WriteLine(" Nome: " + marcaDTO.Nome);
            Console.WriteLine(" Data de Criação: " + marcaDTO.DataCriacao);
            Console.WriteLine(" CNPJ: " + marcaDTO.Cnpj);
        }

        private static void TelaNaoImplementada(Menu menu)
        {
            Console.WriteLine("\n OBS: Tela de " + menu + " ainda não implementado");
            Console.ReadKey();
            DesenharMenu(Menu.Inicio);
        }

        private static void Centralizar(string texto, int tamanhoLacuna)
        {
            texto = texto.Trim();
            int tamanhoTexto = texto.Count();
            int espacoRestante = tamanhoLacuna - tamanhoTexto;
            int espacoAnterior = espacoRestante / 2;
            int espacoPosterior = espacoRestante - espacoAnterior;

            for (int i = 0; i < espacoAnterior; i++)
            {
                Console.Write(" ");
            }

            if (espacoRestante < 0)
            {

                Console.Write(texto.Substring(0, tamanhoLacuna - 3) + "...");
            }
            else
            {
                Console.Write(texto);
            }

            for (int i = 0; i < espacoPosterior; i++)
            {
                Console.Write(" ");
            }
        }

        private static object DesenharMenu(Menu menu, int marcaId = 0)
        {
            switch (menu)
            {
                case Menu.Cabecalho:
                    Console.WriteLine("\n ------------------------------------------------------- DBCarros -------------------------------------------------------\n");
                    break;

                case Menu.Inicio:
                    Limpar();
                    Console.WriteLine(" Qual recurso deseja alterar?");
                    Console.WriteLine(" 1 - Carro");
                    Console.WriteLine(" 2 - Marca");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "2":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.Carro:
                    Limpar();
                    Console.WriteLine(" O que deseja fazer?");
                    Console.WriteLine(" 1 - Cadastrar Carro");
                    Console.WriteLine(" 2 - Buscar Carro");
                    Console.WriteLine(" 3 - Editar Carro");
                    Console.WriteLine(" 4 - Deletar Carro");
                    Console.WriteLine(" 5 - Listar todos os Carros");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarCarro);
                            break;

                        case "2":
                            DesenharMenu(Menu.BuscarCarro);
                            break;

                        case "3":
                            DesenharMenu(Menu.EditarCarro);
                            break;

                        case "4":
                            DesenharMenu(Menu.DeletarCarro);
                            break;

                        case "5":
                            DesenharMenu(Menu.ListarCarro);
                            break;

                        case "9":
                            DesenharMenu(Menu.Inicio);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.CadastrarCarro:
                    Limpar();
                    CarroDTO carroCadastrar = new CarroDTO();
                    Console.WriteLine(" Defina os atributos do carro");
                    Console.WriteLine("\n Marca");
                    carroCadastrar.MarcaId = int.Parse(DesenharMenu(Menu.EscolherMarca).ToString());
                    Console.WriteLine("\n Modelo");
                    carroCadastrar.ModeloId = int.Parse(DesenharMenu(Menu.EscolherModelo, carroCadastrar.MarcaId).ToString());
                    Console.Write("\n Placa: ");
                    carroCadastrar.Placa = Console.ReadLine();
                    Console.Write(" Ano: ");
                    carroCadastrar.Ano = int.Parse(Console.ReadLine());
                    Console.Write(" Esportivo: ");
                    carroCadastrar.Esportivo = bool.Parse(Console.ReadLine());
                    Console.WriteLine("\n Combustível: ");
                    carroCadastrar.Combustivel = (Combustivel)int.Parse(DesenharMenu(Menu.ListarCombustivel).ToString());
                    Console.Write("\n Descrição: ");
                    carroCadastrar.Descricao = Console.ReadLine();

                    Console.WriteLine("\n Documento: ");
                    var documentoDTO = new DocumentoDTO();
                    Console.Write(" - Renavam: ");
                    documentoDTO.Renavam = long.Parse(Console.ReadLine());
                    Console.WriteLine("\n - Categoria: ");
                    documentoDTO.Categoria = (Categoria)int.Parse(DesenharMenu(Menu.ListarCategoria).ToString());
                    Console.Write("\n - Data de Fabricação: ");
                    documentoDTO.DataFabricacao = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    carroCadastrar.Documento = documentoDTO;

                    try
                    {
                        _carroRepository.Cadastrar(carroCadastrar);
                        Console.WriteLine(" Carro cadastrado");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Carro");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Cadastrar outro Carro");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarCarro);
                            break;
                        case "9":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.Carro);
                            break;
                    }
                    break;

                case Menu.ListarCarro:
                    Limpar();
                    try
                    {
                        var listaCarroDTO = _carroRepository.Listar();
                        Centralizar("Lista de Carros", 122);
                        Console.Write("\n\n");
                        Console.WriteLine(" |------|-----------|----------|---------|-----|-----------|---------|---------|-----------|---------|------------------|");
                        Console.WriteLine(" |  Id  |   Marca   |  Modelo  |  Placa  | Ano |Combustível|Esportivo|Descrição|  Renavam  |Categoria|Data de Fabricação|");//121 caracteres
                                                                                                                                                                       //                  |  6   |    11     |    10    |    9    |  5  |    11     |    9    |    9    |    11     |    9    |        18        |
                        Console.WriteLine(" |------|-----------|----------|---------|-----|-----------|---------|---------|-----------|---------|------------------|");

                        foreach (var carro in listaCarroDTO)
                        {
                            Console.Write(" |");
                            Centralizar(carro.Id.ToString(), 6);
                            Console.Write("|");
                            Centralizar(_marcaRepository.Buscar(carro.MarcaId).Nome, 11);
                            Console.Write("|");
                            Centralizar(_modeloRepository.Buscar(carro.ModeloId).Nome, 10);
                            Console.Write("|");
                            Centralizar(carro.Placa, 9);
                            Console.Write("|");
                            Centralizar(carro.Ano.ToString(), 5);
                            Console.Write("|");
                            Centralizar(carro.Combustivel.ToString(), 11);
                            Console.Write("|");
                            Centralizar(carro.Esportivo.ToString(), 9);
                            Console.Write("|");
                            Centralizar(carro.Descricao, 9);
                            Console.Write("|");
                            Centralizar(carro.Documento.Renavam.ToString(), 11);
                            Console.Write("|");
                            Centralizar(carro.Documento.Categoria.ToString(), 9);
                            Console.Write("|");
                            Centralizar(carro.Documento.DataFabricacao.ToShortDateString(), 18);
                            Console.Write("|\n");
                        }

                        Console.WriteLine(" |------|-----------|----------|---------|-----|-----------|---------|---------|-----------|---------|------------------|");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message);
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "9":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.BuscarCarro:
                    Limpar();
                    Console.Write(" Informe o Id do carro: ");
                    try
                    {
                        var carroBuscar = _carroRepository.Buscar(int.Parse(Console.ReadLine()));
                        Console.Write("\n");
                        InformacoesCarro(carroBuscar);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Carro");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Buscar outro Carro");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.BuscarCarro);
                            break;

                        case "9":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.BuscarCarro);
                            break;
                    }
                    break;

                case Menu.EditarCarro:
                    Limpar();
                    Console.Write(" Informe o Id do carro a ser editado: ");
                    try
                    {
                        var carroEditar = _carroRepository.Buscar(int.Parse(Console.ReadLine()));

                        Console.WriteLine("\n Marca: " + carroEditar.MarcaId);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.WriteLine("\n Escolha uma marca:");
                            carroEditar.MarcaId = int.Parse(DesenharMenu(Menu.EscolherMarca).ToString());
                            Console.WriteLine("\n Escolha um modelo:");
                            carroEditar.ModeloId = int.Parse(DesenharMenu(Menu.EscolherModelo, carroEditar.MarcaId).ToString());
                        }
                        else
                        {
                            Console.WriteLine(" Modelo: " + carroEditar.ModeloId);
                            Console.Write(" Deseja alterar este campo? (S/N): ");
                            if (Console.ReadLine().ToLower() == "s")
                            {
                                Console.WriteLine("\n Escolha um modelo:");
                                carroEditar.ModeloId = int.Parse(DesenharMenu(Menu.EscolherModelo, carroEditar.MarcaId).ToString());
                            }
                        }

                        Console.WriteLine("\n Placa: " + carroEditar.Placa);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Placa: ");
                            carroEditar.Placa = Console.ReadLine();
                        }

                        Console.WriteLine("\n Ano: " + carroEditar.Ano);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Ano: ");
                            carroEditar.Ano = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("\n Combustível: " + carroEditar.Combustivel.ToString());
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            carroEditar.Combustivel = Combustivel.Flex;
                            Console.Write(" Combustível: " + carroEditar.Combustivel);
                        }

                        Console.WriteLine("\n Esportivo: " + carroEditar.Esportivo);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Esportivo: ");
                            carroEditar.Esportivo = bool.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("\n Descrição: " + carroEditar.Descricao);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Descrição: ");
                            carroEditar.Descricao = Console.ReadLine();
                        }

                        Console.WriteLine("\n - Documento ");

                        Console.WriteLine(" - Renavam: " + carroEditar.Documento.Renavam);

                        Console.WriteLine(" - Categoria: " + carroEditar.Documento.Categoria);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            carroEditar.Documento.Categoria = Categoria.Pickup;
                            Console.Write(" - Categoria: " + carroEditar.Documento.Categoria);
                        }

                        Console.WriteLine(" - Data de Fabricação: " + carroEditar.Documento.DataFabricacao.ToShortDateString());
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" - Data de Fabricação: ");
                            carroEditar.Documento.DataFabricacao = DateTime.Parse(Console.ReadLine());
                        }

                        _carroRepository.Atualizar(carroEditar);
                        Console.WriteLine("\n Carro editado");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message);
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Editar outro Carro");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.EditarCarro);
                            break;

                        case "9":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.Carro);
                            break;
                    }
                    break;

                case Menu.DeletarCarro:
                    Limpar();
                    Console.Write(" Informe o Id do carro a ser excluído: ");
                    try
                    {
                        var carroExcluir = _carroRepository.Buscar(int.Parse(Console.ReadLine()));

                        Console.Write("\n");
                        InformacoesCarro(carroExcluir);
                        Console.WriteLine();
                        Console.Write(" Deseja mesmo excluir este carro? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            _carroRepository.Excluir(carroExcluir.Id);
                            Console.WriteLine("\n Carro excluído");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Carro");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Excluir outro Carro");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.DeletarCarro);
                            break;

                        case "9":
                            DesenharMenu(Menu.Carro);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.Carro);
                            break;
                    }
                    break;

                case Menu.Marca:
                    Limpar();
                    Console.WriteLine(" O que deseja fazer?");
                    Console.WriteLine(" 1 - Cadastrar Marca");
                    Console.WriteLine(" 2 - Buscar Marca");
                    Console.WriteLine(" 3 - Listar todas as Marcas");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarMarca);
                            break;

                        case "2":
                            DesenharMenu(Menu.BuscarMarca);
                            break;

                        case "3":
                            DesenharMenu(Menu.ListarMarca);
                            break;

                        case "9":
                            DesenharMenu(Menu.Inicio);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.CadastrarMarca:
                    Limpar();
                    MarcaDTO marcaCadastrar = new MarcaDTO();
                    Console.WriteLine(" Defina os atributos da marca");
                    Console.Write("\n Nome: ");
                    marcaCadastrar.Nome = Console.ReadLine();
                    Console.Write(" Data de Criação: ");
                    marcaCadastrar.DataCriacao = DateTime.Parse(Console.ReadLine());
                    Console.Write(" CNPJ: ");
                    marcaCadastrar.Cnpj = Console.ReadLine();
                    Console.WriteLine();

                    try
                    {
                        _marcaRepository.Cadastrar(marcaCadastrar);
                        Console.WriteLine(" Marca cadastrada");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Marca");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Cadastrar outra Marca");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarMarca);
                            break;
                        case "9":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.Marca);
                            break;
                    }
                    break;

                case Menu.ListarMarca:
                    Limpar();
                    try
                    {
                        var listaMarcaDTO = _marcaRepository.Listar();
                        Centralizar("Lista de Marcas", 57);
                        Console.Write("\n\n");
                        Console.WriteLine(" |------|-----------|---------------|------------------|");
                        Console.WriteLine(" |  Id  |   Nome    |Data de Criação|       CNPJ       |");//56 caracteres
                        //                  |  6   |    11     |      15       |        18        |
                        Console.WriteLine(" |------|-----------|---------------|------------------|");

                        foreach (var marca in listaMarcaDTO)
                        {
                            Console.Write(" |");
                            Centralizar(marca.Id.ToString(), 6);
                            Console.Write("|");
                            Centralizar(marca.Nome, 11);
                            Console.Write("|");
                            Centralizar(marca.DataCriacao.ToShortDateString(), 15);
                            Console.Write("|");
                            Centralizar(marca.Cnpj, 18);
                            Console.Write("|\n");
                        }

                        Console.WriteLine(" |------|-----------|---------------|------------------|");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Marca");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "9":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.BuscarMarca:
                    Limpar();
                    Console.Write(" Informe o Id da marca: ");
                    try
                    {
                        marcaId = int.Parse(Console.ReadLine());
                        var marcaBuscar = _marcaRepository.Buscar(marcaId);
                        Console.Write("\n");
                        InformacoesMarca(marcaBuscar);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Marca");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Buscar outra Marca");
                    Console.WriteLine(" 2 - Listar Modelos da Marca");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.BuscarMarca);
                            break;

                        case "2":
                            DesenharMenu(Menu.ListarModelo, marcaId);
                            break;

                        case "9":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.BuscarMarca);
                            break;
                    }
                    break;

                case Menu.EditarMarca:
                    Limpar();
                    Console.Write(" Informe o Id da marca a ser editada: ");
                    try
                    {
                        var marcaEditar = _marcaRepository.Buscar(int.Parse(Console.ReadLine()));

                        Console.WriteLine("\n Nome: " + marcaEditar.Nome);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Nome: ");
                            marcaEditar.Nome = Console.ReadLine();
                        }

                        Console.WriteLine("\n Data de Criação: " + marcaEditar.DataCriacao.ToShortDateString());
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" Data de Criação: ");
                            marcaEditar.DataCriacao = DateTime.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("\n CNPJ: " + marcaEditar.Cnpj);
                        Console.Write(" Deseja alterar este campo? (S/N): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Write(" CNPJ: ");
                            marcaEditar.Cnpj = Console.ReadLine();
                        }

                        _marcaRepository.Atualizar(marcaEditar);
                        Console.WriteLine("\n Marca editada");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message);
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Editar outra Marca");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.EditarMarca);
                            break;

                        case "9":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.Marca);
                            break;
                    }
                    break;

                case Menu.DeletarMarca:
                    Limpar();
                    TelaNaoImplementada(menu);
                    break;

                case Menu.EscolherMarca:
                    Limpar();
                    try
                    {
                        var listaMarcaEscolher = _marcaRepository.Listar();
                        foreach (var marca in listaMarcaEscolher)
                        {
                            Console.WriteLine(" " + marca.Id + " - " + marca.Nome);
                        }
                        Console.Write(" ");
                        return Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Marca");
                        return "0";
                    }

                case Menu.Modelo:
                    Limpar();
                    Console.WriteLine(" O que deseja fazer?");
                    Console.WriteLine(" 1 - Cadastrar Modelo");
                    Console.WriteLine(" 2 - Buscar Modelo");
                    Console.WriteLine(" 3 - Listar todos os Modelos");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarModelo, marcaId);
                            break;

                        case "2":
                            DesenharMenu(Menu.BuscarModelo);
                            break;

                        case "3":
                            DesenharMenu(Menu.ListarModelo);
                            break;

                        case "9":
                            DesenharMenu(Menu.Inicio);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.CadastrarModelo:
                    Limpar();
                    ModeloDTO modeloCadastrar = new ModeloDTO();
                    Console.WriteLine(" Defina os atributos da marca");
                    Console.Write("\n Nome: ");
                    modeloCadastrar.Nome = Console.ReadLine();
                    modeloCadastrar.MarcaId = marcaId;
                    Console.WriteLine();

                    try
                    {
                        _modeloRepository.Cadastrar(modeloCadastrar);
                        Console.WriteLine(" Modelo cadastrada");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Modelo");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Cadastrar outro Modelo");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            DesenharMenu(Menu.CadastrarModelo, marcaId);
                            break;
                        case "9":
                            DesenharMenu(Menu.ListarModelo, marcaId);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(Menu.ListarModelo, marcaId);
                            break;
                    }
                    break;

                case Menu.ListarModelo:
                    Limpar();
                    try
                    {
                        var listaModeloDTO = _modeloRepository.ListarTodos();
                        Centralizar("Lista de Modelos - " + _marcaRepository.Buscar(marcaId).Nome, 33);
                        Console.Write("\n\n");
                        Console.WriteLine(" |------|----------|-----------|");
                        Console.WriteLine(" |  Id  |   Nome   |   Marca   |");//32 caracteres
                        //                  |  6   |    10    |    11     |
                        Console.WriteLine(" |------|----------|-----------|");

                        foreach (var modelo in listaModeloDTO)
                        {
                            if (modelo.MarcaId == marcaId)
                            {
                                Console.Write(" |");
                                Centralizar(modelo.Id.ToString(), 6);
                                Console.Write("|");
                                Centralizar(modelo.Nome, 10);
                                Console.Write("|");
                                Centralizar(_marcaRepository.Buscar(marcaId).Nome, 11);
                                Console.Write("|\n");
                            }
                        }

                        Console.WriteLine(" |------|----------|-----------|");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" " + e.Message + " Modelo");
                    }

                    Console.WriteLine("\n Ações:");
                    Console.WriteLine(" 1 - Cadastrar Modelo");
                    Console.WriteLine(" 9 - Voltar");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write(" ");
                    switch (Console.ReadLine())
                    {
                        case "9":
                            DesenharMenu(Menu.Marca);
                            break;

                        case "0":
                            DesenharMenu(Menu.Sair);
                            break;

                        default:
                            DesenharMenu(menu);
                            break;
                    }
                    break;

                case Menu.BuscarModelo:
                    Limpar();
                    TelaNaoImplementada(menu);
                    break;

                case Menu.EditarModelo:
                    Limpar();
                    TelaNaoImplementada(menu);
                    break;

                case Menu.DeletarModelo:
                    Limpar();
                    TelaNaoImplementada(menu);
                    break;

                case Menu.EscolherModelo:
                    /*try
                    {*/
                    var listaModeloEscolher = _modeloRepository.ListarTodos();
                    foreach (var modelo in listaModeloEscolher)
                    {
                        if (modelo.MarcaId == marcaId)
                        {
                            Console.WriteLine(" " + modelo.Id + " - " + modelo.Nome);
                        }
                    }
                    Console.Write(" ");
                    return Console.ReadLine();
                /*}
                catch (Exception e)
                {
                    Console.WriteLine(" " + e.Message + " Modelo");
                    return "0";
                }*/


                case Menu.ListarCombustivel:
                    foreach (Combustivel combustivel in Enum.GetValues(typeof(Combustivel)))
                    {
                        Console.WriteLine(" " + (int)combustivel + " - " + combustivel.ToString());
                    }
                    Console.Write(" ");
                    return Console.ReadLine();

                case Menu.ListarCategoria:
                    foreach (Categoria categoria in Enum.GetValues(typeof(Categoria)))
                    {
                        Console.WriteLine(" " + (int)categoria + " - " + categoria.ToString());
                    }
                    Console.Write(" ");
                    return Console.ReadLine();

                case Menu.Sair:
                    Limpar();
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine();
                    }

                    Console.WriteLine("                                    ####   #     #  #####        ####   #     #  ##### ");
                    Console.WriteLine("                                    #   #   #   #   #            #   #   #   #   #     ");
                    Console.WriteLine("                                    #   #    # #    #            #   #    # #    #     ");
                    Console.WriteLine("                                    ####      #     ####         ####      #     ####  ");
                    Console.WriteLine("                                    #   #     #     #            #   #     #     #     ");
                    Console.WriteLine("                                    #   #     #     #            #   #     #     #     ");
                    Console.WriteLine("                                    ####      #     #####        ####      #     ##### ");

                    Console.Write(" ");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
