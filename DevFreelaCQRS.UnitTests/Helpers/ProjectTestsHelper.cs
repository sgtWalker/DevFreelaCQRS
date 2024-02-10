using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.UnitTests.Helpers
{
    public static class ProjectTestsHelper
    {
        public static Project GetProject() => new Project("Project Test", "Project Description Test", Guid.NewGuid(), Guid.NewGuid(), 10000);

        public static List<Project> GetProjectsList(int quantityToAdd)
        {
            var projects = new List<Project>();

            for (int i = 1; i <= quantityToAdd; i++)
            {
                projects.Add(new Project($"Project Test {i}", $"Test Project Description {i}", Guid.NewGuid(), Guid.NewGuid(), 10000));
            }

            return projects;
        }
    }
}
