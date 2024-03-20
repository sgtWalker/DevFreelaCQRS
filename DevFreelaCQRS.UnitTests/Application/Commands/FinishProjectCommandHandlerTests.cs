using DevFreelaCQRS.Application.Commands.ProjectCommands.FinishProject;
using DevFreelaCQRS.Core.Enums;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.Core.Services;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;

namespace DevFreelaCQRS.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTests
    {
        [Fact]
        public async Task ThereIsAProjectCreated_Executed_DoNotFinishProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var paymentServiceMock = new Mock<IPaymentService>();

            var finishProjectCommand = new FinishProjectCommand(project.Id);
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object, paymentServiceMock.Object);

            //Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.Created);
        }

        [Fact]
        public async Task ThereIsAProjectInProgress_Executed_FinishProject()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var paymentServiceMock = new Mock<IPaymentService>();

            var finishProjectCommand = new FinishProjectCommand(project.Id);
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object, paymentServiceMock.Object);

            //Act
            project.Start();
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            //Assert
            Assert.True(project.Status == ProjectStatus.PaymentPending);
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

            var paymentServiceMock = new Mock<IPaymentService>();

            var finishProjectCommand = new FinishProjectCommand(fakeProjectId);
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object, paymentServiceMock.Object);

            //Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            //Assert
            Assert.Null(project);
        }
    }
}
