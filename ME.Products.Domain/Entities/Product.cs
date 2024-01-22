using ME.Products.Domain.Common;

namespace ME.Products.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }


    }
}
