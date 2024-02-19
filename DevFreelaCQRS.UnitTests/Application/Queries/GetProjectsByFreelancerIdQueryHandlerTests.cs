using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByFreelancerId;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectsByFreelancerIdQueryHandlerTests
    {
        [Fact]
        public async Task FreelancerExistsAndHasAtLeastOneProject_Executed_ReturnListOfProjectViewModel()
        {
            //Arrange
            var client = ProjectTestsHelper.GetClient();
            var freelancer = ProjectTestsHelper.GetFreelancer();
            var projects = ProjectTestsHelper.GetProjectsWithClientAndFreelancer(client, freelancer, 3);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByFreelancerIdAsync(freelancer.Id).Result)
                .Returns(projects.Where(x => x.FreelancerId == freelancer.Id).ToList());

            var getProjectsByFreelancerIdQuery = new GetProjectsByFreelancerIdQuery(freelancer.Id);
            var getProjectsByFreelancerIdQueryHandler = new GetProjectsByFreelancerIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByFreelancerIdQueryHandler.Handle(getProjectsByFreelancerIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count > 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByFreelancerIdAsync(freelancer.Id).Result, Times.Once());
        }

        [Fact]
        public async Task ClientExistsAndHasNoProjects_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var freelancer = ProjectTestsHelper.GetFreelancer();
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByFreelancerIdAsync(freelancer.Id).Result)
                .Returns(projects.Where(project => project.FreelancerId == freelancer.Id).ToList());

            var getProjectsByFreelancerIdQuery = new GetProjectsByFreelancerIdQuery(freelancer.Id);
            var getProjectsByFreelancerIdQueryHandler = new GetProjectsByFreelancerIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByFreelancerIdQueryHandler.Handle(getProjectsByFreelancerIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByFreelancerIdAsync(freelancer.Id).Result, Times.Once());
        }

        [Fact]
        public async Task FreelancerNotExists_Executed_ReturnEmptyListOfProjectViewModel()
        {
            //Arrange
            var fakeFreelancerId = Guid.NewGuid();
            var projects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetAllByFreelancerIdAsync(fakeFreelancerId).Result)
                .Returns(projects.Where(project => project.FreelancerId == fakeFreelancerId).ToList());

            var getProjectsByFreelancerIdQuery = new GetProjectsByFreelancerIdQuery(fakeFreelancerId);
            var getProjectsByFreelancerIdQueryHandler = new GetProjectsByFreelancerIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModel = await getProjectsByFreelancerIdQueryHandler.Handle(getProjectsByFreelancerIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModel);
            Assert.True(projectsViewModel.Count == 0);

            projectRepositoryMock.Verify(pr => pr.GetAllByFreelancerIdAsync(fakeFreelancerId).Result, Times.Once());
        }
    }
}
