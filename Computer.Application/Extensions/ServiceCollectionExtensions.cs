using Computer.Domain.Interfaces;
using Computer.Application.Mappings;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Computer.Application.Computer.Commands.CreateComputer;

namespace Computer.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateComputerCommand));

            services.AddAutoMapper(typeof(ComputerMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateComputerCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }


    }
}
