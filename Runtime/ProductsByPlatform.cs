using UnityEngine;

namespace AppCharge.Monetization {
    [System.Serializable]
    public class ProductsByPlatform {
        [field: SerializeField] public Platform Platform { get; private set; }
        [field: SerializeField] public Product[] Products { get; private set; }
    }
}