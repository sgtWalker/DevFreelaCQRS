using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Enums;

namespace DevFreelaCQRS.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Project Name Test", "Description Test", Guid.NewGuid(), Guid.NewGuid(), 1000);

            Assert.Equal(ProjectStatus.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatus.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
