using System;
using System.Collections.Generic;
using Filmkeeper.Entities;
using Filmkeeper.Exceptions;

public class ReviewServices : IReviewServices
{
    public IReviewRepository _ReviewRepository;

    public ReviewServices(IReviewRepository reviewRepo)
    {
        this._ReviewRepository = reviewRepo;
    }

    public List<Review> Get(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }
        return _ReviewRepository.Get(id);
    }

    public void Create(Review review)
    {
        if (review == null || string.IsNullOrEmpty(review.review))
        {
            throw new InvalidArguementException("Invalid review details. Content is required.");
        }

        _ReviewRepository.Create(review);
    }

    public void Update(Review review)
    {

        if (review == null || string.IsNullOrEmpty(review.review))
        {
            throw new InvalidArguementException("Invalid review details. Content is required.");
        }

        _ReviewRepository.Update(review);
    }

    public void Delete(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }

        _ReviewRepository.Delete(id);
    }
}


