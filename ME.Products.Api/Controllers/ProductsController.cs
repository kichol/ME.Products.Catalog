
using ME.Products.Application.Features.Products.Queries.GetProductsList;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ME.Products.Application.Features.Products.Queries.GetProductDetail;
using ME.Products.Application.Features.Products.Commands.UpdateProduct;
using ME.Products.Application.Features.Products.Commands.DeleteProduct;

namespace ME.Products.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDetailVm>> GetProductById(Guid id)
        {
            var getProductDetailQuery = new GetProductDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var id = await _mediator.Send(createProductCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            await _mediator.Send(deleteProductCommand);
            return NoContent();
        }

       
    }
}
