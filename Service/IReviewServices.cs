using System;
using System.Collections.Generic;
using Filmkeeper.Entities;

public interface IReviewServices
{
    public List<Review> Get(int id);
    public void Create(Review review);
    public void Update(Review review);
    public void Delete(int id);
}


