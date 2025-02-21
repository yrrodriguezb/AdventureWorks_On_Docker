using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class ShipMethodConfiguration : IEntityTypeConfiguration<ShipMethod>
{
    public void Configure(EntityTypeBuilder<ShipMethod> builder)
    {
        builder.ToTable("ShipMethod", "Purchasing");

        builder.HasKey(e => e.ShipMethodID)
            .HasName("PK_ShipMethod_ShipMethodID");

        builder.Property(e => e.ShipMethodID)
            .HasColumnName("ShipMethodID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ShipBase)
            .HasColumnName("ShipBase")
            .IsRequired()
            .HasColumnType("money")
            .HasDefaultValue(0.00m);

        builder.Property(e => e.ShipRate)
            .HasColumnName("ShipRate")
            .IsRequired()
            .HasColumnType("money")
            .HasDefaultValue(0.00m);

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
            .HasDatabaseName("AK_ShipMethod_Name");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_ShipMethod_rowguid");

        builder.HasCheckConstraint("CK_ShipMethod_ShipBase", "[ShipBase] > 0.00");
        builder.HasCheckConstraint("CK_ShipMethod_ShipRate", "[ShipRate] > 0.00");
    }
}