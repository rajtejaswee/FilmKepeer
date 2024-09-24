using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IReviewRepository
{
    public List<Review> Get(int movieId);
    public void Create(Review _review);
    public void Update(Review _review);
    public void Delete(int id);
}
