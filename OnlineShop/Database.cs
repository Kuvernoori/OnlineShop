using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

public class Database {
    private string connectionString;

    public Database(string host, int port, string database, string username, string password) {
        connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }

    public NpgsqlConnection GetConnection() {
        try {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection to PostgreSQL database established successfully.");
            return connection;
        } catch(Exception ex) {
            Console.WriteLine($"Failed to connect to PostgreSQL database: {ex.Message}");
            throw;
        }
    }

    public void CloseConnection(NpgsqlConnection connection) {
        if(connection != null && connection.State == System.Data.ConnectionState.Open) {
            connection.Close();
            Console.WriteLine("Connection to PostgreSQL database closed.");
        }
    }
}

