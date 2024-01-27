using ME.Products.Application.Features.Products.Commands.CreateProduct;
using ME.Products.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Products.Application.Features.Products.Queries.GetProductsPagedList
{
    public class ProductsPagedListResponse : BaseResponse
    {

        public ProductsPagedListResponse() : base()
        {

        }
        public int TotalCount { get; set; } 
        public IEnumerable<ProductPagedListVm> Products { get; set; } = default!;
    }

}
