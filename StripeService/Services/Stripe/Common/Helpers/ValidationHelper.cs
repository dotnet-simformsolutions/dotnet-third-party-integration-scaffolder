using System;
using System.Text.RegularExpressions;

namespace StripeService.Services.Stripe.Common.Helpers
{
    /// <summary>
    /// Provides reusable validation logic for Stripe-related data.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates that a string is not null or whitespace.
        /// </summary>
        public static bool IsRequired(string? value) => !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Validates that the currency code is a valid ISO 4217 code (3 letters).
        /// </summary>
        public static bool IsValidCurrency(string currency)
        {
            return Regex.IsMatch(currency, "^[A-Z]{3}$");
        }
    }
}
