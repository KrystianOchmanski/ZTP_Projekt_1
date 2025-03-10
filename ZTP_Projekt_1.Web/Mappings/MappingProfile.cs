﻿using AutoMapper;
using ZTP_Projekt_1.Domain;
using ZTP_Projekt_1.Web.DTOs.CategoryDTOs;
using ZTP_Projekt_1.Web.DTOs.ProductDTOs;

namespace ZTP_Projekt_1.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Category
            CreateMap<CreateCategoryDTO, Category>();
            
            CreateMap<EditCategoryDTO, Category>();

            // Product
			CreateMap<Product, ProductDTO>()
			.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            
            CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<EditProductDTO, Product>();
		}
    }
}
