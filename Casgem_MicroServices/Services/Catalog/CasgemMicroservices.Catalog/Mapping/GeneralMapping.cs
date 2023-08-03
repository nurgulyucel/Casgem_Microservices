﻿using AutoMapper;
using CasgemMicroservices.Catalog.Dtos.CategoryDtos;
using CasgemMicroservices.Catalog.Dtos.ProductDtos;
using CasgemMicroservices.Catalog.Models;

namespace CasgemMicroservices.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Products, ResultProductDtos>().ReverseMap();
            CreateMap<Products, CreateProductDto>().ReverseMap();
            CreateMap<Products, UpdateProductDto>().ReverseMap();
        }
    }
}
