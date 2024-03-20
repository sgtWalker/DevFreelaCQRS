using DevFreelaCQRS.Core.DTOs;
using DevFreelaCQRS.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DevFreelaCQRS.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentMessage = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(paymentInfoDTO));

            _messageBusService.Publish(QUEUE_NAME, paymentMessage);
        }
    }
}
