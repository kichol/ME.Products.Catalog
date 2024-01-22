using MediatR;

namespace ME.Products.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Product code: {Code}; Product name: {Name}; Price: {Price}; ";
        }
    }
}
