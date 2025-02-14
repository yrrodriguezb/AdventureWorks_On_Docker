using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
{
    public void Configure(EntityTypeBuilder<StateProvince> builder)
    {
        builder.ToTable("StateProvince", "Person");

        builder.HasKey(e => e.StateProvinceID)
            .HasName("PK_StateProvince_StateProvinceID");

        builder.Property(e => e.StateProvinceID)
            .HasColumnName("StateProvinceID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StateProvinceCode)
            .HasColumnName("StateProvinceCode")
            .IsRequired()
            .HasMaxLength(3)
            .IsFixedLength();

        builder.Property(e => e.CountryRegionCode)
            .HasColumnName("CountryRegionCode")
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(e => e.IsOnlyStateProvinceFlag)
            .HasColumnName("IsOnlyStateProvinceFlag")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .IsRequired();

        builder.Property(e => e.Rowguid)
            .HasColumnName("rowguid")
            .IsRequired()
            .HasDefaultValueSql("newid()");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        // Indexes and constraints
        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_rowguid");

        builder.HasIndex(e => new { e.StateProvinceCode, e.CountryRegionCode })
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_StateProvinceCode_CountryRegionCode");

        // builder.HasOne(d => d.CountryRegion)
        //     .WithMany(p => p.StateProvinces)
        //     .HasForeignKey(d => d.CountryRegionCode)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_StateProvince_CountryRegion_CountryRegionCode");

        // builder.HasOne(d => d.SalesTerritory)
        //     .WithMany(p => p.StateProvinces)
        //     .HasForeignKey(d => d.TerritoryID)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_StateProvince_SalesTerritory_TerritoryID");
    }
}