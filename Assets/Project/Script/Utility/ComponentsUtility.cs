using UnityEngine;

namespace Project.Script.Utility {
    public static class ComponentsUtility {

        public static T GetComponentFromWhole<T>(GameObject obj)  {
            var component = obj.GetComponent<T>();

            if (component == null) {
                Debug.Log($"{obj.name}から{typeof(T)}が取得できなかったため、子からの取得を行います");
                component = obj.GetComponentInChildren<T>();
                if (component == null) {
                    Debug.Log($"子からも{typeof(T)}が取得できなかったため、親からの取得を行います");
                    component = obj.GetComponentInParent<T>();

                    if (component == null) {
                        Debug.LogError($"親からも{typeof(T)}が取得できませんでした。設定を見直してください");
                    }
                }
            }
            return component;
        }
        
    }
}