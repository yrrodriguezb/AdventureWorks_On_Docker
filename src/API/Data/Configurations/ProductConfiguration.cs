using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "Production");

        builder.HasKey(e => e.ProductID)
            .HasName("PK_Product_ProductID");

        builder.Property(e => e.ProductID)
            .HasColumnName("ProductID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ProductNumber)
            .HasColumnName("ProductNumber")
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(e => e.MakeFlag)
            .HasColumnName("MakeFlag")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.FinishedGoodsFlag)
            .HasColumnName("FinishedGoodsFlag")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.Color)
            .HasColumnName("Color")
            .HasMaxLength(15)
            .IsRequired(false);

        builder.Property(e => e.SafetyStockLevel)
            .HasColumnName("SafetyStockLevel")
            .IsRequired();

        builder.Property(e => e.ReorderPoint)
            .HasColumnName("ReorderPoint")
            .IsRequired();

        builder.Property(e => e.StandardCost)
            .HasColumnName("StandardCost")
            .IsRequired();

        builder.Property(e => e.ListPrice)
            .HasColumnName("ListPrice")
            .IsRequired();

        builder.Property(e => e.Size)
            .HasColumnName("Size")
            .HasMaxLength(5)
            .IsRequired(false);

        builder.Property(e => e.SizeUnitMeasureCode)
            .HasColumnName("SizeUnitMeasureCode")
            .HasMaxLength(3)
            .IsFixedLength()
            .IsRequired(false);

        builder.Property(e => e.WeightUnitMeasureCode)
            .HasColumnName("WeightUnitMeasureCode")
            .HasMaxLength(3)
            .IsFixedLength()
            .IsRequired(false);

        builder.Property(e => e.Weight)
            .HasColumnName("Weight")
            .HasColumnType("decimal(8, 2)")
            .IsRequired(false);

        builder.Property(e => e.DaysToManufacture)
            .HasColumnName("DaysToManufacture")
            .IsRequired();

        builder.Property(e => e.ProductLine)
            .HasColumnName("ProductLine")
            .HasMaxLength(2)
            .IsFixedLength()
            .IsRequired(false);

        builder.Property(e => e.Class)
            .HasColumnName("Class")
            .HasMaxLength(2)
            .IsFixedLength()
            .IsRequired(false);

        builder.Property(e => e.Style)
            .HasColumnName("Style")
            .HasMaxLength(2)
            .IsFixedLength()
            .IsRequired(false);

        builder.Property(e => e.ProductSubcategoryID)
            .HasColumnName("ProductSubcategoryID")
            .IsRequired(false);

        builder.Property(e => e.ProductModelID)
            .HasColumnName("ProductModelID")
            .IsRequired(false);

        builder.Property(e => e.SellStartDate)
            .HasColumnName("SellStartDate")
            .IsRequired();

        builder.Property(e => e.SellEndDate)
            .HasColumnName("SellEndDate")
            .IsRequired(false);

        builder.Property(e => e.DiscontinuedDate)
            .HasColumnName("DiscontinuedDate")
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
            .HasDatabaseName("AK_Product_Name");

        builder.HasIndex(e => e.ProductNumber)
            .IsUnique()
            .HasDatabaseName("AK_Product_ProductNumber");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_Product_rowguid");

        builder.HasOne(e => e.ProductSubcategory)
            .WithMany(ps => ps.Products)
            .HasForeignKey(e => e.ProductSubcategoryID)
            .HasConstraintName("FK_Product_ProductSubcategory_ProductSubcategoryID");

        builder.HasOne(e => e.ProductModel)
            .WithMany(pm => pm.Products)
            .HasForeignKey(e => e.ProductModelID)
            .HasConstraintName("FK_Product_ProductModel_ProductModelID");

        builder.HasOne(e => e.SizeUnitMeasure)
            .WithMany(e => e.SizeUnitMeasureProducts)
            .HasForeignKey(e => e.SizeUnitMeasureCode)
            .HasConstraintName("FK_Product_UnitMeasure_SizeUnitMeasureCode");

        builder.HasOne(e => e.WeightUnitMeasure)
            .WithMany(e => e.WeightUnitMeasureProducts)
            .HasForeignKey(e => e.WeightUnitMeasureCode)
            .HasConstraintName("FK_Product_UnitMeasure_WeightUnitMeasureCode");

        builder.HasCheckConstraint("CK_Product_Class", "upper([Class])='H' OR upper([Class])='M' OR upper([Class])='L' OR [Class] IS NULL");
        builder.HasCheckConstraint("CK_Product_DaysToManufacture", "[DaysToManufacture] >= 0");
        builder.HasCheckConstraint("CK_Product_ListPrice", "[ListPrice] >= 0.00");
        builder.HasCheckConstraint("CK_Product_ProductLine", "upper([ProductLine])='R' OR upper([ProductLine])='M' OR upper([ProductLine])='T' OR upper([ProductLine])='S' OR [ProductLine] IS NULL");
        builder.HasCheckConstraint("CK_Product_ReorderPoint", "[ReorderPoint] > 0");
        builder.HasCheckConstraint("CK_Product_SafetyStockLevel", "[SafetyStockLevel] > 0");
        builder.HasCheckConstraint("CK_Product_SellEndDate", "[SellEndDate] >= [SellStartDate] OR [SellEndDate] IS NULL");
        builder.HasCheckConstraint("CK_Product_StandardCost", "[StandardCost] >= 0.00");
        builder.HasCheckConstraint("CK_Product_Style", "upper([Style])='U' OR upper([Style])='M' OR upper([Style])='W' OR [Style] IS NULL");
        builder.HasCheckConstraint("CK_Product_Weight", "[Weight] > 0.00");
    }
}
