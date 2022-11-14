using Data.Context;
using Data.Repository;
using Data.UnitOfWork;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddTransient<IRepositoryTest, RepositoryTest>();

            return services;
        }
    }
}
