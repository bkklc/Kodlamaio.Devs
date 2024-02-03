using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
