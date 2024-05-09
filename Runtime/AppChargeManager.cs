using System;
using UnityEngine;

namespace AppCharge.Monetization {
    public class AppChargeManager : MonoBehaviourSingletonPersistent<AppChargeManager> {
        private MonetizationSettings settings;
        public StoreManager StoreManager { get; private set; }
        public IProductRepository ProductRepository => settings;

        public void Initialize() {
            settings = Resources.Load<MonetizationSettings>("MonetizationSettings");
            if (!settings) {
                Debug.LogError(
                    "Failed to initialize AppCharge. Please make sure to create store settings(AppCharge/Settings)");
            }

            var paymentProcessor = new TestPaymentProcessor();
            StoreManager = new StoreManager(paymentProcessor);
        }
    }
}