using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IActorService
{
	List<Actors> Get();
	Actors Get(int id);
	void Update(Actors actor);
	void Create(Actors actor);
	void Delete(int id);
}


