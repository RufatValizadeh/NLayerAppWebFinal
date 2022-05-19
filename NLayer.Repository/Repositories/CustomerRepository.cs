using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Customer> GetSingleCustomerByIdWithCustomerCreditCardAsync(int customerId)
    {
        return await _context.Customers.Include(x => x.CustomerCreditCards).Where(x => x.Id == customerId).SingleOrDefaultAsync();
    }
}