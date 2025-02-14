using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", "Sales");

        builder.HasKey(e => e.CustomerID)
            .HasName("PK_Customer_CustomerID");

        builder.Property(e => e.CustomerID)
            .HasColumnName("CustomerID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.PersonID)
            .HasColumnName("PersonID")
            .IsRequired(false);

        builder.Property(e => e.StoreID)
            .HasColumnName("StoreID")
            .IsRequired(false);

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .IsRequired(false);

        builder.Property(e => e.AccountNumber)
            .HasColumnName("AccountNumber")
            .HasComputedColumnSql("isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),'')")
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
        builder.HasIndex(e => e.AccountNumber)
            .IsUnique()
            .HasDatabaseName("AK_Customer_AccountNumber");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_Customer_rowguid");

        builder.HasIndex(e => e.TerritoryID)
            .HasDatabaseName("IX_Customer_TerritoryID");

        builder.HasOne(d => d.Person)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.PersonID)
            .HasConstraintName("FK_Customer_Person_PersonID");

        builder.HasOne(d => d.Store)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.StoreID)
            .HasConstraintName("FK_Customer_Store_StoreID");

        builder.HasOne(d => d.SalesTerritory)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.TerritoryID)
            .HasConstraintName("FK_Customer_SalesTerritory_TerritoryID");
    }
}