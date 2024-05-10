using Microsoft.EntityFrameworkCore;
using ProniaWebApp.Models;

namespace ProniaWebApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
        }
        public DbSet <Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductPhoto> ProductsPhoto { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }

    }
}
