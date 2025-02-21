using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
{
    public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
    {
        builder.ToTable("SalesOrderDetail", "Sales");

        builder.HasKey(e => new { e.SalesOrderID, e.SalesOrderDetailID })
            .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

        builder.Property(e => e.SalesOrderID)
            .HasColumnName("SalesOrderID");

        builder.Property(e => e.SalesOrderDetailID)
            .HasColumnName("SalesOrderDetailID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CarrierTrackingNumber)
            .HasColumnName("CarrierTrackingNumber")
            .HasMaxLength(25)
            .IsRequired(false);

        builder.Property(e => e.OrderQty)
            .HasColumnName("OrderQty")
            .IsRequired();

        builder.Property(e => e.ProductID)
            .HasColumnName("ProductID")
            .IsRequired();

        builder.Property(e => e.SpecialOfferID)
            .HasColumnName("SpecialOfferID")
            .IsRequired();

        builder.Property(e => e.UnitPrice)
            .HasColumnName("UnitPrice")
            .IsRequired();

        builder.Property(e => e.UnitPriceDiscount)
            .HasColumnName("UnitPriceDiscount")
            .IsRequired()
            .HasDefaultValue(0.0m);

        builder.Property(e => e.LineTotal)
            .HasColumnName("LineTotal")
            .HasComputedColumnSql("isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))");

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
            .HasDatabaseName("AK_SalesOrderDetail_rowguid");

        builder.HasIndex(e => e.ProductID)
            .HasDatabaseName("IX_SalesOrderDetail_ProductID");

        // builder.HasOne(e => e.SalesOrderHeader)
        //     .WithMany(soh => soh.SalesOrderDetails)
        //     .HasForeignKey(e => e.SalesOrderID)
        //     .HasConstraintName("FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID")
        //     .OnDelete(DeleteBehavior.Cascade);

        // Uncomment the following lines if the SpecialOfferProduct relationship is needed
        // builder.HasOne(e => e.SpecialOfferProduct)
        //     .WithMany(sop => sop.SalesOrderDetails)
        //     .HasForeignKey(e => new { e.SpecialOfferID, e.ProductID })
        //     .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");

        builder.HasCheckConstraint("CK_SalesOrderDetail_OrderQty", "[OrderQty] > 0");
        builder.HasCheckConstraint("CK_SalesOrderDetail_UnitPrice", "[UnitPrice] >= 0.00");
        builder.HasCheckConstraint("CK_SalesOrderDetail_UnitPriceDiscount", "[UnitPriceDiscount] >= 0.00");
    }
}