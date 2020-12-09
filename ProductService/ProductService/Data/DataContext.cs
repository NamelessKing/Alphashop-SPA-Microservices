using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<AssortmentFamily> AssortmentFamilies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Iva> Ivas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
