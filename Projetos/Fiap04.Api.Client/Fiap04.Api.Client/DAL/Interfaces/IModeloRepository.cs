using Fiap04.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL.Interfaces
{
    public interface IModeloRepository
    {
        void Cadastrar(ModeloDTO modeloDTO);
        IList<ModeloDTO> Listar(int marcaId);
        IList<ModeloDTO> ListarTodos();
        ModeloDTO Buscar(int id);
        void Atualizar(ModeloDTO modeloDTO);
        //void Excluir(int id);
    }
}
