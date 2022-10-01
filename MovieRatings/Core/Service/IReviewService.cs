namespace MovieReviewThing.Core.Service;

public interface IReviewService
{
    //1. On input N, what are the number of reviews from reviewer N? 
    int GetNumberOfReviewsFromReviewer(int reviewer);
    
    //2. On input N, what is the average rate that reviewer N had given? Make sure reviews are there so you dont divide by 0
    double GetAverageRateFromReviewer(int reviewer);
    
    //3. On input N and R, how many times has reviewer N given rate R?
    //   Catch invalid ratings i.e. 6,0,200789. also reviewers that don't exist should throw 0
    int GetNumberOfRatesByReviewer(int reviewer, int rate);
    
    //4. On input N, how many have reviewed movie N?
    //   Invalid movies should throw 0
    int GetNumberOfReviews(int movie);
    
    //5. On input N, what is the average rate the movie N had received? //
    //   Invalid movies should throw 0
    
    double GetAverageRateOfMovie(int movie);
    
    //6. On input N and R, how many times had movie N received rate R?
    
    int GetNumberOfRates(int movie, int rate);
    
    //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
    //   So iterate through all movies to see who has the highest occurrence of 5.
    //   But if there are no movies find the movies with the highest rating.
    //   Use a dictionary and a counter on the side.
    List<int> GetMoviesWithHighestNumberOfTopRates();
    
    //8. What reviewer(s) had done most reviews?
    List<int> GetMostProductiveReviewers();
    
    //9. On input N, what is top N of movies? The score of a movie is its average rate.
    //   find top x movies like top 5
    List<int> GetTopRatedMovies(int amount);
    
    //10. On input N, what are the movies that reviewer N has reviewed? The list should
    //be sorted decreasing by rate first, and date secondly.
    List<int> GetTopMoviesByReviewer(int reviewer);
    
    //11. On input N, who ae the reviewers that have reviewed movie N? The list
    //should be sorted decreasing by rate first, and date secondly.
    List<int> GetReviewersByMovie(int movie);
}