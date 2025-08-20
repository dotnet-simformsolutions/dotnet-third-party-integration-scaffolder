using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using StripeService.Services.Stripe.Common.Configuration;
namespace StripeService.Services.Stripe.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStripeService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StripeOptions>(configuration.GetSection("StripeSettings"));
            services.AddScoped<IStripeService, StripeService>();
            return services;
        }
    }
}
