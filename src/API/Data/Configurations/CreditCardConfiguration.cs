using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.ToTable("CreditCard", "Sales");

        builder.HasKey(e => e.CreditCardID)
            .HasName("PK_CreditCard_CreditCardID");

        builder.Property(e => e.CreditCardID)
            .HasColumnName("CreditCardID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CardType)
            .HasColumnName("CardType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CardNumber)
            .HasColumnName("CardNumber")
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(e => e.ExpMonth)
            .HasColumnName("ExpMonth")
            .IsRequired();

        builder.Property(e => e.ExpYear)
            .HasColumnName("ExpYear")
            .IsRequired();

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        // Indexes and constraints
        builder.HasIndex(e => e.CardNumber)
            .IsUnique()
            .HasDatabaseName("AK_CreditCard_CardNumber");
    }
}