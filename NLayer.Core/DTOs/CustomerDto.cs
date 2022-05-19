namespace NLayer.Core.DTOs
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public int StatusId { get; set; }
        
        public int CustomerId { get; set; }
    }
}