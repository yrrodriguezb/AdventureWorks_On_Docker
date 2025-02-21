using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee", "HumanResources");

        builder.HasKey(e => e.BusinessEntityID)
            .HasName("PK_Employee_BusinessEntityID");

        builder.Property(e => e.BusinessEntityID)
            .HasColumnName("BusinessEntityID");

        builder.Property(e => e.NationalIDNumber)
            .HasColumnName("NationalIDNumber")
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(e => e.LoginID)
            .HasColumnName("LoginID")
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(e => e.OrganizationNode)
            .HasColumnName("OrganizationNode")
            .IsRequired(false);

        builder.Property(e => e.OrganizationLevel)
            .HasColumnName("OrganizationLevel")
            .HasComputedColumnSql("[OrganizationNode].[GetLevel]()");

        builder.Property(e => e.JobTitle)
            .HasColumnName("JobTitle")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.BirthDate)
            .HasColumnName("BirthDate")
            .IsRequired();

        builder.Property(e => e.MaritalStatus)
            .HasColumnName("MaritalStatus")
            .IsRequired()
            .HasMaxLength(1)
            .IsFixedLength();

        builder.Property(e => e.Gender)
            .HasColumnName("Gender")
            .IsRequired()
            .HasMaxLength(1)
            .IsFixedLength();

        builder.Property(e => e.HireDate)
            .HasColumnName("HireDate")
            .IsRequired();

        builder.Property(e => e.SalariedFlag)
            .HasColumnName("SalariedFlag")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.VacationHours)
            .HasColumnName("VacationHours")
            .IsRequired()
            .HasDefaultValue((short)0);

        builder.Property(e => e.SickLeaveHours)
            .HasColumnName("SickLeaveHours")
            .IsRequired()
            .HasDefaultValue((short)0);

        builder.Property(e => e.CurrentFlag)
            .HasColumnName("CurrentFlag")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(e => e.Rowguid)
            .HasColumnName("rowguid")
            .IsRequired()
            .HasDefaultValueSql("newid()");

        builder.Property(e => e.ModifiedDate)
            .HasColumnName("ModifiedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.HasIndex(e => e.LoginID)
            .IsUnique()
            .HasDatabaseName("AK_Employee_LoginID");

        builder.HasIndex(e => e.NationalIDNumber)
            .IsUnique()
            .HasDatabaseName("AK_Employee_NationalIDNumber");

        builder.HasIndex(e => e.Rowguid)
            .IsUnique()
            .HasDatabaseName("AK_Employee_rowguid");

        builder.HasIndex(e => new { e.OrganizationLevel, e.OrganizationNode })
            .HasDatabaseName("IX_Employee_OrganizationLevel_OrganizationNode");

        builder.HasIndex(e => e.OrganizationNode)
            .HasDatabaseName("IX_Employee_OrganizationNode");

        builder.HasOne(e => e.Person)
            .WithOne()
            .HasForeignKey<Employee>(e => e.BusinessEntityID)
            .HasConstraintName("FK_Employee_Person_BusinessEntityID");

        builder.HasCheckConstraint("CK_Employee_BirthDate", "[BirthDate] >= '1930-01-01' AND [BirthDate] <= dateadd(year, -18, getdate())");
        builder.HasCheckConstraint("CK_Employee_Gender", "upper([Gender]) = 'F' OR upper([Gender]) = 'M'");
        builder.HasCheckConstraint("CK_Employee_HireDate", "[HireDate] >= '1996-07-01' AND [HireDate] <= dateadd(day, 1, getdate())");
        builder.HasCheckConstraint("CK_Employee_MaritalStatus", "upper([MaritalStatus]) = 'S' OR upper([MaritalStatus]) = 'M'");
        builder.HasCheckConstraint("CK_Employee_SickLeaveHours", "[SickLeaveHours] >= 0 AND [SickLeaveHours] <= 120");
        builder.HasCheckConstraint("CK_Employee_VacationHours", "[VacationHours] >= -40 AND [VacationHours] <= 240");
    }
}