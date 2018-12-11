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
    public class MarcaRepository : IMarcaRepository
    {
        public MarcaMOD Buscar(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Marca
                                WHERE Id = @Id";

                MarcaMOD marca = db.Query<MarcaMOD>(comando, new { id }).FirstOrDefault();

                return marca;
            }
        }

        public MarcaMOD BuscarComCarros(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comandos = @"SELECT * FROM Marca WHERE Id = @Id;
                            SELECT * FROM Carro AS CAR
                            INNER JOIN Marca AS MAR
                            ON CAR.MarcaId = MAR.Id
                            INNER JOIN Documento AS DOC
                            ON CAR.Renavam = Doc.Renavam
                            WHERE CAR.MarcaId = @Id;";

                using (var resultados = db.QueryMultiple(comandos, new { Id = id }))
                {
                    var marca = resultados.Read<MarcaMOD>().Single();
                    var carros = resultados.Read<CarroMOD>().ToList();

                    if (marca != null && carros != null)
                    {
                        carros.ToList().ForEach(c => c.Marca = marca.Nome);
                        marca.Carros = carros;
                    }

                    return marca;
                }
            }
        }

        public void Cadastrar(MarcaMOD marca)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"INSERT INTO Marca (Nome, Cnpj, DataCriacao)
                                VALUES (@Nome, @Cnpj, @DataCriacao);
                                SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = db.Query<int>(comando, marca).Single();
                //ASSOCIA O ID GERADO PELO BANCO
                marca.Id = id;
            }
        }

        public void Editar(MarcaMOD marca)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"UPDATE Marca
                                SET
                                Nome = @Nome,
                                DataCriacao = @DataCriacao,
                                Cnpj = @Cnpj
                                WHERE Id = @Id";
                db.Execute(comando, marca);
            }
        }

        public void Excluir(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"DELETE FROM Marca
                                WHERE Id=@Id";
                db.Execute(comando, new { Id = id });
            }
        }

        public IList<MarcaMOD> Listar()
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Marca";

                var lista = db.Query<MarcaMOD>(comando).ToList();
                return lista;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT COUNT(*) FROM Marca
                                WHERE Cnpj = @Cnpj";
                var qtde = db.Query<int>(comando, new { Cnpj = cnpj }).Single();

                return qtde == 0;
            }
        }
    }
}
