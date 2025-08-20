namespace StripeService.Services.Stripe.Common.Configuration
{
    public class StripeOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string WebhookSecret { get; set; } = string.Empty;
        public string JwtSecret { get; set; } = string.Empty;
    }
}
