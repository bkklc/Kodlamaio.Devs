using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Persistence.Paging;
using Domain.Entities;
using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            //CreateMap<PLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            //CreateMap<PLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<PLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            //CreateMap<PLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            //CreateMap<PLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<PLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<PLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<PLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}