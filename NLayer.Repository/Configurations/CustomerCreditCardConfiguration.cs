using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations;

public class CustomerCreditCardConfiguration : IEntityTypeConfiguration<CustomerCreditCard>
{
    public void Configure(EntityTypeBuilder<CustomerCreditCard> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.StatusId).IsRequired();
        builder.Property(x => x.CardPan).IsRequired().HasMaxLength(16);
        builder.ToTable("Cards");

        builder.Property(x=>x.CreatedDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerCreditCards).HasForeignKey(x => x.CustomerId);
    }
}