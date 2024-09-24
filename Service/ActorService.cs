using System;
using System.Collections.Generic;
using Filmkeeper.Entities;
using Filmkeeper.Exceptions;

public class ActorService : IActorService
{
    private readonly IActorRepository _actorRepo;

    public ActorService(IActorRepository actorRepository)
    {
        _actorRepo = actorRepository;
    }

    public List<Actors> Get()
    {
        return _actorRepo.Get();
    }

    public Actors Get(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }

        var actor = _actorRepo.Get(id);
        if (actor == null)
        {
            throw new InvalidArguementException($"Actor with ID {id} not found.");
        }

        return actor;
    }

    public void Update(Actors actor)
    {
        if (actor == null || actor.id <= 0)
        {
            throw new InvalidArguementException("Invalid actor details.");
        }

        _actorRepo.Update(actor);
    }

    public void Create(Actors actor)
    {
        if (actor == null || string.IsNullOrEmpty(actor.Name))
        {
            throw new InvalidArguementException("Invalid actor details. Name is required.");
        }

        _actorRepo.Create(actor);
    }

    public void Delete(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }

        _actorRepo.Delete(id);
    }
}
