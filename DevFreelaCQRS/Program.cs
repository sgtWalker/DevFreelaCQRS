using DevFreelaCQRS.API.Filters;
using DevFreelaCQRS.Application.Commands.ProjectCommands.CreateProject;
using DevFreelaCQRS.Application.Validators.Project;
using DevFreelaCQRS.Application.Validators.User;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.Core.Services;
using DevFreelaCQRS.Infrastructure;
using DevFreelaCQRS.Infrastructure.Auth;
using DevFreelaCQRS.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCQRSConnection");
builder.Services.AddDbContext<DevFreelaCQRSDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCommentRepository, ProjectCommentRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMediatR(typeof(CreateProjectCommand));
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
