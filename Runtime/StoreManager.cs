using System;
using System.Threading.Tasks;
using AppCharge.Monetization.EventArgs;

namespace AppCharge.Monetization {
    public class StoreManager {
        private readonly IPaymentProcessor _paymentProcessor;

        public event Action<ProductPurchasedEventArgs> ProductPurchased;
        public event Action<ProductPurchaseFailedEventArgs> ProductPurchaseFailed;


        public StoreManager(IPaymentProcessor paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public async Task PurchaseProductAsync(string productID) {
            try {
                var result = await _paymentProcessor.ProcessPaymentAsync(productID);
                if (result.Success) {
                    ProductPurchased?.Invoke(new ProductPurchasedEventArgs(productID));
                } else {
                    ProductPurchaseFailed?.Invoke(new ProductPurchaseFailedEventArgs(productID, result.ErrorMessage));
                }
            }
            catch (Exception exception) {
                ProductPurchaseFailed?.Invoke(new ProductPurchaseFailedEventArgs(productID,
                    "An unexpected error occurred: " + exception.Message));
            }
        }
    }
}