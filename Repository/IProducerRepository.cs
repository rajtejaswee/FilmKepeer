using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IProducerRepository
{
    List<Producers> Get();
    Producers Get(int id);
    void Create(Producers producer);
    void Update(Producers producer);
    void Delete(int id);
}


