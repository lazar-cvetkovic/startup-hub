using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region SQL Properties and Methods

        public string TableName => "User";

        public string Values => "@FirstName, @LastName";

        public string UpdateValues => "FirstName = @FirstName, LastName = @LastName";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var users = new List<IEntity>();
            while (reader.Read())
            {
                var user = new User
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                users.Add(user);
            }
            return users;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString()
            };
        }

        #endregion
    }
}
