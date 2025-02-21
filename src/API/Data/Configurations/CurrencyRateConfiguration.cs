using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
{
    public void Configure(EntityTypeBuilder<CurrencyRate> builder)
    {
        builder.ToTable("CurrencyRate", "Sales");

        builder.HasKey(e => e.CurrencyRateID)
            .HasName("PK_CurrencyRate_CurrencyRateID");

        builder.Property(e => e.CurrencyRateID)
            .HasColumnName("CurrencyRateID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CurrencyRateDate)
            .HasColumnName("CurrencyRateDate")
            .IsRequired();

        builder.Property(e => e.FromCurrencyCode)
            .HasColumnName("FromCurrencyCode")
            .IsRequired()
            .HasMaxLength(3)
            .IsFixedLength();

        builder.Property(e => e.ToCurrencyCode)
            .HasColumnName("ToCurrencyCode")
            .IsRequired()
            .HasMaxLength(3)
            .IsFixedLength();

        builder.Property(e => e.AverageRate)
            .HasColumnName("AverageRate")
            .IsRequired()
            .HasColumnType("money");

        builder.Property(e => e.EndOfDayRate)
            .HasColumnName("EndOfDayRate")
            .IsRequired()
            .HasColumnType("money");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        // Indexes and constraints
        builder.HasIndex(e => new { e.CurrencyRateDate, e.FromCurrencyCode, e.ToCurrencyCode })
            .IsUnique()
            .HasDatabaseName("AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode");

        builder.HasOne(d => d.FromCurrency)
            .WithMany(p => p.FromCurrencyRates)
            .HasForeignKey(d => d.FromCurrencyCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CurrencyRate_Currency_FromCurrencyCode");

        builder.HasOne(d => d.ToCurrency)
            .WithMany(p => p.ToCurrencyRates)
            .HasForeignKey(d => d.ToCurrencyCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CurrencyRate_Currency_ToCurrencyCode");
    }
}