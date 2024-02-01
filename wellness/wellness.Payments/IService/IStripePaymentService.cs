using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStripePaymentService
{
    Task<Dictionary<string, object>> ProcessPaymentMethodIdAsync(
        string paymentMethodId,
       int items,
        string currency,
        bool useStripeSdk
    );

    Task<Dictionary<string, object>> ProcessPaymentIntentIdAsync(string paymentIntentId);
}
