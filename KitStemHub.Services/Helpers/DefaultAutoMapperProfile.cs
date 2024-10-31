using AutoMapper;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;

namespace KitStemHub.Services.Helpers
{
    public class DefaultAutoMapperProfile : Profile
    {
        public DefaultAutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Kit, KitResponseDTO>().ReverseMap();
            CreateMap<KitCreateDTO, Kit>().ReverseMap();
        }
    }
}
