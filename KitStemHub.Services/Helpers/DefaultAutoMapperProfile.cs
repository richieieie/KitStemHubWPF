using AutoMapper;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;

namespace KitStemHub.Services.Helpers
{
    public class DefaultAutoMapperProfile : Profile
    {
        public DefaultAutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<KitCreateDTO, Kit>().ReverseMap();
        }
    }
}
