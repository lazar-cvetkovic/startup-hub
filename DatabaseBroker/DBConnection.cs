using System.Configuration;
using System.Data.SqlClient;


namespace DatabaseBroker
{
    internal class DBConnection
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public DBConnection()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["startuphub"].ConnectionString);
        }

        public void OpenConnection()
        {
            _connection?.Open();
        }

        public void CloseConnection()
        {
            _connection?.Close();
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction?.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", _connection, _transaction);
        }
    }
}
