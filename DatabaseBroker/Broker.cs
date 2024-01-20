using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Interfaces;

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

        public List<IEntity> GetAll(IEntity entity, string condition = null)
        {
            using (var command = _connection.CreateCommand())
            {
                string query = $"SELECT * FROM {entity.TableName}";
                query = (condition == null) ? query : (query + $" WHERE {condition}");

                command.CommandText = query;

                using (var reader = command.ExecuteReader())
                {
                    return entity.GetReaderList(reader);
                }
            }
        }

        public void Insert(IEntity entity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO {entity.TableName} VALUES ({entity.Values})";
                entity.AddSqlParameters(command);
                command.ExecuteNonQuery();
            }
        }

        public void Update(IEntity entity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE {entity.TableName} SET {entity.UpdateValues} WHERE {entity.PrimaryKey}";
                entity.AddSqlParameters(command);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(IEntity entity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.PrimaryKey}";
                entity.AddSqlParameters(command);
                command.ExecuteNonQuery();
            }
        }

        public IEntity FindById(IEntity entity, Dictionary<string, int> ids)
        {
            using (var command = _connection.CreateCommand())
            {
                var whereClauses = ids.Select(id => $"{id.Key} = @{id.Key}").ToList();
                command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {string.Join(" AND ", whereClauses)}";

                foreach (var id in ids)
                {
                    command.Parameters.AddWithValue($"@{id.Key}", id.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? entity.CreateEntity(reader) : null;
                }
            }
        }
    }
}
