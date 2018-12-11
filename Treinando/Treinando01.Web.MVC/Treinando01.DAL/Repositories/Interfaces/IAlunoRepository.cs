using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinando01.MOD;

namespace Treinando01.DAL.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        void Cadastrar(AlunoMOD alunoMOD);
        List<AlunoMOD> Listar();
        AlunoMOD Buscar(int id);
        void Editar(AlunoMOD alunoMOD);
        void Excluir(int id);
    }
}
