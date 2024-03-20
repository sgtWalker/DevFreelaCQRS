namespace DevFreelaCQRS.Core.IntegrationEvents
{
    public class PaymentApprovedIntegrationEvent
    {
        public PaymentApprovedIntegrationEvent(Guid projectId)
        {
            ProjectId = projectId;
        }

        public Guid ProjectId { get; set; }
    }
}
