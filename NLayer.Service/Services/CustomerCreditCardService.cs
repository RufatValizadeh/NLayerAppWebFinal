using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class CustomerCreditCardService : Service<CustomerCreditCard>, ICustomerCreditCardService
{
    private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
    private readonly IMapper _mapper;

    public CustomerCreditCardService(IGenericRepository<CustomerCreditCard> repository, IUnitOfWork unitOfWork,
        IMapper mapper,
        ICustomerCreditCardRepository customerCreditCardRepository) : base(repository, unitOfWork)
    {
        _mapper = mapper;
        _customerCreditCardRepository = customerCreditCardRepository;
    }

    public async Task<List<CustomerCreditCardWithCustomerDto>> GetCustomerCreditCardsWithCustomer()
    {
        var productsWithCategory = await _customerCreditCardRepository.GetCustomerCreditCardWithCustomer();
        var customerCreditCardWithCustomerDtos =
            _mapper.Map<List<CustomerCreditCardWithCustomerDto>>(productsWithCategory);
        return customerCreditCardWithCustomerDtos;
    }
}