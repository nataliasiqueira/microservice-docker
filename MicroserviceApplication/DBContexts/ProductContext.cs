using MicroserviceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceApplication.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Hygiene",
                    Description = "Personal Hygiene Products",
                },
                new Category
                {
                    Id = 2,
                    Name = "Food",
                    Description = "Food Products",
                },
                new Category
                {
                    Id = 3,
                    Name = "Cleaning",
                    Description = "House Cleaning Products"
                }

                );
        }
    }
}
