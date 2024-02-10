using DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExists_CallGetAllProjectsAsync_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var projects = ProjectTestsHelper.GetProjectsList(3);

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

        [Fact]
        public async Task SinceThereAreNoProjects_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllAsync().Result)
                .Returns(new List<Project>());

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.Empty(projectViewModelList);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
