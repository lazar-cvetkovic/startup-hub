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
    public class RegisteredActivity : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region SQL Properties and Methods

        public string TableName => "RegisteredActivity";

        public string Values => "@UserId, @EventId, @Name, @Description";

        public string UpdateValues => "UserId = @UserId, EventId = @EventId, Name = @Name, Description = @Description";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var activities = new List<IEntity>();
            while (reader.Read())
            {
                var activity = new RegisteredActivity
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    EventId = (int)reader["EventId"],
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString()
                };
                activities.Add(activity);
            }
            return activities;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@EventId", EventId);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new RegisteredActivity
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                EventId = (int)reader["EventId"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString()
            };
        }

        #endregion
    }
}
