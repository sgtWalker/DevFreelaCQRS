﻿using DevFreelaCQRS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreelaCQRS.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder 
                .HasOne(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}