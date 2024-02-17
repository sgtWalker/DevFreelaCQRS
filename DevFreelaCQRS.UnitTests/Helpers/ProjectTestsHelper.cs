using DevFreelaCQRS.Core.Entities;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace DevFreelaCQRS.UnitTests.Helpers
{
    public static class ProjectTestsHelper
    {
        private const string PROJECT_NAME = "Project Test";
        private const string PROJECT_DESCRIPTION = "Description of the Project Test";
        private const decimal TOTAL_COST = 1000.00M;
        private const string CLIENT_NAME = "Client Test";
        private const string CLIENT_EMAIL = "client@client.com.br";
        private const string CLIENT_ROLE = "client";
        private const string FREELANCER_NAME = "Freelancer Test";
        private const string FREELANCER_EMAIL = "freelancer@freelancer.com.br";
        private const string FREELANCER_ROLE = "freelancer";
        private const string DEFAULT_PASSWORD = "P@ss09289";
        

        public static Project GetProject() => new Project(Guid.NewGuid(), PROJECT_NAME, PROJECT_DESCRIPTION, Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST);

        public static List<Project> GetProjectsList(int quantityToAdd)
        {
            var projects = new List<Project>();

            for (int i = 1; i <= quantityToAdd; i++)
            {
                projects.Add(new Project($"{PROJECT_NAME} {i}", $"{PROJECT_DESCRIPTION} {i}", Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST));
            }

            return projects;
        }

        public static List<Project> GetProjectsListWithSpecificDescription(int quantityToAdd, int quantityToAddSameDescription, string specificDescription)
        {
            if (quantityToAdd < quantityToAddSameDescription)
                throw new Exception("quantityToAdd is less than the quantityToAddSameDescription!");

            var projects = new List<Project>();

            for (int i = 1; i <= quantityToAdd; i++)
            {
                if (i <= quantityToAddSameDescription)
                    projects.Add(new Project($"{PROJECT_NAME} {i}", specificDescription, Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST));
                else
                    projects.Add(new Project($"{PROJECT_NAME} {i}", $"{PROJECT_DESCRIPTION} {i}", Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST));
            }

            return projects;
        }

        public static List<Project> GetProjectsListWithSpecificTitle(int quantityToAdd, int quantityToAddSameTitle, string specificTitle)
        {
            if (quantityToAdd < quantityToAddSameTitle)
                throw new Exception("quantityToAdd is less than the quantityToAddSameDescription!");

            var projects = new List<Project>();

            for (int i = 1; i <= quantityToAdd; i++)
            {
                if (i <= quantityToAddSameTitle)
                    projects.Add(new Project($"{specificTitle}", $"{PROJECT_DESCRIPTION} {i}", Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST));
                else
                    projects.Add(new Project($"{PROJECT_NAME} {i}", $"{PROJECT_DESCRIPTION} {i}", Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST));
            }

            return projects;
        }

        public static Project GetProjectWithDetails()
        {
            var client = new User(CLIENT_NAME, CLIENT_EMAIL, new DateTime(1993, 02, 21), DEFAULT_PASSWORD, CLIENT_ROLE);

            var freelancer = new User(FREELANCER_NAME, FREELANCER_EMAIL, new DateTime(1990, 02, 09), DEFAULT_PASSWORD, FREELANCER_ROLE);

            var project = new Project(Guid.NewGuid(), PROJECT_NAME, PROJECT_DESCRIPTION, Guid.NewGuid(), Guid.NewGuid(), TOTAL_COST, client, freelancer);

            return project;
        }

        public static List<Project> GetProjectsWithClientAndFreelancer(User client, User freelancer, int quantityProjectsToCreate)
        {
            var projects = new List<Project>();

            for (int i = 1; i <= quantityProjectsToCreate; i++)
            {
                projects.Add(new Project(Guid.NewGuid(), $"{PROJECT_NAME} {i}", $"{PROJECT_DESCRIPTION} {i}", client.Id, freelancer.Id, TOTAL_COST, client, freelancer));
            }

            return projects;
        }
        public static User GetClient() => new User(Guid.NewGuid(), CLIENT_NAME, CLIENT_EMAIL, new DateTime(1990, 03, 08), DEFAULT_PASSWORD, CLIENT_ROLE);
        public static User GetFreelancer() => new User(Guid.NewGuid(), FREELANCER_NAME, FREELANCER_EMAIL, new DateTime(1990, 03, 08), DEFAULT_PASSWORD, FREELANCER_ROLE);
    }
}
