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
    public class MarcaRepository : IMarcaRepository
    {
        private string _url = "http://localhost:52906/";

        public void Cadastrar(MarcaDTO marcaDTO)
        {
            using (var client = new HttpClient())
            {
                //DEFINE O ENDEREÇO DA REQUISIÇÃO
                client.BaseAddress = new Uri(_url);

                //NÃO É NECESSÁRIO DEFINIR O TIPO DE RETORNO POIS NÃO HAVERÁ RETORNO DE DADOS

                //EFETUA REQUISIÇÃO E RETORNA A RESPOSTA DA BASE DE DADOS 
                HttpResponseMessage response =
                    client.PostAsJsonAsync("api/Marca", marcaDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao cadastrar");
                }
            }
        }

        public IList<MarcaDTO> Listar()
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
                    client.GetAsync("api/Marca").Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE MarcaDTO
                    //IEnumerable<MarcaDTO> listaMarcaDTO =
                    //response.Content.ReadAsAsync<IEnumerable<MarcaDTO>>().Result;
                    IList<MarcaDTO> listaMarcaDTO =
                    response.Content.ReadAsAsync<IList<MarcaDTO>>().Result;
                    return listaMarcaDTO;
                }

                throw new Exception("Erro ao listar");
            }
        }

        public MarcaDTO Buscar(int id)
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
                    client.GetAsync("api/Marca/" + id).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (response.IsSuccessStatusCode)
                {
                    //CONVERTE O RETORNO PARA O TIPO LISTA DE MarcaDTO
                    //IEnumerable<MarcaDTO> marcaDTO =
                    //response.Content.ReadAsAsync<IEnumerable<MarcaDTO>>().Result;
                    MarcaDTO marcaDTO =
                    response.Content.ReadAsAsync<MarcaDTO>().Result;
                    return marcaDTO;
                }

                throw new Exception("Erro ao buscar");
            }
        }

        public void Atualizar(MarcaDTO marcaDTO)
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
                    client.PutAsJsonAsync("api/Marca/" + marcaDTO.Id, marcaDTO).Result;

                //VERIFICA SE A REQUISIÇÃO TEVE SUCESSO
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao editar");
                }
            }
        }
    }
}
