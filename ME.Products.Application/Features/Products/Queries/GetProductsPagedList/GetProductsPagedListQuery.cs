using ME.Products.Application.Extrensions;
using MediatR;

namespace ME.Products.Application.Features.Products.Queries.GetProductsPagedList
{
    public class GetProductsPagedListQuery : IRequest<ProductsPagedListResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public  string SortBy { get; set; } = "Name";
    }
}
    