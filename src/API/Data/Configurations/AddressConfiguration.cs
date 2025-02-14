using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address", "Person");

        builder.HasKey(e => e.AddressID)
            .HasName("PK_Address_AddressID");

        builder.Property(e => e.AddressID)
            .HasColumnName("AddressID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.AddressLine1)
            .HasColumnName("AddressLine1")
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(e => e.AddressLine2)
            .HasColumnName("AddressLine2")
            .HasMaxLength(60)
            .IsRequired(false);

        builder.Property(e => e.City)
            .HasColumnName("City")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(e => e.StateProvinceID)
            .HasColumnName("StateProvinceID")
            .IsRequired();

        builder.Property(e => e.PostalCode)
            .HasColumnName("PostalCode")
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(e => e.SpatialLocation)
            .HasColumnName("SpatialLocation")
            .IsRequired(false);

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
            .HasDatabaseName("AK_Address_rowguid");

        builder.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceID, e.PostalCode })
            .IsUnique()
            .HasDatabaseName("IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode");

        builder.HasIndex(e => e.StateProvinceID)
            .HasDatabaseName("IX_Address_StateProvinceID");

        builder.HasOne(d => d.StateProvince)
            .WithMany(p => p.Addresses)
            .HasForeignKey(d => d.StateProvinceID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Address_StateProvince_StateProvinceID");
    }
}
