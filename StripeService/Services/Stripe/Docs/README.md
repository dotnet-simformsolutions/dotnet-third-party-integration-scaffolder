## Testing Setup

**Selected Test Framework:** xUnit

**Installed NuGet Packages:**
- xunit
- Moq
- FluentAssertions

**Test Project Folder Structure:**
```
StripeService.Tests/
  Tests/
    Services/Stripe/
      StripeServiceTests.cs
    Common/
```

**How to Run Tests:**
```
dotnet test StripeService.Tests
```

**How to Collect Code Coverage (optional):**
Install Coverlet:
```
dotnet add StripeService.Tests package coverlet.collector
dotnet test StripeService.Tests --collect:"XPlat Code Coverage"
```
# Stripe Service Integration

## Overview of the Integration
This module provides a modular, testable, and production-grade integration for Stripe, designed for use as a class library in .NET 8 host projects. It supports JWT authentication and follows best practices for configuration, security, and extensibility.

## Configuration Steps
- Add the `StripeService` class library to your host solution and reference it from your Web API project.
- Configure Stripe settings and authentication in your appsettings and DI container.
- Use the provided extension method to register the service:

```csharp
services.AddStripeService(Configuration);
```

## Required NuGet Packages
- Microsoft.Extensions.Configuration
- System.IdentityModel.Tokens.Jwt
- Newtonsoft.Json

## Environment Variables
- STRIPE_API_KEY: Your Stripe secret key
- STRIPE_WEBHOOK_SECRET: Your Stripe webhook secret
- JWT_SECRET: Secret for JWT token validation

## Models
### StripePaymentModel
```csharp
/// <summary>
/// Represents a Stripe payment model for internal use.
/// </summary>
public class StripePaymentModel
{
    public string PaymentId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime PaymentDate { get; set; }
}
```

### TokenMetadata
```csharp
/// <summary>
/// Represents metadata for an access token (JWT/OAuth2).
/// </summary>
public class TokenMetadata
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string TokenType { get; set; }
}
```

### StatusCodes
```csharp
/// <summary>
/// Centralized status code constants for service responses.
/// </summary>
public static class StatusCodes
{
    public const string Success = "SUCCESS";
    public const string Failure = "FAILURE";
    public const string Unauthorized = "UNAUTHORIZED";
}
```

## Helpers
### DateFormatter
```csharp
/// <summary>
/// Provides static methods for date formatting to match Stripe API specifications.
/// </summary>
public static class DateFormatter
{
    public static string ToIso8601(DateTime dateTime)
    {
        // Returns the date in ISO 8601 format (e.g., 2025-07-25T12:34:56Z)
        return dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}
```

### ValidationHelper
```csharp
/// <summary>
/// Provides reusable validation logic for Stripe-related data.
/// </summary>
public static class ValidationHelper
{
    public static bool IsRequired(string? value) => !string.IsNullOrWhiteSpace(value);
    public static bool IsValidCurrency(string currency)
    {
        // Validates that the currency code is a valid ISO 4217 code (3 letters)
        return System.Text.RegularExpressions.Regex.IsMatch(currency, "^[A-Z]{3}$");
    }
}
```

## Authentication Setup
- JWT Bearer authentication is required for all endpoints interacting with Stripe.
- Use the `TokenProvider` for token generation and validation.

## Example Requests/Responses
- **CreatePaymentRequest**
  - Amount: decimal
  - Currency: string
  - SourceToken: string
  - Description: string
- **PaymentResponse**
  - PaymentId: string
  - Success: bool
  - ErrorMessage: string

## Testing Instructions
- Implement unit and integration tests in the host project.
- Mock Stripe API calls for local testing.

## Security Considerations
- Store all secrets in environment variables or secure vaults.
- Validate all incoming JWT tokens.
- Follow Stripe's security best practices for API usage.
