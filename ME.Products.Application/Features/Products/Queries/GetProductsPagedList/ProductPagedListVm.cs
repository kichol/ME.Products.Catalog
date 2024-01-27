namespace ME.Products.Application.Features.Products.Queries.GetProductsPagedList
{
    public class ProductPagedListVm
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
