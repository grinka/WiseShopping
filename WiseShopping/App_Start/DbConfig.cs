using Dapper;
using System.Data.Common;
using TheBesShopping.Repository;

namespace TheBesShopping
{
    class DbConfig
    {
        public static void InitDatabase()
        {
            ShoppingDbConnection.InitAndCreate();
            SeedDatabase();
        }

        private static void SeedDatabase()
        {
            using ( var connection = ShoppingDbConnection.GetConnection() )
            {
                connection.Execute( @"
CREATE TABLE IF NOT EXISTS [test_table] (
    [Id] INTEGER NOT NULL PRIMARY KEY,
    [name] NVARCHAR(50) NOT NULL
)" );
                var records = connection.ExecuteScalar<int>( @"SELECT count(*) FROM [test_table]" );
                if ( records == 0 )
                {
                    InitTablesData( connection );
                }
            }
        }

        private static void InitTablesData( DbConnection connection )
        {
            connection.Execute( @"INSERT INTO [test_table] (Id, name) VALUES (1, 'Grinka')" );
            connection.Execute( @"INSERT INTO [test_table] (Id, name) VALUES (2, 'Lenk')" );
            connection.Execute( @"INSERT INTO [test_table] (Id, name) VALUES (3, 'Gina')" );
        }
    }
}
