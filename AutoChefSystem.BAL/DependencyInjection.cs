using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutoChefSystem.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            services.AddScoped<RoleService>();
            services.AddScoped<UserService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

