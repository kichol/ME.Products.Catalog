using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Application.Extrensions;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using ME.Products.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace ME.Products.Application.Features.Products.Queries.GetProductsPagedList
{
    public class GetProductsPagedListQueryHandler : IRequestHandler<GetProductsPagedListQuery, ProductsPagedListResponse>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductsPagedListQueryHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<ProductsPagedListResponse> Handle(GetProductsPagedListQuery request, CancellationToken cancellationToken)
        {
            var response = new ProductsPagedListResponse();

            var sortBy =  request.SortBy[0].ToString().ToUpper()+request.SortBy.Substring(1);
            var propertyInfo = typeof(Product).GetProperty(sortBy);

            var allProducts = (await _productRepository.GetPagedReponseAsync(request.Page, request.PageSize))
                .OrderBy(x => propertyInfo.GetValue(x, null)??propertyInfo.GetValue("Name"));

            response.TotalCount =  _productRepository.ListAllAsync().Result.Count();
            response.Products =  _mapper.Map<List<ProductPagedListVm>>(allProducts);
            return response;
           
            
        }
    }
}
