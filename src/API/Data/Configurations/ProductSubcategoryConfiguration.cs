using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
{
    public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
    {
        builder.ToTable("ProductSubcategory", "Production");

        builder.HasKey(e => e.ProductSubcategoryID)
            .HasName("PK_ProductSubcategory_ProductSubcategoryID");

        builder.Property(e => e.ProductSubcategoryID)
            .HasColumnName("ProductSubcategoryID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ProductCategoryID)
            .HasColumnName("ProductCategoryID")
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Rowguid)
            .HasColumnName("rowguid")
            .IsRequired()
            .HasDefaultValueSql("newid()");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("AK_ProductSubcategory_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_ProductSubcategory_rowguid");

        builder.HasOne(e => e.ProductCategory)
            .WithMany(p => p.ProductSubcategories)
            .HasForeignKey(e => e.ProductCategoryID)
            .HasConstraintName("FK_ProductSubcategory_ProductCategory_ProductCategoryID");
    }
}