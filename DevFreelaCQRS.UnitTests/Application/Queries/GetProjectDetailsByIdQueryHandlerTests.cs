using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectDetailsById;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectDetailsByIdQueryHandlerTests
    {
        [Fact]
        public async Task GivenThatTheProjectExists_Executed_ReturnProjectDetailsViewModel()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProjectWithDetails();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetDetailsByIdAsync(project.Id).Result)
                .Returns(project);

            var getProjectDetailsByIdQuery = new GetProjectDetailsByIdQuery(project.Id);
            var getProjectDetailsByIdQueryHandler = new GetProjectDetailsByIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectDetails = await getProjectDetailsByIdQueryHandler.Handle(getProjectDetailsByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectDetails);
            Assert.Equal(project.Id, projectDetails.Id);

            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(project.Id), Times.Once());
        }

        [Fact]
        public async Task GivenThatTheProjectNotExists_Executed_ReturnNull()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var getProjectDetailsByIdQuery = new GetProjectDetailsByIdQuery(Guid.Empty);
            var getProjectDetailsByIdQueryHandler = new GetProjectDetailsByIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModel = await getProjectDetailsByIdQueryHandler.Handle(getProjectDetailsByIdQuery, new CancellationToken());

            //Assert
            Assert.Null(projectViewModel);
        }
    }
}
