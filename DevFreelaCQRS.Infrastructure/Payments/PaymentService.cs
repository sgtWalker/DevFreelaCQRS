using DevFreelaCQRS.Core.DTOs;
using DevFreelaCQRS.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DevFreelaCQRS.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string _paymentBaseUrl;

        public PaymentService(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var url = $"{_paymentBaseUrl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoContent = new StringContent(paymentInfoJson, Encoding.UTF8, "application/json");
            var httpClient = _httpClient.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);
            return response.IsSuccessStatusCode;
        }
    }
}
