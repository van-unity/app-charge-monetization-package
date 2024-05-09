namespace AppCharge.Monetization.EventArgs {
    public class ProductPurchaseFailedEventArgs : System.EventArgs {
        public string ProductID { get; }
        public string Reason { get; }

        public ProductPurchaseFailedEventArgs(string productID, string reason = null) {
            ProductID = productID;
            Reason = reason;
        }
    }
}