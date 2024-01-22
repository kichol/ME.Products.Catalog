using ME.Products.Application.Contracts.Persistence;
using ME.Products.Domain.Entities;
using Moq;

namespace ME.Products.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    Code = "Prod1",
                    Name = "Product1",
                    Price = 0.99m,
                },new Product
                {
                    ProductId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    Code = "Prod2",
                    Name = "Product2",
                    Price = 300m,
                },new Product
                {
                    ProductId = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                    Code = "Prod3",
                    Name = "Product3",
                    Price = 8.67m,
                },new Product
                {
                    ProductId = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}"),
                    Code = "Prod4",
                    Name = "Product4",
                    Price = 22.22m,
                }
                
            };

            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(products);
             mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync(((Product product) =>
                {
                    products.Add(product);
                    return product;
                }));

            return mockProductRepository;
        }
    }
}
