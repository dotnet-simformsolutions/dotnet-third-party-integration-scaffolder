using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using StripeService.Services.Stripe;
using StripeService.Services.Stripe.DTO.Requests;
using StripeService.Services.Stripe.DTO.Responses;
using Xunit;

namespace StripeService.Tests.Tests.Services.Stripe
{
    public class StripeServiceTests
    {
        private readonly Mock<IStripeService> _stripeServiceMock;

        public StripeServiceTests()
        {
            _stripeServiceMock = new Mock<IStripeService>();
        }

        [Fact]
        public async Task CreatePaymentAsync_ShouldReturnSuccessResponse()
        {
            // Arrange
            var request = new CreatePaymentRequest { Amount = 100, Currency = "USD", SourceToken = "tok_test", Description = "Test" };
            var expectedResponse = new PaymentResponse { PaymentId = "mock_id", Success = true };
            _stripeServiceMock.Setup(s => s.CreatePaymentAsync(request)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _stripeServiceMock.Object.CreatePaymentAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.PaymentId.Should().Be("mock_id");
        }

        [Fact]
        public async Task RefundPaymentAsync_ShouldReturnSuccessResponse()
        {
            // Arrange
            var paymentId = "mock_id";
            var expectedResponse = new PaymentResponse { PaymentId = paymentId, Success = true };
            _stripeServiceMock.Setup(s => s.RefundPaymentAsync(paymentId)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _stripeServiceMock.Object.RefundPaymentAsync(paymentId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.PaymentId.Should().Be(paymentId);
        }
    }
}
