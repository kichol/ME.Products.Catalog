using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using ME.Products.Domain.Entities;
using MediatR;

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
            if (request.Page <= 0)
                request.Page = 1;

            if (request.PageSize <= 0)
                request.PageSize = 10;

            var propertyInfo = typeof(Product).GetProperty(request.SortBy);

            var allProducts = (await _productRepository.ListAllAsync())
                 .Skip((request.Page - 1) * request.PageSize)
                 .Take(request.PageSize);
                //.OrderBy(x => request.IsSortAscending ? propertyInfo.GetValue(x):0);
           
            var count = allProducts.Count();

            var response = new ProductsPagedListResponse();
            response.TotalCount = count;
            response.Products = _mapper.Map<List<ProductPagedListVm>>(allProducts);
            return response;
           
            
        }
    }
}
