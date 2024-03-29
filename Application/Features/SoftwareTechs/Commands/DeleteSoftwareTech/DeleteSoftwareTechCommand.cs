﻿using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Rules;
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

namespace Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech
{
    public class DeleteSoftwareTechCommand : IRequest<DeletedSoftwareTechDto>, ISecuredRequest
    {
        public string[] Roles { get; } = { "Admin" };
        public int Id { get; set; }

        public class DeleteSoftwareTechCommandHandler : IRequestHandler<DeleteSoftwareTechCommand, DeletedSoftwareTechDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public DeleteSoftwareTechCommandHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<DeletedSoftwareTechDto> Handle(DeleteSoftwareTechCommand request, CancellationToken cancellationToken)
            {
                SoftwareTech? softwareTech = await _softwareTechRepository.GetAsync(predicate: u => u.Id == request.Id);
                await _softwareTechRepository.DeleteAsync(softwareTech);
                DeletedSoftwareTechDto response = _mapper.Map<DeletedSoftwareTechDto>(softwareTech);

                return response;
            }
        }

    }
}
