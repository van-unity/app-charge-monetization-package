using System.IO;
using UnityEditor;
using UnityEngine;

namespace AppCharge.Monetization.Editor.Editor {
    public class MonetizationSettingsEditor : MonoBehaviour
    {
        private const string RESOURCE_PATH = "Assets/AppCharge/Resources";
        private const string SETTINGS_PATH = RESOURCE_PATH + "/MonetizationSettings.asset";

        [MenuItem("AppCharge/Settings")]
        private static void SelectOrCreateMonetizationSettings()
        {
            // Ensure the Resources directory exists
            if (!Directory.Exists(RESOURCE_PATH))
            {
                Directory.CreateDirectory(RESOURCE_PATH);
                AssetDatabase.Refresh();
            }

            // Try to load the MonetizationSettings ScriptableObject
            var settings = AssetDatabase.LoadAssetAtPath<MonetizationSettings>(SETTINGS_PATH);

            if (settings == null)
            {
                // If not found, create a new instance of MonetizationSettings
                settings = ScriptableObject.CreateInstance<MonetizationSettings>();

                // Create the asset in the specified path
                AssetDatabase.CreateAsset(settings, SETTINGS_PATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            // Select the object in the editor
            Selection.activeObject = settings;
            EditorGUIUtility.PingObject(settings);
        }
    }
}