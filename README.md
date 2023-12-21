# DevFreelaCQRS
# inclusão de migrations: 
#dotnet ef migrations add InitialCreate --project .\DevFreelaCQRS.Infrastructure\DevFreelaCQRS.Infrastructure.csproj -s .\DevFreelaCQRS\DevFreelaCQRS.API.csproj -o ..\DevFreelaCQRS.Infrastructure\Persistence\Migrations

#update migrations: 
#dotnet ef database update --project .\DevFreelaCQRS.Infrastructure\DevFreelaCQRS.Infrastructure.csproj -s .\DevFreelaCQRS\DevFreelaCQRS.API.csproj