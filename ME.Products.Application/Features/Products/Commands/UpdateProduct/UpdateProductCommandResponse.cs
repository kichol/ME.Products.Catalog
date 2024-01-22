using ME.Products.Application.Responses;

namespace ME.Products.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse : BaseResponse
    {
        public UpdateProductCommandResponse() : base()
        {

        }

        public UpdateProductDto Product { get; set; } = default!;
    }
}
