using Dapper;
using Fiap03.DAL.ConnectionFactories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        public void Cadastrar(ModeloMOD modelo)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"INSERT INTO Modelo (Nome, MarcaId)
                                VALUES (@Nome, @MarcaId);
                                SELECT CAST(SCOPE_IDENTITY() AS int)";
                modelo.Id = db.Query<int>(comando, modelo).Single();
            }
        }

        public IList<ModeloMOD> Listar(int marcaId)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Modelo
                                WHERE MarcaId = @MarcaId";
                var listaModeloMOD = db.Query<ModeloMOD>(comando, new { MarcaId = marcaId }).ToList();
                return listaModeloMOD;
            }
        }

        public IList<ModeloMOD> ListarTodos()
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Modelo";
                var listaModeloMOD = db.Query<ModeloMOD>(comando).ToList();
                return listaModeloMOD;
            }
        }

        public ModeloMOD Buscar(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Modelo
                                WHERE Id = @Id";
                var modeloMOD = db.Query<ModeloMOD>(comando, new { Id = id }).SingleOrDefault();
                return modeloMOD;
            }
        }

        public IList<ModeloMOD> BuscarModelos(int marcaId)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Modelo
                                WHERE MarcaId = @MarcaId";

                var listaModeloMOD = db.Query<ModeloMOD>(comando, new { MarcaId = marcaId }).ToList();
                return listaModeloMOD;
            }
        }
    }
}
