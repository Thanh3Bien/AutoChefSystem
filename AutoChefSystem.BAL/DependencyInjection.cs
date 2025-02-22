using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Services;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Mappings;
using AutoChefSystem.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutoChefSystem.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            services.AddScoped<RoleService>();
            services.AddScoped<UserService>();
            services.AddScoped<RecipeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();

            //services.AddScoped<IBrothService, BrothService>();
            //services.AddScoped<INoodleService, NoodleService>();

            //Mapper
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }
    }
}

