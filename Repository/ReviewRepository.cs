using Filmkeeper.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using System.Linq;
using Dapper;

public class ReviewRepository : IReviewRepository
{
    const string connectionString = "Server=localhost;Port=3306;Database=Filmkeeper;Uid=root;Pwd=R@jtejaswee02;";
    public List<Review> Get(int movieId)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "select * from Reviews where movie_id=@movieId;";
            var Result = conn.Query<Review>(sql, new { movieId = movieId }).ToList<Review>();
            return Result;
        }
    }

    public void Create(Review review)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "insert into REVIEWS values(@id,@movieId,@review,@rating);";
            conn.Execute(sql, new { id = review.id, movieId = review.movieid, review = review.review, rating = review.rating });
            return;

        }
    }
    public void Update(Review review)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "update reviews set id=@id,movie_id=@movie_id,rating=@rating,review=@review where id=@id;";
            conn.Execute(sql, new { id = review.id, movie_id = review.movieid, review = review.review, rating = review.rating });
            return;
        }
    }
    public void Delete(int id)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            var sql = "delete from reviews where id=@id;";
            conn.Execute(sql, new { id = id });
            return;
        }
    }

}


