using DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExists_CallGetAllProjectsAsync_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var projects = GetProjectsList(3);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllAsync().Result)
                .Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }

        private List<Project> GetProjectsList(int quantityToAdd)
        {
            var projects = new List<Project>();

            for (int i = 1; i <= quantityToAdd; i++)
            {
                projects.Add(new Project($"Project Test {i}", $"Test Project Description {i}", Guid.NewGuid(), Guid.NewGuid(), 10000));
            }

            return projects;
        }
    }
}
