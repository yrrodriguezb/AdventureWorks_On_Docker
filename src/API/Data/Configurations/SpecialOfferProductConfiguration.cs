using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;


public class SpecialOfferProductConfiguration : IEntityTypeConfiguration<SpecialOfferProduct>
{
    public void Configure(EntityTypeBuilder<SpecialOfferProduct> builder)
    {
        builder.ToTable("SpecialOfferProduct", "Sales");

        builder.HasKey(e => new { e.SpecialOfferID, e.ProductID })
            .HasName("PK_SpecialOfferProduct_SpecialOfferID_ProductID");

        builder.Property(e => e.SpecialOfferID)
            .HasColumnName("SpecialOfferID");

        builder.Property(e => e.ProductID)
            .HasColumnName("ProductID");

        builder.Property(e => e.Rowguid)
            .HasColumnName("rowguid")
            .IsRequired()
            .HasDefaultValueSql("newid()");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_SpecialOfferProduct_rowguid");

        builder.HasIndex(e => e.ProductID)
            .HasDatabaseName("IX_SpecialOfferProduct_ProductID");

        builder.HasOne(e => e.Product)
            .WithMany(p => p.SpecialOfferProducts)
            .HasForeignKey(e => e.ProductID)
            .HasConstraintName("FK_SpecialOfferProduct_Product_ProductID");

        builder.HasOne(e => e.SpecialOffer)
            .WithMany(so => so.SpecialOfferProducts)
            .HasForeignKey(e => e.SpecialOfferID)
            .HasConstraintName("FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID");
    }
}