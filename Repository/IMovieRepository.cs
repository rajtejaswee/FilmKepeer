using System;
using Filmkeeper.Entities;
using System.Collections.Generic;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

public interface IMovieRepository
{
    List<Movies> Get();
    IEnumerable<Movies> GetMoviesByYear(int year);
    Movies Get(int id);
    void Create(Movies _movie);
    void Update(Movies _movie);
    void Delete(int id);

}


