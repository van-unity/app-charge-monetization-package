namespace AppCharge.Monetization {
    public class PaymentResult {
        public bool Success { get; }
        public string ErrorMessage { get; }

        public PaymentResult(bool success, string errorMessage = null) {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}