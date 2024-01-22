using AutoMapper;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using ME.Products.Application.Features.Products.Commands.UpdateProduct;
using ME.Products.Application.Features.Products.Queries.GetProductDetail;
using ME.Products.Application.Features.Products.Queries.GetProductsList;
using ME.Products.Domain.Entities;

namespace ME.Products.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDetailVm>().ReverseMap();
            CreateMap<Product, CreateProductDto>();
            CreateMap<Product, UpdateProductDto>();


        }
    }
}
