using MediatR;

namespace ME.Products.Application.Features.Products.Queries.GetProductsPagedList
{
    public class GetProductsPagedListQuery : IRequest<ProductsPagedListResponse>
    {
        public string SortBy { get; set; } = string.Empty;
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
    