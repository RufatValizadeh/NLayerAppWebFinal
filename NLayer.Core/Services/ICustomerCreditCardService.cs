using System.Collections.Generic;
using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICustomerCreditCardService : IService<CustomerCreditCard>
    {
        Task<List<CustomerCreditCardWithCustomerDto>> GetCustomerCreditCardsWithCustomer();
    }
}