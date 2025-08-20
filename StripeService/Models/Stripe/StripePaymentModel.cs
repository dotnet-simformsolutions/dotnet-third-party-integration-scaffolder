using System;

namespace StripeService.Models.Stripe
{
    /// <summary>
    /// Represents a Stripe payment model for internal use.
    /// </summary>
    public class StripePaymentModel
    {
        /// <summary>
        /// Unique identifier for the payment.
        /// </summary>
        public string PaymentId { get; set; } = string.Empty;

        /// <summary>
        /// Amount paid in the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency code (e.g., USD, EUR).
        /// </summary>
        public string Currency { get; set; } = "USD";

        /// <summary>
        /// Date and time of the payment.
        /// </summary>
        public DateTime PaymentDate { get; set; }
    }
}
