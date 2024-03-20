using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.Core.Services;
using DevFreelaCQRS.Infrastructure.Auth;
using DevFreelaCQRS.Infrastructure.MessageBus;
using DevFreelaCQRS.Infrastructure.Payments;
using DevFreelaCQRS.Infrastructure.Repositories;

namespace DevFreelaCQRS.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectCommentRepository, ProjectCommentRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }
    }
}
