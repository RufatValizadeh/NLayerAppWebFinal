using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations;

public class CustomerCreditCardFeatureConfiguration : IEntityTypeConfiguration<CustomerCreditCardFeature>
{
    public void Configure(EntityTypeBuilder<CustomerCreditCardFeature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(x => x.CustomerCreditCard).WithOne(x => x.CustomerCreditCardFeature).HasForeignKey<CustomerCreditCardFeature>(x => x.CustomerCreditCardId);
    }
}