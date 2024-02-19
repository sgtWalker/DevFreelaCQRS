using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByClientId;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectsByClientIdQueryHandlerTests
    {
        [Fact]
        public async Task ClientExistsAndHasAtLeastOneProject_Executed_ReturnListOfProjectViewModel()
        {
            //Arrange
            var client = ProjectTestsHelper.GetClient();
            var freelancer = ProjectTestsHelper.GetFreelancer();
            var projects = ProjectTestsHelper.GetProjectsWithClientAndFreelancer(client, freelancer, 3);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByClientIdAsync(client.Id).Result)
                .Returns(projects.Where(project => project.ClientId == client.Id).ToList());

            var getProjectByClientIdQuery = new GetProjectsByClientIdQuery(client.Id);
            var getProjectByClientIdQueryHandler = new GetProjectsByClientIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectByClientIdQueryHandler.Handle(getProjectByClientIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count > 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByClientIdAsync(client.Id).Result, Times.Once());
        }

        [Fact]
        public async Task ClientExistsAndHasNoProjects_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var client = ProjectTestsHelper.GetClient();
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByClientIdAsync(client.Id).Result)
                .Returns(projects.Where(project => project.ClientId == client.Id).ToList());

            var getProjectByClientIdQuery = new GetProjectsByClientIdQuery(client.Id);
            var getProjectByClientIdQueryHandler = new GetProjectsByClientIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectByClientIdQueryHandler.Handle(getProjectByClientIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByClientIdAsync(client.Id).Result, Times.Once());
        }

        [Fact]
        public async Task ClientNotExists_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var fakeClientId = Guid.NewGuid();
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByClientIdAsync(fakeClientId).Result)
                .Returns(projects.Where(project => project.ClientId == fakeClientId).ToList());

            var getProjectByClientIdQuery = new GetProjectsByClientIdQuery(fakeClientId);
            var getProjectByClientIdQueryHandler = new GetProjectsByClientIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectByClientIdQueryHandler.Handle(getProjectByClientIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByClientIdAsync(fakeClientId).Result, Times.Once());
        }
    }
}
