using DevFreelaCQRS.Application.Commands.ProjectCommands.StartProject;
using DevFreelaCQRS.Core.Enums;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class StartProjectCommandHandlerTests
    {
        [Fact]
        public async Task ThereIsAProjectCreated_Executed_ChangeProjectStatusToInProgress()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var startProjectCommand = new StartProjectCommand(project.Id);
            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.InProgress);
        }

        [Fact]
        public async Task ThereIsNotExistsProject_Executed_ReturnNull()
        {
            //Arrange
            var fakeProjectId = Guid.NewGuid();
            var project = ProjectTestsHelper.GetNullProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(fakeProjectId).Result)
                .Returns(project);

            var startProjectCommand = new StartProjectCommand(fakeProjectId);
            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            //Assert
            Assert.Null(project);
        }
    }
}
