namespace StripeService.Services.Stripe.DTO.Requests
{
    public class CreatePaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string SourceToken { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
