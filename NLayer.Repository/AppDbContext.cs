using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }
    public DbSet<CustomerCreditCardFeature> CustomerCreditCardFeatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {

        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entity)
            {
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}