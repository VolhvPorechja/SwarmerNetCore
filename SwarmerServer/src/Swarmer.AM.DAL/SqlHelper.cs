using System;
using Dommel;
using Npgsql;

namespace Swarmer.AM.DAL
{
    public class SqlHelper
    {
        static SqlHelper()
        {
            DommelMapper.SetTableNameResolver(new TableNameResolver());
        } 

        public static void RunCommand(string connectionString, Action<NpgsqlCommand> command)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var comm = new NpgsqlCommand {Connection = connection})
                    command(comm);

                connection.Close();
            }
        }
    }
}