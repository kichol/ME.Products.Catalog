using ME.Products.Persistence.Repositories;
using ME.Products.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ME.Products.Domain.Entities;



namespace ME.Products.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseInMemoryDatabase("MediaExpert"));
                //(configuration.GetConnectionString("MediaExpertConnectionString")));

            

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();

            SeedDatabase(services.BuildServiceProvider());

            return services;
        }
        private static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

                                
                // Add seed data
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                    Code = "ME001 HP",
                    Name = "EliteBook 850 G6",
                    Price = 300.66m

                });
                context.Products.Add(new Product
                {
                    ProductId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    Code = "ME003 Len",
                    Name = "Lenovo xyx 123",
                    Price = 500.55m
                });
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{3c94da2a-9e29-43b9-834a-685fc06edbbc}"),
                    Code = "ME014 Dell lattitude",
                    Name = "Dell xyz1",
                    Price = 1999.99m
                });
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{acddecfe-bfaa-4560-987a-055f04d7e677}"),
                    Code = "ME012 Atari",
                    Name = "Dell xyz2",
                    Price = 249.99m
                });
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{4ae011a2-56bc-440e-98d8-57495fb55d1e}"),
                    Code = "ME009 Commodeore",
                    Name = "Dell xyz3",
                    Price = 8999.99m

                });
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{bbc5b0b4-2719-4e25-941d-315a534c1d68}"),
                    Code = "ME010 Asus",
                    Name = "Lenovo 823389",
                    Price = 332.49m

                });
                context.Products.Add(new Product {
                    ProductId = Guid.Parse("{2c47c25b-2326-46f1-8a57-a655e36cae6c}"),
                    Code = "PEG 001",
                    Name = "Pegasus Console",
                    Price = 999.99m

                });

                context.SaveChanges();
            }
        }
    }
}
