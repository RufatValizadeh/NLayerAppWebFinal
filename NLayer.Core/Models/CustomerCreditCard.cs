using System.Collections.Generic;

namespace NLayer.Core.Models
{
    public class CustomerCreditCard : BaseEntity
    {
        public int StatusId { get; set; }
        public string CardBrand { get; set; }
        public long CardPan { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public CustomerCreditCardFeature CustomerCreditCardFeature { get; set; }
        public TransactionLog TransactionLogs { get; set; }
    }
}