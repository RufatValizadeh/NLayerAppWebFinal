namespace NLayer.Core.DTOs
{
    public class CustomerCreditCardWithCustomerDto : CustomerCreditCardDto
    {
        public CustomerDto Customer { get; set; }
    }
}