﻿namespace NLayer.Core.DTOs
{
    public class CustomerCreditCardFeatureDto
    {
        public int Id { get; set; }
        public string CardToken { get; set; }
        public string CardNetwork { get; set; }
        public int CustomerCreditCardId { get; set; }
    }
}