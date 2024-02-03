using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech
{
    public class DeleteSoftwareTechCommandValidator : AbstractValidator<DeleteSoftwareTechCommand>
    {
        public DeleteSoftwareTechCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
