using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations;

public class TransactionLogConfiguration  : IEntityTypeConfiguration<TransactionLog>
{
    public void Configure(EntityTypeBuilder<TransactionLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.TypeId).IsRequired();
        builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.CardToken).IsRequired();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.StatusId).IsRequired();
        builder.ToTable("TransactionLogs");
        builder.Property(x=>x.CreatedDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
         builder.HasOne(x => x.Customer).WithMany(x => x.TransactionLogs).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.CustomerCreditCard).WithOne(x => x.TransactionLogs).HasForeignKey<TransactionLog>(x => x.CustomerCreditCardId).OnDelete(DeleteBehavior.Restrict);

    }
}