using Fiap04.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL.Interfaces
{
    public interface ICarroRepository
    {
        void Cadastrar(CarroDTO carroDTO);
        IList<CarroDTO> Listar();
        CarroDTO Buscar(int id);
        void Atualizar(CarroDTO carroDTO);
        void Excluir(int id);
    }
}
