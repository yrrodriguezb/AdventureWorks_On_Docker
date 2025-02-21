using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class BusinessEntityConfiguration : IEntityTypeConfiguration<BusinessEntity>
{
    public void Configure(EntityTypeBuilder<BusinessEntity> builder)
    {
        builder.ToTable("BusinessEntity", "Person");

        builder.HasKey(e => e.BusinessEntityID)
            .HasName("PK_BusinessEntity_BusinessEntityID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID")
            .ValueGeneratedOnAdd();

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
            .HasDatabaseName("AK_BusinessEntity_rowguid");

        builder.HasOne(e => e.Person)
            .WithOne(p => p.BusinessEntity)
            .HasForeignKey<Person>(p => p.BusinessEntityID)
            .HasConstraintName("FK_Person_BusinessEntity_BusinessEntityID");
    }
}