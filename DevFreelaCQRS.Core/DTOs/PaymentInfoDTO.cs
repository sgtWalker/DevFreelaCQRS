namespace DevFreelaCQRS.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(Guid projectId, string creditCardNumber, string cVV, string expiresAt, string fullName, decimal amount)
        {
            ProjectId = projectId;
            CreditCardNumber = creditCardNumber;
            CVV = cVV;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }

        public Guid ProjectId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
    }
}
