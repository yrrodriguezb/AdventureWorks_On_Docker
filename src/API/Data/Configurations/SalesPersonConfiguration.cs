using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
{
    public void Configure(EntityTypeBuilder<SalesPerson> builder)
    {
        builder.ToTable("SalesPerson", "Sales");

        builder.HasKey(e => e.BusinessEntityID)
            .HasName("PK_SalesPerson_BusinessEntityID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID");

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .IsRequired(false);

        builder.Property(e => e.SalesQuota)
            .HasColumnName("SalesQuota")
            .IsRequired(false);

        builder.Property(e => e.Bonus)
            .HasColumnName("Bonus")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.CommissionPct)
            .HasColumnName("CommissionPct")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.SalesYTD)
            .HasColumnName("SalesYTD")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.SalesLastYear)
            .HasColumnName("SalesLastYear")
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

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_SalesPerson_rowguid");

        // builder.HasOne(e => e.Employee)
        //     .WithOne(p => p.SalesPersons)
        //     .HasForeignKey<SalesPerson>(e => e.BusinessEntityID)
        //     .HasConstraintName("FK_SalesPerson_Employee_BusinessEntityID");

        builder.HasOne(e => e.SalesTerritory)
            .WithMany(e => e.SalesPersons)
            .HasForeignKey(e => e.TerritoryID)
            .HasConstraintName("FK_SalesPerson_SalesTerritory_TerritoryID");

        builder.HasCheckConstraint("CK_SalesPerson_Bonus", "[Bonus] >= 0.00");
        builder.HasCheckConstraint("CK_SalesPerson_CommissionPct", "[CommissionPct] >= 0.00");
        builder.HasCheckConstraint("CK_SalesPerson_SalesLastYear", "[SalesLastYear] >= 0.00");
        builder.HasCheckConstraint("CK_SalesPerson_SalesQuota", "[SalesQuota] > 0.00");
        builder.HasCheckConstraint("CK_SalesPerson_SalesYTD", "[SalesYTD] >= 0.00");
    }
}