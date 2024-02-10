using DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectById;
using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.UnitTests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelaCQRS.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task GivenThatTheProjectExists_Executed_ReturnProjectViewModel()
        {
            //Arrange
            var project = ProjectTestsHelper.GetProject();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetByIdAsync(project.Id).Result)
                .Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(project.Id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModel);
            Assert.Equal(project.Id, projectViewModel.Id);

            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(project.Id).Result, Times.Once());
        }

        [Fact]
        public async Task GivenThatTheProjectNotExists_Executed_ReturnNull()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var getProjectByIdQuery = new GetProjectByIdQuery(Guid.Empty);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            //Assert
            Assert.Null(projectViewModel);
        }
    }
}
