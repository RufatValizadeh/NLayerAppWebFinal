using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class CustomerSeed : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                Name = "Doctor",
                Surname = "Strange",
                BirthDate = 2000,
                IdentityNo = 11111111111,
                IdentityNoVerified = false,
                StatusId = 3
            },
            new Customer
            {
                Id = 2,
                Name = "Black",
                Surname = "Widow",
                BirthDate = 2000,
                IdentityNo = 22222222222,
                IdentityNoVerified = false,
                StatusId = 3
            },
            new Customer
            {
                Id = 3,
                Name = "Spider",
                Surname = "Man",
                BirthDate = 2000,
                IdentityNo = 33333333333,
                IdentityNoVerified = false,
                StatusId = 3
            }
        );
    }
}