using System.Threading.Tasks;

namespace AppCharge.Monetization {
    /// <summary>
    /// Just a simple implementation of IPaymentProcessor for the test assignment
    /// </summary>
    public class TestPaymentProcessor : IPaymentProcessor {
        public async Task<PaymentResult> ProcessPaymentAsync(string productID) {
            await Task.Delay(1000); 

            if (UnityEngine.Random.Range(0f, 1f) > 0.5f) {
                return new PaymentResult(true);
            }

            return new PaymentResult(
                false, "Payment failed due to insufficient funds.");
        }
    }
}