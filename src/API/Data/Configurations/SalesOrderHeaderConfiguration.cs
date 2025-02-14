using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
{
    public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
    {
        builder.ToTable("SalesOrderHeader", "Sales");

        builder.HasKey(e => e.SalesOrderID)
            .HasName("PK_SalesOrderHeader_SalesOrderID");

        builder.Property(e => e.SalesOrderID)
            .HasColumnName("SalesOrderID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.RevisionNumber)
            .HasColumnName("RevisionNumber")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(e => e.OrderDate)
            .HasColumnName("OrderDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.Property(e => e.DueDate)
            .HasColumnName("DueDate")
            .IsRequired();

        builder.Property(e => e.ShipDate)
            .HasColumnName("ShipDate")
            .IsRequired(false);

        builder.Property(e => e.Status)
            .HasColumnName("Status")
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(e => e.OnlineOrderFlag)
            .HasColumnName("OnlineOrderFlag")
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(e => e.SalesOrderNumber)
            .HasColumnName("SalesOrderNumber")
            .HasComputedColumnSql("isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***')");

        builder.Property(e => e.PurchaseOrderNumber)
            .HasColumnName("PurchaseOrderNumber")
            .IsRequired(false);

        builder.Property(e => e.AccountNumber)
            .HasColumnName("AccountNumber")
            .IsRequired(false);

        builder.Property(e => e.CustomerID)
            .HasColumnName("CustomerID")
            .IsRequired();

        builder.Property(e => e.SalesPersonID)
            .HasColumnName("SalesPersonID")
            .IsRequired(false);

        builder.Property(e => e.TerritoryID)
            .HasColumnName("TerritoryID")
            .IsRequired(false);

        builder.Property(e => e.BillToAddressID)
            .HasColumnName("BillToAddressID")
            .IsRequired();

        builder.Property(e => e.ShipToAddressID)
            .HasColumnName("ShipToAddressID")
            .IsRequired();

        builder.Property(e => e.ShipMethodID)
            .HasColumnName("ShipMethodID")
            .IsRequired();

        builder.Property(e => e.CreditCardID)
            .HasColumnName("CreditCardID")
            .IsRequired(false);

        builder.Property(e => e.CreditCardApprovalCode)
            .HasColumnName("CreditCardApprovalCode")
            .HasMaxLength(15)
            .IsRequired(false);

        builder.Property(e => e.CurrencyRateID)
            .HasColumnName("CurrencyRateID")
            .IsRequired(false);

        builder.Property(e => e.SubTotal)
            .HasColumnName("SubTotal")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.TaxAmt)
            .HasColumnName("TaxAmt")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.Freight)
            .HasColumnName("Freight")
            .IsRequired()
            .HasDefaultValue(0.00m);

        builder.Property(e => e.TotalDue)
            .HasColumnName("TotalDue")
            .HasComputedColumnSql("isnull(([SubTotal]+[TaxAmt])+[Freight],(0))");

        builder.Property(e => e.Comment)
            .HasColumnName("Comment")
            .HasMaxLength(128)
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
            .HasDatabaseName("AK_SalesOrderHeader_rowguid");

        builder.HasIndex(e => e.SalesOrderNumber)
            .IsUnique()
            .HasDatabaseName("AK_SalesOrderHeader_SalesOrderNumber");

        builder.HasIndex(e => e.CustomerID)
            .HasDatabaseName("IX_SalesOrderHeader_CustomerID");

        builder.HasIndex(e => e.SalesPersonID)
            .HasDatabaseName("IX_SalesOrderHeader_SalesPersonID");

        builder.HasOne(d => d.BillToAddress)
            .WithMany(p => p.BillToSalesOrderHeaders)
            .HasForeignKey(d => d.BillToAddressID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SalesOrderHeader_Address_BillToAddressID");

        builder.HasOne(d => d.ShipToAddress)
            .WithMany(p => p.ShipToSalesOrderHeaders)
            .HasForeignKey(d => d.ShipToAddressID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SalesOrderHeader_Address_ShipToAddressID");

        builder.HasOne(d => d.CreditCard)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.CreditCardID)
            .HasConstraintName("FK_SalesOrderHeader_CreditCard_CreditCardID");

        builder.HasOne(d => d.CurrencyRate)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.CurrencyRateID)
            .HasConstraintName("FK_SalesOrderHeader_CurrencyRate_CurrencyRateID");

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.CustomerID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SalesOrderHeader_Customer_CustomerID");

        builder.HasOne(d => d.SalesPerson)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.SalesPersonID)
            .HasConstraintName("FK_SalesOrderHeader_SalesPerson_SalesPersonID");

        builder.HasOne(d => d.SalesTerritory)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.TerritoryID)
            .HasConstraintName("FK_SalesOrderHeader_SalesTerritory_TerritoryID");

        builder.HasOne(d => d.ShipMethod)
            .WithMany(p => p.SalesOrderHeaders)
            .HasForeignKey(d => d.ShipMethodID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SalesOrderHeader_ShipMethod_ShipMethodID");

        // Check constraints
        builder.HasCheckConstraint("CK_SalesOrderHeader_DueDate", "[DueDate] >= [OrderDate]");
        builder.HasCheckConstraint("CK_SalesOrderHeader_Freight", "[Freight] >= 0.00");
        builder.HasCheckConstraint("CK_SalesOrderHeader_ShipDate", "[ShipDate] >= [OrderDate] OR [ShipDate] IS NULL");
        builder.HasCheckConstraint("CK_SalesOrderHeader_Status", "[Status] BETWEEN 0 AND 8");
        builder.HasCheckConstraint("CK_SalesOrderHeader_SubTotal", "[SubTotal] >= 0.00");
        builder.HasCheckConstraint("CK_SalesOrderHeader_TaxAmt", "[TaxAmt] >= 0.00");
    }
}