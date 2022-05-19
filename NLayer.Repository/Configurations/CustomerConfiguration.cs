using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
        builder.Property(x => x.BirthDate).IsRequired().HasMaxLength(20);
        builder.Property(x => x.IdentityNo).IsRequired().HasMaxLength(50);
        builder.Property(x => x.IdentityNoVerified).IsRequired();
        builder.Property(x => x.StatusId).IsRequired();
        builder.ToTable("Customers");
        builder.Property(x=>x.CreatedDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

    }
}