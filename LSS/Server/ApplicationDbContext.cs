using LSS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ProductsCategories>().HasKey(x => new { x.ProductId, x.CategoryId });



      base.OnModelCreating(modelBuilder);
    }

    public DbSet<About> About { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<ProductsCategories> ProductsCategories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<PatternStyle> PatternStyles { get; set; }
    public DbSet<SizeUnit> SizeUnits { get; set; }
    public DbSet<StarRating> StarRatings { get; set; }
    public DbSet<Style> Styles { get; set; }

    public override bool Equals(object obj)
    {
      return obj is ApplicationDbContext context &&
             base.Equals(obj) &&
             EqualityComparer<DbSet<About>>.Default.Equals(About, context.About);
    }
  }
}
