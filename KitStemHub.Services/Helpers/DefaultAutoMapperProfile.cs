using AutoMapper;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Responses;

namespace KitStemHub.Services.Helpers
{
    public class DefaultAutoMapperProfile : Profile
    {
        public DefaultAutoMapperProfile()
        {
            // Existing KitOrder to KitInOrderDetailDTO mapping
            CreateMap<KitOrder, KitInOrderDetailDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Kit.Name))
                .ForMember(dest => dest.Package, opt => opt.MapFrom(src => src.Kit.Breif))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Kit.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.KitQuantity ?? 0))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Kit.ImageUrl))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => (src.Kit.Price * (src.KitQuantity ?? 0))));

            // Add Category to CategoryDTO mapping
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ?? false)) // handle nullable Status
                .ReverseMap();
        }
    }
}
