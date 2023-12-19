using DevFreelaCQRS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreelaCQRS.Infrastructure
{
    public class DevFreelaCQRSDbContext : DbContext
    {
        public DevFreelaCQRSDbContext(DbContextOptions<DevFreelaCQRSDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
    }
}
