using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class CustomerCreditCardFeatureSeed : IEntityTypeConfiguration<CustomerCreditCardFeature>
{
    public void Configure(EntityTypeBuilder<CustomerCreditCardFeature> builder)
    {
        //
    }
}