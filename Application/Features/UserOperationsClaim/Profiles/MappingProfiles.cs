using Application.Features.UserOperationsClaim.Commands.CreateUserOperationsClaim;
using Application.Features.UserOperationsClaim.Commands.DeleteUserOperationsClaim;
using Application.Features.UserOperationsClaim.Commands.UpdateUserOperationsClaim;
using Application.Features.UserOperationsClaim.Dtos;
using Application.Features.UserOperationsClaim.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationsClaim.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ReverseMap();
        }
    }
} 
