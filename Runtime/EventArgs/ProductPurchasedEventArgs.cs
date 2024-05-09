namespace AppCharge.Monetization.EventArgs {
    public class ProductPurchasedEventArgs : System.EventArgs {
        public string ProductID { get; }

        public ProductPurchasedEventArgs(string productID) {
            ProductID = productID;
        }
    }
}