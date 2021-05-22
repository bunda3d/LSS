using LSS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static LSS.Shared.Entities.Product;

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

      //modelBuilder.Entity<IdentityUser>()
      //.ToTable("AspNetUsers", t => t.ExcludeFromMigrations());

      //M:M Join Tables
      modelBuilder.Entity<ProductCategory>()
        .HasKey(x => new { x.ProductId, x.CategoryId });

      modelBuilder.Entity<ProductPerson>()
        .HasKey(x => new { x.ProductId, x.PersonId });

      modelBuilder.Entity<StarRatingProduct>()
        .HasKey(x => new { x.StarRatingId, x.ProductId });

      modelBuilder.Entity<StarRatingPerson>()
        .HasKey(x => new { x.StarRatingId, x.PersonId });


      //Fields & Tables
      modelBuilder.Entity<Product>()
      .Property(b => b.Price)
      .HasPrecision(8, 2)
      .HasColumnType("decimal(8, 2)");

      modelBuilder.Entity<StarRating>(
      ex =>
      {
        ex.Property(x => x.StarRatingScoreEvent)
        .HasPrecision(1)
        .HasColumnType("int");
        ex.Property(x => x.StarRatingScoreAvg)
        .HasPrecision(1, 1)
        .HasColumnType("decimal(1, 1)");
      });



      base.OnModelCreating(modelBuilder);
    }

    public DbSet<About> About { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<PatternStyle> PatternStyles { get; set; }
    public DbSet<SizeUnit> SizeUnits { get; set; }
    public DbSet<StarRating> StarRatings { get; set; }

    //M:M Join Tables
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<ProductPerson> ProductsPeople { get; set; }
    public DbSet<StarRatingProduct> StarRatingsProducts { get; set; }
    public DbSet<StarRatingPerson> StarRatingsPeople { get; set; }


    public override bool Equals(object obj)
    {
      return obj is ApplicationDbContext context &&
             base.Equals(obj) &&
             EqualityComparer<DbSet<About>>.Default.Equals(About, context.About);
    }
  }
}
