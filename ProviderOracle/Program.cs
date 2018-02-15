using System;
using System.Data.OracleClient;

namespace ProviderOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            var paramConnection = new
            {
                Server = "localhost",
                Port = "1521",
                Database = "database_teste",
                Uid = "admin123",
                Pwd = "admin123"
            };

            var connectionString = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",
                paramConnection.Server,
                paramConnection.Port,
                paramConnection.Database,
                paramConnection.Uid,
                paramConnection.Pwd
                );

            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT table_name FROM all_tables";

                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("========= TABELAS =========");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(reader.GetOrdinal("table_name")));
                        };
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
