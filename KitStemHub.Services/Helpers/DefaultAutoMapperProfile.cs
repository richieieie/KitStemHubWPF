using AutoMapper;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Responses;

namespace KitStemHub.Services.Helpers
{
    public class DefaultAutoMapperProfile : Profile
    {

        public DefaultAutoMapperProfile()
        {
            
            CreateMap<KitOrder, KitInOrderDetailDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Kit.Name))
                .ForMember(dest => dest.Package, opt => opt.MapFrom(src => src.Kit.Breif))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Kit.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.KitQuantity ?? 0))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Kit.ImageUrl))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => (src.Kit.Price * (src.KitQuantity ?? 0))));

            
        }
    }
}
