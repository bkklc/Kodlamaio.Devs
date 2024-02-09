using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareTechs.Commands.CreateSoftwareTech
{
    public class CreateSoftwareTechCommand : IRequest<CreatedSoftwareTechDto>, ISecuredRequest
    {
        public string[] Roles { get; } = { "Admin" };
        public int PLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateSoftwareTechCommandHandler : IRequestHandler<CreateSoftwareTechCommand, CreatedSoftwareTechDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public CreateSoftwareTechCommandHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<CreatedSoftwareTechDto> Handle(CreateSoftwareTechCommand request, CancellationToken cancellationToken)
            {
                await _softwareTechBusinessRules.SoftwareTechNameCanNotBeDuplicatedWhenInserted(request.Name);

                SoftwareTech mappedSoftwareTech = _mapper.Map<SoftwareTech>(request.Name);
                SoftwareTech createdSoftwareTech = await _softwareTechRepository.AddAsync(mappedSoftwareTech);
                CreatedSoftwareTechDto createdSoftwareTechDto = _mapper.Map<CreatedSoftwareTechDto>(createdSoftwareTech);

                return createdSoftwareTechDto;
            }
        }
    }

}
