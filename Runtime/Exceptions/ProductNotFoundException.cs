using System;
using UnityEngine;

namespace AppCharge.Monetization.Exceptions {
    public class ProductNotFoundException : Exception {
        private const string MESSAGE_FORMAT = "Product with ID {0} not found for Platform{1}";

        public ProductNotFoundException(RuntimePlatform platform, string productID) : base(string.Format(MESSAGE_FORMAT,
            productID, platform)) { }
    }
}