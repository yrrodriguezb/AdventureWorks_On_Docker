using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.ToTable("ProductModel", "Production");

        builder.HasKey(e => e.ProductModelID)
            .HasName("PK_ProductModel_ProductModelID");

        builder.Property(e => e.ProductModelID)
            .HasColumnName("ProductModelID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CatalogDescription)
            .HasColumnName("CatalogDescription")
            .HasColumnType("xml")
            .IsRequired(false);

        builder.Property(e => e.Instructions)
            .HasColumnName("Instructions")
            .HasColumnType("xml")
            .IsRequired(false);

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
            .HasDatabaseName("AK_ProductModel_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_ProductModel_rowguid");

        builder.HasCheckConstraint("CK_ProductModel_CatalogDescription", "[CatalogDescription] IS NOT NULL");
        builder.HasCheckConstraint("CK_ProductModel_Instructions", "[Instructions] IS NOT NULL");
    }
}