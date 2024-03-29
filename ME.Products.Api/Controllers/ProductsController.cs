
using ME.Products.Application.Features.Products.Queries.GetProductsList;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ME.Products.Application.Features.Products.Queries.GetProductDetail;
using ME.Products.Application.Features.Products.Commands.UpdateProduct;
using ME.Products.Application.Features.Products.Commands.DeleteProduct;
using ME.Products.Application.Features.Products.Queries.GetProductsPagedList;

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
        
        [HttpGet("GetPagedProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductPagedListVm>>> GetPagedProducts(int page = 1, int pageSize =10,string sortBy = "Name"  )
        {
            var dtos = await _mediator.Send(new GetProductsPagedListQuery() { Page = page, PageSize = pageSize, SortBy= sortBy   });
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
            return Ok(await _mediator.Send(updateProductCommand));
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            return Ok(await _mediator.Send(deleteProductCommand));
       
        }

       
    }
}
