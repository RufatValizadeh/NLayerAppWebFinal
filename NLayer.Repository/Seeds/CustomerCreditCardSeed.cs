using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class CustomerCreditCardSeed : IEntityTypeConfiguration<CustomerCreditCard>
{
    public void Configure(EntityTypeBuilder<CustomerCreditCard> builder)
    {
        builder.HasData(
            new CustomerCreditCard
            {
                Id = 1,
                StatusId = 1,
                CardBrand = "Master Card",
                CardPan = 5555444433332222,
                CustomerId = 1,
                CreatedDate = DateTime.Now
            },
            new CustomerCreditCard
            {
                Id = 2,
                StatusId = 1,
                CardBrand = "Master Card",
                CardPan = 5555444433332222,
                CustomerId = 1,
                CreatedDate = DateTime.Now
            },
            new CustomerCreditCard
            {
                Id = 3,
                StatusId = 3,
                CardBrand = "Master Card",
                CardPan = 5555444433332222,
                CustomerId = 1,
                CreatedDate = DateTime.Now
            },
            new CustomerCreditCard
            {
                Id = 4,
                StatusId = 1,
                CardBrand = "Master Card",
                CardPan = 5555444433332222,
                CustomerId = 2,
                CreatedDate = DateTime.Now
            },
            new CustomerCreditCard
            {
                Id = 5,
                StatusId = 1,
                CardBrand = "Master Card",
                CardPan = 5555444433332222,
                CustomerId = 2,
                CreatedDate = DateTime.Now
            }
        );
    }
}