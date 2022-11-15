using Data.Context;
using Data.Repository;
using Data.UnitOfWork;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace CrossCuting
{
    public static class NativeInjection
    {
        public static IServiceCollection InjectionDependencysExtensions(this IServiceCollection services)
        {
            //DataBase connection
            services.AddScoped<ExodoDbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Repository
            services.AddTransient<IRepositoryClient, RepositoryClient>();

            //Services
            services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
