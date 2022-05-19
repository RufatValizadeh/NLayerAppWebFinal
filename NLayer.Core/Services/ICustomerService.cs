using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        public Task<CustomResponseDto<CustomerWithCustomerCreditCardsDto>>
            GetSingleCustomerByIdWithCustomerCreditCardAsync(int categoryId);
    }
}