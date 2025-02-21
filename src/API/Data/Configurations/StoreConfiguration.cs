using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Store", "Sales");

        builder.HasKey(e => e.BusinessEntityID)
            .HasName("PK_Store_BusinessEntityID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID")
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.SalesPersonID)
            .HasColumnName("SalesPersonID")
            .IsRequired(false);

        builder.Property(e => e.Demographics)
            .HasColumnName("Demographics")
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
            .HasDatabaseName("AK_Store_rowguid");

        builder.HasIndex(e => e.SalesPersonID)
            .HasDatabaseName("IX_Store_SalesPersonID");

        builder.HasOne(d => d.SalesPerson)
            .WithMany(p => p.Stores)
            .HasForeignKey(d => d.SalesPersonID)
            .HasConstraintName("FK_Store_SalesPerson_SalesPersonID");
    }
}