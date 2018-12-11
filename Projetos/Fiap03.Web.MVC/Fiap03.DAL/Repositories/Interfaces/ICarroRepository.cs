using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositories.Interfaces
{
    public interface ICarroRepository
    {
        bool ValidarPlaca(string placa);
        bool ValidarRenavam(long renavam);
        void Cadastrar(CarroMOD carro);
        IList<CarroMOD> Listar();
        IList<CarroMOD> BuscarPorAno(int ano);
        CarroMOD Buscar(int id);
        void Editar(CarroMOD carro);
        void Excluir(int id);
    }
}
