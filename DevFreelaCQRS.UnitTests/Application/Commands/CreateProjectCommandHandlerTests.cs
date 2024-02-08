using DevFreelaCQRS.Application.Commands.ProjectCommands.CreateProject;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            
            var createProjectCommand = new CreateProjectCommand("Project Test", "Description Test", Guid.NewGuid(), Guid.NewGuid(), 10000);
            
            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            var id = createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            Assert.NotNull(id);
            //Assert.True(id.Result != Guid.Empty); //removido até a resposta do Luis
            projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
