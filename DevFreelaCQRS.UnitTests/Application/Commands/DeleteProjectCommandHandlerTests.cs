using DevFreelaCQRS.Application.Commands.ProjectCommands.DeleteProject;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task ThereIsAProject_Executed_DeleteTheProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var deleteProjectCommand = new DeleteProjectCommand(project.Id);
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            //Assert
            Assert.True(!project.Active);
            Assert.True(project.DeletedAt.HasValue);
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

            var deleteProjectCommand = new DeleteProjectCommand(fakeProjectId);
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            //Assert
            Assert.Null(project);
        }
    }
}
