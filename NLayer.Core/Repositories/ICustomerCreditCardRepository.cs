using System.Collections.Generic;
using System.Threading.Tasks;
using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICustomerCreditCardRepository : IGenericRepository<CustomerCreditCard>
    {
        Task<List<CustomerCreditCard>> GetCustomerCreditCardWithCustomer();
    }
}