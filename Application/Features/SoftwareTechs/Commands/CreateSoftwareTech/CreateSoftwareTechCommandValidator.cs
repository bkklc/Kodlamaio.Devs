using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareTechs.Commands.CreateSoftwareTech
{
    public class CreateSoftwareTechCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateSoftwareTechCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
