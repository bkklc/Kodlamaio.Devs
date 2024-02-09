using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>, ISecuredRequest
    {
        public string[] Roles { get; } = { "Admin" };
        public int Id { get; set; }
        public string? Name { get; set; }


        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                PLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(c => c.Id == request.Id);
                if (programmingLanguage != null)
                {
                    programmingLanguage.Name = request.Name;
                    await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                }

                UpdatedProgrammingLanguageDto response = _mapper.Map<UpdatedProgrammingLanguageDto>(programmingLanguage);
                return response;
            }
        }
    }
}
