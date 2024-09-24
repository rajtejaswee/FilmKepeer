using System;
using Filmkeeper.Entities;
using System.Collections.Generic;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

public interface IMovieServices
{
    List<Movies> Get();
    Movies Get(int id);
    IEnumerable<Movies> GetAllByYear(int year);
    void Update(Movies _movie);
    void Create(Movies _movie);
    void Delete(int id);

}

