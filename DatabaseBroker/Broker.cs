using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {
        private DBConnection _connection;

        public Broker()
        {
            _connection = new DBConnection();
        }

        #region DBConnection Methods

        public void OpenConnection() => _connection.OpenConnection();

        public void CloseConnection() => _connection.CloseConnection();

        public void Rollback() => _connection.Rollback();

        public void Commit() => _connection.Commit();

        public void BeginTransaction() => _connection.BeginTransaction();

        #endregion


    }
}
