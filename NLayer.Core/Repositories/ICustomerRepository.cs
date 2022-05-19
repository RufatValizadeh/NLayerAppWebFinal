using System.Threading.Tasks;
using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetSingleCustomerByIdWithCustomerCreditCardAsync(int customerId);
    }
}