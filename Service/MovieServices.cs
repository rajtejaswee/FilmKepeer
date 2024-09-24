using System;
using System.Collections.Generic;
using Filmkeeper.Exceptions;
using Filmkeeper.Entities;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

public class MovieServices : IMovieServices
{
	private IMovieRepository _movierepository;
	public MovieServices(IMovieRepository movieRepository)
	{
		this._movierepository = movieRepository;
	}
	public List<Movies> Get()
	{
		return _movierepository.Get();
	}
	public Movies Get(int id)
	{
		if (id <= 0)
		{
			throw new InvalidArguementException("Invalid movie ID provided.");
        }
		return _movierepository.Get(id);
	}
    public IEnumerable<Movies> GetAllByYear(int year)
    {
        return _movierepository.GetMoviesByYear(year);
    }
    public void Update(Movies movie)
	{
		if (movie == null || movie.id <= 0 || string.IsNullOrEmpty(movie.Name) || movie.yearofRelease < 1900)
		{
			throw new InvalidArguementException("Invalid movie details provided.");
		}
		_movierepository.Update(movie);
	}
	public void Create(Movies movie)
	{
		if (movie == null || string.IsNullOrEmpty(movie.Name) || movie.yearofRelease < 1900)
		{
			throw new InvalidArguementException("Invalid movie details provided.");
		}
		_movierepository.Create(movie);
	}
	public void Delete(int id)
	{
		if (id <= 0)
		{
			throw new InvalidArguementException("Invalid movie ID provided.");
		}
		_movierepository.Delete(id);
	}
}


