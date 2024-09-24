using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Filmkeeper.Entities;
using System;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

public class MovieRepository : BaseRepository<Movies>, IMovieRepository
{
    private readonly string _tableName = "Movies";
    public MovieRepository(IConfiguration configuration) : base(configuration)
    {
    }
    public List<Movies> Get()
    {
        return (List<Movies>)GetAll(_tableName);
    }

    public IEnumerable<Movies> GetMoviesByYear(int year)
    {
        using (var conn = Connection)
        {
            var sql = "SELECT * FROM Movies WHERE YearOfRelease = @Year";
            return conn.Query<Movies>(sql, new { Year = year });
        }
    }

    public Movies Get(int id)
    {
        return GetById(_tableName, id);
    }

    public void Create(Movies movie)
    {
        var sql = @"
        INSERT INTO movies (id, Name, Year, Plot, Poster, ProducerId)
        VALUES (@id, @Name, @Year, @Plot, @Poster, @ProducerId);";
        Create(_tableName, sql, new { movie.id, movie.Name, movie.yearofRelease, movie.Plot, movie.Poster, movie.ProducerId });

    }
    public void Update(Movies movie)
    {
        var sql = @"
        UPDATE movies
        SET Name = @Name, Year = @Year, Plot = @Plot, Poster = @Poster, ProducerId = @ProducerId
        WHERE id = @id;";
        Update(_tableName, sql, new { movie.id, movie.Name, movie.yearofRelease, movie.Plot, movie.Poster, movie.ProducerId });
    }

    public void Delete(int id)
    {
        using (var conn = Connection)
        {
            var sql = "CALL RemoveMovie(@id);";
            conn.Execute(sql, new { id });
        }
    }

}