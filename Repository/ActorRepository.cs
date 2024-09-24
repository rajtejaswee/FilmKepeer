using System;
using System.Collections.Generic;
using System.Linq;
using Filmkeeper.Entities;
using Microsoft.Extensions.Configuration;
using System.Numerics;

public class ActorRepository : BaseRepository<Actors>, IActorRepository
{
    private readonly string _tableName = "Actors";

    public ActorRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public List<Actors> Get()
    {
        return (List<Actors>)GetAll(_tableName);
    }

    public Actors Get(int id)
    {
        return GetById(_tableName, id);
    }

    public void Create(Actors actor)
    {
        var sql = @"
        INSERT INTO actors (id, Name, DOB, Sex, Bio)
        VALUES (@id, @Name, @DOB, @Sex, @Bio);";
        Create(_tableName, sql, new { actor.id, actor.Name, actor.DOB, actor.Sex, actor.Bio });
    }

    public void Update(Actors actor)
    {
        var sql = @"
        UPDATE actors
        SET Name = @Name, DOB = @DOB, Sex = @Sex, Bio = @Bio
        WHERE id = @id;";
        Update(_tableName, sql, new { actor.id, actor.Name, actor.DOB, actor.Sex, actor.Bio });
    }

    public void Delete(int id)
    {
        base.Delete(_tableName, id);
    }
}
