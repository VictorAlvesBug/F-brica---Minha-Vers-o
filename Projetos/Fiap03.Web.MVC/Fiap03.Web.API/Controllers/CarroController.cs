using Fiap03.DAL.Repositories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using Fiap03.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Fiap03.Web.API.Controllers
{
    [EnableCors(origins:"*", headers:"*",methods:"*")]

    public class CarroController : ApiController
    {
        private ICarroRepository _carroRepository = new CarroRepository();

        private CarroMOD GetCarroMOD(CarroDTO carroDTO)
        {
            var carroMOD = new CarroMOD()
            {
                Id = carroDTO.Id,
                MarcaId = carroDTO.MarcaId,
                Marca = carroDTO.Marca,
                ModeloId = carroDTO.ModeloId,
                Modelo = carroDTO.Modelo,
                Placa = carroDTO.Placa,
                Ano = carroDTO.Ano,
                Esportivo = carroDTO.Esportivo,
                Combustivel = carroDTO.Combustivel,
                Descricao = carroDTO.Descricao,
                Renavam = carroDTO.Renavam,
                Documento = GetDocumentoMOD(carroDTO.Documento)
            };

            return carroMOD;
        }

        private DocumentoMOD GetDocumentoMOD(DocumentoDTO documentoDTO)
        {
            var documentoMOD = new DocumentoMOD()
            {
                Renavam = documentoDTO.Renavam,
                Categoria = documentoDTO.Categoria,
                DataFabricacao = documentoDTO.DataFabricacao
            };

            return documentoMOD;
        }

        public IList<CarroDTO> Get()
        {
            var listaCarroMOD = _carroRepository.Listar();
            var listaCarroDTO = new List<CarroDTO>();
            listaCarroMOD.ToList().ForEach(c => listaCarroDTO.Add(new CarroDTO(c)));
            return listaCarroDTO;
        }

        //O NOME DO PARAMETRO TEM QUE SER id PORQUE TEM O MESMO NOME NA ROTA
        //api/carro/{id}
        public CarroDTO Get(int id)
        {
            return new CarroDTO(_carroRepository.Buscar(id));
        }

        public IHttpActionResult Post(CarroDTO carroDTO)
        {
            if (ModelState.IsValid)
            {
                var carroMOD = GetCarroMOD(carroDTO);
                _carroRepository.Cadastrar(carroMOD);
                var link = Url.Link("DefaultApi", new { id = carroMOD.Id });
                carroDTO.Id = carroMOD.Id;
                // FUNCIONA IGUAL
                return Created<CarroDTO>(new Uri(link), carroDTO);
                //return Created(new Uri(link), carroDTO);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Put(int id, CarroDTO carroDTO)
        {
            if (ModelState.IsValid)
            {
                var carroMOD = GetCarroMOD(carroDTO);
                carroMOD.Id = id;
                _carroRepository.Editar(carroMOD);
                return Ok(carroDTO);
            }

            return BadRequest(ModelState);
        }

        public void Delete(int id)
        {
            _carroRepository.Excluir(id);
        }
    }
}
