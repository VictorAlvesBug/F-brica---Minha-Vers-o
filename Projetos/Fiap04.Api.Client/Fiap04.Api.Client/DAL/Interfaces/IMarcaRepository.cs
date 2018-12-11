using Fiap04.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL.Interfaces
{
    public interface IMarcaRepository
    {
        void Cadastrar(MarcaDTO marcaDTO);
        IList<MarcaDTO> Listar();
        MarcaDTO Buscar(int id);
        void Atualizar(MarcaDTO marcaDTO);
        //void Excluir(int id);
    }
}
