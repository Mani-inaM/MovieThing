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
        int amount = 0;
        double avrage = 0.0;

        foreach (BEReview review in repository.GetAll())
        {
            if (review.Reviewer == reviewer)
            {
                amount++;
                avrage = avrage + review.Grade;
            }
        }

        if (amount == 0)
        {
            return 0;
        }
        else
        {
            return avrage / amount;
        }
        
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfReviews(int movie)
    {
        int count = 0;
        
        foreach (BEReview review in repository.GetAll())
        {
            if (review.Movie == movie)
            {
                count++;
            }
        }

        return count;
    }

    public double GetAverageRateOfMovie(int movie)
    {
        int amount = 0;
        double avrage = 0.0;

        foreach (BEReview review in repository.GetAll())
        {
            if (review.Movie == movie)
            {
                amount++;
                avrage = avrage + review.Grade;
            }
        }

        if (amount == 0)
        {
            return 0;
        }
        else
        {
            return avrage / amount;
        }
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        int result = 0;

        foreach (BEReview review in repository.GetAll())
        {
            if (review.Movie == movie)
            {
                if (rate == review.Grade)
                {
                    result++;
                }
            }
        }

        return result;
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