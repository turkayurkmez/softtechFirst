using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastucture.Data
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired()
                                                               .HasMaxLength(70);

            //Fluent API 
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(p => p.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Bilgisayar" },
                new Category() { Id = 2, Name = "Kozmetik ve Bakım" }

            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Dell XPS 15", CategoryId = 1, Description = "16 GB Ram 512 SSD", Price = 40000, Stocks = 10, ImageUrl = "https://cdn.dsmcdn.com/ty595/product/media/images/20221110/13/211603679/618960823/1/1_org.jpg" },
                new Product() { Id = 2, Name = "Rimel", CategoryId = 2, Description = "Çeşitli rimeller :) ", Price = 250, Stocks = 100, ImageUrl = "https://cdn.dsmcdn.com/ty595/product/media/images/20221110/13/211603679/618960823/1/1_org.jpg" }


            );

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer();
        //}




    }
}
