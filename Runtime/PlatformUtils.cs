#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace AppCharge.Monetization {
    public static class PlatformUtils {
        public static Platform GetAppChargePlatform() {
#if UNITY_EDITOR
            return EditorUserBuildSettings.activeBuildTarget switch {
                BuildTarget.Android => Platform.GooglePlay,
                BuildTarget.iOS => Platform.AppStore,
                _ => Platform.UnSupported
            };
#endif
            var currentRuntimePlatform = Application.platform;
            return currentRuntimePlatform switch {
                RuntimePlatform.Android => Platform.GooglePlay,
                RuntimePlatform.IPhonePlayer => Platform.AppStore,
                _ => Platform.UnSupported
            };
        }
    }
}