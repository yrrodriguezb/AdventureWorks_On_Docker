using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegion>
{
    public void Configure(EntityTypeBuilder<CountryRegion> builder)
    {
        builder.ToTable("CountryRegion", "Person");

        builder.HasKey(e => e.CountryRegionCode)
            .HasName("PK_CountryRegion_CountryRegionCode");

        builder.Property(e => e.CountryRegionCode)
            .HasColumnName("CountryRegionCode")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("AK_CountryRegion_Name");

        builder.HasCheckConstraint("CK_CountryRegion_Name", "[Name] IS NOT NULL");
    }
}