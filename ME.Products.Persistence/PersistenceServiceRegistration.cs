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
                    Price = 300m

                });context.Products.Add(new Product {
                    ProductId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    Code = "ME003 Len",
                    Name = "Lenowvo xyx 123",
                    Price = 500m

                });

                context.SaveChanges();
            }
        }
    }
}
