using Application.Features.SoftwareTechs.Commands.CreateSoftwareTech;
using Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech;
using Application.Features.SoftwareTechs.Commands.UpdateSoftwareTech;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SoftwareTechs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SoftwareTech, CreatedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, UpdatedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, DeletedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, CreateSoftwareTechCommand>().ReverseMap();
            CreateMap<SoftwareTech, UpdateSoftwareTechCommand>().ReverseMap();
            CreateMap<SoftwareTech, DeleteSoftwareTechCommand>().ReverseMap();
            CreateMap<IPaginate<SoftwareTech>, SoftwareTechListModel>().ReverseMap();
            CreateMap<SoftwareTech, SoftwareTechListDto>()
                .ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.PLanguage.Name))
                .ReverseMap();

            CreateMap<SoftwareTech, SoftwareTechGetByIdDto>()
                .ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.PLanguage.Name))
                .ReverseMap();
        }
    }
}

