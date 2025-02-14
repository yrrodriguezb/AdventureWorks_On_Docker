using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currency", "Sales");

        builder.HasKey(e => e.CurrencyCode)
            .HasName("PK_Currency_CurrencyCode");

        builder.Property(e => e.CurrencyCode)
            .HasColumnName("CurrencyCode")
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

        // Indexes and constraints
        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("AK_Currency_Name");
    }
}