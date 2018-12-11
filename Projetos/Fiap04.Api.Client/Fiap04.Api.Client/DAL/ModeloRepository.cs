using Fiap04.Api.Client.DAL.Interfaces;
using Fiap04.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL
{
    public class ModeloRepository : IModeloRepository
    {
        private string _url = "http://localhost:52906/";

        public void Cadastrar(ModeloDTO modeloDTO)
        {
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //NÃO É NECESSÁRIO DEFINIR O TIPO DE RETORNO POIS NÃO HAVERÁ RETORNO DE DADOS

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.PostAsJsonAsync("api/Modelo", modeloDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao cadastrar");
                }
            }
        }

        public IList<ModeloDTO> Listar(int id)
        {
            //id da marca
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //LIMPA LISTA DE TIPOS ACEITOS
                client.DefaultRequestHeaders.Clear();

                //DEFINE O TIPO DE RETORNO DE DADOS
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.GetAsync("api/Modelo/" + id).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE ModeloDTO
                    //IEnumerable<ModeloDTO> listaModeloDTO =
                    //response.Content.ReadAsAsync<IEnumerable<ModeloDTO>>().Result;
                    IList<ModeloDTO> listaModeloDTO =
                    response.Content.ReadAsAsync<IList<ModeloDTO>>().Result;
                    return listaModeloDTO;
                }

                throw new Exception("Erro ao listar");
            }
        }

        public IList<ModeloDTO> ListarTodos()
        {
            //id da marca
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //LIMPA LISTA DE TIPOS ACEITOS
                client.DefaultRequestHeaders.Clear();

                //DEFINE O TIPO DE RETORNO DE DADOS
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.GetAsync("api/Modelo").Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE ModeloDTO
                    //IEnumerable<ModeloDTO> listaModeloDTO =
                    //response.Content.ReadAsAsync<IEnumerable<ModeloDTO>>().Result;
                    IList<ModeloDTO> listaModeloDTO =
                    response.Content.ReadAsAsync<IList<ModeloDTO>>().Result;
                    return listaModeloDTO;
                }

                throw new Exception("Erro ao listar");
            }
        }

        public ModeloDTO Buscar(int id)
        {
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //LIMPA LISTA DE TIPOS ACEITOS
                client.DefaultRequestHeaders.Clear();

                //DEFINE O TIPO DE RETORNO DE DADOS
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.GetAsync("api/Modelo/" + id).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE ModeloDTO
                    //IEnumerable<ModeloDTO> modeloDTO =
                    //response.Content.ReadAsAsync<IEnumerable<ModeloDTO>>().Result;
                    ModeloDTO modeloDTO =
                    response.Content.ReadAsAsync<ModeloDTO>().Result;
                    return modeloDTO;
                }

                throw new Exception("Erro ao buscar");
            }
        }

        public void Atualizar(ModeloDTO modeloDTO)
        {
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //LIMPA LISTA DE TIPOS ACEITOS
                client.DefaultRequestHeaders.Clear();

                //DEFINE O TIPO DE RETORNO DE DADOS
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.PutAsJsonAsync("api/Modelo/" + modeloDTO.Id, modeloDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao editar");
                }
            }
        }
    }
}
