using System.Collections.Generic;

namespace NLayer.Core.DTOs
{
    public class CustomerWithCustomerCreditCardsDto : CustomerDto
    {
        public List<CustomerCreditCardDto> Products { get; set; }
    }
}