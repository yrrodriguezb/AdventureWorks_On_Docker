using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person", "Person");

        builder.HasKey(e => e.BusinessEntityID)
            .HasName("PK_Person_BusinessEntityID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID");

        builder.Property(e => e.PersonType)
            .HasColumnName("PersonType")
            .IsRequired()
            .HasMaxLength(2)
            .IsFixedLength();

        builder.Property(e => e.NameStyle)
            .HasColumnName("NameStyle")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(e => e.Title)
            .HasColumnName("Title")
            .HasMaxLength(8)
            .IsRequired(false);

        builder.Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .IsRequired();

        builder.Property(e => e.MiddleName)
            .HasColumnName("MiddleName")
            .IsRequired(false);

        builder.Property(e => e.LastName)
            .HasColumnName("LastName")
            .IsRequired();

        builder.Property(e => e.Suffix)
            .HasColumnName("Suffix")
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(e => e.EmailPromotion)
            .HasColumnName("EmailPromotion")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(e => e.AdditionalContactInfo)
            .HasColumnName("AdditionalContactInfo")
            .HasColumnType("xml")
            .IsRequired(false);

        builder.Property(e => e.Demographics)
            .HasColumnName("Demographics")
            .HasColumnType("xml")
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
            .HasDatabaseName("AK_Person_rowguid");

        builder.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName })
            .HasDatabaseName("IX_Person_LastName_FirstName_MiddleName");

        // builder.HasOne(e => e.BusinessEntity)
        //     .WithOne()
        //     .HasForeignKey<Person>(e => e.BusinessEntityID)
        //     .HasConstraintName("FK_Person_BusinessEntity_BusinessEntityID");

        builder.HasCheckConstraint("CK_Person_EmailPromotion", "[EmailPromotion] >= 0 AND [EmailPromotion] <= 2");
        builder.HasCheckConstraint("CK_Person_PersonType", "[PersonType] IS NULL OR (upper([PersonType])='GC' OR upper([PersonType])='SP' OR upper([PersonType])='EM' OR upper([PersonType])='IN' OR upper([PersonType])='VC' OR upper([PersonType])='SC')");
    }
}