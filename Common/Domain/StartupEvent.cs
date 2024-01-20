using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StartupEvent : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }

        #region SQL Properties and Methods

        public string TableName => "StartupEvent";

        public string Values => "@Name, @Description, @Date, @Location, @UserId";

        public string UpdateValues => "Name = @Name, Description = @Description, Date = @Date, Location = @Location, UserId = @UserId";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var events = new List<IEntity>();
            while (reader.Read())
            {
                var startupEvent = new StartupEvent
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Date = (DateTime)reader["Date"],
                    Location = reader["Location"].ToString(),
                    UserId = (int)reader["UserId"]
                };
                events.Add(startupEvent);
            }
            return events;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@UserId", UserId);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new StartupEvent
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Date = (DateTime)reader["Date"],
                Location = reader["Location"].ToString(),
                UserId = (int)reader["UserId"]
            };
        }


        #endregion
    }
}
