using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Application.Features.Products.Queries.GetProductsList;
using ME.Products.Application.Features.Products.Queries.GetProductsPagedList;
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

namespace ME.Products.UnitTests.Products.Queries
{
    public class GetProductsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetProductsListQueryHandlerTests()
        {
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task CreateProductsListTest()
        {
            var handler = new GetProductsListQueryHandler(_mapper, _mockProductRepository.Object);
            var result = await handler.Handle(new GetProductListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<ProductListVm>>();
            result.Count.ShouldBe(4);
        }
        [Fact]
        public async Task PagedListShouldReceiveCorrectPageSizeAndTotalCount()
        {
            var handler = new GetProductsPagedListQueryHandler(_mapper, _mockProductRepository.Object);
            var result = await handler.Handle(new GetProductsPagedListQuery() {Page = 1, PageSize = 2 }, CancellationToken.None);
            result.ShouldBeOfType<ProductsPagedListResponse>();
            result.TotalCount.ShouldBe(4);
          
        }

    }
}
