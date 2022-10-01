using System.Net.Http.Headers;
using MovieReviewThing.Core.Repositories;
using MovieReviewThing.Core.Service;

namespace MovieReviewThing.Application;

public class ReviewService : IReviewService
{
    private IReviewRepository repository;
    public ReviewService(IReviewRepository repo)
    {
        if (repo == null)
            throw new ArgumentException("Missing Repository");
        repository = repo;
    }

    public int GetNumberOfReviewsFromReviewer(int reviewer)
    {
        int count = 0;
        
        foreach (BEReview review in repository.GetAll())
        {
            if (review.Reviewer == reviewer)
            {
                count++;
            }
        }

        return count;
    }

    public double GetAverageRateFromReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfReviews(int movie)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateOfMovie(int movie)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        throw new NotImplementedException();
    }

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewersByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}