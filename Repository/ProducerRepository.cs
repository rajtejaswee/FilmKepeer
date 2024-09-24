using Filmkeeper.Entities;
using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Configuration;

public class ProducerRepository : BaseRepository<Producers>, IProducerRepository
{
    private readonly string _tableName = "Producers";
    public ProducerRepository(IConfiguration configuration) : base(configuration)
    {
    }
    public List<Producers> Get()
    {
        return (List<Producers>)GetAll(_tableName);
    }

    public Producers Get(int id)
    {
        return GetById(_tableName, id);
    }

    public void Create(Producers producer)
    {
        var sql = @"
        INSERT INTO producers (id, Name, DOB, Bio, Gender)
        VALUES (@id, @Name, @DOB, @Bio, @Gender);";
        Create(_tableName, sql, new { producer.id, producer.Name, producer.DOB, producer.Bio, producer.Gender });
    }

    public void Update(Producers producer)
    {
        var sql = @"
        UPDATE producers
        SET Name = @Name, DOB = @DOB, Bio = @Bio, Gender = @Gender
        WHERE id = @id;";
        Update(_tableName, sql, new { producer.id, producer.Name, producer.DOB, producer.Bio, producer.Gender });
    }

    public void Delete(int id)
    {
        base.Delete(_tableName, id);
    }
}

