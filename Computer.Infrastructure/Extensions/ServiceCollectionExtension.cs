using Computer.Domain.Interfaces;
using Computer.Infrastructure.Persistence;
using Computer.Infrastructure.Repositories;
using Computer.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ComputerDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Computer")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ComputerDbContext>();

            services.AddScoped<ComputerSeeder>();

            services.AddScoped<IComputerRepository, ComputerRepository>();
        }
            
    }
}
