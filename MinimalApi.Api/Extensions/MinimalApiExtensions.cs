using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.DataAccess.Repositories;
using MinimalApi.DataAccess;
using MinimalApi.Api.Abstractions;

namespace MinimalApi.Api.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
           
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SocialDbcontext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePost).Assembly));
        }

        public static void RegisterEndpointDefinitions(this WebApplication app) 
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDef in endpointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}
