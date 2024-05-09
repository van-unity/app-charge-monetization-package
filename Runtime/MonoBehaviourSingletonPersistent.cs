using UnityEngine;

namespace AppCharge.Monetization {
    public abstract class MonoBehaviourSingletonPersistent<T> : MonoBehaviour where T : class {
        public static T Instance { get; private set; }

        protected virtual void Awake() {
            if (Instance == null) {
                Instance = this as T;
                DontDestroyOnLoad(this);
            } else {
                Destroy(gameObject);
            }
        }
    }
}