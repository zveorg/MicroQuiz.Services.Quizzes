using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper
{
    public class ReadDbContext : IDisposable
    {
        public ReadDbContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public MySqlConnection Connection { get; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
