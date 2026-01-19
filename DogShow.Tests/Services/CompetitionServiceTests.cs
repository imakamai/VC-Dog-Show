using Xunit;
using Moq;
using DogShow.Services.CompetitionService;
using DogShow.Repository.CompetitionRepository;
using DogShow.Modules.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DogShow.Tests.Services
{
    public class CompetitionServiceTests
    {
        [Fact]
        public async Task GetAllCompetitionsAsync_ReturnsListOfCompetitions()
        {
            // Arrange
            var mockRepo = new Mock<ICompetitionRepository>();
            var expectedCompetitions = new List<Competition>
            {
                new Competition { Id = 1, Title = "Competition 1" },
                new Competition { Id = 2, Title = "Competition 2" }
            };
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(expectedCompetitions);

            var service = new CompetitionService(mockRepo.Object);

            // Act
            var result = await service.GetAllCompetitionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Competition 1", result[0].Title);
        }

        [Fact]
        public async Task GetActiveCompetitionsAsync_ReturnsActiveCompetitions()
        {
            // Arrange
            var mockRepo = new Mock<ICompetitionRepository>();
            var expectedCompetitions = new List<Competition>
            {
                new Competition { Id = 3, Title = "Active Competition" }
            };
            mockRepo.Setup(repo => repo.GetActiveAsync())
                .ReturnsAsync(expectedCompetitions);

            var service = new CompetitionService(mockRepo.Object);

            // Act
            var result = await service.GetActiveCompetitionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Active Competition", result[0].Title);
        }
    }
}
