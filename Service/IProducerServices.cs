using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IProducerServices
{
    List<Producers> Get();
    Producers Get(int id);
    void Update(Producers producer);
    void Create(Producers producer);
    void Delete(int id);
}


