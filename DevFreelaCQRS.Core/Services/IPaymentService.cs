using DevFreelaCQRS.Core.DTOs;

namespace DevFreelaCQRS.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
