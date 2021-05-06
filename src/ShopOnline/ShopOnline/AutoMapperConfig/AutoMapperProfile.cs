using AutoMapper;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Order, OrderDTO>().ForMember(dto => dto.ConfirmStatusName, model => model.MapFrom(m => m.ConfirmStatus.Name));
        }
    }
}