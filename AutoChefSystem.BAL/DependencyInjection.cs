using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Services;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Repositories.Services;
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
            services.AddScoped<OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRecipeStepService, RecipeStepService>();
            services.AddScoped<IRobotService, RobotService>();
            services.AddScoped<IRobotTypeService, RobotTypeService>();
            services.AddScoped<ILocationService, LocationService>();

            //    services.AddSingleton<RobotArmService>(provider =>
            //new RobotArmService("192.168.1.19", 5000));

            //    services.AddSingleton<IRobotArmService>(provider =>
            //new RobotArmService("192.168.1.19", 5000));
            services.AddSingleton<IRobotArmService, MockRobotArmService>();

            //Mapper
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }
    }
}

