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
    public class StartupPitch : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PitchFileName { get; set; }
        public byte[] PitchFileData { get; set; }
        public string Feedback { get; set; }
        public int UserId { get; set; }

        #region SQL Properties and Methods

        public string TableName => "StartupPitch";

        public string Values => "@Name, @Description, @PitchFileName, @PitchFileData, @Feedback, @UserId";

        public string UpdateValues => "Name = @Name, Description = @Description, PitchFileName = @PitchFileName, PitchFileData = @PitchFileData, Feedback = @Feedback, UserId = @UserId";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var pitches = new List<IEntity>();
            while (reader.Read())
            {
                var pitch = new StartupPitch
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    PitchFileName = reader["PitchFileName"].ToString(),
                    PitchFileData = (byte[])reader["PitchFileData"],
                    Feedback = reader["Feedback"].ToString(),
                    UserId = (int)reader["UserId"]
                };
                pitches.Add(pitch);
            }
            return pitches;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@PitchFileName", PitchFileName);
            command.Parameters.AddWithValue("@PitchFileData", PitchFileData);
            command.Parameters.AddWithValue("@Feedback", Feedback);
            command.Parameters.AddWithValue("@UserId", UserId);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new StartupPitch
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                PitchFileName = reader["PitchFileName"].ToString(),
                PitchFileData = (byte[])reader["PitchFileData"],
                Feedback = reader["Feedback"].ToString(),
                UserId = (int)reader["UserId"]
            };
        }

        #endregion
    }
}
