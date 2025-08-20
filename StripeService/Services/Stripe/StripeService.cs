using System.Threading.Tasks;
using StripeService.Services.Stripe.DTO.Requests;
using StripeService.Services.Stripe.DTO.Responses;

namespace StripeService.Services.Stripe
{
    public class StripeService : IStripeService
    {
        public async Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
        {
            // TODO: Integrate with Stripe API
            await Task.Delay(100); // Simulate async work
            return new PaymentResponse { PaymentId = "mock_id", Success = true };
        }

        public async Task<PaymentResponse> RefundPaymentAsync(string paymentId)
        {
            // TODO: Integrate with Stripe API
            await Task.Delay(100); // Simulate async work
            return new PaymentResponse { PaymentId = paymentId, Success = true };
        }
    }
}
