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
    public class MarcaController : ApiController
    {
        private IMarcaRepository _marcaRepository = new MarcaRepository();

        private MarcaMOD GetMarcaMOD(MarcaDTO marcaDTO)
        {
            var marcaMOD = new MarcaMOD()
            {
                Id = marcaDTO.Id,
                Nome = marcaDTO.Nome,
                Cnpj = marcaDTO.Cnpj,
                DataCriacao = marcaDTO.DataCriacao
            };

            return marcaMOD;
        }

        public IList<MarcaDTO> Get()
        {
            var listaMarcaMOD = _marcaRepository.Listar();
            var listaMarcaDTO = new List<MarcaDTO>();
            listaMarcaMOD.ToList().ForEach(c => listaMarcaDTO.Add(new MarcaDTO(c)));
            return listaMarcaDTO;
        }

        //O NOME DO PARAMETRO TEM QUE SER id PORQUE TEM O MESMO NOME NA ROTA
        //api/marca/{id}
        public MarcaDTO Get(int id)
        {
            return new MarcaDTO(_marcaRepository.Buscar(id));
        }

        public IHttpActionResult Post(MarcaDTO marcaDTO)
        {
            if (ModelState.IsValid)
            {
                var marcaMOD = GetMarcaMOD(marcaDTO);
                _marcaRepository.Cadastrar(marcaMOD);
                var link = Url.Link("DefaultApi", new { id = marcaMOD.Id });
                marcaDTO.Id = marcaMOD.Id;
                // FUNCIONA IGUAL
                return Created<MarcaDTO>(new Uri(link), marcaDTO);
                //return Created(new Uri(link), marcaDTO);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Put(int id, MarcaDTO marcaDTO)
        {
            if (ModelState.IsValid)
            {
                var marcaMOD = GetMarcaMOD(marcaDTO);
                marcaMOD.Id = id;
                _marcaRepository.Editar(marcaMOD);
                return Ok(marcaDTO);
            }

            return BadRequest(ModelState);
        }
    }
}
