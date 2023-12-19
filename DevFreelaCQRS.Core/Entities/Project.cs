﻿using DevFreelaCQRS.Core.Enums;

namespace DevFreelaCQRS.Core.Entities
{
    public class Project :  BaseEntity
    {
        public Project(string title, string description, Guid clientId, Guid freelancerId, decimal totalCost, ProjectStatus status, List<ProjectComment> comments)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;
            Status = status;
            Comments = comments;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid ClientId { get; private set; }
        public User Client { get; private set; }
        public Guid FreelancerId { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatus Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}