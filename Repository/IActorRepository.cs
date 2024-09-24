using System;
using System.Collections.Generic;
using Filmkeeper.Entities;


	public interface IActorRepository
	{
        List<Actors> Get();
        Actors Get(int id);
        void Create(Actors actor);
        void Update(Actors actor);
        void Delete(int id);
    }


