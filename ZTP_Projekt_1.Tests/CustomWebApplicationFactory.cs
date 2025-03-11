using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZTP_Projekt_1.Domain;
using ZTP_Projekt_1.Infrastructure;

public class CustomWebApplicationFactory: WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            builder.UseEnvironment("Testing");

            // Remove original DB context
            var dbContextDescriptors = services
                .Where(d => d.ServiceType == typeof(AppDbContext) ||
                            d.ServiceType == typeof(DbContextOptions<AppDbContext>))
                .ToList();

            foreach (var descriptor in dbContextDescriptors)
            {
                services.Remove(descriptor);
            }

            // Init in-memory DB
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });

            // Mock DB
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                try
                {
                    SeedDatabase(db);
                }
                catch (Exception ex)
                {
                    throw new Exception("Seeding test DB error", ex);
                }
            }
        });
    }

    private void SeedDatabase(AppDbContext db)
    {
        db.Products.AddRange(
            new Product { Id = 1, Name = "Test Product 1", Price = 9.99m, StockQuantity = 10, CategoryId = 1 },
            new Product { Id = 2, Name = "Test Product 2", Price = 19.99m, StockQuantity = 5, CategoryId = 1 }
        );

        db.Categories.Add(
            new Category { Id = 1, Name = "Electronics", MinPrice = 50, MaxPrice = 50000 }
        );

        db.SaveChanges();
    }
}
