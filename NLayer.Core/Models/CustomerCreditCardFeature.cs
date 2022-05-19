namespace NLayer.Core.Models
{
    public class CustomerCreditCardFeature
    {
        public int Id { get; set; }
        public string CardToken { get; set; }
        public string CardNetwork { get; set; }
        public int CustomerCreditCardId { get; set; }

        public CustomerCreditCard CustomerCreditCard { get; set; }
    }
}