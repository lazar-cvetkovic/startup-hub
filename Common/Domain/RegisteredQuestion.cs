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
    public class RegisteredQuestion : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }

        #region SQL Properties and Methods

        public string TableName => "RegisteredQuestion";

        public string Values => "@UserId, @EventId, @Question, @Description";

        public string UpdateValues => "Question = @Question, Description = @Description";

        public string PrimaryKey => "Id = @Id AND UserId = @UserId AND EventId = @EventId";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var activities = new List<IEntity>();
            while (reader.Read())
            {
                var activity = new RegisteredQuestion
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    EventId = (int)reader["EventId"],
                    Question = reader["Question"].ToString(),
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
            command.Parameters.AddWithValue("@Question", Question);
            command.Parameters.AddWithValue("@Description", Description);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new RegisteredQuestion
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                EventId = (int)reader["EventId"],
                Question = reader["Question"].ToString(),
                Description = reader["Description"].ToString()
            };
        }

        #endregion
    }
}
