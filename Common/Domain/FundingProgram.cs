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
    public class FundingProgram : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string FundingAmount { get; set; }
        public int UserId { get; set; }

        #region SQL Properties and Methods

        public string TableName => "FundingProgram";

        public string Values => "@Name, @Description, @Deadline, @FundingAmount, @UserId";

        public string UpdateValues => "Name = @Name, Description = @Description, Deadline = @Deadline, FundingAmount = @FundingAmount, UserId = @UserId";

        public string PrimaryKey => "Id = @Id";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var programs = new List<IEntity>();
            while (reader.Read())
            {
                var program = new FundingProgram
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Deadline = (DateTime)reader["Deadline"],
                    FundingAmount = (string)reader["FundingAmount"],
                    UserId = (int)reader["UserId"]
                };
                programs.Add(program);
            }
            return programs;
        }

        public void AddSqlParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Deadline", Deadline);
            command.Parameters.AddWithValue("@FundingAmount", FundingAmount);
            command.Parameters.AddWithValue("@UserId", UserId);
        }

        public IEntity CreateEntity(SqlDataReader reader)
        {
            return new FundingProgram
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Deadline = (DateTime)reader["Deadline"],
                FundingAmount = (string)reader["FundingAmount"],
                UserId = (int)reader["UserId"]
            };
        }

        #endregion
    }
}
