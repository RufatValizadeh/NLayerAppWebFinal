using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Repository.Seeds;

namespace NLayer.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CustomerCreditCard, CustomerCreditCardDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerCreditCardFeature, CustomerCreditCardFeatureDto>().ReverseMap();
        CreateMap<CustomerCreditCardUpdateDto, CustomerCreditCard>();
        CreateMap<CustomerCreditCard, CustomerCreditCardWithCustomerDto>();
        CreateMap<Customer, CustomerWithCustomerCreditCardsDto>();
    }
}