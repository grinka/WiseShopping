using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBesShopping.Code
{
    public class ConnectionFactory
    {
        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings[ "main" ].ConnectionString );
            connection.Open();

            return connection;
        }
    }
}
