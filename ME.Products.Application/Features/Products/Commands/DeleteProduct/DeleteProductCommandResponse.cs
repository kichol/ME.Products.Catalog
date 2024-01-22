using ME.Products.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Products.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandResponse : BaseResponse
    {
        public DeleteProductCommandResponse() : base()
        {

        }

        public Guid ProductId { get; set; } = default!;
    }
}
