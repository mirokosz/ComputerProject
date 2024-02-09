using Computer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Computer.Application.Computer.Commands.CreateComputer;

namespace Computer.Application.Computer.Commands.CreateComputer
{
    public class CreateComputerCommandValidator : AbstractValidator<CreateComputerCommand>
    {
        public CreateComputerCommandValidator(IComputerRepository repository) 
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(20).WithMessage("Name should have maximum of 20 characters")
            .Custom((value, context) =>
            {
                var existingComputer = repository.GetByName(value).Result;
                if(existingComputer != null)
                {
                    context.AddFailure($"{value} is not unique name for car workshop");
                }
            });                                                                              

            RuleFor(c => c.Producer)
                .NotEmpty().WithMessage("Please enter producer");

            RuleFor(c => c.CPU)
                .NotEmpty().WithMessage("Please enter CPU");

            RuleFor(c => c.Memory)
                .NotEmpty().WithMessage("Please enter memory");

            RuleFor(c => c.GPU)
                .NotEmpty().WithMessage("Please enter GPU");
        }
    }
}
