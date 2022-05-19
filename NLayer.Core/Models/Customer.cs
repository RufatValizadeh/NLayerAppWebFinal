using System.Collections.Generic;

namespace NLayer.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public int StatusId { get; set; }
        
        public int CustomerId { get; set; }

        public ICollection<CustomerCreditCard> CustomerCreditCards { get; set; }
        public ICollection<TransactionLog> TransactionLogs { get; set; }
    }
}