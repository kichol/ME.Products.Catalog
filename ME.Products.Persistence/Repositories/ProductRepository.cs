using ME.Products.Application.Contracts.Persistence;
using ME.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Products.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext dbContext) : base(dbContext)
        {
  
        }

        public Task<bool> IsProductNameAndCodeUnique(string name, string code)
        {
            var matches = _dbContext.Products.Any(e => e.Name.Equals(name) && e.Code.Equals(code));
            return Task.FromResult(matches);
        }
    }
}
