using System.Threading.Tasks;

namespace AppCharge.Monetization {
    public interface IPaymentProcessor {
        Task<PaymentResult> ProcessPaymentAsync(string productID);
    }
}