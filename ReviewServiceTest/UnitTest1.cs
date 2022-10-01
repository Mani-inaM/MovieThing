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
    
}