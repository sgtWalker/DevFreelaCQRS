using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByDescription;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectsByDescriptionQueryTests
    {
        private const string SPECIFIC_DESCRIPTION = "Projeto Vai Corinthians!";
        private static bool ContainsSpecificDescription(Project s) => s.Description.Contains(SPECIFIC_DESCRIPTION);

        [Fact]
        public async Task ThereAreTwoProjectsWithSpecificDescription_Executed_ReturnBothProjectsViewModel()
        {
            //Arrange
            int numberOfProjectsWithTheSameDescription = 2;
            var projects = ProjectTestsHelper.GetProjectsListWithSpecificDescription(3, numberOfProjectsWithTheSameDescription, SPECIFIC_DESCRIPTION);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result)
                .Returns(projects.Where(ContainsSpecificDescription).ToList());

            var getProjectsByDescriptionQuery = new GetProjectsByDescriptionQuery(SPECIFIC_DESCRIPTION);
            var getProjectsByDescriptionQueryHandler = new GetProjectsByDescriptionQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByDescriptionQueryHandler.Handle(getProjectsByDescriptionQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == numberOfProjectsWithTheSameDescription);

            projectRepositoryMock.Verify(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result, Times.Once());
        }

        [Fact]
        public async Task ThereAreProjectsButWithoutTheSearchDescription_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var projects = ProjectTestsHelper.GetProjectsList(3);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result)
                .Returns(projects.Where(ContainsSpecificDescription).ToList());

            var getProjectsByDescriptionQuery = new GetProjectsByDescriptionQuery(SPECIFIC_DESCRIPTION);
            var getProjectsByDescriptionQueryHandler = new GetProjectsByDescriptionQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByDescriptionQueryHandler.Handle(getProjectsByDescriptionQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result, Times.Once());
        }

        [Fact]
        public async Task ThereAreNoProjects_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result)
                .Returns(projects.Where(ContainsSpecificDescription).ToList());

            var getProjectsByDescriptionQuery = new GetProjectsByDescriptionQuery(SPECIFIC_DESCRIPTION);
            var getProjectsByDescriptionQueryHandler = new GetProjectsByDescriptionQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByDescriptionQueryHandler.Handle(getProjectsByDescriptionQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByDescriptionAsync(SPECIFIC_DESCRIPTION).Result, Times.Once());
        }
    }
}
