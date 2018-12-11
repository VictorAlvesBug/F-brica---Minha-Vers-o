using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositories.Interfaces
{
    public interface IModeloRepository
    {
        IList<ModeloMOD> BuscarModelos(int marcaId);
        void Cadastrar(ModeloMOD modelo);
        IList<ModeloMOD> Listar(int marcaId);
        IList<ModeloMOD> ListarTodos();
        ModeloMOD Buscar(int id);
    }
}
