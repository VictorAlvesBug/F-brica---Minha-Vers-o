using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinando01.DAL.ConnectionFactories
{ 
    public class ConnectionFactory
    {
        public static string _connectionString = ConfigurationManager
            .ConnectionStrings["DBAlunos"].ConnectionString;

        public static IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
