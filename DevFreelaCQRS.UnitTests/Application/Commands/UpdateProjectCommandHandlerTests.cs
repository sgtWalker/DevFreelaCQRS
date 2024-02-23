using DevFreelaCQRS.Application.Commands.ProjectCommands.UpdateProject;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class UpdateProjectCommandHandlerTests
    {
        [Fact]
        public async Task GivenThatTheProjectExists_Executed_UpdateTheProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var updatedTitle = "Update Title Tests";
            var updatedDescription = "Update Description Tests";
            var updatedCoast = 10.00m;

            var updateProjectCommand = new UpdateProjectCommand(project.Id, updatedTitle, updatedDescription, updatedCoast);
            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Title == updatedTitle);
            Assert.True(project.Description == updatedDescription);
            Assert.True(project.TotalCost == updatedCoast);
        }

        [Fact]
        public async Task GivenThatTheSearchIdDoesNotExists_Executed_DoNotTheUpdateAndReturnNull()
        {
            //Arrange
            var fakeProjectId = Guid.NewGuid();
            var project = ProjectTestsHelper.GetNullProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(fakeProjectId).Result)
                .Returns(project);

            var updatedTitle = "Update Title Tests";
            var updatedDescription = "Update Description Tests";
            var updatedCoast = 10.00m;

            var updateProjectCommand = new UpdateProjectCommand(fakeProjectId, updatedTitle, updatedDescription, updatedCoast);
            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            //Assert
            Assert.Null(project);
        }
    }
}
