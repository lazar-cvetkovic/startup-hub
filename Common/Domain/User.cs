using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        #region SQL Properties and Methods

        public string TableName => "User";

        public string Values => "@Email, @Name, @Password";

        public string UpdateValues => "Email = @Email, Name = @Name, Password = @Password";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var users = new List<IEntity>();
            while (reader.Read())
            {
                var user = new User
                {
                    Id = (int)reader["Id"],
                    Email = reader["Email"].ToString(),
                    Name = reader["Name"].ToString(),
                    Password = reader["Password"].ToString()
                };
                users.Add(user);
            }
            return users;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Password", Password);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                Name = reader["Name"].ToString(),
                Password = reader["Password"].ToString()
            };
        }

        #endregion
    }
}
