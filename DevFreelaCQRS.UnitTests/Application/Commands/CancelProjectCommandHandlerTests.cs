using DevFreelaCQRS.Application.Commands.ProjectCommands.CancelProject;
using DevFreelaCQRS.Core.Enums;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class CancelProjectCommandHandlerTests
    {
        [Fact]
        public async Task ThereIsAProjectCreated_Executed_CancelTheProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var cancelProjectCommand = new CancelProjectCommand(project.Id);
            var cancelProjectCommandHandler = new CancelProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await cancelProjectCommandHandler.Handle(cancelProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.Cancelled);
        }

        [Fact]
        public async Task ThereIsAProjectInProgress_Executed_CancelTheProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();
            
            project.Start();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var cancelProjectCommand = new CancelProjectCommand(project.Id);
            var cancelProjectCommandHandler = new CancelProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await cancelProjectCommandHandler.Handle(cancelProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.Cancelled);
        }

        [Fact]
        public async Task ThereIsAProjectFinished_Executed_DoNotCancelTheProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            project.Start();
            project.Finish();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var cancelProjectCommand = new CancelProjectCommand(project.Id);
            var cancelProjectCommandHandler = new CancelProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await cancelProjectCommandHandler.Handle(cancelProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.Finished);
        }

        [Fact]
        public async Task ThereIsNoProject_Executed_ReturnNull()
        {
            //Arrange
            var fakeProjectId = Guid.NewGuid();
            var project = ProjectTestsHelper.GetNullProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(fakeProjectId).Result)
                .Returns(project);

            var cancelProjectCommand = new CancelProjectCommand(fakeProjectId);
            var cancelProjectCommandHandler = new CancelProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await cancelProjectCommandHandler.Handle(cancelProjectCommand, new CancellationToken());

            //Assert
            Assert.Null(project);
        }
    }
}
