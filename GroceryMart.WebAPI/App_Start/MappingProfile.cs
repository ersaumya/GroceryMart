using AutoMapper;
using GroceryMart.DomainModels.Dtos;
using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMart.WebAPI.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}