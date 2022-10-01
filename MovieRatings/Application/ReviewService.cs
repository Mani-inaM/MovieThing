﻿using System.Net.Http.Headers;
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
        int count = 0;
        if (rate is >= 1 and <= 5)
        {
            foreach (BEReview review in repository.GetAll())
            {
                if (review.Reviewer == reviewer)
                {
                    if (rate == review.Grade)
                    {
                        count++;
                    }
                }
            }
        }
        else
        {
            throw new ArgumentException("Invalid Number");
        }

        return count;
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
        List<BEReview> listOfMovies = new List<BEReview>(); 
        List<int> listOfMoviesWithHighestNumberOfTopRates = new List<int>();
        int topRate = 0; 
        int numberOfTopRates = 0;
        int amount = 0;
        int movieID = 0;
        foreach (BEReview review in repository.GetAll())
        {
            if (review.Grade >= topRate)
            {
                topRate = review.Grade;
            }
        }
        
        foreach (BEReview review in repository.GetAll())
        {
            if (!listOfMovies.Contains(review) && review.Grade.Equals(topRate))
            {
                listOfMovies.Add(review);
            }
            
        }
        
        foreach (BEReview review in listOfMovies)
        {
            if (GetNumberOfRates(review.Movie, topRate) > numberOfTopRates)
            {
                numberOfTopRates = GetNumberOfRates(review.Movie, topRate);
                
            }
        }
        restart:
        foreach (BEReview review in listOfMovies)
        {
            movieID = review.Movie;
            if (listOfMovies.Contains(review).Equals(review.Movie == movieID))
            {
                if (amount == numberOfTopRates)
                {
                    listOfMoviesWithHighestNumberOfTopRates.Add(review.Movie);
                    amount = 0;
                }
            }


        }
        return listOfMoviesWithHighestNumberOfTopRates;
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