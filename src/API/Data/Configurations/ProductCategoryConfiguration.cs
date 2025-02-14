using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory", "Production");

        builder.HasKey(e => e.ProductCategoryID)
            .HasName("PK_ProductCategory_ProductCategoryID");

        builder.Property(e => e.ProductCategoryID)
            .HasColumnName("ProductCategoryID")
            .ValueGeneratedOnAdd();

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
            .HasDatabaseName("AK_ProductCategory_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_ProductCategory_rowguid");
    }
}