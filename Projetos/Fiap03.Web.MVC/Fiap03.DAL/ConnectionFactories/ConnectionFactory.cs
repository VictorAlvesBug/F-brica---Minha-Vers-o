using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.ConnectionFactories
{
    //RESPONSÁVEL POR CRIAR AS CONEXÕES COM O BANCO DE DADOS

    public class ConnectionFactory
    {
        private static string _connectionString = ConfigurationManager
            .ConnectionStrings["DBCarros"].ConnectionString;

        public static IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
