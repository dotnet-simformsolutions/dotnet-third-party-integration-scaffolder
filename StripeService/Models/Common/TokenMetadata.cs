using System;

namespace StripeService.Models.Common
{
    /// <summary>
    /// Represents metadata for an access token (JWT/OAuth2).
    /// </summary>
    public class TokenMetadata
    {
        /// <summary>
        /// The access token string.
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// The expiration date and time of the token.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// The type of the token (e.g., Bearer).
        /// </summary>
        public string TokenType { get; set; } = "Bearer";
    }
}
