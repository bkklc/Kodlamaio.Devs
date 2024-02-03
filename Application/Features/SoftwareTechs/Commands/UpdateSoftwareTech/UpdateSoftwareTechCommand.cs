using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareTechs.Commands.UpdateSoftwareTech
{
    public  class UpdateSoftwareTechCommand : IRequest<UpdatedSoftwareTechDto> 
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? Name { get; set; }

        public class UpdateSoftwareTechCommandHandler : IRequestHandler<UpdateSoftwareTechCommand, UpdatedSoftwareTechDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public UpdateSoftwareTechCommandHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<UpdatedSoftwareTechDto> Handle(UpdateSoftwareTechCommand request, CancellationToken cancellationToken)
            {
                SoftwareTech? softwareTech = await _softwareTechRepository.GetAsync(predicate: u => u.Id == request.Id);
                await _softwareTechRepository.DeleteAsync(softwareTech);
                UpdatedSoftwareTechDto response = _mapper.Map<UpdatedSoftwareTechDto>(softwareTech);

                return response;
            }
        }

    }
}
