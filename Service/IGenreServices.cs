using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IGenreServices
{
    List<Genres> Get();
    Genres Get(int id);
    void Create(Genres genre);
    void Update(Genres genre);
    void Delete(int id);
}

