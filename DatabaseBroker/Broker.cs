using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Helpers;
using Common.Interfaces;

namespace DatabaseBroker
{
    public class Broker
    {
        private DBConnection _connection;

        public Broker()
        {
            try
            {
                _connection = new DBConnection();
            }
            catch (Exception)
            {
                throw;
            }        
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
                Console.WriteLine(command.CommandText);

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

                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
            }
        }

        public void Update(IEntity entity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE {entity.TableName} SET {entity.UpdateValues} WHERE {entity.PrimaryKey}";
                entity.AddSqlParameters(command);

                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(IEntity entity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.PrimaryKey}";
                entity.AddSqlParameters(command);

                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
            }
        }

        public IEntity FindById(IEntity entity, Dictionary<string, int> ids)
        {
            using (var command = _connection.CreateCommand())
            {
                var whereClauses = ids.Select(id => $"{entity.TableName}.{id.Key} = @{id.Key}").ToList();
                command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {string.Join(" AND ", whereClauses)}";

                foreach (var id in ids)
                {
                    command.Parameters.AddWithValue($"@{id.Key}", id.Value);
                }

                Console.WriteLine(command.CommandText);

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? entity.CreateEntity(reader) : null;
                }
            }
        }

        public IEntity FindByColumns(IEntity prototype, Dictionary<string, object> columns)
        {
            using (var command = _connection.CreateCommand())
            {
                var whereClauses = columns.Select(col => $"{prototype.TableName}.{col.Key} = @{col.Key}").ToList();
                command.CommandText = $"SELECT * FROM {prototype.TableName} WHERE {string.Join(" AND ", whereClauses)}";

                foreach (var col in columns)
                {
                    command.Parameters.AddWithValue($"@{col.Key}", col.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? prototype.CreateEntity(reader) : null;
                }
            }
        }

        public List<IEntity> LoadByJoinCondition(IEntity prototype, Dictionary<string, object> ids, string joinTable, Dictionary<string, string> joinOn)
        {
            using (var command = _connection.CreateCommand())
            {
                var whereClauses = ids.Select(id => $"{prototype.TableName}.{id.Key} = @{id.Key}").ToList();
                var joinClauses = joinOn.Select(j => $"{prototype.TableName}.{j.Key} = {joinTable}.{j.Value}").ToList();

                command.CommandText =
                    $"SELECT {prototype.TableName}.* FROM {prototype.TableName} " +
                    $"JOIN {joinTable} ON {string.Join(" AND ", joinClauses)} " +
                    $"WHERE {string.Join(" AND ", whereClauses)}";

                foreach (var id in ids)
                {
                    command.Parameters.AddWithValue($"@{id.Key}", id.Value);
                }

                var entities = new List<IEntity>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = prototype.CreateEntity(reader);
                        entities.Add(entity);
                    }
                }

                return entities;
            }
        }
    }
}
