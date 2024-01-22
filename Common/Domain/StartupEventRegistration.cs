using Common.Enums;
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
    public class StartupEventRegistration : IEntity
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public RegistrationStatus Status { get; set; }
        public DateTime DateOfRegistration { get; set; }

        #region SQL Properties and Methods

        public string TableName => "StartupEventRegistration";

        public string Values => "@UserId, @EventId, @Status, @DateOfRegistration";

        public string UpdateValues => "UserId = @UserId, EventId = @EventId, Status = @Status, DateOfRegistration = @DateOfRegistration";

        public string PrimaryKey => "UserId = @UserId AND EventId = @EventId";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var registrations = new List<IEntity>();

            while (reader.Read())
            {
                var registration = new StartupEventRegistration
                {
                    UserId = (int)reader["UserId"],
                    EventId = (int)reader["EventId"],
                    Status = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), (string)reader["Status"]),
                    DateOfRegistration = (DateTime)reader["DateOfRegistration"]
                };

                registrations.Add(registration);
            }

            return registrations;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@EventId", EventId);
            command.Parameters.AddWithValue("@Status", Status.ToString());
            command.Parameters.AddWithValue("@DateOfRegistration", DateOfRegistration);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new StartupEventRegistration
            {
                UserId = (int)reader["UserId"],
                EventId = (int)reader["EventId"],
                Status = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), (string)reader["Status"]),
                DateOfRegistration = (DateTime)reader["DateOfRegistration"]
            };
        }

        #endregion
    }
}

