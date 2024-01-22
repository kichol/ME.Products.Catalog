using MediatR;

namespace ME.Products.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public Guid ProductId { get; set; }
    }
}
