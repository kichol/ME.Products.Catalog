using MediatR;

namespace ME.Products.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public Guid Id { get; set; }
    }
}
