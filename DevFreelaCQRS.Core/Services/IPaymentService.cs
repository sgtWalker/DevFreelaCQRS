using DevFreelaCQRS.Core.DTOs;

namespace DevFreelaCQRS.Core.Services
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
