using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Application.Features.Products.Commands.CreateProduct;
using ME.Products.Application.Profiles;
using ME.Products.Domain.Entities;
using ME.Products.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Products.UnitTests.Products.Commands
{
    public class CreateProductTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public CreateProductTests()
        {
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task Handle_ValidProduct_AddedToProductsRepo()
        {
            var handler = new CreateProductCommandHandler(_mapper, _mockProductRepository.Object );

            await handler.Handle(new CreateProductCommand() { Name = "TestName", Code= "TestCode", Price = 123  }, CancellationToken.None);

            var allProducts = await _mockProductRepository.Object.ListAllAsync();
            allProducts.Count.ShouldBe(5);
        }
    }
}
