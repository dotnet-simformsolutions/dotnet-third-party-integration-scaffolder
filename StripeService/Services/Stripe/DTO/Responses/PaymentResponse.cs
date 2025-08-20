namespace StripeService.Services.Stripe.DTO.Responses
{
    public class PaymentResponse
    {
        public string PaymentId { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
