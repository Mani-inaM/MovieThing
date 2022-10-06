using System.ComponentModel.Design;
using Moq;
using MovieReviewThing;
using MovieReviewThing.Application;
using MovieReviewThing.Core.Repositories;
using MovieReviewThing.Core.Service;

namespace ReviewServiceTest;

public class UnitTest1
{
    [Fact]
    public void CreateReviewServiceWithRepository()
    {
        // Arrange
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        IReviewRepository repository = mockRepository.Object;
        // Act
        ReviewService service = new ReviewService(repository);
        // Assert
        Assert.NotNull(service);
        Assert.True(service is ReviewService);
        
    }

    [Fact]
    public void CreateReviewServiceWithNoRepositoryThatShouldThrowAnArgumentException()
    {
        // Arrange
        IReviewService service = null;

        // Act + Assert
        var ex = Assert.Throws<ArgumentException>(()=> service = new ReviewService(null));
        Assert.Equal("Missing Repository", ex.Message);
        Assert.Null(service);
    }

    [Theory]
    [InlineData(1,2)]
    [InlineData(2,1)]
    [InlineData(3,0)]
    public void GetNumberOfReviewsFromReviewer(int reviewerID, int expectedValue)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, Date = new DateTime()}
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);
        
        // Act
        int result = service.GetNumberOfReviewsFromReviewer(reviewerID);
        
        // Assert
        Assert.Equal(expectedValue, result);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    [Theory]
    [InlineData(1,3.5)]
    [InlineData(2,3)]
    [InlineData(3,0)]
    public void GetAverageRateFromReviewer(int reviewerID, double expectedValue)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 1, Date = new DateTime()}
            
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);
        
        // Act
        double result = service.GetAverageRateFromReviewer(reviewerID);
        
        // Assert
        Assert.Equal(expectedValue, result);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }
    
    
    [Theory]
        [InlineData(1,3,2)]
        [InlineData(2,3,1)]
        public void GetNumberOfRatesByReviewer(int reviewerID, int rating  ,int expectedValue)
        {
            // Arrange
            BEReview[] fakeRepo = new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, Date = new DateTime()},
                new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, Date = new DateTime()}
            };
            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);
    
            IReviewService service = new ReviewService(mockRepository.Object);
    
            // Act
            int result = service.GetNumberOfRatesByReviewer(reviewerID, rating);
    
            // Assert
            Assert.Equal(expectedValue, result);
            mockRepository.Verify(r => r.GetAll(), Times.Once);
        }
        [Fact]
        public void GetThrownArgumentExceptionForInvalidNumber()
        {
            // Arrange
            BEReview[] fakeRepo = new BEReview[]
            {
                new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
                new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, Date = new DateTime()},
                new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, Date = new DateTime()}
            };
            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);
    
            IReviewService service = new ReviewService(mockRepository.Object);
    
            //Act+Assert
            int result;
            var ex = Assert.Throws<ArgumentException>(()=> result = service.GetNumberOfRatesByReviewer(1, 2000));
    
    
        }

    [Theory]
    [InlineData(1,3)]
    [InlineData(2,1)]
    [InlineData(3,0)]
    public void GetNumberOfReviews(int movieID, int expectedValue)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 1, Date = new DateTime()}
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);
        
        // Act
        int result = service.GetNumberOfReviews(movieID);
        
        // Assert
        Assert.Equal(expectedValue, result);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }

   [Fact]
    public  void GetAverageRateOfMovie()
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 1, Date = new DateTime()}
            
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);
        
        // Act
        double result = service.GetAverageRateOfMovie(3);
        
        // Assert
        Assert.Equal(3, 3);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }

    
    [Theory]
    [InlineData(1,1,3)]
    [InlineData(1,2,1)]
    [InlineData(1,3,2)]
    [InlineData(2,1,2)]
    [InlineData(2,2,2)]
    [InlineData(2,3,2)]
    public void GetNumberOfRates(int movieID, int rate, int expectedValue)
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 3, Date = new DateTime()}
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);
        
        // Act
        int result = service.GetNumberOfRates(movieID, rate);
        
        // Assert
        Assert.Equal(expectedValue, result);
        mockRepository.Verify(r => r.GetAll(), Times.Once);
    }

    
    [Fact]
    public void GetMoviesWithHighestNumberOfTopRates()
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 5, Date = new DateTime()}
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);

        List<int> expectedValue = new List<int>();
        expectedValue.Add(1);
        expectedValue.Add(3);

        // Act
        List<int> result = service.GetMoviesWithHighestNumberOfTopRates();
        
        // Assert
        Assert.Equal(expectedValue, result );
    }

    [Fact] public void GetMostProductiveReviewerMethodTest()
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 3, Movie = 3, Grade = 5, Date = new DateTime()}
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);

        List<int> expectedValue = new List<int>();
        expectedValue.Add(1);
        expectedValue.Add(2);

        // Act
        List<int> result = service.GetMostProductiveReviewers();
        
        // Assert
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    public void GetTopRatedMovies()
    {
        // Arrange
        BEReview[] fakeRepo = new BEReview[]
        {
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 1, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 2, Grade = 3, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 2, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 5, Date = new DateTime()},
            new BEReview() { Reviewer = 1, Movie = 3, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 4, Date = new DateTime()},
            new BEReview() { Reviewer = 2, Movie = 3, Grade = 5, Date = new DateTime()}
            
        };
        Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
        mockRepository.Setup(r=>r.GetAll()).Returns(fakeRepo);

        IReviewService service = new ReviewService(mockRepository.Object);

        List<int> expectedValue = new List<int>();
        expectedValue.Add(1);
        expectedValue.Add(3);

        // Act
        List<int> result = service.GetTopRatedMovies(2);
        
        // Assert
        Assert.Equal(expectedValue, result);
    }
   
}