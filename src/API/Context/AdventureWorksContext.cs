using API.Data.Configurations;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class AdventureWorksContext : DbContext
{
    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<ProductSubcategory> ProductSubcategories { get; set; } = null!;
    public DbSet<SalesPerson> SalesPersons { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;
    public DbSet<BusinessEntity> BusinessEntities { get; set; } = null!;
    public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;
    public DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; } = null!;
    public DbSet<ProductModel> ProductModels { get; set; } = null!;
    public DbSet<UnitMeasure> UnitMeasures { get; set; } = null!;
    public DbSet<SalesTerritory> SalesTerritories { get; set; } = null!;
    public DbSet<CountryRegion> CountryRegions { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<StateProvince> StateProvinces { get; set; } = null!;
    public DbSet<CreditCard> CreditCards { get; set; } = null!;
    public DbSet<CurrencyRate> CurrencyRates { get; set; } = null!;    
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<ShipMethod> ShipMethods { get; set; } = null!;
    public DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderHeaderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSubcategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SalesPersonConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialOfferConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialOfferProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
        modelBuilder.ApplyConfiguration(new UnitMeasureConfiguration());
        modelBuilder.ApplyConfiguration(new SalesTerritoryConfiguration());
        modelBuilder.ApplyConfiguration(new CountryRegionConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new StateProvinceConfiguration());
        modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyRateConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new ShipMethodConfiguration());
        modelBuilder.ApplyConfiguration(new SalesTerritoryHistoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}