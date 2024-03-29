﻿using Application.Features.UserOperationsClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationsClaim.Commands.CreateUserOperationsClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles { get; } = { "Admin" };
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
            }
            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim addedUserOperationClaim =
                    await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                User? user = await _userRepository.GetAsync(u => u.Id == addedUserOperationClaim.UserId);
                OperationClaim? operationClaim =
                    await _operationClaimRepository.GetAsync(o => o.Id == addedUserOperationClaim.OperationClaimId);
                CreatedUserOperationClaimDto createdUserOperationClaimDto = new()
                {
                    Id = addedUserOperationClaim.Id,
                    OperationClaimName = operationClaim.Name,
                    UserName = user.FirstName
                };
                return createdUserOperationClaimDto;
            }
        }
    }
}
