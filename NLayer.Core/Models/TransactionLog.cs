using System.Collections.Generic;

namespace NLayer.Core.Models
{
    public class TransactionLog : BaseEntity
    {
        public string TypeId { get; set; }
        public decimal Amount { get; set; }
        public string CardToken { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerCreditCardId { get; set; }
        public Customer Customer { get; set; }

        public CustomerCreditCard CustomerCreditCard { get; set; }
    }
}