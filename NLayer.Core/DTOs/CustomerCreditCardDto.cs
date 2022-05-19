namespace NLayer.Core.DTOs
{
    public class CustomerCreditCardDto : BaseDto
    {
        public int StatusId { get; set; }
        public string CardBrand { get; set; }
        public long CardPan { get; set; }
        public int CustomerId { get; set; }
    }
}