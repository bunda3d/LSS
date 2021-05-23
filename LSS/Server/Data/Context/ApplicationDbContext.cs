using LSS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace LSS.Server.Data.Context
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
      modelBuilder.Entity<ProductsCategories>()
        .HasKey(x => new { x.ProductId, x.CategoryId });

      modelBuilder.Entity<ProductsPeople>()
        .HasKey(x => new { x.ProductId, x.PersonId });

      modelBuilder.Entity<StarRatingsProducts>()
        .HasKey(x => new { x.StarRatingId, x.ProductId });

      modelBuilder.Entity<StarRatingsPeople>()
        .HasKey(x => new { x.StarRatingId, x.PersonId });


      base.OnModelCreating(modelBuilder);

      //apply all model configurations
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<About> About { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<PatternStyle> PatternStyles { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SizeMeasure> SizeTypes { get; set; }
    public DbSet<SizeType> SizeUnits { get; set; }
    public DbSet<StarRating> StarRatings { get; set; }
    public DbSet<Style> Styles { get; set; }

    //M:M Join Tables
    public DbSet<ProductsCategories> ProductsCategories { get; set; }
    public DbSet<ProductsPeople> ProductsPeople { get; set; }
    public DbSet<StarRatingsPeople> StarRatingsPeople { get; set; }
    public DbSet<StarRatingsProducts> StarRatingsProducts { get; set; }


    public override bool Equals(object obj)
    {
      return obj is ApplicationDbContext context &&
             base.Equals(obj) &&
             EqualityComparer<DbSet<Employee>>.Default.Equals(Employees, context.Employees);
    }
  }
}
