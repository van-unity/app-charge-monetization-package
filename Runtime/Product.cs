using UnityEngine;

namespace AppCharge.Monetization {
    [System.Serializable]
    public class Product {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string ProductName { get; private set; }
        [field: SerializeField] public float Price { get;  private set; }
        [field: SerializeField] public string Description { get;  private set; }
    }
}