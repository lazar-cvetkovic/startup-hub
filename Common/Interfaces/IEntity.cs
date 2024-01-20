using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string UpdateValues { get; }
        string PrimaryKey { get; } 

        List<IEntity> GetReaderList(SqlDataReader reader);
        void AddSqlParameters(SqlCommand command);
        IEntity CreateEntity(SqlDataReader reader); 

    }
}
