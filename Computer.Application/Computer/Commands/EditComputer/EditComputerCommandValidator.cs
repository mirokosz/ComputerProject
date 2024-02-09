using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Commands.EditComputer
{
    public class EditComputerCommandValidator : AbstractValidator<EditComputerCommand>
    {
        public EditComputerCommandValidator()
        {
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
