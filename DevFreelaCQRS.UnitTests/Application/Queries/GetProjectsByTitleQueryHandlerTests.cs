using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByDescription;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByTitle;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectsByTitleQueryHandlerTests
    {
        private const string SPECIFIC_TITLE = "Vai Corinthians!";

        private static bool ContainsSpecificTitle(Project s) => s.Title.Contains(SPECIFIC_TITLE);

        [Fact]
        public async Task ThereAreTwoProjectsWithSpecificDescription_Executed_ReturnBothProjectsViewModel()
        {
            //Arrange
            int numberOfProjectsWithTheSameTitle = 2;
            var projects = ProjectTestsHelper.GetProjectsListWithSpecificTitle(3, numberOfProjectsWithTheSameTitle, SPECIFIC_TITLE);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result)
                .Returns(projects.Where(ContainsSpecificTitle).ToList());

            var getProjectsByTitleQuery = new GetProjectsByTitleQuery(SPECIFIC_TITLE);
            var getProjectsByTitleQueryHandler = new GetProjectsByTitleQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByTitleQueryHandler.Handle(getProjectsByTitleQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == numberOfProjectsWithTheSameTitle);

            projectRepositoryMock.Verify(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result, Times.Once());
        }

        [Fact]
        public async Task ThereAreProjectsButWithoutTheSearchTitle_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var projects = ProjectTestsHelper.GetProjectsList(3);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result)
                .Returns(projects.Where(ContainsSpecificTitle).ToList());

            var getProjectsByTitleQuery = new GetProjectsByTitleQuery(SPECIFIC_TITLE);
            var getProjectsByTitleQueryHandler = new GetProjectsByTitleQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByTitleQueryHandler.Handle(getProjectsByTitleQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result, Times.Once());
        }

        [Fact]
        public async Task ThereAreNoProjects_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result)
                .Returns(projects.Where(ContainsSpecificTitle).ToList());

            var getProjectsByTitleQuery = new GetProjectsByTitleQuery(SPECIFIC_TITLE);
            var getProjectsByTitleQueryHandler = new GetProjectsByTitleQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByTitleQueryHandler.Handle(getProjectsByTitleQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByTitleAsync(SPECIFIC_TITLE).Result, Times.Once());
        }
    }
}
