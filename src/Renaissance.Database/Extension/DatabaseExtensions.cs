using System.Data;
using System.Data.Common;

using Microsoft.EntityFrameworkCore;

namespace Renaissance.Database.Extension
{
    public static class DatabaseExtensions
    {
        public static bool TableExists(this DbContext context, string tableName)
        {
            DbConnection connection = context.Database.GetDbConnection();
            using DbCommand command = connection.CreateCommand();

            if (connection.State.Equals(ConnectionState.Closed))
                connection.Open(); /* EF Core manages closing. */

            command.CommandText = $"select case when exists((select * from information_schema.tables where table_name = '{ tableName}')) then 1 else 0 end";

            return (int)command.ExecuteScalar() == 1;
        }
    }
}
