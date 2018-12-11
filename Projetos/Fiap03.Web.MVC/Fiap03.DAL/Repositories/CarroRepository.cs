using Dapper;
using Fiap03.DAL.ConnectionFactories;
using Fiap03.DAL.Repositories.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fiap03.DAL.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        public CarroMOD Buscar(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                //BUSCAR CARRO NO BANCO PELO ID
                var comando = @"SELECT * FROM Carro AS CAR 
                                INNER JOIN Documento AS DOC 
                                ON CAR.Renavam = DOC.Renavam
                                AND CAR.Id = @Id";
                var carroMOD = db.Query<CarroMOD, DocumentoMOD, CarroMOD>(comando,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro;
                    },
                    new { id },
                    splitOn: "Renavam,Renavam").SingleOrDefault();

                return carroMOD;
            }
        }

        public IList<CarroMOD> BuscarPorAno(int ano)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT * FROM Carro AS CAR 
                                INNER JOIN Documento AS DOC
                                ON CAR.Renavam = DOC.Renavam 
                                INNER JOIN Marca AS MAR 
                                ON CAR.MarcaId = MAR.Id
                                INNER JOIN Modelo AS MDL 
                                ON CAR.ModeloId = MDL.Id 
                                WHERE CAR.Ano = @Ano OR 0 = @Ano";

                IList<CarroMOD> listaMOD = db.Query<CarroMOD, DocumentoMOD, MarcaMOD, ModeloMOD, CarroMOD>(comando,
                     (carro, documento, marca, modelo) =>
                     {
                         carro.Marca = marca.Nome;
                         carro.Modelo = modelo.Nome;
                         carro.Renavam = documento.Renavam;
                         carro.Documento = documento;
                         return carro;
                     },
                     new { Ano = ano },
                     splitOn: "Id,Renavam,Id,Id").ToList();

                return listaMOD;
            }
        }

        public void Cadastrar(CarroMOD carro)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                using (var txtScope = new TransactionScope())
                {
                    //CADASTRA O DOCUMENTO
                    var comandoDocumento = @"INSERT INTO Documento 
                                (Renavam, DataFabricacao, Categoria)
                                VALUES (@Renavam, @DataFabricacao, @Categoria)";

                    db.Execute(comandoDocumento, carro.Documento);

                    //CADASTRA O CARRO
                    string comandoCarro = @"INSERT INTO Carro
                    (MarcaId, ModeloId, Placa, Ano, Esportivo, Combustivel, Descricao, Renavam)
                    VALUES (@MarcaId, @ModeloId, @Placa, @Ano, @Esportivo, @Combustivel, @Descricao, @Renavam);
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

                    carro.Renavam = carro.Documento.Renavam;

                    carro.Id = db.Query<int>(comandoCarro, carro).Single();

                    //Completa a transacao
                    txtScope.Complete();
                }
            }
        }

        public void Editar(CarroMOD carro)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                using (var txtScope = new TransactionScope())
                {
                    //EDITA O DOCUMENTO
                    string comandoDocumento = @"UPDATE Documento
                                SET Categoria = @Categoria, DataFabricacao = @DataFabricacao
                                WHERE Renavam = @Renavam";
                    db.Execute(comandoDocumento, carro.Documento);

                    //EDITA O CARRO
                    string comandoCarro = @"UPDATE Carro
                                SET MarcaId = @MarcaId, ModeloId = @ModeloId, Placa = @Placa, Ano = @Ano, Esportivo = @Esportivo, Combustivel = @Combustivel, Descricao = @Descricao
                                WHERE Id = @Id";
                    carro.Renavam = carro.Documento.Renavam;
                    db.Execute(comandoCarro, carro);

                    //Completa a transacao
                    txtScope.Complete();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                using (var txtScope = new TransactionScope())
                {
                    var comandoCarroRenavam = 
                        @"SELECT (Renavam) FROM Carro
                          WHERE Id = @Id";

                    var renavam = db.Query<long>(comandoCarroRenavam, new { Id = id }).SingleOrDefault();

                    var comandoCarro = 
                        @"DELETE FROM Carro 
                         WHERE Id = @Id";
                    db.Execute(comandoCarro, new { Id = id });

                    var comandoDocumento = 
                        @"DELETE FROM Documento
                         WHERE Renavam = @Renavam";
                    db.Execute(comandoDocumento, new { Renavam = renavam });

                    txtScope.Complete();
                }
                
            }
        }

        public IList<CarroMOD> Listar()
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comandoCarro = @"SELECT * FROM Carro AS CAR 
                                INNER JOIN Documento AS DOC
                                ON CAR.Renavam = DOC.Renavam 
                                INNER JOIN Marca AS MAR 
                                ON CAR.MarcaId = MAR.Id 
                                INNER JOIN Modelo AS MDL 
                                ON CAR.ModeloId = MDL.Id";
                IList<CarroMOD> listaMOD = db.Query<CarroMOD, DocumentoMOD, MarcaMOD, ModeloMOD, CarroMOD>(comandoCarro,
                    (carro, documento, marca, modelo) =>
                    {
                        carro.Marca = marca.Nome;
                        carro.Modelo = modelo.Nome;
                        carro.Renavam = documento.Renavam;
                        carro.Documento = documento;
                        return carro;
                    },
                    splitOn: "Id,Renavam,Id,Id").ToList();
                return listaMOD;
            }
        }

        public bool ValidarPlaca(string placa)
        {
            //TRUE --> VALIDA (NAO ENCONTRAR A PLACA NO DB)
            //FALSE --> INvALIDA (PLACA JA EXISTE NO DB)
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT COUNT(*) FROM Carro
                                WHERE Placa = @Placa";

                int qtde = db.Query<int>(comando, new { Placa = placa }).Single();

                return qtde == 0;
            }
        }

        public bool ValidarRenavam(long renavam)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                var comando = @"SELECT COUNT(*) FROM Documento
                                WHERE Renavam = @Renavam";

                int qtde = db.Query<int>(comando, new { Renavam = renavam }).Single();

                return qtde == 0;
            }
        }
    }
}
