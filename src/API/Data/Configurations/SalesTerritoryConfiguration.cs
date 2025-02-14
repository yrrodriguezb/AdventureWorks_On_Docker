using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SalesTerritoryConfiguration : IEntityTypeConfiguration<SalesTerritory>
{
    public void Configure(EntityTypeBuilder<SalesTerritory> builder)
    {
        builder.ToTable("SalesTerritory", "Sales");

        builder.HasKey(e => e.TerritoryID)
            .HasName("PK_SalesTerritory_TerritoryID");

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CountryRegionCode)
            .HasColumnName("CountryRegionCode")
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(e => e.Group)
            .HasColumnName("Group")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.SalesYTD)
            .HasColumnName("SalesYTD")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.SalesLastYear)
            .HasColumnName("SalesLastYear")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.CostYTD)
            .HasColumnName("CostYTD")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.CostLastYear)
            .HasColumnName("CostLastYear")
            .IsRequired()
            .HasDefaultValue(0.00m);

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
            .HasDatabaseName("AK_SalesTerritory_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_SalesTerritory_rowguid");

        builder.HasOne(e => e.CountryRegion)
            .WithMany(cr => cr.SalesTerritories)
            .HasForeignKey(e => e.CountryRegionCode)
            .HasConstraintName("FK_SalesTerritory_CountryRegion_CountryRegionCode");

        builder.HasCheckConstraint("CK_SalesTerritory_CostLastYear", "[CostLastYear] >= 0.00");
        builder.HasCheckConstraint("CK_SalesTerritory_CostYTD", "[CostYTD] >= 0.00");
        builder.HasCheckConstraint("CK_SalesTerritory_SalesLastYear", "[SalesLastYear] >= 0.00");
        builder.HasCheckConstraint("CK_SalesTerritory_SalesYTD", "[SalesYTD] >= 0.00");
    }
}