using LSS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSS.Server.Data.Configurations
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Products");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .HasColumnType("int");

      builder.Property(x => x.CategoryId)
          .HasColumnType("int");

      builder.Property(x => x.ColorId )
          .HasColumnType("int");

      builder.Property(x => x.DaysToManufacture)
          .HasColumnType("int");

      builder.Property(x => x.DiscontinuedDate )
          .IsRequired()
          .HasColumnType("datetime2");

      builder.Property(x => x.IsMarkedDownFlag )
          .HasColumnType("bit");

      builder.Property(x => x.OnClearanceFlag )
          .HasColumnType("bit");

      builder.Property(x => x.PatternId )
          .HasColumnType("int");

      builder.Property(x => x.Poster)
          .HasColumnType("varchar(50)");

      builder.Property(x => x.Price )
          .HasPrecision(8, 2)
          .HasColumnType("decimal(8,2)");

      builder.Property(x => x.ProductNumber)
          .HasColumnType("int");

      builder.Property(x => x.SellStartDate )
          .IsRequired()
          .HasColumnType("datetime2");

      builder.Property(x => x.SizeMeasureId )
          .HasColumnType("int");

      builder.Property(x => x.SizeTypeId )
          .HasColumnType("int");

      builder.Property(x => x.StarRatingId )
          .HasColumnType("int");

      builder.Property(x => x.StyleId)
          .HasColumnType("int");

      builder.Property(x => x.Summary)
          .HasColumnType("varchar(1024)");

      builder.Property(x => x.Title)
          .IsRequired()
          .HasColumnType("varchar(100)");

      builder.Property(x => x.Video)
          .HasColumnType("varchar(100)");
    }
  }
}
