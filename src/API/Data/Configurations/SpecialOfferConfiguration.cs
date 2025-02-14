using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SpecialOfferConfiguration : IEntityTypeConfiguration<SpecialOffer>
{
    public void Configure(EntityTypeBuilder<SpecialOffer> builder)
    {
        builder.ToTable("SpecialOffer", "Sales");

        builder.HasKey(e => e.SpecialOfferID)
            .HasName("PK_SpecialOffer_SpecialOfferID");

        builder.Property(e => e.SpecialOfferID)
            .HasColumnName("SpecialOfferID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Description)
            .HasColumnName("Description")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.DiscountPct)
            .HasColumnName("DiscountPct")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.Type)
            .HasColumnName("Type")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Category)
            .HasColumnName("Category")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.StartDate)
            .HasColumnName("StartDate")
            .IsRequired();

        builder.Property(e => e.EndDate)
            .HasColumnName("EndDate")
            .IsRequired();

        builder.Property(e => e.MinQty)
            .HasColumnName("MinQty")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(e => e.MaxQty)
            .HasColumnName("MaxQty")
            .IsRequired(false);

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
            .HasDatabaseName("AK_SpecialOffer_rowguid");

        builder.HasCheckConstraint("CK_SpecialOffer_DiscountPct", "[DiscountPct] >= 0.00");
        builder.HasCheckConstraint("CK_SpecialOffer_EndDate", "[EndDate] >= [StartDate]");
        builder.HasCheckConstraint("CK_SpecialOffer_MaxQty", "[MaxQty] >= 0");
        builder.HasCheckConstraint("CK_SpecialOffer_MinQty", "[MinQty] >= 0");
    }
}