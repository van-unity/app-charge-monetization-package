using System;
using UnityEngine;

namespace AppCharge.Monetization.Exceptions {
    public class PlatformNotSupportedException : Exception {
        private const string MESSAGE_FORMAT = "{0} platform is not supported by AppCharge";

        public PlatformNotSupportedException(RuntimePlatform runtimePlatform) : base(string.Format(MESSAGE_FORMAT,
            runtimePlatform)) { }
    }
}