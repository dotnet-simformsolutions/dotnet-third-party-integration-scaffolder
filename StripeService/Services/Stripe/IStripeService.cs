using System.Threading.Tasks;
using StripeService.Services.Stripe.DTO.Requests;
using StripeService.Services.Stripe.DTO.Responses;

namespace StripeService.Services.Stripe
{
    public interface IStripeService
    {
        Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);
        Task<PaymentResponse> RefundPaymentAsync(string paymentId);
    }
}
