using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class UnitMeasureConfiguration : IEntityTypeConfiguration<UnitMeasure>
{
    public void Configure(EntityTypeBuilder<UnitMeasure> builder)
    {
        builder.ToTable("UnitMeasure", "Production");

        builder.HasKey(e => e.UnitMeasureCode)
            .HasName("PK_UnitMeasure_UnitMeasureCode");

        builder.Property(e => e.UnitMeasureCode)
            .HasColumnName("UnitMeasureCode")
            .HasMaxLength(3)
            .IsFixedLength()
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
            .HasDatabaseName("AK_UnitMeasure_Name");

        builder.HasCheckConstraint("CK_UnitMeasure_Name", "[Name] IS NOT NULL");
    }
}