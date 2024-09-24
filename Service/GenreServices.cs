using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public class GenreServices:IGenreServices
{
	private IGenreRepository _GenreRepository;
	public GenreServices(IGenreRepository genreRepository)
	{
		this._GenreRepository = genreRepository;
	}
	public List<Genres> Get()
	{
		return _GenreRepository.Get();
	}
	public Genres Get(int id)
	{
		return _GenreRepository.Get(id);
	}
	public void Update(Genres genre)
	{
		_GenreRepository.Update(genre);
		return;
	}
	public void Create(Genres genre)
	{
		_GenreRepository.Create(genre);
		return;
	}
	public void Delete(int id)
	{
		_GenreRepository.Delete(id);
		return;
	}

}


