using System;

namespace StripeService.Services.Stripe.Common.Helpers
{
    /// <summary>
    /// Provides static methods for date formatting to match Stripe API specifications.
    /// </summary>
    public static class DateFormatter
    {
        /// <summary>
        /// Formats a DateTime object to ISO 8601 string.
        /// </summary>
        public static string ToIso8601(DateTime dateTime)
        {
            // Returns the date in ISO 8601 format (e.g., 2025-07-25T12:34:56Z)
            return dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
