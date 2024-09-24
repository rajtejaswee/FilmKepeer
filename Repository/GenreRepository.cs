using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Filmkeeper.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


public class GenreRepository : IGenreRepository
{
    string connectionString = "Server=localhost;Port=3306;Database=Filmkeeper;Uid=root;Pwd=R@jtejaswee02;";

    public List<Genres> Get()
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "select * from genre;";
            var result = conn.Query<Genres>(sql).ToList<Genres>();
            return result;
        }
    }
    public void Update(Genres genre)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "update genre set id=@id,Name=@Name where id=@id;";
            conn.Execute(sql, new { id = genre.id, Name = genre.Name });
            return;
        }
    }
    public void Create(Genres genre)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "insert into genre values(@id,@Name);";
            conn.Execute(sql, new { id = genre.id, Name = genre.Name });
        }
        return;
    }
    public void Delete(int id)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "delete from genre where id=@id;";
            conn.Execute(sql, new { id = id });
            return;
        }

    }
    public Genres Get(int id)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "select * from genre where id=@id;";
            var result = conn.Query<Genres>(sql, new { id = id }).ToList<Genres>();
            return result[0];
        }
    }

}



