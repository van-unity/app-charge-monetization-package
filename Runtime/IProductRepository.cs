using System.Collections.Generic;

namespace AppCharge.Monetization {
    public interface IProductRepository {
        Product GetProductByID(string productID);
        IEnumerable<Product> EnumerateProducts();
    }
}