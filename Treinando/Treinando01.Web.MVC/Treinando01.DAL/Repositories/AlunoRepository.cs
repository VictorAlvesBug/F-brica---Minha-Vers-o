using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinando01.DAL.ConnectionFactories;
using Treinando01.DAL.Repositories.Interfaces;
using Treinando01.MOD;

namespace Treinando01.DAL.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public void Cadastrar(AlunoMOD alunoMOD)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = 
                    @"INSERT INTO Aluno (Nome, Rm)
                      VALUES (@Nome, @Rm)";

                db.Execute(comando, alunoMOD);
            }
        }

        public List<AlunoMOD> Listar()
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando =
                    @"SELECT * FROM Aluno";

                var listaAlunoMOD = db.Query<AlunoMOD>(comando).ToList();

                return listaAlunoMOD;
            }
        }

        public AlunoMOD Buscar(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando =
                    @"SELECT * FROM Aluno
                      WHERE Id = @Id";

                var alunoMOD = db.Query<AlunoMOD>(comando, new { Id = id } ).SingleOrDefault();

                return alunoMOD;
            }
        }

        public void Editar(AlunoMOD alunoMOD)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando =
                    @"UPDATE Aluno SET (Nome = @Nome, Rm = @Rm)
                      WHERE Id = @Id";

                db.Execute(comando, alunoMOD);
            }
        }

        public void Excluir(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando =
                    @"DELETE Aluno
                      WHERE Id = @Id";

                db.Execute(comando, new { Id = id });
            }
        }
    }
}
