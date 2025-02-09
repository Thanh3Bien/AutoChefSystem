using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AutoChefSystem.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDALServices(this IServiceCollection services)
        {
            services.AddScoped<AutoChefSystemContext>();
            return services;
        }
    }
}
