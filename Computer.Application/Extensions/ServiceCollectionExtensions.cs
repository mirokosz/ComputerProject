using Computer.Domain.Interfaces;
using Computer.Application.Mappings;
using Computer.Application.Services;
using Computer.Application.Computer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;

namespace Computer.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IComputerService, ComputerService>();

            services.AddAutoMapper(typeof(ComputerMappingProfile));

            services.AddValidatorsFromAssemblyContaining<ComputerDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }


    }
}
