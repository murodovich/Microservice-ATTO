using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using University.Application.FileServices;
using University.Application.Interfaces;

namespace University.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IFileService, FileService>();
            return services;
        }

    }
}
