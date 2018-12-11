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

namespace Fiap03.Web.API.Controllers
{
    public class ModeloController : ApiController
    {
        private IModeloRepository _modeloRepository = new ModeloRepository();

        private ModeloMOD GetModeloMOD(ModeloDTO modeloDTO)
        {
            var modeloMOD = new ModeloMOD()
            {
                Id = modeloDTO.Id,
                Nome = modeloDTO.Nome,
                MarcaId = modeloDTO.MarcaId
            };

            return modeloMOD;
        }

        public IList<ModeloDTO> Get()
        {
            //id da marca
            var listaModeloMOD = _modeloRepository.ListarTodos();
            var listaModeloDTO = new List<ModeloDTO>();
            listaModeloMOD.ToList().ForEach(c => listaModeloDTO.Add(new ModeloDTO(c)));
            return listaModeloDTO;
        }

        //O NOME DO PARAMETRO TEM QUE SER id PORQUE TEM O MESMO NOME NA ROTA
        //api/modelo/{id}
        public ModeloDTO Get(int id)
        {
            return new ModeloDTO(_modeloRepository.Buscar(id));
        }

        public IHttpActionResult Post(ModeloDTO modeloDTO)
        {
            if (ModelState.IsValid)
            {
                var modeloMOD = GetModeloMOD(modeloDTO);
                _modeloRepository.Cadastrar(modeloMOD);
                var link = Url.Link("DefaultApi", new { id = modeloMOD.Id });
                modeloDTO.Id = modeloMOD.Id;
                // FUNCIONA IGUAL
                return Created<ModeloDTO>(new Uri(link), modeloDTO);
                //return Created(new Uri(link), modeloDTO);
            }

            return BadRequest(ModelState);
        }

        /*public IHttpActionResult Put(int id, ModeloDTO modeloDTO)
        {
            if (ModelState.IsValid)
            {
                var modeloMOD = GetModeloMOD(modeloDTO);
                modeloMOD.Id = id;
                _modeloRepository.Editar(modeloMOD);
                return Ok(modeloDTO);
            }

            return BadRequest(ModelState);
        }*/
    }
}
