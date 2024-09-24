using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;


public class BaseRepository<T> where T : class
{
    private readonly string _connectionString;

    public BaseRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    protected MySqlConnection Connection => new MySqlConnection(_connectionString);

    public IEnumerable<T> GetAll(string tableName)
    {
        using (var conn = Connection)
        {
            return conn.Query<T>($"SELECT * FROM {tableName}");
        }
    }

    public T GetById(string tableName, int id)
    {
        using (var conn = Connection)
        {
            return conn.QueryFirstOrDefault<T>($"SELECT * FROM {tableName} WHERE id = @Id", new { Id = id });
        }
    }

    public void Create(string tableName, string sql, object parameters)
    {
        using (var conn = Connection)
        {
            conn.Execute(sql, parameters);
        }
    }

    public void Update(string tableName, string sql, object parameters)
    {
        using (var conn = Connection)
        {
            conn.Execute(sql, parameters);
        }
    }

    public void Delete(string tableName, int id)
    {
        using (var conn = Connection)
        {
            conn.Execute($"DELETE FROM {tableName} WHERE id = @Id", new { Id = id });
        }
    }
}
