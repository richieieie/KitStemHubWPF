﻿using AutoMapper;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using System.Security.Cryptography;

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

            //Map for cart
            CreateMap<Cart, CartCreateDTO>().ReverseMap();
            CreateMap<Cart, CartResponseDTO>().ReverseMap();

            //Map for Order
            CreateMap<Order, OrderCreateDTO>().ReverseMap();

            //Map for KitOrder
            CreateMap<KitOrder, KitOrderCreateDTO>().ReverseMap();

            //Map for Kit 
            CreateMap<KitUpdateDTO, Kit>();
            CreateMap<Kit, KitResponseDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status == true ? "Có sẵn" : "Không có sẵn"));
            CreateMap<KitCreateDTO, Kit>().ReverseMap();

            //Map for User
            CreateMap<User, UserDTO>().ReverseMap();

            //Map for Payment
            CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
        }
    }
}
