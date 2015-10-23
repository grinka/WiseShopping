using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace TheBesShopping.Repository
{
    internal class ShoppingDbConnection : DbConnection
    {
        private SQLiteConnection _dbConnection;

        private ShoppingDbConnection( string connectionString )
        {
            _dbConnection = new SQLiteConnection( connectionString );
            _dbConnection.Open();
        }

        ~ShoppingDbConnection()
        {
            if ( _dbConnection.State == ConnectionState.Open )
            {
                _dbConnection.Close();
            }
            if ( _dbConnection.State != ConnectionState.Closed )
            {
                throw new Exception( "Can't terminate unclosed connection" );
            }
        }

        /// <summary>
        /// Initializes the database with filename from the AppSettings.
        /// Creates the new database file if needed. Returns connection string.
        /// </summary>
        public static void InitAndCreate()
        {
            if ( !File.Exists( GetFilePath() ) )
            {
                SQLiteConnection.CreateFile( GetFilePath() );
            }
        }

        private static string _connectionString = string.Empty;
        public static string GetConnectionString()
        {
            if ( string.IsNullOrEmpty( _connectionString ) )
            {
                _connectionString = string.Format( "Data Source={0};Version=3;", GetFilePath() );
            }
            return _connectionString;
        }

        private static string _dbFilePath;
        private static string GetFilePath()
        {
            if ( string.IsNullOrEmpty( _dbFilePath ) )
            {
                var fileName = ConfigurationManager.AppSettings[ "dbFileName" ];
                _dbFilePath = string.Format( "{0}App_Data\\{1}", System.Web.HttpRuntime.AppDomainAppPath, fileName );
            }
            return _dbFilePath;
        }

        public static ShoppingDbConnection GetConnection()
        {
            return new ShoppingDbConnection( GetConnectionString() );
        }

        #region Abstract Class Implement
        public override string ConnectionString
        {
            get
            {
                return _dbConnection.ConnectionString;
            }

            set
            {
                _dbConnection.ConnectionString = value;
            }
        }

        public override string Database
        {
            get
            {
                return _dbConnection.Database;
            }
        }

        public override string DataSource
        {
            get
            {
                return _dbConnection.DataSource;
            }
        }

        public override string ServerVersion
        {
            get
            {
                return _dbConnection.ServerVersion;
            }
        }

        public override ConnectionState State
        {
            get
            {
                return _dbConnection.State;
            }
        }

        public override void ChangeDatabase( string databaseName )
        {
            _dbConnection.ChangeDatabase( databaseName );
        }

        public override void Close()
        {
            _dbConnection.Close();
        }

        public override void Open()
        {
            _dbConnection.Open();
        }

        protected override DbTransaction BeginDbTransaction( IsolationLevel isolationLevel )
        {
            return _dbConnection.BeginTransaction( isolationLevel );
        }

        protected override DbCommand CreateDbCommand()
        {
            return _dbConnection.CreateCommand();
        }
        #endregion
    }
}
