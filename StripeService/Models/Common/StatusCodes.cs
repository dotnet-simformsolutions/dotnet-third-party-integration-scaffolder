namespace StripeService.Models.Common
{
    /// <summary>
    /// Centralized status code constants for service responses.
    /// </summary>
    public static class StatusCodes
    {
        /// <summary>
        /// Indicates a successful operation.
        /// </summary>
        public const string Success = "SUCCESS";

        /// <summary>
        /// Indicates a failed operation.
        /// </summary>
        public const string Failure = "FAILURE";

        /// <summary>
        /// Indicates an unauthorized request.
        /// </summary>
        public const string Unauthorized = "UNAUTHORIZED";
    }
}
