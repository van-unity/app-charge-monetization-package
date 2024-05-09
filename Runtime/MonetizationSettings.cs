using System.Collections.Generic;
using AppCharge.Monetization.Exceptions;
using UnityEngine;
using PlatformNotSupportedException = AppCharge.Monetization.Exceptions.PlatformNotSupportedException;

namespace AppCharge.Monetization {
    /// <summary>
    /// MonetizationSettings is a concrete implementation of IProductRepository that provides 
    /// access to products defined in Unity's inspector using Serializable fields. This class 
    /// simplifies the task of managing product configurations across different platforms 
    /// directly within the Unity Editor. It currently employs a linear search for product lookup.
    /// This approach is chosen to maintain simplicity in the context of a test project. In a larger scale
    /// or production environment, more efficient search mechanisms could be implemented.
    /// </summary>
    [CreateAssetMenu(fileName = "MonetizationSettings", menuName = "AppCharge/MonetizationSettings", order = 0)]
    public class MonetizationSettings : ScriptableObject, IProductRepository {
        [field: SerializeField] public List<ProductsByPlatform> ProductsByPlatform { get; private set; }


        public Product GetProductByID(string productID) {
            var platform = PlatformUtils.GetAppChargePlatform();

            if (platform == Platform.UnSupported) {
                throw new PlatformNotSupportedException(Application.platform);
            }

            foreach (var productsByPlatform in ProductsByPlatform) {
                if (productsByPlatform.Platform == platform) {
                    foreach (var product in productsByPlatform.Products) {
                        if (product.ID == productID) {
                            return product;
                        }
                    }

                    throw new ProductNotFoundException(Application.platform, productID);
                }
            }

            throw new ProductNotFoundException(Application.platform, productID);
        }

        public IEnumerable<Product> EnumerateProducts() {
            var platform = PlatformUtils.GetAppChargePlatform();

            if (platform == Platform.UnSupported) {
                throw new PlatformNotSupportedException(Application.platform);
            }

            foreach (var productsByPlatform in ProductsByPlatform) {
                if (productsByPlatform.Platform == platform) {
                    return productsByPlatform.Products;
                }
            }

            return null;
        }

#if UNITY_EDITOR
        private void OnValidate() {
            ProductsByPlatform.RemoveAll(p => p.Platform == Platform.UnSupported);
        }
#endif
    }
}