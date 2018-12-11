using Fiap04.Api.Client.DAL.Interfaces;
using Fiap04.Api.Client.Models;
using Fiap04.Api.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL
{
    class CarroRepository : ICarroRepository
    {
        private string _url = "http://localhost:52906/";

        public void Cadastrar(CarroDTO carroDTO)
        {
            using (var client = new HttpClient())
            {
                //DEVINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                carroDTO.Renavam = carroDTO.Documento.Renavam;

                //NÃO É NECESSÁRIO DEFINIR O TIPO DE RETORNO POIS NÃO HAVERÁ RETORNO DE DADOS

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.PostAsJsonAsync("api/Carro", carroDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao cadastrar");
                }
            }
        }

        public IList<CarroDTO> Listar()
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
                    client.GetAsync("api/Carro").Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE CarroDTO
                    //IEnumerable<CarroDTO> listaCarroDTO =
                    //response.Content.ReadAsAsync<IEnumerable<CarroDTO>>().Result;
                    IList<CarroDTO> listaCarroDTO =
                    response.Content.ReadAsAsync<IList<CarroDTO>>().Result;
                    return listaCarroDTO;
                }

                throw new Exception("Erro ao listar");
            }
        }

        public CarroDTO Buscar(int id)
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
                    client.GetAsync("api/Carro/" + id).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE CarroDTO
                    //IEnumerable<CarroDTO> carroDTO =
                    //response.Content.ReadAsAsync<IEnumerable<CarroDTO>>().Result;
                    CarroDTO carroDTO =
                    response.Content.ReadAsAsync<CarroDTO>().Result;
                    return carroDTO;
                }

                throw new Exception("Erro ao buscar");
            }
        }

        public void Atualizar(CarroDTO carroDTO)
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
                    client.PutAsJsonAsync("api/Carro/" + carroDTO.Id, carroDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao editar");
                }
            }
        }

        public void Excluir(int id)
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
                    client.DeleteAsync("api/Carro/" + id).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao excluir");
                }
            }
        }
    }
}
