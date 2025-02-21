using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SalesTerritoryHistoryConfiguration : IEntityTypeConfiguration<SalesTerritoryHistory>
{
    public void Configure(EntityTypeBuilder<SalesTerritoryHistory> builder)
    {
        builder.ToTable("SalesTerritoryHistory", "Sales");

        builder.HasKey(e => new { e.BusinessEntityID, e.StartDate, e.TerritoryID })
            .HasName("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID")
            .IsRequired();

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .IsRequired();

        builder.Property(e => e.StartDate)
            .HasColumnName("StartDate")
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(e => e.EndDate)
            .HasColumnName("EndDate")
            .IsRequired(false)
            .HasColumnType("datetime");

        builder.Property(e => e.Rowguid)
            .HasColumnName("rowguid")
            .IsRequired()
            .HasDefaultValueSql("newid()");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        // Indexes and constraints
        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_SalesTerritoryHistory_rowguid");

        builder.HasCheckConstraint("CK_SalesTerritoryHistory_EndDate", "[EndDate] >= [StartDate] OR [EndDate] IS NULL");

        // builder.HasOne(d => d.SalesPerson)
        //     .WithMany(p => p.SalesTerritoryHistories)
        //     .HasForeignKey(d => d.BusinessEntityID)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID");

        // builder.HasOne(d => d.SalesTerritory)
        //     .WithMany(p => p.SalesTerritoryHistories)
        //     .HasForeignKey(d => d.TerritoryID)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_SalesTerritoryHistory_SalesTerritory_TerritoryID");
    }
}