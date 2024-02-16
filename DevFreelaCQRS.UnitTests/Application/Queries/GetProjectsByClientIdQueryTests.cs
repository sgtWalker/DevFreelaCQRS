using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByClientId;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectsByClientIdQueryTests
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
                .Returns(projects);

            var getProjectByClientIdQuery = new GetProjectsByClientIdQuery(client.Id);
            var getProjectByClientIdQueryHandler = new GetProjectsByClientIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectByClientIdQueryHandler.Handle(getProjectByClientIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count > 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByClientIdAsync(client.Id).Result, Times.Once());
        }
    }
}
