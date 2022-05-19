using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CustomerCreditCardRepository : GenericRepository<CustomerCreditCard>, ICustomerCreditCardRepository
{
    public CustomerCreditCardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CustomerCreditCard>> GetCustomerCreditCardWithCustomer()
    {
        return await _context.CustomerCreditCards.Include(x => x.Customer).ToListAsync();
    }
}